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
            // Get the Vet table from the in-memory database.
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            // Check if the primary key has been provided.
            if (!fieldValues.ContainsKey(primaryKeyName))
                return new OperationResult { success = false, message = "Primary key must be inputed." };

            // Extract and validate the primary key.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };

            // Check for duplicate primary key.
            if (vetTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };

            // Validate foreign keys.
            foreach (var (foreignKeyName, referencedTableName) in foreignKeys)
            {
                if (!fieldValues.ContainsKey(foreignKeyName)) continue;

                var foreignKeyValue = fieldValues[foreignKeyName]?.ToString();
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                if (!referencedTable.GetAll().Any(record => record.Fields.ContainsKey(foreignKeyName) && record[foreignKeyName]?.ToString() == foreignKeyValue))
                    return new OperationResult { success = false, message = $"Foreign key '{foreignKeyName}' with value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
            }

            // Create and populate new record.
            var newRecord = new Record();
            foreach (var field in fieldValues)
                newRecord[field.Key] = field.Value;

            // Try inserting into in-memory database.
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
            // Get the vet table and record that matches specific criteria.
            var vetTable = _inMemoryDatabase.GetTable("Vet");
            var matchingRecords = vetTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();

            // If there are no matching records return a fail operation.
            if (matchingRecords.Count == 0)
                return new OperationResult { success = false, message = $"No records found in table '{vetTable.Name}' where {fieldName} = '{fieldValue}'." };

            // Return a success status.
            return new OperationResult { success = true, message = "Operation was successed", data = matchingData };
        }



        // Method to update the Vet table.
        public OperationResult UpdateOperationForVet(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Vet table from the in memory database.
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            // Convert the data type of the new value to object type.
            object newValueToObject = newValue;

            // Try updating the data into the Vet table.
            try
            {
                // Update the vet with the new data.
                vetTable.Update(primaryKeyValue, fieldName, newValueToObject);

                // Save to SQL database.
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



        // Method to delete data from the Vet table.
        public OperationResult DeleteVetbyId(string VetId)
        {
            var VetTable = _inMemoryDatabase.GetTable("Vet");

            // Try delete from memory
            try
            {
                VetTable.Delete(VetId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Appointment with ID {VetId} not found in in-memory database." };
            }

            // Try delete from SQL Server
            var locationEntity = _dbContext.Locations.Find(VetId);
            if (locationEntity != null)
            {
                _dbContext.Locations.Remove(locationEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Location with ID {VetId} not found in SQL database.");
            }

            // Return a success status.
            return new OperationResult { success = true, message = $"Location with ID {VetId} deleted from in-memory database." };
        }



        // Method to get all the vet records.
        public OperationResult GetAllVetRecord()
        {
            // Method to get all the Vet record.
            var table = _inMemoryDatabase.GetTable("Vet");

            // Get all of the record from Supplier table.
            var allVetRecord = table.GetAll().Select(record => record.Fields).ToList();

            return new OperationResult { success = true, message = "Operation was successed", data = allVetRecord };
        }
    }
}
