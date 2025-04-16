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
    // Class that encapsulates all CRUD operations for the Medication table.
    public class MedicationCRUD
    {
        // Define fields to store references to the in-memory and SQL Server databases.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;



        // Constructor to initialize the class with instances of the in-memory and SQL Server databases.
        public MedicationCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }



        // Method to insert data into the Medication table.
        public OperationResult InsertOperationForMedication(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {
            // Get the Medication table from the in-memory database.
            var medicationTable = _inMemoryDatabase.GetTable("Medication");

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
            if (medicationTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
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

            // Get the record form each field.
            var newRecord = new Record();
            foreach (var field in fieldValues)
                newRecord[field.Key] = field.Value;

            //  Try inserting into memory.
            try
            {
                // Insert into in-memory table.
                medicationTable.Insert(newRecord, skipDb: true);

                // Insert into SQL database.
                var entity = new Medication();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Medication).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(entity, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext. Medications.Add(entity);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into medication table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }



        // Method to read a record from the Medication table by a specific field.
        public OperationResult ReadOperationForMedication(string fieldName, string fieldValue)
        {
            // Get the Medication table from the in-memory database.
            var medicationTable = _inMemoryDatabase.GetTable("Medication");

            // Find all records matching the criteria.
            var matchingRecords = medicationTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // Return if no records are found.
            if (matchingRecords.Count == 0)
            {
                return new OperationResult { success = false, message = $"No records found in table '{medicationTable.Name}' where {fieldName} = '{fieldValue}'." };
            }

            // Return the matched records.
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();
            return new OperationResult { success = true, message = "Operation was successful", data = matchingData };
        }



        // Method to update a field in a Medication record.
        public OperationResult UpdateOperationForMedication(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Medication table.
            var medicationTable = _inMemoryDatabase.GetTable("Medication");

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
                medicationTable.Update(primaryKeyValue, fieldName, newValueToObject);

                var medicationEntity = _dbContext.Medications.Find(primaryKeyValue);
                if (medicationEntity != null)
                {
                    var property = typeof(Medication).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(medicationEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Medication with primary key '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"No record found with primary key '{primaryKeyValue}' in Medication table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }



        // Method to delete a Medication record by ID.
       public OperationResult DeleteMedicationById(string medicationId)
        {
            // Get the Medication table from memory
            var medicationTable = _inMemoryDatabase.GetTable("Medication");

            // Try deleting from in-memory
            try
            {
                medicationTable.Delete(medicationId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Medication with ID {medicationId} not found in in-memory database." };
            }

            // Try deleting from SQL database
            try
            {
                var medicationEntity = _dbContext.Medications
                    .FirstOrDefault(m => m.MedicationID == medicationId);

                if (medicationEntity == null)
                {
                    return new OperationResult { success = false, message = $"Medication with ID {medicationId} not found in SQL database." };
                }

                // Delete related Orders.
                var relatedOrders = _dbContext.Orders.Where(o => o.MedicationID == medicationId).ToList();
                _dbContext.Orders.RemoveRange(relatedOrders);

                // Delete related PrescriptionMedications (ensure this DbSet exists)
                var relatedPrescriptions = _dbContext.PrescriptionMedications.Where(pm => pm.MedicationID == medicationId).ToList();
                _dbContext.PrescriptionMedications.RemoveRange(relatedPrescriptions);

                // Remove the Medication record
                _dbContext.Medications.Remove(medicationEntity);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = $"Medication with ID {medicationId} deleted successfully" };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Error while deleting from SQL database: {ex.Message}" };
            }
        }



        // Method to retrieve all Medication records.
        public OperationResult GetAllMedicationRecord()
        {
            // Get the Medication table.
            var table = _inMemoryDatabase.GetTable("Medication");

            // Retrieve all records.
            var allMedicationRecords = table.GetAll().Select(record => record.Fields).ToList();

            // Return a success status.
            return new OperationResult { success = true, message = "Operation was successful", data = allMedicationRecords };
        }
    }
}
