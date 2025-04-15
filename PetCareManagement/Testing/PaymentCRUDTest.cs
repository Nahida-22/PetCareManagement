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
    public class DatabaseContextTestsForPayment
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "PaymentDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create a Payment.
        [TestMethod]
        public async Task TestCreatePayment()
        {
            // Create a new c object with test data.
            var Payment = new Payment
            {
                BillID = "B90000",
                AppointmentID = "A23301",
                TotalAmount = 347,
                PaymentDate = DateTime.Now,
                PaymentStatus = "Completed"
            };

            // Add the Payment to the database and check if the changes have been made.
            _dbContext!.Payments.Add(Payment);
            await _dbContext.SaveChangesAsync();

            // Verify that the Payment is added to the database.
            var addedPayment = await _dbContext.Payments.FirstOrDefaultAsync(a => a.BillID == "B90000");

            // Check that the Payment was successfully added.
            Assert.IsNotNull(addedPayment); // Payment should not be null.
            Assert.AreEqual(addedPayment.PaymentStatus, "Completed"); // ServiceType should match expected value.
        }



        // Test method to get an Payment by its ID.
        [TestMethod]
        public async Task TestGetPaymentById()
        {
            // Create a new Payment object with test data.
            var Payment = new Payment
            {
                BillID = "B90001",
                AppointmentID = "A23301",
                TotalAmount = 347,
                PaymentDate = DateTime.Now,
                PaymentStatus = "Completed"
            };

            // Add the Payment to the database and save the changes have been made.
            _dbContext!.Payments.Add(Payment);
            await _dbContext.SaveChangesAsync();

            // Retrieve the Payment by its ID.
            var retrievedPayment = await _dbContext.Payments.FirstOrDefaultAsync(a => a.BillID == "B90001");

            // Verify that the Payment was found correctly
            Assert.IsNotNull(retrievedPayment); // Ensure result is not null.
            Assert.AreEqual(retrievedPayment.PaymentStatus, "Completed"); // Ensure ServiceType matches expected.
        }



        // Test method to update an Payment field.
        [TestMethod]
        public async Task TestUpdatePaymentstatus()
        {
            // Create a new Payment object with test data.
            var Payment = new Payment
            {
                BillID = "B90002",
                AppointmentID = "A23301",
                TotalAmount = 347,
                PaymentDate = DateTime.Now,
                PaymentStatus = "Completed"
            };

            // Add the Payment to the database and save the changes have been made.
            _dbContext!.Payments.Add(Payment);
            await _dbContext.SaveChangesAsync();

            // Modify the Payment status.
            Payment.PaymentStatus = "Pending"; // Update stock quantity field.
            _dbContext.Payments.Update(Payment); // Mark Payment as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedPayment = await _dbContext.Payments.FirstOrDefaultAsync(a => a.BillID == "B90002");

            // Verify that the Payment data was change.
            Assert.IsNotNull(updatedPayment); // Ensure Payment exists.
            Assert.AreEqual(updatedPayment.PaymentStatus, "Pending"); // Verify new stock quantity.
        }



        // Test method to delete an Payment field.
        [TestMethod]
        public async Task TestDeletePayment()
        {
            // Create a new Payment object with test data.
            var Payment = new Payment
            {
                BillID = "B90003",
                AppointmentID = "A23301",
                TotalAmount = 347,
                PaymentDate = DateTime.Now,
                PaymentStatus = "Completed"
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Payments.Add(Payment);
            await _dbContext.SaveChangesAsync();

            // Delete the Payment.
            _dbContext.Payments.Remove(Payment);
            await _dbContext.SaveChangesAsync();

            // Verify that the Payment has been deleted.
            var deletedPayment = await _dbContext.Payments.FirstOrDefaultAsync(a => a.BillID == "B90003");

            // Check if the field has been deleted.
            Assert.IsNull(deletedPayment);
        }
    }
}
