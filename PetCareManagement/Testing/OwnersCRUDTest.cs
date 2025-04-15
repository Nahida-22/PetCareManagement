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
    public class DatabaseContextTestsForOwner
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "OwnerDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a Owner.
        [TestMethod]
        public async Task TestCreateOwner()
        {
            // Create a new Owner object with test data.
            var owner = new Owner
            {
                OwnerID = "O10000",
                FirstName = "Joe",
                LastName = "Mama",
                PhoneNo = "5555555",
                Email = "Joemama@gmail.com",
                Address = "Lakaz"
            };

            // Add the Owner to the database and check if the changes have been made.
            _dbContext!.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();

            // Verify that the Owner is added to the database.
            var addedOwner = await _dbContext.Owners.FirstOrDefaultAsync(a => a.OwnerID == "O10000");

            // Check that the Owner was successfully added.
            Assert.IsNotNull(addedOwner); // Owner should not be null.
            Assert.AreEqual(addedOwner.Email, "Joemama@gmail.com"); // ServiceType should match expected value.
        }



        // Test method to get an Owner by its ID.
        [TestMethod]
        public async Task TestGetOwnerById()
        {
            // Create a new Owner object with test data.
            var owner = new Owner
            {
                OwnerID = "O10001",
                FirstName = "Joe",
                LastName = "Mama",
                PhoneNo = "5555555",
                Email = "Joemama@gmail.com",
                Address = "Lakaz"
            };

            // Add the Owner to the database and save the changes have been made.
            _dbContext!.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();

            // Retrieve the Owner by its ID.
            var retrievedOwner = await _dbContext.Owners.FirstOrDefaultAsync(a => a.OwnerID == "O10001");

            // Verify that the Owner was found correctly
            Assert.IsNotNull(retrievedOwner); // Ensure result is not null.
            Assert.AreEqual(retrievedOwner.Email, "Joemama@gmail.com"); // Ensure ServiceType matches expected.
        }



        // Test method to update an Owner field.
        [TestMethod]
        public async Task TestUpdateOwnerstatus()
        {
            // Create a new Owner object with test data.
            var owner = new Owner
            {
                OwnerID = "O10002",
                FirstName = "Joe",
                LastName = "Mama",
                PhoneNo = "5555555",
                Email = "Joemama@gmail.com",
                Address = "Lakaz"
            };

            // Add the Owner to the database and save the changes have been made.
            _dbContext!.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();

            // Modify the Owner status.
            owner.Address = "Home"; // Update stock quantity field.
            _dbContext.Owners.Update(owner); // Mark owner as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedOwner = await _dbContext.Owners.FirstOrDefaultAsync(a => a.OwnerID == "O10002");

            // Verify that the Owner data was change.
            Assert.IsNotNull(updatedOwner); // Ensure Owner exists.
            Assert.AreEqual(updatedOwner.Address, "Home"); // Verify new stock quantity.
        }



        // Test method to delete an Owner field.
        [TestMethod]
        public async Task TestDeleteOwner()
        {
            // Create a new Owner object with test data.
            var owner = new Owner
            {
                OwnerID = "O10003",
                FirstName = "Joe",
                LastName = "Mama",
                PhoneNo = "5555555",
                Email = "Joemama@gmail.com",
                Address = "Lakaz"
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();

            // Delete the Owner.
            _dbContext.Owners.Remove(owner);
            await _dbContext.SaveChangesAsync();

            // Verify that the Owner has been deleted.
            var deletedOwner = await _dbContext.Owners.FirstOrDefaultAsync(a => a.OwnerID == "O10003");

            // Check if the field has been deleted.
            Assert.IsNull(deletedOwner);
        }
    }
}
