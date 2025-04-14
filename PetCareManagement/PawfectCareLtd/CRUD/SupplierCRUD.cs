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
    // Class to encapsulate all of the CRUD operations for the Supplier table.
    public class SupplierCRUD
    {

        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        // Constructor to initialise the class with an instance of the in memory database.
        public SupplierCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }
        // Method to insert data into the Supplier table.
        public OperationResult InsertOperationForSupplier(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat)
        {
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

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

            if (supplierTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };
            }


            // Create a new record.
            var newRecord = new Record();

            // Add each field form the inputed dictionary into the record.
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            // Try inserting the new record into the Supplier table.
            try
            {
                // Insert the data into the in memory database.
                supplierTable.Insert(newRecord, skipDb: true);

                // Save to SQL database.
                var newSupplier = new Supplier();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Supplier).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(newSupplier, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Suppliers.Add(newSupplier);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into Supplier table." };
            }
            catch (Exception ex) // Catch any errors.
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }

        public OperationResult ReadOperationForSupplier(string fieldName, string fieldValue)
        {

            // Get the supplier table form the in memory database.
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

            // Check if there are any record that matches the search critria.
            var matchingRecords = supplierTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();
            // Transform the record into a file that can be read into the database.
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();
            // If there are not any matches, tell the user that are not any matches.

            if (matchingRecords.Count == 0)
            {
                return new OperationResult { success = false, message = $"No records found in table '{supplierTable.Name}' where {fieldName} = '{fieldValue}'." };

            }

            // If there are any matches, tell the user what record are.
            return new OperationResult { success = true, message = "Operation was successed", data = matchingData };
        }

        // Method to update data from the Owner table.
        public OperationResult UpdateOperationForSupplier(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Owner table from the in memory database.
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

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
            // Try updating the data into the Supplier table.
            try
            {
                // Update the supplier with the new data.
                supplierTable.Update(primaryKeyValue, fieldName, newValueToObject);

                // Save to SQL database.
                var supplierEntity = _dbContext.Suppliers.Find(primaryKeyValue);
                if (supplierEntity != null)
                {
                    var property = typeof(Supplier).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(supplierEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Supplier with primary key '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException) // Catch any errors that related to data not being found.
            {
                return new OperationResult { success = false, message = $"No record found with primary key '{primaryKeyValue}' in Supplier table." };
            }
            catch (Exception ex) // Catch any other error.
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }




        //Method for API delete 
        public OperationResult DeleteSupplierById(string supplierId)
        {
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

            // Try delete from memory
            try
            {
                supplierTable.Delete(supplierId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Supplier with ID {supplierId} not found in in-memory database." };
            }

            // Try delete from SQL Server
            var supplierEntity = _dbContext.Suppliers.Find(supplierId);
            if (supplierEntity != null)
            {
                _dbContext.Suppliers.Remove(supplierEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Owner with ID {supplierId} not found in SQL database.");
            }

            return new OperationResult { success = true, message = $"Supplier with ID {supplierId} deleted from in-memory database." };
        }

        // Method to get all the appointments record.
        public OperationResult GetAllSupplierRecord()
        {
            // Get the Supplier table from the inmemory database.
            var table = _inMemoryDatabase.GetTable("Supplier");

            // Get all of the record from Supplier table.
            var allSupplierRecord = table.GetAll().Select(record => record.Fields).ToList();

            return new OperationResult { success = true, message = "Operation was successed", data = allSupplierRecord };
        }

    }
}