// Import dependencies.
using System; // Import the System namespace which includes fundamental classes and base classes.
using System.Collections.Generic; // Import the System.Collections.Generic namespace for generic collections.
using System.Linq; // Import the System.Linq namespace for LINQ (Language-Integrated Query) operations on collections.
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Controllers; // Import the Controllers namespace from the PawfectCareLtd project.
using PawfectCareLtd.Data; // Import the Data namespace from the PawfectCareLtd project.
using PawfectCareLtd.Data.DataRetrieval;  // Import the custom in memory database.
using PawfectCareLtd.Models;  // Import the custom in memory database.


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
        public OperationResult InsertOperationForSupplier(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string, string)> foreignKeys)
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



        // Method to update data from the Supplier table.
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



        // Method to delete data from the Supplier table.
        public OperationResult DeleteSupplierById(string supplierId)
        {
            // Get the in mememory database table for the Supplier.
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

            // Try deleting the in memory database.
            try
            {
                supplierTable.Delete(supplierId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Supplier with ID {supplierId} not found in in-memory database." };
            }

            // If the supplier ID was not found in the in memory table.
            var supplierEntity = _dbContext.Suppliers.Include(s => s.Medications).ThenInclude(m => m.Orders).FirstOrDefault(s => s.SupplierID == supplierId);

            // If the supplier was not found in the SQL database, return a failure message.
            if (supplierEntity == null)
            {
                return new OperationResult { success = false, message = $"Supplier with ID {supplierId} not found in SQL database." };
            }

            // Check if any of the medications linked to the supplier have existing orders.
            if (supplierEntity.Medications.Any(m => m.Orders.Any()))
            {
                return new OperationResult { success = false,message = "Cannot delete supplier because one or more medications are linked to existing orders." };
            }

            // Loop through each medication linked to the supplier.
            foreach (var med in supplierEntity.Medications)
            {
                _dbContext.Orders.RemoveRange(med.Orders);
            }

            // Remove medications manually first.
            _dbContext.Medications.RemoveRange(supplierEntity.Medications);
            _dbContext.Suppliers.Remove(supplierEntity);
            _dbContext.SaveChanges();

            return new OperationResult { success = true, message = $"Supplier with ID {supplierId} and related medications deleted." };
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