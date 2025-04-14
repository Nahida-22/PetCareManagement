using System;
using System.Collections.Generic;
using System.Linq;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{
    // Class to encapsulate all of the CRUD operations for the Supplier table.
    public class SupplierCRUD
    {
        // Define fields to store references to the in-memory and EF Core databases.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        // Constructor to initialise the class with instances of the in-memory and EF Core databases.
        public SupplierCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }
        // Method to insert data into the Supplier table.
        public void InsertOperationForSupplier(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat)
        {
            // Get the Supplier table from the in-memory database.
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

            // Check if the primary key has been added into the input dictionary.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                Console.WriteLine("Primary key field is missing.");
                return;
            }

            // Get the primary key for the record being inserted then convert it to string.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            // Check if primary key is non-empty and matches the required format.
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                Console.WriteLine($"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'.");
                return;
            }

            // Check if the primary key already exists in the Supplier table.
            if (supplierTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                Console.WriteLine($"A record with primary key '{primaryKeyValue}' already exists.");
                return;
            }

            // Create a new record and populate it with values from the input dictionary.
            var newRecord = new Record();
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }


            // Try inserting the new record into the Supplier table.
            try
            {
                supplierTable.Insert(newRecord, skipDb: true);
                Console.WriteLine("Record inserted successfully into Supplier table.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }


        // Method to read data from the Supplier table.
        public void ReadOperationForSupplier(string fieldName, string fieldValue)
        {
            // Get the Supplier table from the in-memory database.
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

            // Check if there are any records that match the search criteria.
            var matchingRecords = supplierTable.GetAll()
                .Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue)
                .ToList();

            // If there are no matches, inform the user.
            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{supplierTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

            // If there are matches, display the matching records.
            Console.WriteLine($"Found {matchingRecords.Count} record(s) in table '{supplierTable.Name}' where {fieldName} = '{fieldValue}':");
            foreach (var record in matchingRecords)
            {
                Console.WriteLine("----- Record -----");
                foreach (var field in record.Fields)
                {
                    Console.WriteLine($"{field.Key}: {field.Value}");
                }
                Console.WriteLine("------------------\n");
            }
        }

        // Method to update data in the Supplier table.
        public void UpdateOperationForSupplier(string primaryKeyValue, string fieldName, string newValue)
        {
            // Get the Supplier table from the in-memory database.
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");
            // Convert the new value to object type.
            object newValueToObject = newValue;

            // Try updating the Supplier record.
            try
            {
                supplierTable.Update(primaryKeyValue, fieldName, newValueToObject);
                Console.WriteLine($"Field '{fieldName}' updated successfully for Supplier with primary key '{primaryKeyValue}'.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"No record found with primary key '{primaryKeyValue}' in Supplier table.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating field: {ex.Message}");
            }
        }

        // Method for API delete (e.g. https://localhost:7038/api/Suppliers/S00001)

        public bool DeleteSupplierById(string supplierId)
        {
            // Get the Supplier table from the in-memory database.
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");
            
            // Get the Medication table from the in-memory database.
            var medicationTable = _inMemoryDatabase.GetTable("Medication");

            // Attempt to retrieve the supplier record from the in-memory database.
            var supplierRecord = supplierTable.Get(supplierId)
                                  ?? throw new KeyNotFoundException("Supplier not found in memory.");

            // Delete related medication records from the in-memory database.
            var medicationRecords = medicationTable.GetAll()
                .Where(m => m.Fields.ContainsKey("SupplierID") && m["SupplierID"]?.ToString() == supplierId)
                .ToList();

            // Iterate through each related medication and delete it.
            foreach (var medication in medicationRecords)
            {
                medicationTable.Delete(medication["MedicationID"].ToString());
            }

            // Delete the supplier record from the in-memory database.
            supplierTable.Delete(supplierId);

            // Remove the supplier and related medication records from the SQL database.
            var supplierEntity = _dbContext.Suppliers.Find(supplierId);
            if (supplierEntity != null)
            {
                var medsInDb = _dbContext.Medications.Where(m => m.SupplierID == supplierId).ToList();
                _dbContext.Medications.RemoveRange(medsInDb);
                _dbContext.Suppliers.Remove(supplierEntity);
                _dbContext.SaveChanges();
            }

            // Indicate success.
            return true;
        }
    }
}
