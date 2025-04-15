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
    public class DatabaseContextTestsForLocation
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "LocationDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a location.
        [TestMethod]
        public async Task TestCreateLocation()
        {
            // Create a new Location object with test data.
            var location = new Location
            {
                LocationID = "L003",
                Name = "Pawfect Care Ltd",
                Address = "Downtown City",
                Phone = "555-1234",
                Email = "downtown@petcare.com"
            };

            // Add the location to the database and check if the changes have been made.
            _dbContext!.Locations.Add(location);
            await _dbContext.SaveChangesAsync();

            // Verify that the location is added to the database.
            var addedLocation = await _dbContext.Locations.FirstOrDefaultAsync(a => a.LocationID == "L003");

            // Check that the location was successfully added.
            Assert.IsNotNull(addedLocation); // location should not be null.
            Assert.AreEqual(addedLocation.Email, "downtown@petcare.com"); // ServiceType should match expected value.
        }



        // Test method to get an location by its ID.
        [TestMethod]
        public async Task TestGetLocationById()
        {
            // Create a new location object with test data.
            var location = new Location
            {
                LocationID = "L004",
                Name = "Pawfect Care Ltd",
                Address = "Downtown City",
                Phone = "555-1234",
                Email = "downtown@petcare.com"
            };

            // Add the location to the database and save the changes have been made.
            _dbContext!.Locations.Add(location);
            await _dbContext.SaveChangesAsync();

            // Retrieve the location by its ID.
            var retrievedLocation = await _dbContext.Locations.FirstOrDefaultAsync(a => a.LocationID == "L004");

            // Verify that the location was found correctly
            Assert.IsNotNull(retrievedLocation); // Ensure result is not null.
            Assert.AreEqual(retrievedLocation.Email, "downtown@petcare.com"); // Ensure ServiceType matches expected.
        }



        // Test method to update an location field.
        [TestMethod]
        public async Task TestUpdateLocationStatus()
        {
            // Create a new Location object with test data.
            var location = new Location
            {
                LocationID = "L005",
                Name = "Pawfect Care Ltd",
                Address = "Downtown City",
                Phone = "555-1234",
                Email = "downtown@petcare.com"
            };

            // Add the location to the database and save the changes have been made.
            _dbContext!.Locations.Add(location);
            await _dbContext.SaveChangesAsync();

            // Modify the location status.
            location.Address = "Uptown City"; // Update status field.
            _dbContext.Locations.Update(location); // Mark location as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedLocation = await _dbContext.Locations.FirstOrDefaultAsync(a => a.LocationID == "L005");

            // Verify that the location data was change.
            Assert.IsNotNull(updatedLocation); // Ensure location exists.
            Assert.AreEqual(updatedLocation.Address, "Uptown City"); // Verify new status.
        }



        // Test method to delete an location field.
        [TestMethod]
        public async Task TestDeleteLocation()
        {
            // Create a new Location object with test data.
            var location = new Location
            {
                LocationID = "L006",
                Name = "Pawfect Care Ltd",
                Address = "Downtown City",
                Phone = "555-1234",
                Email = "downtown@petcare.com"
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Locations.Add(location);
            await _dbContext.SaveChangesAsync();

            // Delete the location.
            _dbContext.Locations.Remove(location);
            await _dbContext.SaveChangesAsync();

            // Verify that the location has been deleted.
            var deletedLocation = await _dbContext.Locations.FirstOrDefaultAsync(a => a.LocationID == "L006");

            // Check if the field has been deleted.
            Assert.IsNull(deletedLocation);
        }
    }
}
