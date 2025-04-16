// Import dependencies.
using Microsoft.EntityFrameworkCore;  // Import the entity framework for databases related operation.
using PawfectCareLtd.Data; // Imports the application's database context.
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.
using PawfectCareLtd.Models; // Import the data models used in the application.


namespace PawfectCareLtd.Repositories.HashTableDatabaseLoader // Define the namespace for the application.
{

    // Implement the interface IHashTableDatabaseLoader.
    public class HashTableDatabaseLoader : IHashTableDatabaseLoader
    {
        // Define a field to store a reference to the in memory database.
        private readonly Database _inMemoryDatabase;


        // Define a field to store a reference to the in memory database.
        public HashTableDatabaseLoader(Database inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }


        // Helper function to load any table into the in memory hashtable.
        private async Task LoadTable<T>(

            // Define the variable needed.
            DbSet<T> dbSet, // DbSet for the entity.
            string tableName, // Name of the table to input in the in memory database.
            string primaryKey, // The primary key of the table.
            Func<T, Record> recordMapper, // Convert each entity into a Record.
            DatabaseContext dbContext // Original database for data syncing.

        ) where T : class // Constraint to only allow class based ef models.
        {
            // Get all records from the SSMS and store them in a variable call item.
            var items = await dbSet.ToListAsync();

            // Create a new in memory table instance.
            var table = new Table(tableName, primaryKey, dbContext);

            // Iterate through each record and add them to the in memory database.
            foreach (var item in items)
            {
                // Map the record.
                var record = recordMapper(item);

                // Insert the record into the into in memory table.
                table.Insert(record, skipDb: true);
            }

            // Insert the record into the into in memory database.
            _inMemoryDatabase.AddTable(table);
        }


        // Method to load the Vet table from the SSMS in the in memroy database.
        public Task LoadVetTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Vet, // Access theDbSet<Vet> from the databse context.
                "Vet", // Set the name of the in memory table.
                "VetID", // Define the primary key field of the table.

                // Function that maps each Vet entity to a record.
                vet => new Record
                {
                    // Map each field.
                    ["VetID"] = vet.VetID,
                    ["VetName"] = vet.VetName,
                    ["Specialisation"] = vet.Specialisation,
                    ["PhoneNo"] = vet.PhoneNo,
                    ["Email"] = vet.Email,
                    ["Address"] = vet.Address
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }


        // Method to load the Location table from the SSMS in the in memroy database.
        public Task LoadLocationTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Locations, // Access theDbSet<Location> from the databse context.
                "Location", // Set the name of the in memory table.
                "LocationID", // Define the primary key field of the table.

                // Function that maps each Location entity to a record.
                loc => new Record
                {
                    ["LocationID"] = loc.LocationID,
                    ["Name"] = loc.Name,
                    ["Address"] = loc.Address,
                    ["Phone"] = loc.Phone,
                    ["Email"] = loc.Email
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }


        // Method to load the Appointment table from the SSMS in the in memroy database.
        public Task LoadAppointmentTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Appointments, // Access theDbSet<Appointment> from the databse context.
                "Appointment", // Set the name of the in memory table.
                "AppointmentID", // Define the primary key field of the table.

                // Function that maps each Appointment entity to a record.
                appt => new Record
                {
                    ["AppointmentID"] = appt.AppointmentID,
                    ["PetID"] = appt.PetID,
                    ["VetID"] = appt.VetID,
                    ["ServiceType"] = appt.ServiceType,
                    ["ApptDate"] = appt.ApptDate,
                    ["Status"] = appt.Status,
                    ["LocationID"] = appt.LocationID
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }


        // Method to load the Medication table from the SSMS in the in memroy database.
        public Task LoadMedicationTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Medications, // Access theDbSet<Medication> from the databse context.
                "Medication", // Set the name of the in memory table.
                "MedicationID", // Define the primary key field of the table.

                // Function that maps each Medication entity to a record.
                med => new Record
                {
                    ["MedicationID"] = med.MedicationID,
                    ["MedicationName"] = med.MedicationName,
                    ["SupplierID"] = med.SupplierID,
                    ["StockQuantity"] = med.StockQuantity,
                    ["Category"] = med.Category,
                    ["UnitPrice"] = med.UnitPrice,
                    ["ExpiryDate"] = med.ExpiryDate
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }


        // Method to load the Order table from the SSMS in the in memroy database.
        public Task LoadOrderTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Orders, // Access theDbSet<Order> from the databse context.
                "Order", // Set the name of the in memory table.
                "OrderID", // Define the primary key field of the table.

                // Function that maps each Order entity to a record.
                order => new Record
                {
                    ["OrderID"] = order.OrderID,
                    ["MedicationID"] = order.MedicationID,
                    ["Quantity"] = order.Quantity,
                    ["OrderDate"] = order.OrderDate,
                    ["OrderStatus"] = order.OrderStatus
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }


        // Method to load the Owner table from the SSMS in the in memroy database.
        public Task LoadOwnerTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Owners, // Access theDbSet<Owner> from the databse context.
                "Owner", // Set the name of the in memory table.
                "OwnerID", // Define the primary key field of the table.

                // Function that maps each Owner entity to a record.
                owner => new Record
                {
                    ["OwnerID"] = owner.OwnerID,
                    ["FirstName"] = owner.FirstName,
                    ["LastName"] = owner.LastName,
                    ["PhoneNo"] = owner.PhoneNo,
                    ["Email"] = owner.Email,
                    ["Address"] = owner.Address
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }


        // Method to load the Payment table from the SSMS in the in memroy database.
        public Task LoadPaymentTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Payments, // Access theDbSet<Payment> from the databse context.
                "Payment", // Set the name of the in memory table.
                "BillID", // Define the primary key field of the table.

                // Function that maps each Payment entity to a record.
                payment => new Record
                {
                    ["BillID"] = payment.BillID,
                    ["AppointmentID"] = payment.AppointmentID,
                    ["Total_amt"] = payment.TotalAmount,
                    ["Payment_Date"] = payment.PaymentDate,
                    ["Payment_Status"] = payment.PaymentStatus
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }


        // Method to load the Prescription table from the SSMS in the in memroy database.
        public Task LoadPrescriptionTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Prescriptions, // Access theDbSet<Prescriptions> from the databse context.
                "Prescription", // Set the name of the in memory table.
                "PrescriptionID", // Define the primary key field of the table.

                // Function that maps each Prescription entity to a record.
                prescription => new Record
                {
                    ["PrescriptionID"] = prescription.PrescriptionID,
                    ["PetID"] = prescription.PetID,
                    ["IssueDate"] = prescription.DateIssued,
                    ["VetID"] = prescription.VetID,
                    ["Diagnosis"] = prescription.Diagnosis
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }

        // Method to load the Pet table from the SSMS in the in memroy database.
        public Task LoadPetTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Pets, // Access theDbSet<Pet> from the databse context.
                "Pet", // Set the name of the in memory table.
                "PetID", // Define the primary key field of the table.

                // Function that maps each Pet entity to a record.
                pet => new Record
                {
                    ["PetID"] = pet.PetID,
                    ["OwnerID"] = pet.OwnerID,
                    ["PetName"] = pet.PetName,
                    ["PetType"] = pet.PetType,
                    ["Breed"] = pet.Breed,
                    ["Age"] = pet.Age
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }


        // Method to load the Supplier table from the SSMS in the in memroy database.
        public Task LoadSupplierTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Suppliers, // Access theDbSet<Suppliers> from the databse context.
                "Supplier", // Set the name of the in memory table.
                "SupplierID", // Define the primary key field of the table.

                // Function that maps each Supplier entity to a record.
                supplier => new Record
                {
                    ["SupplierID"] = supplier.SupplierID,
                    ["SupplierName"] = supplier.SupplierName,
                    ["PhoneNumber"] = supplier.PhoneNumber,
                    ["Address"] = supplier.Address,
                    ["Email"] = supplier.Email
                },
                dbContext // Pass original DbContext to maintain a reference for syncing with SSMS database.
            );
        }
    }
}
