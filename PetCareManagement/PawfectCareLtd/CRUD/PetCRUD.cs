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


        // Method to update data from the Pet table.
        public void UpdateOperationForPet(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Pet table from the in memory database.
            var appointmentTable = _inMemoryDatabase.GetTable("Pet");

            // Convert the data type of the new value to object type.
            object newValueToObject = newValue;

            // If the field that is being updated is a foreign key.
            if (isForeignKey)
            {
                // Check if the referenced table exists in the in memory database.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the referenced table does not exist, exit out of the method.
                if (referencedTable == null)
                {
                    Console.WriteLine($"Referenced table '{referencedTableName}' not found in memory.");
                    return;
                }

                // Check if the foreign key value exists in the referenced table.
                bool exists = referencedTable.GetAll().Any(record => record.Fields.ContainsKey(referencedTable.GetAll().First().Fields.Keys.First()) && record[referencedTable.GetAll().First().Fields.Keys.First()].ToString() == newValue);

                // If new value does not exist in the reference table, exit out of the method to prevent data linking issues.
                if (!exists)
                {
                    Console.WriteLine($"Foreign key value '{newValueToObject}' does not exist in the '{referencedTableName}' table.");
                    return;
                }
            }

            // Try updating the data into the Pet table.
            try
            {
                // Update the the Pet with the new data.
                appointmentTable.Update(primaryKeyValue, fieldName, newValueToObject);

                Console.WriteLine($"Field '{fieldName}' updated successfully for Appointment with primary key '{primaryKeyValue}'.");
            }
            catch (KeyNotFoundException) // Catch any errors that related to data not being found.
            {
                Console.WriteLine($"No record found with primary key '{primaryKeyValue}' in Appointment table.");
            }
            catch (Exception ex) // Catch any other error.
            {
                Console.WriteLine($"Error updating field: {ex.Message}");
            }
        }


        // Method to delete date from the Pet table.
        public void DeletePetById(string petId)
        {
            // Get the in memory Pet table.
            var petTable = _inMemoryDatabase.GetTable("Pet");

            // Get the in memory Appointment table.
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");

            // Get the in memory Prescription table.
            var prescriptionTable = _inMemoryDatabase.GetTable("Prescription");

            // Try deleting the data.
            try
            {
                // Try to get the pet from in memory DB
                var petRecord = petTable.Get(petId);

                // Get the related appointments from in-memory database.
                var appointments = appointmentTable.GetAll()
                    .Where(app => app.Fields.ContainsKey("PetID") && app["PetID"]?.ToString() == petId)
                    .ToList();

                // Iterate though each appointment from appointment record to delete them.
                foreach (var appt in appointments)
                {
                    appointmentTable.Delete(appt["AppointmentID"].ToString());
                }

                // Get the related appointments from in-memory database.
                var prescriptions = prescriptionTable.GetAll()
                    .Where(presc => presc.Fields.ContainsKey("PetID") && presc["PetID"]?.ToString() == petId)
                    .ToList();

                // Iterate though each prescriptions from prescriptions record to delete them.
                foreach (var presc in prescriptions)
                {
                    prescriptionTable.Delete(presc["PrescriptionID"].ToString());
                }

                // Delete pet from in memory database.
                petTable.Delete(petId);

                Console.WriteLine($"Pet with ID {petId} and {appointments.Count} appointment(s), {prescriptions.Count} prescription(s) deleted from in-memory database.");

                // Delete from SSMS database. 
                var petEntity = _dbContext.Pets.Find(petId);

                // If the pet table does exist in the database.
                if (petEntity != null)
                {
                    // Update the database to reflect the changes made in the in memory databse.
                    var dbAppointments = _dbContext.Appointments.Where(a => a.PetID == petId).ToList();
                    var dbPrescriptions = _dbContext.Prescriptions.Where(p => p.PetID == petId).ToList();

                    _dbContext.Appointments.RemoveRange(dbAppointments);
                    _dbContext.Prescriptions.RemoveRange(dbPrescriptions);
                    _dbContext.Pets.Remove(petEntity);
                    _dbContext.SaveChanges();

                    // Tell that deletion was a success.
                    Console.WriteLine($"Pet and {dbAppointments.Count} appointment(s), {dbPrescriptions.Count} prescription(s) also deleted from SQL database.");
                }
                else
                {
                    // Tell that owner was not found in the SSMS database.
                    Console.WriteLine($"Pet with ID {petId} not found in SQL database.");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Pet with ID {petId} does not exist in the in-memory database.");  // Throw an error to show the owner ID was not found in the in memory database.
            }
        }

    }
}
