// Import dependencies.
using System;
using System.Collections.Generic;
using System.Linq;
using PawfectCareLtd.Controllers;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;



namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{

    // Class the encapsulate all of the CRUD operation for the Owner table.
    public class OwnerCRUD
    {

        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;


        // Constructor to initialise the class with an instance of the in memory database.
        public OwnerCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }


        // Method to insert data into the Owner table.
        public OperationResult InsertOperationForOwner(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {

            // Get the Owner table from the in memory database.
            var ownerTable = _inMemoryDatabase.GetTable("Owner");

            // Check if the primary key has been added into the input dictionary.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                return new OperationResult { success = false, message = "Primary key must be inputed." };
            }

            // Get the primary key for the record being inserted then convert it to string.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            // Check if primary for the the record being inserted is non empty and is in the required format.
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };
            }

            // Check if the primary key for the new already exist in the the Owner table, If yes exist out of the function.
            if (ownerTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };
            }

            // Iterate through each foreignkey that need to valides.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                // If the foreign key field is not into the input dictionary, skip it.
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                // Get the foreign key from the inputed list.
                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();

                // Get the referenced table which contain the foreign key as the primary key.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the foreign key exist in the referenced table, if not exist out of the function.
                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    return new OperationResult { success = false, message = $"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
                }
            }

            // Create a new record.
            var newRecord = new Record();

            // Add each field form the inputed dictionary into the record.
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            // Try inserting the new record into the Owner table.
            try
            {
                // Insert the data into the in memory database.
                ownerTable.Insert(newRecord, skipDb: true);

                // Save to SQL database.
                var newOwner = new Owner();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Owner).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(newOwner, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Owners.Add(newOwner);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into Owner table." };
            }
            catch (Exception ex) // Catch any errors.
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }


        // Method to read the data from the Owner table.
        public OperationResult ReadOperationForOwner(string fieldName, string fieldValue)
        {

            // Get the Owner table form the in memory database.
            var ownerTable = _inMemoryDatabase.GetTable("Owner");

            // Check if there are any record that matches the search critria.
            var matchingRecords = ownerTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();
            // Transform the record into a file that can be read into the database.
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();
            // If there are not any matches, tell the user that are not any matches.
           
            if (matchingRecords.Count == 0)
            {
                return new OperationResult { success = false, message = $"No records found in table '{ownerTable.Name}' where {fieldName} = '{fieldValue}'." };

            }

            // If there are any matches, tell the user what record are.
            return new OperationResult { success = true, message = "Operation was successed", data = matchingData };
        }


        // Method to update data from the Owner table.
        public OperationResult UpdateOperationForOwner(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Owner table from the in memory database.
            var ownerTable = _inMemoryDatabase.GetTable("Owner");

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
            // Try updating the data into the Owner table.
            try
            {
                // Update the the Owner with the new data.
                ownerTable.Update(primaryKeyValue, fieldName, newValueToObject);

                // Save to SQL database.
                var ownerEntity = _dbContext.Owners.Find(primaryKeyValue);
                if (ownerEntity != null)
                {
                    var property = typeof(Owner).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(ownerEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Owner with primary key '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException) // Catch any errors that related to data not being found.
            {
                return new OperationResult { success = false, message = $"No record found with primary key '{primaryKeyValue}' in Owner table." };
            }
            catch (Exception ex) // Catch any other error.
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }




        //Method for API delete (e.g https://localhost:7038/api/Owners/O00001).
        public OperationResult DeleteOwnerById(string ownerId)
        {
            var ownerTable = _inMemoryDatabase.GetTable("Owner");

            // Try delete from memory
            try
            {
                ownerTable.Delete(ownerId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Owner with ID {ownerId} not found in in-memory database." };
            }

            // Try delete from SQL Server
            var ownerEntity = _dbContext.Owners.Find(ownerId);
            if (ownerEntity != null)
            {
                _dbContext.Owners.Remove(ownerEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Owner with ID {ownerId} not found in SQL database.");
            }

            return new OperationResult { success = true, message = $"Owner with ID {ownerId} deleted from in-memory database." };
        }

        // Method to get all the appointments record.
        public OperationResult GetAllOwnerRecord()
        {
            // Get the Appointment table from the inmemory database.
            var table = _inMemoryDatabase.GetTable("Owner");

            // Get all of the record from Appointment table.
            var allOwnerRecord = table.GetAll().Select(record => record.Fields).ToList();

            return new OperationResult { success = true, message = "Operation was successed", data = allOwnerRecord };
        }

    }
}
