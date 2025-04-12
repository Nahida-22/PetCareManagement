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
    }
}
