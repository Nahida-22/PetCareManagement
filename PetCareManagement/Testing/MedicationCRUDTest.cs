// Import dependencies
using System; // Import the System namespace which includes fundamental classes and base classes.
using System.Linq; // Import the System.Linq namespace for LINQ (Language-Integrated Query) operations on collections.
using PawfectCareLtd.Data; // Import the Data namespace from the PawfectCareLtd project.
using PawfectCareLtd.Models; // Import the custom in memory database.
using System.Threading.Tasks; // Provides asynchronous programming support
using Microsoft.EntityFrameworkCore; // Import the Entity Framework Core components for in-memory database.
using Microsoft.VisualStudio.TestTools.UnitTesting; // Import MSTesting.


namespace PawfectCareLtd.Tests // Define the namespace for the test framework.
{
    // Show that this is a test class.
    [TestClass]
    public class DatabaseContextTestsForMedication
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "MedicationDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a medication.
        [TestMethod]
        public async Task TestCreateMedication()
        {
            // Create a new Medication object with test data.
            var medication = new Medication
            {
              MedicationID = "M10000",
                MedicationName = "Miconazole",
                SupplierID = "M90000",
                StockQuantity = 166,
                Category = "Antifungal",
                UnitPrice = 25,
                ExpiryDate = DateTime.Now
            };

            // Add the Medication to the database and check if the changes have been made.
            _dbContext!.Medications.Add(medication);
            await _dbContext.SaveChangesAsync();

            // Verify that the Medication is added to the database.
            var addedMedication = await _dbContext.Medications.FirstOrDefaultAsync(a => a.MedicationID == "M10000");

            // Check that the medication was successfully added.
            Assert.IsNotNull(addedMedication); // Medication should not be null.
            Assert.AreEqual(addedMedication.StockQuantity, 166); // ServiceType should match expected value.
        }



        // Test method to get an medication by its ID.
        [TestMethod]
        public async Task TestGetMedicationById()
        {
            // Create a new medication object with test data.
            var medication = new Medication
            {
                MedicationID = "M10001",
                MedicationName = "Miconazole",
                SupplierID = "M90000",
                StockQuantity = 166,
                Category = "Antifungal",
                UnitPrice = 25,
                ExpiryDate = DateTime.Now
            };

            // Add the medication to the database and save the changes have been made.
            _dbContext!.Medications.Add(medication);
            await _dbContext.SaveChangesAsync();

            // Retrieve the medication by its ID.
            var retrievedMedication = await _dbContext.Medications.FirstOrDefaultAsync(a => a.MedicationID == "M10001");

            // Verify that the medication was found correctly
            Assert.IsNotNull(retrievedMedication); // Ensure result is not null.
            Assert.AreEqual(retrievedMedication.StockQuantity, 166); // Ensure ServiceType matches expected.
        }



        // Test method to update an medication field.
        [TestMethod]
        public async Task TestUpdateMedicationtatus()
        {
            // Create a new Medication object with test data.
            var medication = new Medication
            {
                MedicationID = "M10002",
                MedicationName = "Miconazole",
                SupplierID = "M90000",
                StockQuantity = 166,
                Category = "Antifungal",
                UnitPrice = 25,
                ExpiryDate = DateTime.Now
            };

            // Add the medication to the database and save the changes have been made.
            _dbContext!.Medications.Add(medication);
            await _dbContext.SaveChangesAsync();

            // Modify the medication status.
            medication.StockQuantity = 200; // Update stock quantity field.
            _dbContext.Medications.Update(medication); // Mark medication as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedMedication = await _dbContext.Medications.FirstOrDefaultAsync(a => a.MedicationID == "M10002");

            // Verify that the medication data was change.
            Assert.IsNotNull(updatedMedication); // Ensure medication exists.
            Assert.AreEqual(updatedMedication.StockQuantity, 200); // Verify new stock quantity.
        }



        // Test method to delete an medication field.
        [TestMethod]
        public async Task TestDeleteMedication()
        {
            // Create a new Medication object with test data.
            var medication = new Medication
            {
                MedicationID = "M10003",
                MedicationName = "Miconazole",
                SupplierID = "M90000",
                StockQuantity = 166,
                Category = "Antifungal",
                UnitPrice = 25,
                ExpiryDate = DateTime.Now
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Medications.Add(medication);
            await _dbContext.SaveChangesAsync();

            // Delete the medication.
            _dbContext.Medications.Remove(medication);
            await _dbContext.SaveChangesAsync();

            // Verify that the medication has been deleted.
            var deletedMedication = await _dbContext.Medications.FirstOrDefaultAsync(a => a.MedicationID == "M10003");

            // Check if the field has been deleted.
            Assert.IsNull(deletedMedication);
        }
    }
}
