// Import dependencies.
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.


namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{

    // Class the encapsulate all of the CRUD operation for the Prescription table.
    public class PrescriptionCRUD
    {

        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;


        // Constructor to initialise the class with an instance of the in memory database.
        public PrescriptionCRUD(Database inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }


        // Method to insert data into the Prescription table.
        public void InsertOperationForPrescription(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {

            // Get the Prescription table from the in memory database.
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

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

            // Check if the primary key for the new already exist in the the Prescription table, If yes exist out of the function.
            if (prescriptionTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
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

            // Try inserting the new record into the Prescription table.
            try
            {
                // Insert the data into the in memory database.
                prescriptionTable.Insert(newRecord, skipDb: true);
                Console.WriteLine("Record inserted successfully into Location table.");
            }
            catch (Exception ex) // Catch any errors.
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }


        // Method to read the data from the Prescription table.
        public void ReadOperationForPrescription(string fieldName, string fieldValue)
        {
            // Get the Prescription table form the in memory database.
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            // Check if there are any record that matches the search critria.
            var matchingRecords = prescriptionTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // If there are not any matches, tell the user that are not any matches.
            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{prescriptionTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

            // If there are any matches, tell the user what record are.
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


        // Method to update data from the Prescription table.
        public void UpdateOperationForPrescription(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Prescription table from the in memory database.
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            // Convert the data type of the new value to object type.
            object newValueToObject = newValue;

            // If the field that is being updated is a foreign key.
            if (isForeignKey)
            {
                // Check if the referenced table exists in the in memory database.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the referenced table does not exist, exit out of the method.
                if (referencedTable == null)
                {
                    Console.WriteLine($"Referenced table '{referencedTableName}' not found in memory.");
                    return;
                }

                // Check if the foreign key value exists in the referenced table.
                bool exists = referencedTable.GetAll().Any(record => record.Fields.ContainsKey(referencedTable.GetAll().First().Fields.Keys.First()) && record[referencedTable.GetAll().First().Fields.Keys.First()].ToString() == newValue);

                // If new value does not exist in the reference table, exit out of the method to prevent data linking issues.
                if (!exists)
                {
                    Console.WriteLine($"Foreign key value '{newValueToObject}' does not exist in the '{referencedTableName}' table.");
                    return;
                }
            }

            // Try updating the data into the Prescription table.
            try
            {
                // Update the the Prescription with the new data.
                prescriptionTable.Update(primaryKeyValue, fieldName, newValueToObject);

                Console.WriteLine($"Field '{fieldName}' updated successfully for Appointment with primary key '{primaryKeyValue}'.");
            }
            catch (KeyNotFoundException) // Catch any errors that related to data not being found.
            {
                Console.WriteLine($"No record found with primary key '{primaryKeyValue}' in Appointment table.");
            }
            catch (Exception ex) // Catch any other error.
            {
                Console.WriteLine($"Error updating field: {ex.Message}");
            }
        }
    }
}
