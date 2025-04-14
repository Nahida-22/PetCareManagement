// Import dependencies.
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in-memory database.

namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{
    // Class that encapsulates all of the CRUD operations for the Prescription table.
    public class PrescriptionCRUD
    {
        // Define a field to store a reference to the in-memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        // Constructor to initialize the class with an instance of the in-memory and SQL database.
        public PrescriptionCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }

        // Method to insert data into the Prescription table.
        public void InsertOperationForPrescription(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {
            // Get the Prescription table from the in-memory database.
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            // Check if the primary key field is included in the input dictionary.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                Console.WriteLine("Primary key field is missing.");
                return;
            }

            // Extract and validate the primary key value.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                Console.WriteLine($"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'.");
                return;
            }

            // Check for duplicate primary key.
            if (prescriptionTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                Console.WriteLine($"A record with primary key '{primaryKeyValue}' already exists.");
                return;
            }

            // Validate each foreign key.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    Console.WriteLine($"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'.");
                    return;
                }
            }

            // Create and populate a new record.
            var newRecord = new Record();
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            // Try inserting the new record.
            try
            {
                prescriptionTable.Insert(newRecord, skipDb: true);
                Console.WriteLine("Record inserted successfully into Prescription table.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }

        // Method to read data from the Prescription table.
        public void ReadOperationForPrescription(string fieldName, string fieldValue)
        {
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            var matchingRecords = prescriptionTable.GetAll()
                .Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue)
                .ToList();

            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{prescriptionTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

            Console.WriteLine($"Found {matchingRecords.Count} record(s) in table '{prescriptionTable.Name}' where {fieldName} = '{fieldValue}':");
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

        // Method to update a field in the Prescription table.
        public void UpdateOperationForPrescription(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");
            object newValueToObject = newValue;

            // If the update involves a foreign key, validate it.
            if (isForeignKey)
            {
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                if (referencedTable == null)
                {
                    Console.WriteLine($"Referenced table '{referencedTableName}' not found in memory.");
                    return;
                }

                bool exists = referencedTable.GetAll().Any(record => record.Fields.ContainsKey(referencedTable.GetAll().First().Fields.Keys.First()) && record[referencedTable.GetAll().First().Fields.Keys.First()].ToString() == newValue);

                if (!exists)
                {
                    Console.WriteLine($"Foreign key value '{newValueToObject}' does not exist in the '{referencedTableName}' table.");
                    return;
                }
            }

            try
            {
                prescriptionTable.Update(primaryKeyValue, fieldName, newValueToObject);
                Console.WriteLine($"Field '{fieldName}' updated successfully for Prescription with primary key '{primaryKeyValue}'.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"No record found with primary key '{primaryKeyValue}' in Prescription table.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating field: {ex.Message}");
            }
        }

        // Method to find prescriptions by any field.
        public List<object> FindPrescriptionByField(string fieldName, string fieldValue)
        {
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            var matchingRecords = prescriptionTable.GetAll()
                .Where(record => record.Fields.ContainsKey(fieldName) &&
                                 record[fieldName]?.ToString() == fieldValue)
                .Select(record => record.Fields.ToDictionary(f => f.Key, f => f.Value))
                .Cast<object>()
                .ToList();

            return matchingRecords;
        }

        // Method to delete a prescription record.
        public (bool Success, string Message) DeletePrescriptionById(string prescriptionId)
        {
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            try
            {
                // In-memory deletion.
                prescriptionTable.Delete(prescriptionId);

                // SQL deletion.
                var prescriptionEntity = _dbContext.Prescriptions.Find(prescriptionId);
                if (prescriptionEntity != null)
                {
                    _dbContext.Prescriptions.Remove(prescriptionEntity);
                    _dbContext.SaveChanges();
                    return (true, "Prescription deleted from both in-memory and SQL database.");
                }

                return (true, "Prescription deleted from in-memory. Not found in SQL database.");
            }
            catch (KeyNotFoundException)
            {
                return (false, $"Prescription with ID '{prescriptionId}' not found in in-memory database.");
            }
        }
    }
}
