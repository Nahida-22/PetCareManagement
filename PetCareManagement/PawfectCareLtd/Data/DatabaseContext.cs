using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PawfectCareLtd.Data
{
    /// <summary>
    /// DatabaseContext class handles the Entity Framework Core operations
    /// and configuration for the PawfectCareLtd application.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the DatabaseContext with the specified options.
        /// </summary>
        /// <param name="options">DbContextOptions used to configure the context.</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        // Define all DbSets (Tables).
        public DbSet<Vet> Vet { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        /// <summary>
        /// Configures the relationships, keys, and constraints for the database tables.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship between Appointment and Vet.
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Vet) // Appointment has ONE Vet
                .WithMany(v => v.Appointments)  // Vet has MANY Appointments
                .HasForeignKey(a => a.VetID);   // Foreign key in Appointment table

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Pet)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PetID);

            // Relationship: One Medication has many Orders
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Medication)  // Order has one Medication
                .WithMany(m => m.Orders)    // Medication has many Orders
                .HasForeignKey(o => o.MedicationID); // Foreign key in Order table

            // Relationship: One Supplier has many Medications
            modelBuilder.Entity<Medication>()
                .HasOne(m => m.Supplier)  // Medication has one Supplier
                .WithMany(s => s.Medications)  // Supplier has many Medications
                .HasForeignKey(m => m.SupplierID); // Foreign key in Medication table


            // Add precision for Unit Price in Medication table
            modelBuilder.Entity<Medication>()
               .Property(m => m.UnitPrice)
               .HasPrecision(18, 2);

            // Relationship: One Pet has many Prescriptions
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Pet)
                .WithMany()
                .HasForeignKey(p => p.PetID);

            // Relationship: One Vet has many Prescriptions
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Vet)
                .WithMany()
                .HasForeignKey(p => p.VetID);

            /// <summary>
            /// Configures relationships for the PrescriptionMedication table.
            /// </summary>
            modelBuilder.Entity<PrescriptionMedication>()
                // Define Composite Primary Key
                .HasKey(pm => new { pm.PrescriptionID, pm.MedicationID });

            modelBuilder.Entity<PrescriptionMedication>()
                // Configure many-to-one relationship with Prescription
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedications)
                .HasForeignKey(pm => pm.PrescriptionID);

            modelBuilder.Entity<PrescriptionMedication>()
                // Configure many-to-one relationship with Medication
                .HasOne(pm => pm.Medication)
                .WithMany(m => m.PrescriptionMedications)
                .HasForeignKey(pm => pm.MedicationID);

        }

        public void BulkInsertOwners(string csvFilePath)
        {
            if (!Owners.Any()) // Ensure data is inserted only once
            {
                var owners = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Owner
                    {
                        OwnerID = data[0].Trim(),
                        FirstName = data[1].Trim(),
                        LastName = data[2].Trim(),
                        PhoneNo = data[3].Trim(),
                        Email = data[4].Trim(),
                        Address = data[5].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                this.BulkInsert(owners, bulkConfig);
                this.SaveChanges();
            }
        }

        // Function to bullk insert vets into tables
        public void BulkInsertVets(string csvFilePath)
        {
            if (!Vet.Any()) // Ensure data is inserted only once
            {
                var vets = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Vet
                    {
                        VetID = data[0].Trim(),
                        VetName = data[1].Trim(),
                        Specialisation = data[2].Trim(),
                        PhoneNo = data[3].Trim(),
                        Email = data[4].Trim(),
                        Address = data[5].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                this.BulkInsert(vets, bulkConfig);
                this.SaveChanges();
            }
        }
        public void BulkInsertPets(string csvFilePath)
        {
            if (!Pets.Any()) // Ensure data is inserted only once
            {
                var pets = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Pet
                    {
                        PetID = data[0].Trim(),
                        OwnerID = data[1].Trim(),
                        PetName = data[2].Trim(),
                        PetType = data[3].Trim(),
                        Breed = data[4].Trim(),
                        Age = data[5].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                this.BulkInsert(pets, bulkConfig);
                this.SaveChanges();
            }
        }

        // Function to bullk insert appointments into tables
        public void BulkInsertAppointments(string csvFilePath)
        {
            if (!Appointments.Any()) // Ensure data is inserted only once
            {
                var appointments = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Appointment
                    {
                        AppointmentID = data[0].Trim(),
                        PetID = data[1].Trim(),
                        VetID = data[2].Trim(),
                        ServiceType = data[3].Trim(),
                        ApptDate = DateTime.ParseExact(data[4].Trim(),
                               new[] { "M/d/yyyy", "MM/dd/yyyy" },
                               System.Globalization.CultureInfo.InvariantCulture,
                               System.Globalization.DateTimeStyles.None),
                        Status = data[5].Trim(),
                        Address = data[6].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                this.BulkInsert(appointments, bulkConfig);
                this.SaveChanges();
            }
        }

        // Function to bullk insert supplier into table
        public void BulkInsertSuppliers(string csvFilePath)
        {
            if (!Suppliers.Any()) // Ensure data is inserted only once
            {
                var suppliers = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Supplier
                    {
                        SupplierID = data[0].Trim(),
                        SupplierName = data[1].Trim(),
                        PhoneNumber = data[2].Trim(),
                        Address = data[3].Trim(),
                        Email = data[4].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                this.BulkInsert(suppliers, bulkConfig);
                this.SaveChanges();
            }
        }

        // Function to bullk insert order into table
        public void BulkInsertOrders(string csvFilePath)
        {
            if (!Orders.Any()) // Ensure data is inserted only once
            {
                var orders = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Order
                    {
                        OrderID = data[0].Trim(),
                        MedicationID = data[1].Trim(),
                        Quantity = int.Parse(data[2].Trim()),
                        OrderDate = DateTime.Parse(data[3].Trim()),
                        OrderStatus = data[4].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                this.BulkInsert(orders, bulkConfig);
                this.SaveChanges();
            }
        }

        // Function to bullk insert medication into table
        public void BulkInsertMedications(string csvFilePath)
        {
            if (!Medications.Any()) // Ensure data is inserted only once
            {
                var medications = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Medication
                    {
                        MedicationID = data[0].Trim(),
                        MedicationName = data[1].Trim(),
                        SupplierID = data[2].Trim(),
                        StockQuantity = int.Parse(data[3].Trim()),
                        Category = data[4].Trim(),
                        UnitPrice = decimal.Parse(data[5].Trim()),
                        ExpiryDate = DateTime.ParseExact(data[6].Trim(),
                            "dd/MM/yyyy", // Parsing the date in the specified format
                            System.Globalization.CultureInfo.InvariantCulture)
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                this.BulkInsert(medications, bulkConfig);
                this.SaveChanges();
            }
        }
        public void BulkInsertPrescriptions(string csvFilePath)
        {
            if (!Prescriptions.Any()) // Ensure data is inserted only once
            {
                var prescriptionList = new List<Prescription>();
                var prescriptionMedicationsList = new List<PrescriptionMedication>();

                var lines = File.ReadAllLines(csvFilePath).Skip(1); // Skip header

                foreach (var line in lines)
                {
                    var data = line.Split(',');

                    var prescription = new Prescription
                    {
                        PrescriptionID = data[0].Trim(),
                        PetID = data[1].Trim(),
                        VetID = data[2].Trim(),
                        Diagnosis = data[3].Trim(),
                        Dosage = data[4].Trim(),
                        DateIssued = DateTime.Parse(data[5].Trim())
                    };

                    prescriptionList.Add(prescription);

                    // Handle Many-to-Many Medication Relationship
                    var medicationIDs = data[6].Trim().Split(',');
                    foreach (var medID in medicationIDs)
                    {
                        prescriptionMedicationsList.Add(new PrescriptionMedication
                        {
                            PrescriptionID = prescription.PrescriptionID,
                            MedicationID = medID.Trim()
                        });
                    }
                }

                var bulkConfig = new BulkConfig { SetOutputIdentity = false };

                // Insert Prescriptions
                this.BulkInsert(prescriptionList, bulkConfig);

                // Insert Prescription-Medication Relationships
                this.BulkInsert(prescriptionMedicationsList, bulkConfig);
                this.SaveChanges();
            }
        }
    }
}