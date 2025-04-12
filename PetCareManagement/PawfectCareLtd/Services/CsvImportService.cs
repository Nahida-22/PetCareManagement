using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Repositories.BulkInsertRepository;

namespace PawfectCareLtd.Services
{
    // Service responsible for importing data from CSV files into the database using bulk insert methods.
    public class CsvImportService
    {
        // Private readonly field to hold the BulkInsertRepository instance.
        private readonly IBulkInsertRepository _bulkInsertRepository;

        /// <summary>
        /// Constructor: Initialises the CsvImportService with the provided BulkInsertRepository.
        /// This allows the service to access methods for bulk inserting data into the database.
        /// </summary>
        public CsvImportService(IBulkInsertRepository bulkInsertRepository)
        {
            _bulkInsertRepository = bulkInsertRepository;
        }

        // Method responsible for importing data from CSV files into the database.
        // It finds the CSV files in the "CSV" directory and calls the appropriate bulk insert methods.
        public void ImportData()
        {
            // Determine the directory where CSV files are stored.
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "CSV");

            // Map each CSV filename(key) to its corresponding bulk insert method(value).
            // Each key represents a CSV file, and the value represents the corresponding bulk insert action.
            var csvFiles = new Dictionary <string, Action<string>>
            {
                { "Owner.csv", _bulkInsertRepository.BulkInsertOwners },
                { "Pet.csv", _bulkInsertRepository.BulkInsertPets },
                { "Vet.csv", _bulkInsertRepository.BulkInsertVets },
                { "Appointment.csv", _bulkInsertRepository.BulkInsertAppointments },
                { "Supplier.csv", _bulkInsertRepository.BulkInsertSuppliers },
                { "Order.csv", _bulkInsertRepository.BulkInsertOrders },
                { "Medication.csv", _bulkInsertRepository.BulkInsertMedications },
                { "Prescription.csv", _bulkInsertRepository.BulkInsertPrescriptions },
                { "Location.csv", _bulkInsertRepository.BulkInsertLocations },
                { "Payment.csv", _bulkInsertRepository.BulkInsertPayments }
            };

            // Iterate through each file in the dictionary to process the CSV files and insert data into the database.
            foreach (var csvFile in csvFiles)
            {
                // Get the full path to the current CSV file by combining base path and file name.
                string csvFilePath = Path.Combine(basePath, csvFile.Key);

                // Check if the CSV file exists at the given path.
                if (File.Exists(csvFilePath)) 
                {
                    // Call the appropriate bulk insert method to insert data into the database from the CSV file.
                    csvFile.Value(csvFilePath);

                    // Output a success message
                    Console.WriteLine($"{csvFile.Key} imported successfully.");
                } else
                {
                    // Output error message if file does not exist.
                    Console.WriteLine($"File not found : {csvFile.Key}");
                }
            }
        }

    }
}
