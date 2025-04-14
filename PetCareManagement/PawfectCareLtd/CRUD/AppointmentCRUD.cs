// Import dependencies.
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;  // Import the custom in memory database.


namespace PawfectCareLtd.CRUD// Define the namespace for the application.
{

    // Class the encapsulate all of the CRUD operation for the Appointment table.
    public class AppointmentCRUD
    {
        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;

        // Constructor to initialise the class with an instance of the in memory database.
        public AppointmentCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;

        }


        // Method to insert data into the Appointment table.
        public void InsertOperationForAppointment(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {

            // Get the Appointment table from the in memory database.
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");

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

            // Check if the primary key for the new already exist in the the Appointment table, If yes exist out of the function.
            if (appointmentTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                Console.WriteLine($"A record with primary key '{primaryKeyValue}' already exists.");
                return;
            }

            // Iterate through each foreignkey that need to valides.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                // If the foreign key field is not into the input dictionary, skip it.
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                // Get the foreign key from the inputed list.
                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();

                // Get the referenced table which contain the foreign key as the primary key.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the foreign key exist in the referenced table, if not exist out of the function.
                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    Console.WriteLine($"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'.");
                    return;
                }
            }

            // Create a new record.
            var newRecord = new Record();

            // Add each field form the inputed dictionary into the record.
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            // Try inserting the new record into the Appointment table.
            try
            {
                // Insert the data into the in memory database.
                appointmentTable.Insert(newRecord, skipDb: true);
                Console.WriteLine("Record inserted successfully into Location table.");
            }
            catch (Exception ex) // Catch any errors.
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }


        // Method to read the data from the Appointment table.
        public void ReadOperationForAppointment(string fieldName, string fieldValue)
        {

            // Get the appointment table form the in memory database.
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");

            // Check if there are any record that matches the search critria.
            var matchingRecords = appointmentTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // If there are not any matches, tell the user that are not any matches.
            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{appointmentTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

            // If there are any matches, tell the user what record are.
            Console.WriteLine($"Found {matchingRecords.Count} record(s) in table '{appointmentTable.Name}' where {fieldName} = '{fieldValue}':");
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

<<<<<<< Updated upstream
        //Method to insert data into the Appointment table.
        public void InsertOperationForAppointment(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {

            // Get the Appointment table from the in memory database.
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");

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

            // Check if the primary key for the new already exist in the the Appointment table, If yes exist out of the function.
            if (appointmentTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                Console.WriteLine($"A record with primary key '{primaryKeyValue}' already exists.");
                return;
            }

            // Iterate through each foreignkey that need to valides.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                // If the foreign key field is not into the input dictionary, skip it.
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                // Get the foreign key from the inputed list.
                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();

                // Get the referenced table which contain the foreign key as the primary key.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the foreign key exist in the referenced table, if not exist out of the function.
                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    Console.WriteLine($"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'.");
                    return;
                }
            }

            // Create a new record.
            var newRecord = new Record();

            // Add each field form the inputed dictionary into the record.
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            // Try inserting the new record into the Appointment table.
            try
            {
                // Insert the data into the in memory database.
                appointmentTable.Insert(newRecord, skipDb: true);
                Console.WriteLine("Record inserted successfully into Location table.");
            }
            catch (Exception ex) // Catch any errors.
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }
=======
        
>>>>>>> Stashed changes

        public int GetAppointmentCount()
        {
            var table = _inMemoryDatabase.GetTable("Appointment");
            return table.GetAll().Count(); 
        }

    }
}
