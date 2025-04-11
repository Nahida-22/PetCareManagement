// Import dependencies.
using System; // Import a base class definition.
using System.Collections.Generic; // To collect generic collections like Dictionary.
using System.Linq; // Enable Linq queries.
using PawfectCareLtd.Data.DataRetrieval.cs; // Import the custom in memory database
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


        // Method to insert data into the in memeory database.
        public void Insert(Record record, bool skipDb = false)
        {
            string key = record[primaryKey].ToString(); // Get the key value of the primary key from the record.
            rows.Add(key, record); // Add the record to the hashtable.
        }


        // Method to get a record by its primary key value.
        public Record Get(string primaryKeyValue) => rows.Get(primaryKeyValue);


        //
        public void Delete(string primaryKeyValue)
        {
            if (!rows.Remove(primaryKeyValue))
                throw new KeyNotFoundException($"No record found with key: {primaryKeyValue}");

            if (Name == "Location")
            {
                var entity = _dbContext.Locations.FirstOrDefault(l => l.LocationID == primaryKeyValue);
                if (entity != null)
                {
                    _dbContext.Locations.Remove(entity);
                    _dbContext.SaveChanges();
                }
            }
        }


        //
        public void Update(string primaryKeyValue, string fieldName, object newValue)
        {
            var record = rows.Get(primaryKeyValue);
            if (record != null)
            {
                record[fieldName] = newValue;

                if (Name == "Location")
                {
                    var entity = _dbContext.Locations.FirstOrDefault(l => l.LocationID == primaryKeyValue);
                    if (entity != null)
                    {
                        typeof(Location).GetProperty(fieldName)?.SetValue(entity, newValue);
                        _dbContext.SaveChanges();
                    }
                }
            }
            else
            {
                throw new KeyNotFoundException($"Record with key '{primaryKeyValue}' not found.");
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