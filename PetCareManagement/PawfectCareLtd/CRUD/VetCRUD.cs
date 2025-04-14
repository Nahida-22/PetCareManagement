// Import dependencies.
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Controllers;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{
    // Class that encapsulates all of the CRUD operations for the Vet table.
    public class VetCRUD
    {
        // Define fields to store references to the in-memory and SQL databases.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        // Constructor to initialise the class with instances of the databases.
        public VetCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }

        // Method to insert data into the Vet table.
        public OperationResult InsertOperationForVet(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string, string)> foreignKeys)
        {
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            if (!fieldValues.ContainsKey(primaryKeyName))
                return new OperationResult { success = false, message = "Primary key must be inputed." };

            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };

            if (vetTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };

            foreach (var (foreignKeyName, referencedTableName) in foreignKeys)
            {
                if (!fieldValues.ContainsKey(foreignKeyName)) continue;

                var foreignKeyValue = fieldValues[foreignKeyName]?.ToString();
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                if (!referencedTable.GetAll().Any(record => record.Fields.ContainsKey(foreignKeyName) && record[foreignKeyName]?.ToString() == foreignKeyValue))
                    return new OperationResult { success = false, message = $"Foreign key '{foreignKeyName}' with value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
            }

            var newRecord = new Record();
            foreach (var field in fieldValues)
                newRecord[field.Key] = field.Value;

            try
            {
                vetTable.Insert(newRecord, skipDb: true);

                var newVet = new Vet();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Vet).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(newVet, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Vet.Add(newVet);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into Vet table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }

        // Method to read the data from the Vet table.
        public OperationResult ReadOperationForVet(string fieldName, string fieldValue)
        {
            var vetTable = _inMemoryDatabase.GetTable("Vet");
            var matchingRecords = vetTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();

            if (matchingRecords.Count == 0)
                return new OperationResult { success = false, message = $"No records found in table '{vetTable.Name}' where {fieldName} = '{fieldValue}'." };

            return new OperationResult { success = true, message = "Operation was successed", data = matchingData };
        }

        // Method to update the Vet table.
        public OperationResult UpdateOperationForVet(string primaryKeyValue, string fieldName, string newValue)
        {
            var vetTable = _inMemoryDatabase.GetTable("Vet");
            object newValueToObject = newValue;

            try
            {
                vetTable.Update(primaryKeyValue, fieldName, newValueToObject);

                var vetEntity = _dbContext.Vet.Find(primaryKeyValue);
                if (vetEntity != null)
                {
                    var property = typeof(Vet).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(vetEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Vet with ID '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"No record found with Vet ID '{primaryKeyValue}'." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }

      

        // Method to get all the vet records.
        public OperationResult GetAllVetRecord()
        {
            var table = _inMemoryDatabase.GetTable("Vet");
            var allVetRecord = table.GetAll().Select(record => record.Fields).ToList();

            return new OperationResult { success = true, message = "Operation was successed", data = allVetRecord };
        }
    }
}
