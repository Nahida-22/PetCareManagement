// Import dependencies.
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
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        public SupplierCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }

        public void InsertOperationForSupplier(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat)
        {
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                Console.WriteLine("Primary key field is missing.");
                return;
            }

            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                Console.WriteLine($"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'.");
                return;
            }

            if (supplierTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                Console.WriteLine($"A record with primary key '{primaryKeyValue}' already exists.");
                return;
            }

            var newRecord = new Record();
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            try
            {
                supplierTable.Insert(newRecord, skipDb: true);

                // --- Save to SQL DB ---
                var newSupplier = new Supplier();
                foreach (var kv in fieldValues)
                {
                    var prop = typeof(Supplier).GetProperty(kv.Key);
                    if (prop != null && kv.Value != null)
                    {
                        prop.SetValue(newSupplier, Convert.ChangeType(kv.Value, prop.PropertyType));
                    }
                }
                _dbContext.Suppliers.Add(newSupplier);
                _dbContext.SaveChanges();

                Console.WriteLine("Record inserted successfully into Supplier table.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }

        public void ReadOperationForSupplier(string fieldName, string fieldValue)
        {
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");

            var matchingRecords = supplierTable.GetAll()
                .Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue)
                .ToList();

            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{supplierTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

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

        public void UpdateOperationForSupplier(string primaryKeyValue, string fieldName, string newValue)
        {
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");
            object newValueToObject = newValue;

            try
            {
                supplierTable.Update(primaryKeyValue, fieldName, newValueToObject);

                var supplierEntity = _dbContext.Suppliers.Find(primaryKeyValue);
                if (supplierEntity != null)
                {
                    var prop = typeof(Supplier).GetProperty(fieldName);
                    if (prop != null)
                    {
                        prop.SetValue(supplierEntity, Convert.ChangeType(newValue, prop.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

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