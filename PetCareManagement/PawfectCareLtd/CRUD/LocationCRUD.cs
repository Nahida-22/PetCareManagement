// Import dependencies.
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database
using System;  // Import a base class definition.
using System.Collections.Generic; // To collect generic collections like Dictionary.
using System.Linq; // Enable Linq queries.


namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{

    // Class the encapsulate all of the CRUD operation for the Location table.
    public class LocationCRUD
    {

        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;


        // Constructor to initialise the class with an instance of the in memory database.
        public LocationCRUD(Database inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }


        // Method to read the data from the Location table.
        public void ReadOperationForLocation(string fieldName, string fieldValue)
        {
            // Get the location table form the in memory database.
            var locationTable = _inMemoryDatabase.GetTable("Location");

            // Check if there are any record that matches the search critria.
            var matchingRecords = locationTable.GetAll()
                .Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue)
                .ToList();

            // If there are not any matches, tell the user that are not any matches.
            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{locationTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

            // If there are any matches, tell the user what record are.
            Console.WriteLine($"Found {matchingRecords.Count} record(s) in table '{locationTable.Name}' where {fieldName} = '{fieldValue}':");
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


        // Method to update data from the Location table.
        public void UpdateOperationForLocation(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Appointment table from the in-memory database.
            var locationTable = _inMemoryDatabase.GetTable("Location");

            // Convert the data type of the new value to object type.
            object newValueToObject = newValue;

            // If the field that is being updated is a foreign key.
            if (isForeignKey)
            {
                // Check if the referenced table exists in the in memory database.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);
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


            // Try updating the data into the Location table.
            try
            {
                // Update the the Location with the new data.
                locationTable.Update(primaryKeyValue, fieldName, newValueToObject);

                Console.WriteLine($"Field '{fieldName}' updated successfully for Location with primary key '{primaryKeyValue}'.");
            }
            catch (KeyNotFoundException) // Catch any errors that related to data not being found.
            {
                Console.WriteLine($"No record found with primary key '{primaryKeyValue}' in Location table.");
            }
            catch (Exception ex) // Catch any other error.
            {
                Console.WriteLine($"Error updating field: {ex.Message}");
            }
        }
    }
}