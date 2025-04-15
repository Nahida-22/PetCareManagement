// Import dependencies.
using System; // Import the System namespace which includes fundamental classes and base classes.
using System.Collections.Generic; // Import the System.Collections.Generic namespace for generic collections.
using System.Linq; // Import the System.Linq namespace for LINQ (Language-Integrated Query) operations on collections.
using PawfectCareLtd.Controllers; // Import the Controllers namespace from the PawfectCareLtd project.
using PawfectCareLtd.Data; // Import the Data namespace from the PawfectCareLtd project.
using PawfectCareLtd.Data.DataRetrieval;  // Import the custom in memory database.
using PawfectCareLtd.Models;  // Import the custom in memory database.


namespace PawfectCareLtd.CRUD
{
    // Class that encapsulates all CRUD operations for the Order table.
    public class OrderCRUD
    {
        // Define fields to store references to the in-memory and SQL Server databases.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;



        // Constructor to initialize the class with instances of the in-memory and SQL Server databases.
        public OrderCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }



        // Method to insert data into the Order table.
        public OperationResult InsertOperationForOrder(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {
            // Get the Order table from the in-memory database.
            var orderTable = _inMemoryDatabase.GetTable("Order");

            // Check if the primary key is present in the input dictionary.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                return new OperationResult { success = false, message = "Primary key must be inputted." };
            }

            // Retrieve and convert the primary key to a string.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            // Check if the primary key is empty or doesn't match the required format.
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };
            }

            // Check if a record with the same primary key already exists.
            if (orderTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };
            }

            // Validate each foreign key against the referenced table.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                // Skip if the foreign key field is not provided.
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                // Retrieve the foreign key value.
                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();

                // Get the referenced table.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the foreign key exists in the referenced table.
                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    return new OperationResult { success = false, message = $"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
                }
            }

            var newRecord = new Record();
            foreach (var field in fieldValues)
                newRecord[field.Key] = field.Value;

            try
            {
                // Insert into in-memory table.
                orderTable.Insert(newRecord, skipDb: true);

                // Insert into SQL database.
                var entity = new Order();  // Use the Order model here
                foreach (var field in fieldValues)
                {
                    var property = typeof(Order).GetProperty(field.Key);  // Reflective mapping to Order model properties
                    if (property != null)
                        property.SetValue(entity, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Orders.Add(entity);  // Add to the Orders table
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into order table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }



        // Method to read a record from the Order table by a specific field.
        public OperationResult ReadOperationForOrder(string fieldName, string fieldValue)
        {
            // Get the Order table from the in-memory database.
            var orderTable = _inMemoryDatabase.GetTable("Order");

            // Find all records matching the criteria.
            var matchingRecords = orderTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // Return if no records are found.
            if (matchingRecords.Count == 0)
            {
                return new OperationResult { success = false, message = $"No records found in table '{orderTable.Name}' where {fieldName} = '{fieldValue}'." };
            }

            // Return the matched records.
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();
            return new OperationResult { success = true, message = "Operation was successful", data = matchingData };
        }



        // Method to update a field in an Order record.
        public OperationResult UpdateOperationForOrder(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Order table.
            var orderTable = _inMemoryDatabase.GetTable("Order");

            // Convert the new value to object type.
            object newValueToObject = newValue;

            // If updating a foreign key, validate it.
            if (isForeignKey)
            {
                // Get the referenced table.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the referenced table exists.
                if (referencedTable == null)
                {
                    return new OperationResult { success = false, message = $"Referenced table '{referencedTableName}' not found in memory." };
                }

                // Check if the new foreign key value exists in the referenced table.
                bool exists = referencedTable.GetAll().Any(record => record.Fields.ContainsKey(referencedTable.GetAll().First().Fields.Keys.First()) && record[referencedTable.GetAll().First().Fields.Keys.First()].ToString() == newValue);

                if (!exists)
                {
                    return new OperationResult { success = false, message = $"Foreign key value '{newValueToObject}' does not exist in the '{referencedTableName}' table." };
                }
            }

            // Try updating the record in both in-memory and SQL Server database.
            try
            {
                orderTable.Update(primaryKeyValue, fieldName, newValueToObject);

                var orderEntity = _dbContext.Orders.Find(primaryKeyValue);  // Find the Order by primary key
                if (orderEntity != null)
                {
                    var property = typeof(Order).GetProperty(fieldName);  // Reflective mapping to Order model properties
                    if (property != null)
                    {
                        property.SetValue(orderEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Order with primary key '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"No record found with primary key '{primaryKeyValue}' in Order table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }



        // Method to delete an Order record by ID.
        public OperationResult DeleteOrderById(string orderId)
        {
            // Get the Order table.
            var orderTable = _inMemoryDatabase.GetTable("Order");

            // Try deleting from the in-memory database.
            try
            {
                orderTable.Delete(orderId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Order with ID {orderId} not found in in-memory database." };
            }

            // Try deleting from the SQL Server database.
            var orderEntity = _dbContext.Orders.Find(orderId);
            if (orderEntity != null)
            {
                _dbContext.Orders.Remove(orderEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Order with ID {orderId} not found in SQL database.");
            }

            // Return a success status.
            return new OperationResult { success = true, message = $"Order with ID {orderId} deleted from in-memory database." };
        }



        // Method to retrieve all Order records.
        public OperationResult GetAllOrderRecord()
        {
            // Get the Order table.
            var table = _inMemoryDatabase.GetTable("Order");

            // Retrieve all records.
            var allOrderRecords = table.GetAll().Select(record => record.Fields).ToList();

            // Return a success status.
            return new OperationResult { success = true, message = "Operation was successful", data = allOrderRecords };
        }
    }
}
