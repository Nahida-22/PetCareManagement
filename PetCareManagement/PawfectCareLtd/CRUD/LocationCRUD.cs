// Import dependencies.
using System; // Import the System namespace which includes fundamental classes and base classes.
using System.Collections.Generic; // Import the System.Collections.Generic namespace for generic collections.
using System.Linq; // Import the System.Linq namespace for LINQ (Language-Integrated Query) operations on collections.
using PawfectCareLtd.Controllers; // Import the Controllers namespace from the PawfectCareLtd project.
using PawfectCareLtd.Data; // Import the Data namespace from the PawfectCareLtd project.
using PawfectCareLtd.Data.DataRetrieval;  // Import the custom in memory database.
using PawfectCareLtd.Models;  // Import the custom in memory database.


namespace PawfectCareLtd.CRUD// Define the namespace for the application.
{
    // Class the encapsulate all of the CRUD operation for the Location table.
    public class LocationCRUD
    {
        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;



        // Constructor to initialise the class with an instance of the in memory database.
        public LocationCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;

        }



        // Method to insert data into the Location table.
        public OperationResult InsertOperationForLocation(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {
            // Get the location table from the in-memory database.
            var locationTable = _inMemoryDatabase.GetTable("Location");

            // Check if the primary key has been provided.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                return new OperationResult { success = false, message = "Primary key must be inputed." };
            }

            // Extract and validate the primary key.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };
            }

            // Check for duplicate primary key.
            if (locationTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };
            }

            // Validate foreign keys.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    return new OperationResult { success = false, message = $"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
                }
            }

            // Create and populate new record.
            var newRecord = new Record();
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            try
            {
                // Insert into in-memory database.
                locationTable.Insert(newRecord, skipDb: true);

                // Insert into SQL database.
                var newLocation = new Location();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Location).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(newLocation, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Locations.Add(newLocation);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into Location table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }



        // Method to read the data from the Location table.
        public OperationResult ReadOperationForLocation(string fieldName, string fieldValue)
        {

            // Get the location table form the in memory database.
            var locationTable = _inMemoryDatabase.GetTable("Location");

            // Check if there are any record that matches the search critria.
            var matchingRecords = locationTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // Transform the record into a file that can be read into the database.
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();

            // If there are not any matches, tell the user that are not any matches.
            if (matchingRecords.Count == 0)
            {
                return new OperationResult { success = false, message = $"No records found in table '{locationTable.Name}' where {fieldName} = '{fieldValue}'." };

            }

            // If there are any matches, tell the user what record are.
            return new OperationResult { success = true, message = "Operation was successed", data = matchingData };
        }



        // Method to update data from the Location table.
        public OperationResult UpdateOperationForLocation(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the location table from the in memory database.
            var locationTable = _inMemoryDatabase.GetTable("Location");

            // Convert the data type of the new value to object type.
            object newValueToObject = newValue;

            // If the field that is being updated is a foreign key.
            if (isForeignKey)
            {
                // Check if the referenced table exists in the in memory database.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the referenced table does not exist, exit out of the method.
                if (referencedTable == null)
                {
                    return new OperationResult { success = false, message = $"Referenced table '{referencedTableName}' not found in memory." };
                }

                // Check if the foreign key value exists in the referenced table.
                bool exists = referencedTable.GetAll().Any(record => record.Fields.ContainsKey(referencedTable.GetAll().First().Fields.Keys.First()) && record[referencedTable.GetAll().First().Fields.Keys.First()].ToString() == newValue);

                // If new value does not exist in the reference table, exit out of the method to prevent data linking issues.
                if (!exists)
                {
                    return new OperationResult { success = false, message = $"Foreign key value '{newValueToObject}' does not exist in the '{referencedTableName}' table." };
                }
            }
            // Try updating the data into the Location table.
            try
            {
                // Update the location with the new data.
                locationTable.Update(primaryKeyValue, fieldName, newValueToObject);

                // Save to SQL database.
                var locationEntity = _dbContext.Locations.Find(primaryKeyValue);
                if (locationEntity != null)
                {
                    var property = typeof(Location).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(locationEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Location with primary key '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException) // Catch any errors that related to data not being found.
            {
                return new OperationResult { success = false, message = $"No record found with primary key '{primaryKeyValue}' in Location table." };
            }
            catch (Exception ex) // Catch any other error.
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }



        // Method to delete data from the Location table.
        public OperationResult DeleteLocationtbyId(string locationId)
        {
            var locationTable = _inMemoryDatabase.GetTable("Location");

            // Try delete from memory
            try
            {
                locationTable.Delete(locationId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Appointment with ID {locationId} not found in in-memory database." };
            }

            // Try delete from SQL Server
            var locationEntity = _dbContext.Locations.Find(locationId);
            if (locationEntity != null)
            {
                _dbContext.Locations.Remove(locationEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Location with ID {locationId} not found in SQL database.");
            }

            // Return a success status.
            return new OperationResult { success = true, message = $"Location with ID {locationId} deleted from in-memory database." };
        }



        // Method to get all the locations record.
        public OperationResult GetAllLocationRecord()
        {
            // Get the Location table from the in memory database.
            var table = _inMemoryDatabase.GetTable("Location");

            // Get all of the record from Locationn table.
            var allLocationRecord = table.GetAll().Select(record => record.Fields).ToList();

            // Return a success status.
            return new OperationResult { success = true, message = "Operation was successed", data = allLocationRecord };
        }

    }
}
