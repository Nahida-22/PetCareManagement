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
    public class DatabaseContextTestsForAppointment
    {
        // Define a field that to hold the in memory database context.
        private DatabaseContext? _dbContext;

        // Ms test method that will run every time before each test.
        [TestInitialize]
        public void SetUp()
        {
            // Create an in memory database options for the DbContext.
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "AppointmentDatabase").Options;

            // Initialise the context with the in memory database.
            _dbContext = new DatabaseContext(options);
        }



        // Test method to create an appointment.
        [TestMethod]
        public async Task TestCreateAppointment()
        {
            // Create a new Appointment object with test data.
            var appointment = new Appointment
            {
                AppointmentID = "A10001",
                PetID = "P001",
                VetID = "V001",
                ServiceType = "Heart Screening",
                ApptDate = DateTime.Now,
                Status = "Scheduled",
                LocationID = "L001"
            };

            // Add the appointment to the database and check if the changes have been made.
            _dbContext!.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            // Verify that the appointment is added to the database.
            var addedAppointment = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.AppointmentID == "A10001");

            // Check that the appointment was successfully added.
            Assert.IsNotNull(addedAppointment); // Appointment should not be null.
            Assert.AreEqual(addedAppointment.ServiceType, "Heart Screening"); // ServiceType should match expected value.
        }



        // Test method to get an appointment by its ID.
        [TestMethod]
        public async Task TestGetAppointmentById()
        {
            // Create a new Appointment object with test data.
            var appointment = new Appointment
            {
                AppointmentID = "A10002",
                PetID = "P002",
                VetID = "V002",
                ServiceType = "Vaccination",
                ApptDate = DateTime.Now,
                Status = "Scheduled",
                LocationID = "L002"
            };

            // Add the appointment to the database and save the changes have been made.
            _dbContext!.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            // Retrieve the appointment by its ID.
            var retrievedAppointment = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.AppointmentID == "A10002");

            // Verify that the appointment was found correctly
            Assert.IsNotNull(retrievedAppointment); // Ensure result is not null.
            Assert.AreEqual(retrievedAppointment.ServiceType, "Vaccination"); // Ensure ServiceType matches expected.
        }



        // Test method to update an appointment field.
        [TestMethod]
        public async Task TestUpdateAppointmentStatus()
        {
            // Create a new Appointment object with test data.
            var appointment = new Appointment
            {
                AppointmentID = "A10003",
                PetID = "P003",
                VetID = "V003",
                ServiceType = "Checkup",
                ApptDate = DateTime.Now,
                Status = "Scheduled",
                LocationID = "L003"
            };

            // Add the appointment to the database and save the changes have been made.
            _dbContext!.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            // Modify the appointment status.
            appointment.Status = "Completed"; // Update status field.
            _dbContext.Appointments.Update(appointment); // Mark appointment as modified.
            await _dbContext.SaveChangesAsync(); // Save changes.

            // Verify that the status has been updated.
            var updatedAppointment = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.AppointmentID == "A10003");

            // Verify that the appointment data was change.
            Assert.IsNotNull(updatedAppointment); // Ensure appointment exists.
            Assert.AreEqual(updatedAppointment.Status, "Completed"); // Verify new status.
        }



        // Test method to delete an appointment field.
        [TestMethod]
        public async Task TestDeleteAppointment()
        {
            // Create a new Appointment object with test data.
            var appointment = new Appointment
            {
                AppointmentID = "A10004",
                PetID = "P004",
                VetID = "V004",
                ServiceType = "Surgery",
                ApptDate = DateTime.Now,
                Status = "Scheduled",
                LocationID = "L004"
            };

            // Add the data to table first to that the table so that the tester have something to delete.
            _dbContext!.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            // Delete the appointment.
            _dbContext.Appointments.Remove(appointment);
            await _dbContext.SaveChangesAsync();

            // Verify that the appointment has been deleted.
            var deletedAppointment = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.AppointmentID == "A10004");

            // Check if the field has been deleted.
            Assert.IsNull(deletedAppointment);
        }
    }
}
