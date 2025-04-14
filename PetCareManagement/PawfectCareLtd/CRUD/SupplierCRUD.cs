using System;
using System.Collections.Generic;
using System.Linq;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.CRUD
{
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
            var supplierTable = _inMemoryDatabase.GetTable("Supplier");
            var medicationTable = _inMemoryDatabase.GetTable("Medication");

            var supplierRecord = supplierTable.Get(supplierId)
                                  ?? throw new KeyNotFoundException("Supplier not found in memory.");

            // Delete related medications
            var medicationRecords = medicationTable.GetAll()
                .Where(m => m.Fields.ContainsKey("SupplierID") && m["SupplierID"]?.ToString() == supplierId)
                .ToList();

            foreach (var medication in medicationRecords)
            {
                medicationTable.Delete(medication["MedicationID"].ToString());
            }

            supplierTable.Delete(supplierId);

            // Remove from EF Core DB
            var supplierEntity = _dbContext.Suppliers.Find(supplierId);
            if (supplierEntity != null)
            {
                var medsInDb = _dbContext.Medications.Where(m => m.SupplierID == supplierId).ToList();
                _dbContext.Medications.RemoveRange(medsInDb);
                _dbContext.Suppliers.Remove(supplierEntity);
                _dbContext.SaveChanges();
            }

            return true;
        }
    }
}
