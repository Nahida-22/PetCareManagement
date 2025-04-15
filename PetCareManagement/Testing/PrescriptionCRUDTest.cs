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
    public class DatabaseContextTestsForPrescription
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "PrescriptionDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a Prescription.
        [TestMethod]
        public async Task TestCreatePrescription()
        {
            // Create a new Prescription object with test data.
            var Prescription = new Prescription
            {
                PrescriptionID = "PR20000",
                PetID = "P08482",
                VetID = "V1006",
                Diagnosis = "Parasitic Infestation",
                Dosage = "2 times a day for 14 days",
                DateIssued = DateTime.Now
            };

            // Add the Prescription to the database and check if the changes have been made.
            _dbContext!.Prescriptions.Add(Prescription);
            await _dbContext.SaveChangesAsync();

            // Verify that the Prescription is added to the database.
            var addedPrescription = await _dbContext.Prescriptions.FirstOrDefaultAsync(a => a.PrescriptionID == "PR20000");

            // Check that the Prescription was successfully added.
            Assert.IsNotNull(addedPrescription); // Prescription should not be null.
            Assert.AreEqual(addedPrescription.VetID, "V1006"); // ServiceType should match expected value.
        }



        // Test method to get an Prescription by its ID.
        [TestMethod]
        public async Task TestGetPrescriptionById()
        {
            // Create a new Prescription object with test data.
            var Prescription = new Prescription
            {
                PrescriptionID = "PR20001",
                PetID = "P08482",
                VetID = "V1006",
                Diagnosis = "Parasitic Infestation",
                Dosage = "2 times a day for 14 days",
                DateIssued = DateTime.Now
            };

            // Add the Prescription to the database and save the changes have been made.
            _dbContext!.Prescriptions.Add(Prescription);
            await _dbContext.SaveChangesAsync();

            // Retrieve the Prescription by its ID.
            var retrievedPrescription = await _dbContext.Prescriptions.FirstOrDefaultAsync(a => a.PrescriptionID == "PR20001");

            // Verify that the Prescription was found correctly
            Assert.IsNotNull(retrievedPrescription); // Ensure result is not null.
            Assert.AreEqual(retrievedPrescription.VetID, "V1006"); // Ensure ServiceType matches expected.
        }



        // Test method to update an Prescription field.
        [TestMethod]
        public async Task TestUpdatePrescriptionstatus()
        {
            // Create a new Prescription object with test data.
            var Prescription = new Prescription
            {
                PrescriptionID = "PR20002",
                PetID = "P08482",
                VetID = "V1006",
                Diagnosis = "Parasitic Infestation",
                Dosage = "2 times a day for 14 days",
                DateIssued = DateTime.Now
            };


            // Add the Prescription to the database and save the changes have been made.
            _dbContext!.Prescriptions.Add(Prescription);
            await _dbContext.SaveChangesAsync();

            // Modify the Prescription status.
            Prescription.Dosage = "3 times a day for 14 days"; // Update stock quantity field.
            _dbContext.Prescriptions.Update(Prescription); // Mark Prescription as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedPrescription = await _dbContext.Prescriptions.FirstOrDefaultAsync(a => a.PrescriptionID == "PR20002");

            // Verify that the Prescription data was change.
            Assert.IsNotNull(updatedPrescription); // Ensure Prescription exists.
            Assert.AreEqual(updatedPrescription.Dosage, "3 times a day for 14 days"); // Verify new stock quantity.
        }



        // Test method to delete an Prescription field.
        [TestMethod]
        public async Task TestDeletePrescription()
        {
            // Create a new Prescription object with test data.
            var Prescription = new Prescription
            {
                PrescriptionID = "PR20003",
                PetID = "P08482",
                VetID = "V1006",
                Diagnosis = "Parasitic Infestation",
                Dosage = "2 times a day for 14 days",
                DateIssued = DateTime.Now
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Prescriptions.Add(Prescription);
            await _dbContext.SaveChangesAsync();

            // Delete the Prescription.
            _dbContext.Prescriptions.Remove(Prescription);
            await _dbContext.SaveChangesAsync();

            // Verify that the Prescription has been deleted.
            var deletedPrescription = await _dbContext.Prescriptions.FirstOrDefaultAsync(a => a.PrescriptionID == "P00004");

            // Check if the field has been deleted.
            Assert.IsNull(deletedPrescription);
        }
    }
}
