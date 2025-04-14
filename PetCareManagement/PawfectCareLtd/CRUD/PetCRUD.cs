// Import dependencies.
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Controllers;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{
    // Class that encapsulates all of the CRUD operations for the Pet table.
    public class PetCRUD
    {
        // Define fields to store references to the in-memory and SQL databases.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        // Constructor to initialise the class with instances of the databases.
        public PetCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }

        // Method to insert data into the Pet table.
        public OperationResult InsertOperationForPet(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {
            var petTable = _inMemoryDatabase.GetTable("Pet");

            // Check if the primary key has been added into the input dictionary.
            if (!fieldValues.ContainsKey(primaryKeyName))
                return new OperationResult { success = false, message = "Primary key must be inputed." };

            // Get the primary key for the record being inserted and validate format.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };

            // Check for duplicate primary key.
            if (petTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };

            // Validate foreign key constraints.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;
                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                    return new OperationResult { success = false, message = $"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
            }

            // Add fields to a new record.
            var newRecord = new Record();
            foreach (var field in fieldValues)
                newRecord[field.Key] = field.Value;

            try
            {
                // Insert into in-memory database.
                petTable.Insert(newRecord, skipDb: true);

                // Insert into SQL database.
                var newPet = new Pet();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Pet).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(newPet, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Pets.Add(newPet);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into Pet table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }

        // Method to read the data from the Pet table.
        public OperationResult ReadOperationForPet(string fieldName, string fieldValue)
        {
            var petTable = _inMemoryDatabase.GetTable("Pet");
            var matchingRecords = petTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();

            // Check if there are any matching records.
            if (matchingRecords.Count == 0)
                return new OperationResult { success = false, message = $"No records found in table '{petTable.Name}' where {fieldName} = '{fieldValue}'." };

            return new OperationResult { success = true, message = "Operation was successed", data = matchingData };
        }

        // Method to update data in the Pet table.
        public OperationResult UpdateOperationForPet(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            var petTable = _inMemoryDatabase.GetTable("Pet");
            object newValueToObject = newValue;

            // If the field is a foreign key, validate its existence in the referenced table.
            if (isForeignKey)
            {
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);
                if (referencedTable == null)
                    return new OperationResult { success = false, message = $"Referenced table '{referencedTableName}' not found in memory." };

                bool exists = referencedTable.GetAll().Any(record => record.Fields.ContainsKey(referencedTable.GetAll().First().Fields.Keys.First()) && record[referencedTable.GetAll().First().Fields.Keys.First()].ToString() == newValue);
                if (!exists)
                    return new OperationResult { success = false, message = $"Foreign key value '{newValueToObject}' does not exist in the '{referencedTableName}' table." };
            }

            try
            {
                // Update the in-memory database.
                petTable.Update(primaryKeyValue, fieldName, newValueToObject);

                // Update the SQL database.
                var petEntity = _dbContext.Pets.Find(primaryKeyValue);
                if (petEntity != null)
                {
                    var property = typeof(Pet).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(petEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Pet with primary key '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"No record found with primary key '{primaryKeyValue}' in Pet table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }

        // Method to delete a pet record.
        public OperationResult DeletePetById(string petId)
        {
            var petTable = _inMemoryDatabase.GetTable("Pet");
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            try
            {
                // Delete from in-memory database.
                petTable.Delete(petId);

                // Delete from SQL database.
                var petEntity = _dbContext.Pets.Find(petId);
                if (petEntity != null)
                {
                    var dbAppointments = _dbContext.Appointments.Where(a => a.PetID == petId).ToList();
                    var dbPrescriptions = _dbContext.Prescriptions.Where(p => p.PetID == petId).ToList();

                    _dbContext.Appointments.RemoveRange(dbAppointments);
                    _dbContext.Prescriptions.RemoveRange(dbPrescriptions);
                    _dbContext.Pets.Remove(petEntity);
                    _dbContext.SaveChanges();
                }

                return new OperationResult { success = true, message = $"Pet with ID {petId} and related data deleted." };
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Pet with ID {petId} not found in in-memory database." };
            }
        }

        // Method to get all the pet records.
        public OperationResult GetAllPetRecord()
        {
            var table = _inMemoryDatabase.GetTable("Pet");
            var allPetRecord = table.GetAll().Select(record => record.Fields).ToList();

            return new OperationResult { success = true, message = "Operation was successed", data = allPetRecord };
        }
    }
}