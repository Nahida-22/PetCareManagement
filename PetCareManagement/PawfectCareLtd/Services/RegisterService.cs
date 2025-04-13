using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.Services
{
    public class RegisterService
    {
        private readonly DatabaseContext _dbContext;
        private readonly Database _inMemoryDatabase;

        public RegisterService(DatabaseContext dbContext, Database inMemoryDatabase)
        {
            _dbContext = dbContext;
            _inMemoryDatabase = inMemoryDatabase;
        }

        public string RegisterNewOwnerAndPet(string firstName, string lastName, string phone, string email, string address,
                                   string petName, string petType, string breed, int age)
        {
            var ownerTable = _inMemoryDatabase.GetTable("Owner");
            // Make sure no nulls are compared, and use trimmed lowercase for reliable comparison
            var existingOwner = ownerTable.GetAll()
                .FirstOrDefault(o =>
                    o["Email"] != null &&
                    o["Email"].ToString().Trim().ToLower() == email.Trim().ToLower()
                );

            string ownerId;
            string message;

            if (existingOwner != null)
            {
                Console.WriteLine("existing owner ", existingOwner);

                // Owner exists — reuse OwnerID
                ownerId = existingOwner["OwnerID"].ToString();
                message = $"Owner already exists. Using existing OwnerID: {ownerId}";
                Console.WriteLine($"Owner already exists. Using existing OwnerID: {ownerId}");
            }
            else
            {
                // Create new owner
                ownerId = $"O{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
                var ownerRecord = new Record
                {
                    ["OwnerID"] = ownerId,
                    ["FirstName"] = firstName,
                    ["LastName"] = lastName,
                    ["PhoneNo"] = phone,
                    ["Email"] = email,
                    ["Address"] = address
                };
                ownerTable.Insert(ownerRecord);
                SyncOwnerToDatabase(ownerRecord);
                Console.WriteLine($"Registered new owner '{firstName} {lastName}'.");

                // Always register a new pet for the owner
                string petId = $"P{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
                var petRecord = new Record
                {
                    ["PetID"] = petId,
                    ["OwnerID"] = ownerId,
                    ["PetName"] = petName,
                    ["PetType"] = petType,
                    ["Breed"] = breed,
                    ["Age"] = age
                };
                _inMemoryDatabase.GetTable("Pet").Insert(petRecord);
                SyncPetToDatabase(petRecord);

                message = $"Pet '{petName}' registered for owner ID: {ownerId}.";
                Console.WriteLine($"Pet '{petName}' registered for owner ID: {ownerId}.");
            }
            return message;

        }


        public string RegisterPetForExistingOwner(string firstName, string lastName,
                                        string petName, string petType, string breed, int age)
        {
            var ownerTable = _inMemoryDatabase.GetTable("Owner");
            var petTable = _inMemoryDatabase.GetTable("Pet");

            string message;

            // Find the owner by first and last name
            var matchingOwner = ownerTable.GetAll().FirstOrDefault(r =>
                r["FirstName"].ToString().Trim().Equals(firstName.Trim(), StringComparison.OrdinalIgnoreCase) &&
                r["LastName"].ToString().Trim().Equals(lastName.Trim(), StringComparison.OrdinalIgnoreCase));

            if (matchingOwner == null)
            {
                Console.WriteLine($"Owner '{firstName} {lastName}' not found.");
                return message = $"Owner '{firstName} {lastName}' not found.";
            }
            else
            {
                string ownerId = matchingOwner["OwnerID"].ToString();


                // Check if the pet already exists for this owner
                var existingPet = petTable.GetAll().FirstOrDefault(p =>
                    p["OwnerID"].ToString() == ownerId &&
                    p["PetName"].ToString().Trim().Equals(petName.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    p["PetType"].ToString().Trim().Equals(petType.Trim(), StringComparison.OrdinalIgnoreCase)
                );

                if (existingPet != null)
                {
                    Console.WriteLine($"Pet '{petName}' of type '{petType}' already exists for owner '{firstName} {lastName}'.");
                    return message = $"Pet '{petName}' of type '{petType}' already exists for owner '{firstName} {lastName}'.";
                    
                } else
                {
                    // Add the new pet
                    string petId = $"P{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
                    var petRecord = new Record
                    {
                        ["PetID"] = petId,
                        ["OwnerID"] = ownerId,
                        ["PetName"] = petName,
                        ["PetType"] = petType,
                        ["Breed"] = breed,
                        ["Age"] = age
                    };
                    petTable.Insert(petRecord);

                    // Sync to database
                    SyncPetToDatabase(petRecord);

                    Console.WriteLine($"Pet '{petName}' added to owner '{firstName} {lastName}'.");
                    return message = $"Pet '{petName}' added to owner '{firstName} {lastName}'.";

                }
            }

            
        }

        private void SyncOwnerToDatabase(Record owner)
        {
            var entity = new Owner
            {
                OwnerID = owner["OwnerID"].ToString(),
                FirstName = owner["FirstName"].ToString(),
                LastName = owner["LastName"].ToString(),
                PhoneNo = owner["PhoneNo"].ToString(),
                Email = owner["Email"].ToString(),
                Address = owner["Address"].ToString()
            };
            _dbContext.Owners.Add(entity);
            _dbContext.SaveChanges();
        }

        private void SyncPetToDatabase(Record pet)
        {
            var entity = new Pet
            {
                PetID = pet["PetID"].ToString(),
                OwnerID = pet["OwnerID"].ToString(),
                PetName = pet["PetName"].ToString(),
                PetType = pet["PetType"].ToString(),
                Breed = pet["Breed"].ToString(),
                Age = pet["Age"].ToString()
            };
            _dbContext.Pets.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
