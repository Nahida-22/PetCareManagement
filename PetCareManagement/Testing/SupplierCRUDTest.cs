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
    public class DatabaseContextTestsForSupplier
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "SupplierDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a Supplier.
        [TestMethod]
        public async Task TestCreateSupplier()
        {
            // Create a new Supplier object with test data.
            var Supplier = new Supplier
            {
                SupplierID = "S10001",
                SupplierName = "Joe",
                PhoneNumber = "555555",
                Address = "Maison",
                Email = "Joe@supplier.com"
            };

            // Add the Supplier to the database and check if the changes have been made.
            _dbContext!.Suppliers.Add(Supplier);
            await _dbContext.SaveChangesAsync();

            // Verify that the Supplier is added to the database.
            var addedSupplier = await _dbContext.Suppliers.FirstOrDefaultAsync(a => a.SupplierID == "S10001");

            // Check that the Supplier was successfully added.
            Assert.IsNotNull(addedSupplier); // Supplier should not be null.
            Assert.AreEqual(addedSupplier.Address, "Maison"); // ServiceType should match expected value.
        }



        // Test method to get an Supplier by its ID.
        [TestMethod]
        public async Task TestGetSupplierById()
        {
            // Create a new Supplier object with test data.
            var Supplier = new Supplier
            {
                SupplierID = "S10002",
                SupplierName = "Joe",
                PhoneNumber = "555555",
                Address = "Maison",
                Email = "Joe@supplier.com"
            };

            // Add the Supplier to the database and save the changes have been made.
            _dbContext!.Suppliers.Add(Supplier);
            await _dbContext.SaveChangesAsync();

            // Retrieve the Supplier by its ID.
            var retrievedSupplier = await _dbContext.Suppliers.FirstOrDefaultAsync(a => a.SupplierID == "S10002");

            // Verify that the Supplier was found correctly
            Assert.IsNotNull(retrievedSupplier); // Ensure result is not null.
            Assert.AreEqual(retrievedSupplier.Address, "Maison"); // Ensure ServiceType matches expected.
        }



        // Test method to update an Supplier field.
        [TestMethod]
        public async Task TestUpdateSupplierstatus()
        {
            // Create a new Supplier object with test data.
            var Supplier = new Supplier
            {
                SupplierID = "S10003",
                SupplierName = "Joe",
                PhoneNumber = "555555",
                Address = "Maison",
                Email = "Joe@supplier.com"
            };

            // Add the Supplier to the database and save the changes have been made.
            _dbContext!.Suppliers.Add(Supplier);
            await _dbContext.SaveChangesAsync();

            // Modify the Supplier status.
            Supplier.Address = "Home"; // Update stock quantity field.
            _dbContext.Suppliers.Update(Supplier); // Mark Supplier as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedSupplier = await _dbContext.Suppliers.FirstOrDefaultAsync(a => a.SupplierID == "S10003");

            // Verify that the Supplier data was change.
            Assert.IsNotNull(updatedSupplier); // Ensure Supplier exists.
            Assert.AreEqual(updatedSupplier.Address, "Home"); // Verify new stock quantity.
        }



        // Test method to delete an Supplier field.
        [TestMethod]
        public async Task TestDeleteSupplier()
        {
            // Create a new Supplier object with test data.
            var Supplier = new Supplier
            {
                SupplierID = "S10006",
                SupplierName = "Joe",
                PhoneNumber = "555555",
                Address = "Maison",
                Email = "Joe@supplier.com"
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Suppliers.Add(Supplier);
            await _dbContext.SaveChangesAsync();

            // Delete the Supplier.
            _dbContext.Suppliers.Remove(Supplier);
            await _dbContext.SaveChangesAsync();

            // Verify that the Supplier has been deleted.
            var deletedSupplier = await _dbContext.Suppliers.FirstOrDefaultAsync(a => a.SupplierID == "S10006");

            // Check if the field has been deleted.
            Assert.IsNull(deletedSupplier);
        }
    }
}
