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
    public class DatabaseContextTestsForVet
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "VetDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a Vet.
        [TestMethod]
        public async Task TestCreateVet()
        {
            // Create a new Vet object with test data.
            var Vet = new Vet
            {
                VetID = "V9000",
                VetName = "Brigitte Ernser",
                Specialisation = "Cardiology",
                PhoneNo = "59194183",
                Email = "brigitteernser24@gmail.com",
                Address = "30711 Rogahn Tunnel, Lake Edatown"
            };

            // Add the Vet to the database and check if the changes have been made.
            _dbContext!.Vet.Add(Vet);
            await _dbContext.SaveChangesAsync();

            // Verify that the Vet is added to the database.
            var addedVet = await _dbContext.Vet.FirstOrDefaultAsync(a => a.VetID == "V9000");

            // Check that the Vet was successfully added.
            Assert.IsNotNull(addedVet); // Vet should not be null.
            Assert.AreEqual(addedVet.VetID, "V9000"); // ServiceType should match expected value.
        }



        // Test method to get an Vet by its ID.
        [TestMethod]
        public async Task TestGetVetById()
        {
            // Create a new Vet object with test data.
            var Vet = new Vet
            {
                VetID = "V9001",
                VetName = "Brigitte Ernser",
                Specialisation = "Cardiology",
                PhoneNo = "59194183",
                Email = "brigitteernser24@gmail.com",
                Address = "30711 Rogahn Tunnel, Lake Edatown"
            };

            // Add the Vet to the database and save the changes have been made.
            _dbContext!.Vet.Add(Vet);
            await _dbContext.SaveChangesAsync();

            // Retrieve the Vet by its ID.
            var retrievedVet = await _dbContext.Vet.FirstOrDefaultAsync(a => a.VetID == "V9001");

            // Verify that the Vet was found correctly
            Assert.IsNotNull(retrievedVet); // Ensure result is not null.
            Assert.AreEqual(retrievedVet.VetName, "Brigitte Ernser"); // Ensure ServiceType matches expected.
        }



        // Test method to update an Vet field.
        [TestMethod]
        public async Task TestUpdateVetstatus()
        {
            // Create a new Vet object with test data.
            var Vet = new Vet
            {
                VetID = "V9002",
                VetName = "Brigitte Ernser",
                Specialisation = "Cardiology",
                PhoneNo = "59194183",
                Email = "brigitteernser24@gmail.com",
                Address = "30711 Rogahn Tunnel, Lake Edatown"
            };

            // Add the Vet to the database and save the changes have been made.
            _dbContext!.Vet.Add(Vet);
            await _dbContext.SaveChangesAsync();

            // Modify the Vet status.
            Vet.Email = "brigitteernser@gmail.com"; // Update stock quantity field.
            _dbContext.Vet.Update(Vet); // Mark Vet as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedVet = await _dbContext.Vet.FirstOrDefaultAsync(a => a.VetID == "V9002");

            // Verify that the Vet data was change.
            Assert.IsNotNull(updatedVet); // Ensure Vet exists.
            Assert.AreEqual(updatedVet.Email, "brigitteernser@gmail.com"); // Verify new stock quantity.
        }



        // Test method to delete an Vet field.
        [TestMethod]
        public async Task TestDeleteVet()
        {
            // Create a new Vet object with test data.
            var Vet = new Vet
            {
                VetID = "V9003",
                VetName = "Brigitte Ernser",
                Specialisation = "Cardiology",
                PhoneNo = "59194183",
                Email = "brigitteernser24@gmail.com",
                Address = "30711 Rogahn Tunnel, Lake Edatown"
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Vet.Add(Vet);
            await _dbContext.SaveChangesAsync();

            // Delete the Vet.
            _dbContext.Vet.Remove(Vet);
            await _dbContext.SaveChangesAsync();

            // Verify that the Vet has been deleted.
            var deletedVet = await _dbContext.Vet.FirstOrDefaultAsync(a => a.VetID == "V9003");

            // Check if the field has been deleted.
            Assert.IsNull(deletedVet);
        }
    }
}
