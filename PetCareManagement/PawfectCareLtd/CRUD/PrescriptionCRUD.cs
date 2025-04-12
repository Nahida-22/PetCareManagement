using PawfectCareLtd.Data.DataRetrieval;

namespace PawfectCareLtd.CRUD
{
    public class PrescriptionCRUD
    {
        // Method to read the data from the owner table.
        public static void ReadOperationForPrescription(string fieldName, string fieldValue)
        {

            // Get the location table form the in memory location.
            var prescriptionTable = InMemoryDatabase.InMemoryDatabaseInstance.GetTable("Prescription");

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
