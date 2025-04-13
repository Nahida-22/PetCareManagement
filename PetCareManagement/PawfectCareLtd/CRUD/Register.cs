using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.CRUD
{
    public class Register
    {
        private readonly DatabaseContext _dbContext;
        private readonly Database _inMemoryDatabase;

        public Register(DatabaseContext dbContext, Database inMemoryDatabase)
        {
            _dbContext = dbContext;
            _inMemoryDatabase = inMemoryDatabase;
        }

        public void RegisterNewOwnerAndPet(string firstName, string lastName, string phone, string email, string address,
                                           string petName, string petType, string breed, int age)
        {
            string ownerId = $"O{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
            string petId = $"P{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";

            // Insert Owner into hash table (in-memory)
            var ownerRecord = new Record
            {
                ["OwnerID"] = ownerId,
                ["FirstName"] = firstName,
                ["LastName"] = lastName,
                ["PhoneNo"] = phone,
                ["Email"] = email,
                ["Address"] = address
            };
            _inMemoryDatabase.GetTable("Owner").Insert(ownerRecord);

            // Insert Pet into hash table (in-memory)
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

            // Reflect in-memory data to EF Core database
            SyncOwnerToDatabase(ownerRecord);
            SyncPetToDatabase(petRecord);

            Console.WriteLine($"✅ Registered new owner '{firstName} {lastName}' and pet '{petName}'.");
        }

        public void RegisterPetForExistingOwner(string firstName, string lastName,
                                                string petName, string petType, string breed, int age)
        {
            // Look up owner in hash table first
            var ownerTable = _inMemoryDatabase.GetTable("Owner");
            var matchingOwner = ownerTable.GetAll().FirstOrDefault(r =>
                r["FirstName"].ToString() == firstName && r["LastName"].ToString() == lastName);

            if (matchingOwner == null)
            {
                Console.WriteLine($"❌ Owner '{firstName} {lastName}' not found.");
                return;
            }

            string ownerId = matchingOwner["OwnerID"].ToString();
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

            //Sync
            SyncPetToDatabase(petRecord);

            Console.WriteLine($"✅ Pet '{petName}' added to owner '{firstName} {lastName}'.");
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
