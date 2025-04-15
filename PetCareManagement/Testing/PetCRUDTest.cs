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
    public class DatabaseContextTestsForPet
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "PetDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a Pet.
        [TestMethod]
        public async Task TestCreatePet()
        {
            // Create a new pet object with test data.
            var Pet = new Pet
            {
                PetID = "P00001",
                OwnerID = "O00001",
                PetName = "GAE",
                Breed = "Cane Corso",
                PetType = "Dog",
                Age = "8"
            };

            // Add the Pet to the database and check if the changes have been made.
            _dbContext!.Pets.Add(Pet);
            await _dbContext.SaveChangesAsync();

            // Verify that the Pet is added to the database.
            var addedPet = await _dbContext.Pets.FirstOrDefaultAsync(a => a.PetID == "P00001");

            // Check that the Pet was successfully added.
            Assert.IsNotNull(addedPet); // Pet should not be null.
            Assert.AreEqual(addedPet.PetType, "Dog"); // ServiceType should match expected value.
        }



        // Test method to get an Pet by its ID.
        [TestMethod]
        public async Task TestGetPetById()
        {
            // Create a new pet object with test data.
            var Pet = new Pet
            {
                PetID = "P00002",
                OwnerID = "O00001",
                PetName = "GAE",
                Breed = "Cane Corso",
                PetType = "Dog",
                Age = "8"
            };

            // Add the Pet to the database and save the changes have been made.
            _dbContext!.Pets.Add(Pet);
            await _dbContext.SaveChangesAsync();

            // Retrieve the Pet by its ID.
            var retrievedPet = await _dbContext.Pets.FirstOrDefaultAsync(a => a.PetID == "P00002");

            // Verify that the Pet was found correctly
            Assert.IsNotNull(retrievedPet); // Ensure result is not null.
            Assert.AreEqual(retrievedPet.PetType, "Dog"); // Ensure ServiceType matches expected.
        }



        // Test method to update an Pet field.
        [TestMethod]
        public async Task TestUpdatePetstatus()
        {
            // Create a new pet object with test data.
            var Pet = new Pet
            {
                PetID = "P00003",
                OwnerID = "O00001",
                PetName = "GAE",
                Breed = "Cane Corso",
                PetType = "Dog",
                Age = "8"
            };

            // Add the Pet to the database and save the changes have been made.
            _dbContext!.Pets.Add(Pet);
            await _dbContext.SaveChangesAsync();

            // Modify the Pet status.
            Pet.Age = "9"; // Update stock quantity field.
            _dbContext.Pets.Update(Pet); // Mark Pet as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedPet = await _dbContext.Pets.FirstOrDefaultAsync(a => a.PetID == "P00003");

            // Verify that the Pet data was change.
            Assert.IsNotNull(updatedPet); // Ensure Pet exists.
            Assert.AreEqual(updatedPet.Age, "9"); // Verify new stock quantity.
        }



        // Test method to delete an Pet field.
        [TestMethod]
        public async Task TestDeletePet()
        {
            // Create a new pet object with test data.
            var Pet = new Pet
            {
                PetID = "P00004",
                OwnerID = "O00001",
                PetName = "GAE",
                Breed = "Cane Corso",
                PetType = "Dog",
                Age = "8"
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Pets.Add(Pet);
            await _dbContext.SaveChangesAsync();

            // Delete the Pet.
            _dbContext.Pets.Remove(Pet);
            await _dbContext.SaveChangesAsync();

            // Verify that the Pet has been deleted.
            var deletedPet = await _dbContext.Pets.FirstOrDefaultAsync(a => a.PetID == "P00004");

            // Check if the field has been deleted.
            Assert.IsNull(deletedPet);
        }
    }
}