// Import dependencies.
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.


namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{

    // Class the encapsulate all of the CRUD operation for the Pet table.
    public class PetCRUD
    {
        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;


        // Constructor to initialise the class with an instance of the in memory database.
        public PetCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext= dbContext;

        }


        // Method to read the data from the Pet table.
        public void ReadOperationForPet(string fieldName, string fieldValue)
        {

            // Get the Pet table form the in memory database.
            var petTable = _inMemoryDatabase.GetTable("Pet");

            // Check if there are any record that matches the search critria.
            var matchingRecords = petTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // If there are not any matches, tell the user that are not any matches.
            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{petTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

            // If there are any matches, tell the user what record are.
            Console.WriteLine($"Found {matchingRecords.Count} record(s) in table '{petTable.Name}' where {fieldName} = '{fieldValue}':");
            foreach (var record in matchingRecords)
            {
                Console.WriteLine("----- Record -----");
                foreach (var field in record.Fields)
                {
                    Console.WriteLine($"{field.Key}: {field.Value}");
                }
                Console.WriteLine("------------------\n");
            }
        }
        public void DeletePetById(string petId)
        {
            var petTable = _inMemoryDatabase.GetTable("Pet");
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            try
            {
                // Try to get the pet from in-memory DB
                var petRecord = petTable.Get(petId);

                // --- Delete related appointments and prescriptions from in-memory database ---
                var appointments = appointmentTable.GetAll()
                    .Where(app => app.Fields.ContainsKey("PetID") && app["PetID"]?.ToString() == petId)
                    .ToList();

                foreach (var appt in appointments)
                {
                    appointmentTable.Delete(appt["AppointmentID"].ToString());
                }

                var prescriptions = prescriptionTable.GetAll()
                    .Where(presc => presc.Fields.ContainsKey("PetID") && presc["PetID"]?.ToString() == petId)
                    .ToList();

                foreach (var presc in prescriptions)
                {
                    prescriptionTable.Delete(presc["PrescriptionID"].ToString());
                }

                // --- Delete pet from in-memory database ---
                petTable.Delete(petId);

                Console.WriteLine($"Pet with ID {petId} and {appointments.Count} appointment(s), {prescriptions.Count} prescription(s) deleted from in-memory database.");

                // --- Delete from EF Core SQL database ---
                var petEntity = _dbContext.Pets.Find(petId);
                if (petEntity != null)
                {
                    var dbAppointments = _dbContext.Appointments.Where(a => a.PetID == petId).ToList();
                    var dbPrescriptions = _dbContext.Prescriptions.Where(p => p.PetID == petId).ToList();

                    _dbContext.Appointments.RemoveRange(dbAppointments);
                    _dbContext.Prescriptions.RemoveRange(dbPrescriptions);
                    _dbContext.Pets.Remove(petEntity);

                    _dbContext.SaveChanges();

                    Console.WriteLine($"Pet and {dbAppointments.Count} appointment(s), {dbPrescriptions.Count} prescription(s) also deleted from SQL database.");
                }
                else
                {
                    Console.WriteLine($"Pet with ID {petId} not found in SQL database.");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Pet with ID {petId} does not exist in the in-memory database.");
            }
        }

        public List<object> FindPetByField(string fieldName, string fieldValue)
        {
            var petTable = _inMemoryDatabase.GetTable("Owner");

            var matchingRecords = petTable.GetAll()
                .Where(record => record.Fields.ContainsKey(fieldName) &&
                                 record[fieldName]?.ToString() == fieldValue)
                .Select(record => record.Fields.ToDictionary(f => f.Key, f => f.Value))
                .Cast<object>()
                .ToList();

            return matchingRecords;
        }

        // Method to delete a pet record.
        public (bool Success, string Message, int AppointmentCount, int PrescriptionCount) DeletePetById2(string petId)
        {
            var petTable = _inMemoryDatabase.GetTable("Pet");
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            try
            {
                var petRecord = petTable.Get(petId);

                // In-memory deletions
                var appointments = appointmentTable.GetAll()
                    .Where(app => app.Fields.ContainsKey("PetID") && app["PetID"]?.ToString() == petId)
                    .ToList();

                foreach (var appt in appointments)
                    appointmentTable.Delete(appt["AppointmentID"].ToString());

                var prescriptions = prescriptionTable.GetAll()
                    .Where(presc => presc.Fields.ContainsKey("PetID") && presc["PetID"]?.ToString() == petId)
                    .ToList();

                foreach (var presc in prescriptions)
                    prescriptionTable.Delete(presc["PrescriptionID"].ToString());

                petTable.Delete(petId);

                // SQL deletions
                var petEntity = _dbContext.Pets.Find(petId);
                if (petEntity != null)
                {
                    var dbAppointments = _dbContext.Appointments.Where(a => a.PetID == petId).ToList();
                    var dbPrescriptions = _dbContext.Prescriptions.Where(p => p.PetID == petId).ToList();

                    _dbContext.Appointments.RemoveRange(dbAppointments);
                    _dbContext.Prescriptions.RemoveRange(dbPrescriptions);
                    _dbContext.Pets.Remove(petEntity);
                    _dbContext.SaveChanges();

                    return (true, $"Pet and related records deleted from both in-memory and SQL.", dbAppointments.Count, dbPrescriptions.Count);
                }

                return (true, $"Pet deleted from in-memory. Not found in SQL DB.", appointments.Count, prescriptions.Count);
            }
            catch (KeyNotFoundException)
            {
                return (false, $"Pet with ID {petId} not found in in-memory database.", 0, 0);
            }
        }

    }
}
