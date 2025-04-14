// Import dependencies.
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;  // Import the custom in memory database


namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{
    // Class the encapsulate all of the CRUD operation for the Vet table.
    public class VetCRUD
    {

        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        // Constructor to initialise the class with an instance of the in memory database.
        public VetCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }



        // Method to insert data into the Vet table.
        public void InsertOperationForVet(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string, string)> foreignKeys)
        {

            // Get the Vet table from the in memory database.
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            // Check if the primary key has been added into the input dictionary.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                Console.WriteLine("Primary key field is missing.");
                return;
            }

            // Get the primary key for the record being inserted then convert it to string.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            // Check if primary for the the record being inserted is non empty and is in the required format.
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                Console.WriteLine($"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'.");
                return;
            }

            // Check if the primary key for the new already exist in the the Vet table, If yes exist out of the function.
            if (vetTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                Console.WriteLine($"A record with primary key '{primaryKeyValue}' already exists.");
                return;
            }

            // Iterate through each foreignkey that need to valides.
            foreach (var (foreignKeyName, referencedTable) in foreignKeys)
            {
                // If the foreign key field is not into the input dictionary, skip it.
                if (fieldValues.ContainsKey(foreignKeyName))
                {
                    // Get the foreign key from the inputed list.
                    var foreignKeyValue = fieldValues[foreignKeyName]?.ToString();

                    // Get the referenced table which contain the foreign key as the primary key.
                    var referencedTableRecords = _inMemoryDatabase.GetTable(referencedTable).GetAll();

                    // Check if the foreign key exist in the referenced table, if not exist out of the function.
                    if (!referencedTableRecords.Any(record => record[foreignKeyName]?.ToString() == foreignKeyValue))
                    {
                        Console.WriteLine($"Foreign key '{foreignKeyName}' with value '{foreignKeyValue}' does not exist in the referenced table '{referencedTable}'.");
                        return;
                    }
                }
            }

            // Insert the new record.
            var newRecord = new Record();

            // Add each field form the inputed dictionary into the record.
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            // Try inserting the new record into the Vet table.
            try
            {
                // Insert the data into the in memory database.
                vetTable.Insert(newRecord, skipDb: true);
                Console.WriteLine("Record inserted successfully into Vet table.");
            }
            catch (Exception ex) // Catch any errors.
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }



        // Method to read the data from the Vet table.
        public void ReadOperationForVet(string fieldName, string fieldValue)
        {
            // Get the Vet table form the in memory database.
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            // Check if there are any record that matches the search critria.
            var matchingRecords = vetTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // If there are not any matches, tell the user that are not any matches.
            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in Vet table where {fieldName} = '{fieldValue}'.");
                return;
            }

            // If there are any matches, tell the user what record are.
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


        // Method to update the vet table.
        public void UpdateOperationForVet(string primaryKeyValue, string fieldName, string newValue)
        {

            // Get the Vet table from the in memory table.
            var vetTable = _inMemoryDatabase.GetTable("Vet");

            // Try to update te data.
            try
            {
                vetTable.Update(primaryKeyValue, fieldName, newValue);
                Console.WriteLine($"Field '{fieldName}' updated successfully for Vet with ID '{primaryKeyValue}'.");
            }
            catch (KeyNotFoundException) // Catch any errors related to vetID.
            {
                Console.WriteLine($"No record found with Vet ID '{primaryKeyValue}'.");
            }
            catch (Exception ex) // Catch any other errors.
            {
                Console.WriteLine($"Error updating field: {ex.Message}");
            }
        }
    }
}
