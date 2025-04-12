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
    }
}