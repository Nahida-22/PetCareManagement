// Import dependencies.
using System; // Import the System namespace which includes fundamental classes and base classes.
using System.Collections.Generic; // Import the System.Collections.Generic namespace for generic collections.
using System.Linq; // Import the System.Linq namespace for LINQ (Language-Integrated Query) operations on collections.
using PawfectCareLtd.Controllers; // Import the Controllers namespace from the PawfectCareLtd project.
using PawfectCareLtd.Data; // Import the Data namespace from the PawfectCareLtd project.
using PawfectCareLtd.Data.DataRetrieval;  // Import the custom in memory database.
using PawfectCareLtd.Models;  // Import the custom in memory database.


namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{
    // Class that encapsulates all of the CRUD operations for the Prescription table.
    public class PrescriptionCRUD
    {
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;



        // Constructor to initialise the class with instances of the databases.
        public PrescriptionCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }



        // Method to insert a prescription record.
        public OperationResult InsertOperationForPrescription(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string, string)> foreignKeys)
        {
            var table = _inMemoryDatabase.GetTable("Prescription");

            // Check for primary key presence.
            if (!fieldValues.ContainsKey(primaryKeyName))
                return new OperationResult { success = false, message = "Primary key must be inputed." };

            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            // Validate format of the primary key.
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };

            // Prevent duplicate primary keys.
            if (table.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };

            // Validate all foreign key references.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Ensure foreign key value exists in referenced table.
                if (!referencedTable.GetAll().Any(record => record.Fields.ContainsKey(foreignKeyField) && record[foreignKeyField]?.ToString() == foreignKeyValue))
                    return new OperationResult { success = false, message = $"Foreign key '{foreignKeyField}' with value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
            }

            // Build and insert new record.
            var newRecord = new Record();
            foreach (var field in fieldValues)
                newRecord[field.Key] = field.Value;

            try
            {
                // Insert into in-memory table.
                table.Insert(newRecord, skipDb: true);

                // Insert into SQL database.
                var entity = new Prescription();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Prescription).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(entity, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Prescriptions.Add(entity);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into Prescription table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }



        // Method to read a prescription record by a specific field.
        public OperationResult ReadOperationForPrescription(string fieldName, string fieldValue)
        {
            // Get the Prescription table and get record base on the required criteria.
            var table = _inMemoryDatabase.GetTable("Prescription");
            var matchingRecords = table.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();

            // Return result if no matches found.
            if (matchingRecords.Count == 0)
                return new OperationResult { success = false, message = $"No records found in table '{table.Name}' where {fieldName} = '{fieldValue}'." };

            // Return matching records.
            return new OperationResult { success = true, message = "Operation was successed", data = matchingData };
        }



        // Method to update a prescription record field.
        public OperationResult UpdateOperationForPrescription(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            var table = _inMemoryDatabase.GetTable("Prescription");
            object newValueToObject = newValue;

            try
            {
                // Update in-memory.
                table.Update(primaryKeyValue, fieldName, newValueToObject);

                // Update in SQL database.
                var entity = _dbContext.Prescriptions.Find(primaryKeyValue);
                if (entity != null)
                {
                    var property = typeof(Prescription).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(entity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Prescription with ID '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"No record found with ID '{primaryKeyValue}'." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }



        // Method to delete a prescription record by ID.
        public OperationResult DeletePrescriptionById(string id)
        {
            var table = _inMemoryDatabase.GetTable("Prescription");

            try
            {
                // Delete from in-memory database.
                table.Delete(id);

                // Delete from SQL database.
                var entity = _dbContext.Prescriptions.Find(id);
                if (entity != null)
                {
                    _dbContext.Prescriptions.Remove(entity);
                    _dbContext.SaveChanges();
                }

                return new OperationResult { success = true, message = $"Prescription with ID {id} deleted successfully." };
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Prescription with ID {id} not found in in-memory database." };
            }
        }



        // Method to get all the prescription records.
        public OperationResult GetAllPrescriptionRecord()
        {
            // Method to get all the Prescription record.
            var table = _inMemoryDatabase.GetTable("Prescription");

            // Collect all records.
            var allRecords = table.GetAll().Select(record => record.Fields).ToList();

            return new OperationResult { success = true, message = "Operation was successed", data = allRecords };
        }
    }
}
