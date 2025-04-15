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
    public class DatabaseContextTestsForOrder
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "OrderDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a order.
        [TestMethod]
        public async Task TestCreateOrder()
        {
            // Create a new Order object with test data.
            var order = new Order
            {
                OrderID = "O10000",
                MedicationID = "M90000",
                Quantity = 74,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending"
            };

            // Add the order to the database and check if the changes have been made.
            _dbContext!.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            // Verify that the Owner is added to the database.
            var addedOrder = await _dbContext.Orders.FirstOrDefaultAsync(a => a.OrderID == "O10000");

            // Check that the order was successfully added.
            Assert.IsNotNull(addedOrder); // order should not be null.
            Assert.AreEqual(addedOrder.Quantity, 74); // ServiceType should match expected value.
        }



        // Test method to get an order by its ID.
        [TestMethod]
        public async Task TestGetOrderById()
        {
            // Create a new Order object with test data.
            var order = new Order
            {
                OrderID = "O10003",
                MedicationID = "M90000",
                Quantity = 74,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending"
            };

            // Add the Order to the database and save the changes have been made.
            _dbContext!.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            // Retrieve the order by its ID.
            var retrievedOrder = await _dbContext.Orders.FirstOrDefaultAsync(a => a.OrderID == "O10003");

            // Verify that the order was found correctly
            Assert.IsNotNull(retrievedOrder); // Ensure result is not null.
            Assert.AreEqual(retrievedOrder.Quantity, 74); // Ensure ServiceType matches expected.
        }



        // Test method to update an Order field.
        [TestMethod]
        public async Task TestUpdateOrdertatus()
        {
            // Create a new Order object with test data.
            var order = new Order
            {
                OrderID = "O10001",
                MedicationID = "M90000",
                Quantity = 74,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending"
            };

            // Add the order to the database and save the changes have been made.
            _dbContext!.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            // Modify the order status.
            order.Quantity = 200; // Update stock quantity field.
            _dbContext.Orders.Update(order); // Mark order as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedOrder = await _dbContext.Orders.FirstOrDefaultAsync(a => a.OrderID == "O10001");

            // Verify that the order data was change.
            Assert.IsNotNull(updatedOrder); // Ensure Order exists.
            Assert.AreEqual(updatedOrder.Quantity, 200); // Verify new stock quantity.
        }



        // Test method to delete an order field.
        [TestMethod]
        public async Task TestDeleteOrder()
        {
            // Create a new Order object with test data.
            var order = new Order
            {
                OrderID = "O10002",
                MedicationID = "M90000",
                Quantity = 74,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending"
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            // Delete the Order.
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();

            // Verify that the Order has been deleted.
            var deletedOrder = await _dbContext.Orders.FirstOrDefaultAsync(a => a.OrderID == "O10002");

            // Check if the field has been deleted.
            Assert.IsNull(deletedOrder);
        }
    }
}
