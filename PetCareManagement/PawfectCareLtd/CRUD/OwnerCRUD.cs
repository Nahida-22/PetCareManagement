// Import dependencies.
using System;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.


namespace PawfectCareLtd.CRUD // Define the namespace for the application.
{

    // Class the encapsulate all of the CRUD operation for the Owner table.
    public class OwnerCRUD
    {

        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;
        private readonly DatabaseContext _dbContext;


        // Constructor to initialise the class with an instance of the in memory database.
        public OwnerCRUD(Database inMemoryDatabase, DatabaseContext dbContext)
        {
            _inMemoryDatabase = inMemoryDatabase;
            _dbContext = dbContext;
        }


        // Method to insert data into the Owner table.
        public void InsertOperationForOwner(Dictionary<string, object> fieldValues, string primaryKeyName, string primaryKeyFormat, List<(string ForeignKeyField, string ReferencedTableName)> foreignKeys)
        {

            // Get the Owner table from the in memory database.
            var ownerTable = _inMemoryDatabase.GetTable("Owner");

            // Check if the primary key has been added into the input dictionary.
            if (!fieldValues.ContainsKey(primaryKeyName))
            {
                Console.WriteLine("Primary key field is missing.");
                return;
            }

            // Get the primary key for the record being inserted then convert it to string.
            string primaryKeyValue = fieldValues[primaryKeyName]?.ToString();

            // Check if primary for the the record being inserted is non empty and is in the required format.
            if (string.IsNullOrWhiteSpace(primaryKeyValue) || !System.Text.RegularExpressions.Regex.IsMatch(primaryKeyValue, primaryKeyFormat))
            {
                Console.WriteLine($"Primary key '{primaryKeyValue}' does not match required format '{primaryKeyFormat}'.");
                return;
            }

            // Check if the primary key for the new already exist in the the Owner table, If yes exist out of the function.
            if (ownerTable.GetAll().Any(record => record[primaryKeyName]?.ToString() == primaryKeyValue))
            {
                Console.WriteLine($"A record with primary key '{primaryKeyValue}' already exists.");
                return;
            }

            // Iterate through each foreignkey that need to valides.
            foreach (var (foreignKeyField, referencedTableName) in foreignKeys)
            {
                // If the foreign key field is not into the input dictionary, skip it.
                if (!fieldValues.ContainsKey(foreignKeyField)) continue;

                // Get the foreign key from the inputed list.
                string foreignKeyValue = fieldValues[foreignKeyField]?.ToString();

                // Get the referenced table which contain the foreign key as the primary key.
                var referencedTable = _inMemoryDatabase.GetTable(referencedTableName);

                // Check if the foreign key exist in the referenced table, if not exist out of the function.
                if (!referencedTable.GetAll().Any(record => record.Fields.Values.Contains(foreignKeyValue)))
                {
                    Console.WriteLine($"Foreign key value '{foreignKeyValue}' not found in table '{referencedTableName}'.");
                    return;
                }
            }

            // Create a new record.
            var newRecord = new Record();

            // Add each field form the inputed dictionary into the record.
            foreach (var field in fieldValues)
            {
                newRecord[field.Key] = field.Value;
            }

            // Try inserting the new record into the Owner table.
            try
            {
                // Insert the data into the in memory database.
                ownerTable.Insert(newRecord, skipDb: true);
                Console.WriteLine("Record inserted successfully into Location table.");
            }
            catch (Exception ex) // Catch any errors.
            {
                Console.WriteLine($"Failed to insert record: {ex.Message}");
            }
        }


        // Method to read the data from the Owner table.
        public void ReadOperationForOwner(string fieldName, string fieldValue)
        {

            // Get the Owner table form the in memory database.
            var ownerTable = _inMemoryDatabase.GetTable("Owner");

            // Check if there are any record that matches the search critria.
            var matchingRecords = ownerTable.GetAll().Where(record => record.Fields.ContainsKey(fieldName) && record[fieldName]?.ToString() == fieldValue).ToList();

            // If there are not any matches, tell the user that are not any matches.
            if (matchingRecords.Count == 0)
            {
                Console.WriteLine($"No records found in table '{ownerTable.Name}' where {fieldName} = '{fieldValue}'.");
                return;
            }

            // If there are any matches, tell the user what record are.
            Console.WriteLine($"Found {matchingRecords.Count} record(s) in table '{ownerTable.Name}' where {fieldName} = '{fieldValue}':");
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


        // Method to update data from the Owner table.
        public void UpdateOperationForOwner(string primaryKeyValue, string fieldName, string newValue, bool isForeignKey = false, string referencedTableName = null)
        {
            // Get the Owner table from the in memory database.
            var ownerTable = _inMemoryDatabase.GetTable("Owner");

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

            // Try updating the data into the Owner table.
            try
            {
                // Update the the Owner with the new data.
                ownerTable.Update(primaryKeyValue, fieldName, newValueToObject);

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


        // Method to delete date from the Owner table.
        public void DeleteOwnerById(string ownerId)
        {

            // Get the in memory Owner table.
            var ownerTable = _inMemoryDatabase.GetTable("Owner");

            // Get the in memory Pet table.
            var petTable = _inMemoryDatabase.GetTable("Pet");

            // Try deleting the data.
            try
            {
                // Get the owner record by its id.
                var ownerRecord = ownerTable.Get(ownerId);

                // Delete pets from in memory database.
                var petRecords = petTable.GetAll()
                                         .Where(pet => pet.Fields.ContainsKey("OwnerID") && pet["OwnerID"]?.ToString() == ownerId)
                                         .ToList();

                // Iterate though each pet from pet record to delete them.
                foreach (var pet in petRecords)
                {
                    string petId = pet["PetID"].ToString();
                    petTable.Delete(petId);
                }

                Console.WriteLine($"{petRecords.Count} pet(s) deleted for Owner ID {ownerId}.");

                // Delete owner from in memory database.
                ownerTable.Delete(ownerId);
                Console.WriteLine($"Owner with ID {ownerId} has been successfully deleted from in-memory database.");

                // Delete from SSMS database.
                var ownerEntity = _dbContext.Owners.Find(ownerId);

                // If the Owner table does exist in the database.
                if (ownerEntity != null)
                {
                    // Update the database to reflect the changes made in the in memory databse.
                    var petsInDb = _dbContext.Pets.Where(p => p.OwnerID == ownerId).ToList();
                    _dbContext.Pets.RemoveRange(petsInDb);
                    _dbContext.Owners.Remove(ownerEntity);
                    _dbContext.SaveChanges();

                    // Tell that deletion was a success.
                    Console.WriteLine($"Owner and {petsInDb.Count} pet(s) also deleted from SQL database.");
                }
                else
                {
                    // Tell that owner was not found in the SSMS database.
                    Console.WriteLine($"Owner with ID {ownerId} not found in SQL database.");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Owner with ID {ownerId} does not exist in the in memory database."); // Throw an error to show the owner ID was not found in the in memory database.
            }
        }

        //Method for API delete (e.g https://localhost:7038/api/Owners/O00001).
        public bool DeleteOwnerById2(string ownerId)
        {
            var ownerTable = _inMemoryDatabase.GetTable("Owner");
            var petTable = _inMemoryDatabase.GetTable("Pet");

            var ownerRecord = ownerTable.Get(ownerId)
                              ?? throw new KeyNotFoundException("Owner not found in memory.");

            // Delete pets
            var petRecords = petTable.GetAll()
                                     .Where(pet => pet.Fields.ContainsKey("OwnerID") && pet["OwnerID"]?.ToString() == ownerId)
                                     .ToList();

            foreach (var pet in petRecords)
            {
                petTable.Delete(pet["PetID"].ToString());
            }

            ownerTable.Delete(ownerId);

            // Delete from EF Core
            var ownerEntity = _dbContext.Owners.Find(ownerId);
            if (ownerEntity != null)
            {
                var petsInDb = _dbContext.Pets.Where(p => p.OwnerID == ownerId).ToList();
                _dbContext.Pets.RemoveRange(petsInDb);
                _dbContext.Owners.Remove(ownerEntity);
                _dbContext.SaveChanges();
            }

            return true;
        }

    }
}
