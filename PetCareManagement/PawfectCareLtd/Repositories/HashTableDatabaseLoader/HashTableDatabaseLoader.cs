using System.Drawing;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.Repositories.HashTableDatabaseLoader
{
    public class HashTableDatabaseLoader : IHashTableDatabaseLoader
    {
        // Field to hold the LoadedDatabase instance.
        private readonly Database _inMemoryDatabase;

        // Constructor
        public HashTableDatabaseLoader(Database inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        // Helper Function
        private async Task LoadTable<T>(
            DbSet<T> dbSet,
            string tableName,
            string primaryKey,
            Func<T, Record> recordMapper,
            DatabaseContext dbContext
        ) where T : class
        {
            var items = await dbSet.ToListAsync();
            var table = new Table(tableName, primaryKey, dbContext);

            foreach (var item in items)
            {
                var record = recordMapper(item);
                table.Insert(record, skipDb: true);
            }

            _inMemoryDatabase.AddTable(table);
        }

        // Load all tables from database into hashtable.
        public Task LoadVetTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Vet,
                "Vet",
                "VetID",
                vet => new Record
                {
                    ["VetID"] = vet.VetID,
                    ["VetName"] = vet.VetName,
                    ["Specialisation"] = vet.Specialisation,
                    ["PhoneNo"] = vet.PhoneNo,
                    ["Email"] = vet.Email
                },
                dbContext
            );
        }

        public Task LoadLocationTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Locations,
                "Location",
                "LocationID",
                loc => new Record
                {
                    ["LocationID"] = loc.LocationID,
                    ["Name"] = loc.Name,
                    ["Address"] = loc.Address,
                    ["Phone"] = loc.Phone,
                    ["Email"] = loc.Email
                },
                dbContext
            );
        }

        public Task LoadAppointmentTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Appointments,
                "Appointment",
                "AppointmentID",
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
                dbContext
            );
        }

        public Task LoadMedicationTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Medications,
                "Medication",
                "MedicationID",
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
                dbContext
            );
        }

        public Task LoadOrderTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Orders,
                "Order",
                "OrderID",
                order => new Record
                {
                    ["OrderID"] = order.OrderID,
                    ["MedicationID"] = order.MedicationID,
                    ["Quantity"] = order.Quantity,
                    ["OrderDate"] = order.OrderDate,
                    ["OrderStatus"] = order.OrderStatus
                },
                dbContext
            );
        }

        public Task LoadOwnerTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Owners,
                "Owner",
                "OwnerID",
                owner => new Record
                {
                    ["OwnerID"] = owner.OwnerID,
                    ["FirstName"] = owner.FirstName,
                    ["LastName"] = owner.LastName,
                    ["PhoneNo"] = owner.PhoneNo,
                    ["Email"] = owner.Email,
                    ["Address"] = owner.Address
                },
                dbContext
            );
        }


        public Task LoadPaymentTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Payments,
                "Payment",
                "BillID",
                payment => new Record
                {
                    ["BillID"] = payment.BillID,
                    ["AppointmentID"] = payment.AppointmentID,
                    ["Total_amt"] = payment.TotalAmount,
                    ["Payment_Date"] = payment.PaymentDate,
                    ["Payment_Status"] = payment.PaymentStatus
                },
                dbContext
            );
        }

        public Task LoadPrescriptionTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Prescriptions,
                "Prescription",
                "PrescriptionID",
                prescription => new Record
                {
                    ["PrescriptionID"] = prescription.PrescriptionID,
                    ["PetID"] = prescription.PetID,
                    ["IssueDate"] = prescription.DateIssued,
                    ["VetID"] = prescription.VetID,
                    ["Diagnosis"] = prescription.Diagnosis
                },
                dbContext
            );
        }


        public Task LoadPetTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Pets,
                "Pet",
                "PetID",
                pet => new Record
                {
                    ["PetID"] = pet.PetID,
                    ["OwnerID"] = pet.OwnerID,
                    ["PetName"] = pet.PetName,
                    ["PetType"] = pet.PetType,
                    ["Breed"] = pet.Breed,
                    ["Age"] = pet.Age
                },
                dbContext
            );
        }


        public Task LoadSupplierTable(DatabaseContext dbContext)
        {
            return LoadTable(
                dbContext.Suppliers,
                "Supplier",
                "SupplierID",
                supplier => new Record
                {
                    ["SupplierID"] = supplier.SupplierID,
                    ["SupplierName"] = supplier.SupplierName,
                    ["PhoneNumber"] = supplier.PhoneNumber,
                    ["Address"] = supplier.Address,
                    ["Email"] = supplier.Email
                },
                dbContext
            );
        }

        

    }
}
