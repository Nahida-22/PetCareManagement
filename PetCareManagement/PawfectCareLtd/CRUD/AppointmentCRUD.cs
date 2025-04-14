// Import dependencies.
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;  // Import the custom in memory database.
using PawfectCareLtd.Controllers;
using PawfectCareLtd.Models;  // Import the custom in memory database.


namespace PawfectCareLtd.CRUD// Define the namespace for the application.
{

    // Class the encapsulate all of the CRUD operation for the Appointment table.
    public class AppointmentCRUD
    {
        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;



        // Constructor to initialise the class with an instance of the in memory database.
        public AppointmentCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;

        }



        // Method to insert data into the Appointment table.
        public OperationResult InsertOperationForAppointment(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {
            // Get the Appointment table from the in-memory database.
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");

            // Check if the primary key has been provided.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                return new OperationResult { success = false, message = "Primary key must be inputed." };
            }

            // Extract and validate the primary key.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                return new OperationResult { success = false, message = $"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'." };
            }

            // Check for duplicate primary key.
            if (appointmentTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                return new OperationResult { success = false, message = $"A record with primary key '{primaryKeyValue}' already exists." };
            }

            // Validate foreign keys.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    return new OperationResult { success = false, message = $"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'." };
                }
            }

            // Create and populate new record.
            var newRecord = new Record();
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            try
            {
                // Insert into in-memory database.
                appointmentTable.Insert(newRecord, skipDb: true);

                // Insert into SQL database.
                var newAppointment = new Appointment();
                foreach (var field in fieldValues)
                {
                    var property = typeof(Appointment).GetProperty(field.Key);
                    if (property != null)
                        property.SetValue(newAppointment, Convert.ChangeType(field.Value, property.PropertyType));
                }
                _dbContext.Appointments.Add(newAppointment);
                _dbContext.SaveChanges();

                return new OperationResult { success = true, message = "Record inserted successfully into Appointment table." };
            }
            catch (Exception ex)
            {
                return new OperationResult { success = false, message = $"Failed to insert record: {ex.Message}" };
            }
        }



        // Method to read the data from the Appointment table.
        public OperationResult ReadOperationForAppointment(string fieldName, string fieldValue)
        {

            // Get the appointment table form the in memory database.
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");

            // Check if there are any record that matches the search critria.
            var matchingRecords = appointmentTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // Transform the record into a file that can be read into the database.
            var matchingData = matchingRecords.Select(r => r.Fields).ToList();

            // If there are not any matches, tell the user that are not any matches.
            if (matchingRecords.Count == 0)
            {
                return new OperationResult { success = false, message = $"No records found in table '{appointmentTable.Name}' where {fieldName} = '{fieldValue}'." };
                
            }

            // If there are any matches, tell the user what record are.
            return new OperationResult { success = true, message = "Operation was successed", data = matchingData };
        }



        // Method to update data from the Appointment table.
        public OperationResult UpdateOperationForAppointment(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Appointment table from the in memory database.
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");

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
                    return new OperationResult { success = false, message= $"Referenced table '{referencedTableName}' not found in memory." };
                }

                // Check if the foreign key value exists in the referenced table.
                bool exists = referencedTable.GetAll().Any(record => record.Fields.ContainsKey(referencedTable.GetAll().First().Fields.Keys.First()) && record[referencedTable.GetAll().First().Fields.Keys.First()].ToString() == newValue);

                // If new value does not exist in the reference table, exit out of the method to prevent data linking issues.
                if (!exists)
                {
                    return new OperationResult { success = false, message = $"Foreign key value '{newValueToObject}' does not exist in the '{referencedTableName}' table." };
                }
            }
            // Try updating the data into the Appointment table.
            try
            {
                // Update the the Owner with the new data.
                appointmentTable.Update(primaryKeyValue, fieldName, newValueToObject);

                // Save to SQL database.
                var appointmentEntity = _dbContext.Appointments.Find(primaryKeyValue);
                if (appointmentEntity != null)
                {
                    var property = typeof(Appointment).GetProperty(fieldName);
                    if (property != null)
                    {
                        property.SetValue(appointmentEntity, Convert.ChangeType(newValue, property.PropertyType));
                        _dbContext.SaveChanges();
                    }
                }

                return new OperationResult { success = true, message = $"Field '{fieldName}' updated successfully for Appointment with primary key '{primaryKeyValue}'." };
            }
            catch (KeyNotFoundException) // Catch any errors that related to data not being found.
            {
                return new OperationResult { success = false, message = $"No record found with primary key '{primaryKeyValue}' in Appointment table." };
            }
            catch (Exception ex) // Catch any other error.
            {
                return new OperationResult { success = false, message = $"Error updating field: {ex.Message}" };
            }
        }

       

        // Method to delete data from the Appointment table.
        public OperationResult DeleteAppointmentbyId(string appointmentId)
        {
            var appointmentTable = _inMemoryDatabase.GetTable("Appointment");

            // Try delete from memory
            try
            {
                appointmentTable.Delete(appointmentId);
            }
            catch (KeyNotFoundException)
            {
                return new OperationResult { success = false, message = $"Appointment with ID {appointmentId} not found in in-memory database."};
            }

            // Try delete from SQL Server
            var appointmentEntity = _dbContext.Appointments.Find(appointmentId);
            if (appointmentEntity != null)
            {
                _dbContext.Appointments.Remove(appointmentEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Appointment with ID {appointmentId} not found in SQL database.");
            }

            return new OperationResult { success = true, message = $"Appointment with ID {appointmentId} deleted from in-memory database." };
        }



        // Method to get all the appointments record.
        public OperationResult GetAllAppointmentRecord()
        {
            // Get the Appointment table from the inmemory database.
            var table = _inMemoryDatabase.GetTable("Appointment");

            // Get all of the record from Appointment table.
            var allAppointmentRecord = table.GetAll().Select(record => record.Fields).ToList();

            return new OperationResult { success = true, message = "Operation was successed", data = allAppointmentRecord };
        }
    }
}
