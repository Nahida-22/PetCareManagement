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
        public void DeleteOwnerById(string ownerId)
        {
            var ownerTable = _inMemoryDatabase.GetTable("Owner");
            var petTable = _inMemoryDatabase.GetTable("Pet");

            try
            {
                var ownerRecord = ownerTable.Get(ownerId);

                // --- Delete pets from in-memory database ---
                var petRecords = petTable.GetAll()
                                         .Where(pet => pet.Fields.ContainsKey("OwnerID") && pet["OwnerID"]?.ToString() == ownerId)
                                         .ToList();

                foreach (var pet in petRecords)
                {
                    string petId = pet["PetID"].ToString();
                    petTable.Delete(petId);
                }

                Console.WriteLine($"{petRecords.Count} pet(s) deleted for Owner ID {ownerId}.");

                // --- Delete owner from in-memory database ---
                ownerTable.Delete(ownerId);
                Console.WriteLine($"Owner with ID {ownerId} has been successfully deleted from in-memory database.");

                // --- Delete from EF Core database ---
                var ownerEntity = _dbContext.Owners.Find(ownerId);
                if (ownerEntity != null)
                {
                    var petsInDb = _dbContext.Pets.Where(p => p.OwnerID == ownerId).ToList();
                    _dbContext.Pets.RemoveRange(petsInDb);
                    _dbContext.Owners.Remove(ownerEntity);
                    _dbContext.SaveChanges();

                    Console.WriteLine($"Owner and {petsInDb.Count} pet(s) also deleted from SQL database.");
                }
                else
                {
                    Console.WriteLine($"Owner with ID {ownerId} not found in SQL database.");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Owner with ID {ownerId} does not exist in the in-memory database.");
            }
        }



    }
}
