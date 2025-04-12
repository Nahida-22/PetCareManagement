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
        private readonly Database _inMemoryDatabase;

        public LocationCRUD(Database inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public void ReadOperationForLocation(string fieldName, string fieldValue)
        {
            var locationTable = _inMemoryDatabase.GetTable("Location");

            var matchingRecords = locationTable.GetAll()
                .Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue)
                .ToList();

            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{locationTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

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