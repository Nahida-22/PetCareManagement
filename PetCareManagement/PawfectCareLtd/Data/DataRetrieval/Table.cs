// Import dependencies.
using System; // Import a base class definition.
using System.Collections.Generic; // To collect generic collections like Dictionary.
using System.Linq; // Enable Linq queries.
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.
using PawfectCareLtd.Models; // Import the data models used in the application.


namespace PawfectCareLtd.Data.DataRetrieval // Define the namespace for the application.
{
    public class Table
    {

        // Define of all variable needed.
        private readonly HashTable<string, Record> rows = new(); // Field to store all rows in the table using the in memory hashtable
        public string Name { get; } // To get the name of each table.
        private readonly string primaryKey; // To get the primary key.
        private readonly DatabaseContext _dbContext; // Use to get sink between the in memory database and the ssms database.


        // Constructor method for the class 'Table'.
        public Table(string name, string primaryKeyField, DatabaseContext dbContext)
        {
            Name = name; // Set the table name.
            primaryKey = primaryKeyField; // Set the primary key.
            _dbContext = dbContext; // Set the dbContext.
        }


        // Dynamically retrieves the corresponding Dbset<T> from the DbContext.
        private dynamic GetDbSet()
        {
            // Match the property name to the table name.
            var dbSetProperty = _dbContext.GetType().GetProperties().FirstOrDefault(p => p.Name == Name);
            return dbSetProperty?.GetValue(_dbContext); // Return the DbSet value, if it is found.
        }



        // Method to add a new data into the in memeory database.
        public void Insert(Record record, bool skipDb = false)
        {
            // Extract primary key value as a string and store it in a variable call key.
            string key = record[primaryKey].ToString();

            // Add the record to the in memory hashtable.
            rows.Add(key, record);

            // Check if sync with SSMS database is not unable.
            if (!skipDb)
            {

                // Get the data set.
                var dbSet = GetDbSet();

                // If dataset is not empty.
                if (dbSet != null)
                {
                    // Create entity dynamically from the data set.
                    var entityType = dbSet.GetType().GenericTypeArguments[0];
                    var entity = Activator.CreateInstance(entityType);

                    // Iterate through each record to an entity's properties.
                    foreach (var field in record.Fields)
                    {
                        entityType.GetProperty(field.Key)?.SetValue(entity, field.Value);
                    }

                    // Add the populated entity to the DbSet.
                    dbSet.Add(entity);

                    // Save the saves to the database.
                    _dbContext.SaveChanges();
                }
            }
        }


        // Method to get a record by its primary key value.
        public Record Get(string primaryKeyValue) => rows.Get(primaryKeyValue);


        // Method to delete a record by its primary key value.
        public void Delete(string primaryKeyValue)
        {
            // Remove the row and if the key doesn't exist, throw an exception.
            if (!rows.Remove(primaryKeyValue))
                throw new KeyNotFoundException($"No record found with key: {primaryKeyValue}");

            // Get the data set.
            var dbSet = GetDbSet();

            // If dataset is not empty.
            if (dbSet != null)
            {
                // Create entity dynamically from the data set.
                var entityType = dbSet.GetType().GenericTypeArguments[0];

                // Convert the Dbset to a list of objects for easier searching.
                var entityList = ((IEnumerable<object>)dbSet).ToList();

                // Search the actual database to get the entry that match the primary key.
                var entityToRemove = entityList.FirstOrDefault(e => entityType.GetProperty(primaryKey)?.GetValue(e)?.ToString() == primaryKeyValue);

                // If the entry is found in the DbSet, save the delete changes in the actual database.
                if (entityToRemove != null)
                {
                    dbSet.Remove(entityToRemove);
                    _dbContext.SaveChanges();
                }
            }
        }


        // Method to update a record by its primary key value.
        public void Update(string primaryKeyValue, string fieldName, object newValue, bool skipDb = true)
        {
            // Get the record from the in memory database using the primary key.
            var record = rows.Get(primaryKeyValue);

            // If the record exist, update the field with the new value.
            if (record != null)
            {
                record[fieldName] = newValue;

                // Check if sync with SSMS database is not unable.
                if (!skipDb)
                {
                    // Get the data set.
                    var dbSet = GetDbSet();

                    // If dataset is not empty.
                    if (dbSet != null)
                    {
                        // Create entity dynamically from the data set.
                        var entityType = dbSet.GetType().GenericTypeArguments[0];

                        // Convert the Dbset to a list of objects for easier searching.
                        var entityList = ((IEnumerable<object>)dbSet).ToList();

                        // Search the actual database to get the entry that match the primary key.
                        var entity = entityList.FirstOrDefault(e => entityType.GetProperty(primaryKey)?.GetValue(e)?.ToString() == primaryKeyValue);

                        // If the entry is found in the DbSet, save the updated changes in the actual database.
                        if (entity != null)
                        {
                            entityType.GetProperty(fieldName)?.SetValue(entity, newValue);
                            _dbContext.SaveChanges();
                        }

                    }
                }
            }
            else
            {
                throw new KeyNotFoundException($"Record with key '{primaryKeyValue}' not found."); // Throw an error to show that primary key does not exist.
            }
        }


        // Method to return all the record of a table as an enumerable.
        public IEnumerable<Record> GetAll()
        {
            // Iterates over all key-value pairs in the hash table.
            foreach (var pair in rows.GetAll())
                yield return pair.Value; // Return only the record, not the key.
        }
    }
}