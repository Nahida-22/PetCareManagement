using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PawfectCareLtd.Tests
{
    [TestClass]
    public class DatabaseContextTests
    {
        private DatabaseContext _dbContext;

        // This method will set up the in-memory database for testing
        [TestInitialize]
        public void SetUp()
        {
            // Create options for InMemoryDatabase
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")  // Specify a unique in-memory database name
                .Options;

            // Initialize the context with the in-memory database
            _dbContext = new DatabaseContext(options);
        }

        // Test: Create an Appointment and verify it is added
        [TestMethod]
        public async Task TestCreateAppointment()
        {
            // Arrange
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

            // Act: Add the appointment to the database
            _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            // Assert: Verify that the appointment is added to the database
            var addedAppointment = await _dbContext.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentID == "A10001");

            Assert.IsNotNull(addedAppointment);
            Assert.AreEqual(addedAppointment.ServiceType, "Heart Screening");
        }

        // Test: Retrieve an Appointment by ID
        [TestMethod]
        public async Task TestGetAppointmentById()
        {
            // Arrange
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
            _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            // Act: Retrieve the appointment by ID
            var retrievedAppointment = await _dbContext.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentID == "A10002");

            // Assert: Verify that the appointment was retrieved correctly
            Assert.IsNotNull(retrievedAppointment);
            Assert.AreEqual(retrievedAppointment.ServiceType, "Vaccination");
        }

        // Test: Update an Appointment's status
        [TestMethod]
        public async Task TestUpdateAppointmentStatus()
        {
            // Arrange: Add a test appointment
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
            _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            // Act: Update the status of the appointment
            appointment.Status = "Completed";
            _dbContext.Appointments.Update(appointment);
            await _dbContext.SaveChangesAsync();

            // Assert: Verify that the status has been updated
            var updatedAppointment = await _dbContext.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentID == "A10003");
            Assert.IsNotNull(updatedAppointment);
            Assert.AreEqual(updatedAppointment.Status, "Completed");
        }

        // Test: Delete an Appointment
        [TestMethod]
        public async Task TestDeleteAppointment()
        {
            // Arrange: Add a test appointment
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
            _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            // Act: Delete the appointment
            _dbContext.Appointments.Remove(appointment);
            await _dbContext.SaveChangesAsync();

            // Assert: Verify that the appointment has been deleted
            var deletedAppointment = await _dbContext.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentID == "A10004");
            Assert.IsNull(deletedAppointment);
        }

        // Cleanup after each test
        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Dispose();
        }
    }
}
