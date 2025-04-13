using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.Services
{
    public class BookAppointmentService
    {
        private readonly DatabaseContext _dbContext;
        private readonly Database _inMemoryDatabase;

        public BookAppointmentService(DatabaseContext dbContext, Database inMemoryDatabase)
        {
            _dbContext = dbContext;
            _inMemoryDatabase = inMemoryDatabase;
        }
        public string BookAppointment(string firstName, string lastName, string petName,
                              DateTime appointmentDate, string location,
                              string serviceType, string vetId)
        {
            var ownerTable = _inMemoryDatabase.GetTable("Owner");
            var petTable = _inMemoryDatabase.GetTable("Pet");
            var vetTable = _inMemoryDatabase.GetTable("Vet");
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");
            var paymentTable = _inMemoryDatabase.GetTable("Payment");

            // 1. Get Owner
            var owner = ownerTable.GetAll().FirstOrDefault(o =>
                o["FirstName"].ToString().Trim().Equals(firstName.Trim(), StringComparison.OrdinalIgnoreCase) &&
                o["LastName"].ToString().Trim().Equals(lastName.Trim(), StringComparison.OrdinalIgnoreCase));

            if (owner == null)
                return $"Owner '{firstName} {lastName}' not found.";

            string ownerId = owner["OwnerID"].ToString();

            // 2. Get Pet
            var pet = petTable.GetAll().FirstOrDefault(p =>
                p["OwnerID"].ToString() == ownerId &&
                p["PetName"].ToString().Trim().Equals(petName.Trim(), StringComparison.OrdinalIgnoreCase));

            if (pet == null)
                return $"Pet '{petName}' not found for owner '{firstName} {lastName}'.";

            string petId = pet["PetID"].ToString();

            // 3. Validate VetID passed by user
            var vet = vetTable.GetAll().FirstOrDefault(v =>
                v["VetID"].ToString().Trim().Equals(vetId.Trim(), StringComparison.OrdinalIgnoreCase));

            if (vet == null)
                return $"Vet with ID '{vetId}' not found.";

            // 4. Create Appointment Record
            string appointmentId = $"A{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
            var appointmentRecord = new Record
            {
                ["AppointmentID"] = appointmentId,
                ["PetID"] = petId,
                ["VetID"] = vetId,
                ["ServiceType"] = serviceType,
                ["ApptDate"] = appointmentDate.ToString("yyyy-MM-dd"),
                ["Status"] = "Scheduled",
                ["LocationID"] = location,
            };

            appointmentTable.Insert(appointmentRecord);
            Console.WriteLine($"Appointment record inserted: AppointmentID = {appointmentId}, PetID = {petId}, VetID = {vetId}, ServiceType = {serviceType}, AppointmentDate = {appointmentDate}");

            // 5. Create Payment Record
            string billId = $"B{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
            var paymentRecord = new Record
            {
                ["BillID"] = billId,
                ["AppointmentID"] = appointmentId,
                ["Total_amt"] = 0.0,
                ["Payment_Date"] = null,
                ["Payment_Status"] = "Pending"
            };

            paymentTable.Insert(paymentRecord);
            Console.WriteLine($"Payment record inserted: BillID = {billId}, AppointmentID = {appointmentId}, Total_amt = 0.0, Payment_Status = Pending");

            return $"Appointment booked with vet '{vet["VetName"]}' for pet '{petName}' on {appointmentDate:yyyy-MM-dd}. Payment status: Pending.";
        }


    }
}
