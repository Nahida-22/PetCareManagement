using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;

namespace PawfectCareLtd.CRUD
{
    public class VetCRUD
    {
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        public VetCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }

        public void InsertOperationForVet(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string, string)> foreignKeys)
        {
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            // Check if the primary key is in the field values
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                Console.WriteLine("Primary key field is missing.");
                return;
            }

            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            // Check if the primary key matches the required format
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                Console.WriteLine($"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'.");
                return;
            }

            // Check if the primary key already exists in the table
            if (vetTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                Console.WriteLine($"A record with primary key '{primaryKeyValue}' already exists.");
                return;
            }

            // Check foreign key constraints
            foreach (var (foreignKeyName, referencedTable) in foreignKeys)
            {
                if (fieldValues.ContainsKey(foreignKeyName))
                {
                    var foreignKeyValue = fieldValues[foreignKeyName]?.ToString();
                    var referencedTableRecords = _inMemoryDatabase.GetTable(referencedTable).GetAll();

                    if (!referencedTableRecords.Any(record => record[foreignKeyName]?.ToString() == foreignKeyValue))
                    {
                        Console.WriteLine($"Foreign key '{foreignKeyName}' with value '{foreignKeyValue}' does not exist in the referenced table '{referencedTable}'.");
                        return;
                    }
                }
            }

            // Insert the new record
            var newRecord = new Record();
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            try
            {
                vetTable.Insert(newRecord, skipDb: true);
                Console.WriteLine("Record inserted successfully into Vet table.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }


        public void ReadOperationForVet(string fieldName, string fieldValue)
        {
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            var matchingRecords = vetTable.GetAll()
                .Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue)
                .ToList();

            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in Vet table where {fieldName} = '{fieldValue}'.");
                return;
            }

            Console.WriteLine($"Found {matchingRecords.Count} record(s) in Vet table:");
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

        public void UpdateOperationForVet(string primaryKeyValue, string fieldName, string newValue)
        {
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            try
            {
                vetTable.Update(primaryKeyValue, fieldName, newValue);
                Console.WriteLine($"Field '{fieldName}' updated successfully for Vet with ID '{primaryKeyValue}'.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"No record found with Vet ID '{primaryKeyValue}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating field: {ex.Message}");
            }
        }


        


    }
}
