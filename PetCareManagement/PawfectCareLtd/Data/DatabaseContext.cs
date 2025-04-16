// Import dependencies.
using EFCore.BulkExtensions; // For bulk insertion.
using Microsoft.EntityFrameworkCore; // For database-related operations using Entity Framework.
using PawfectCareLtd.Models; // For data models used in the application.
using Swashbuckle.AspNetCore.SwaggerGen; // Import namespace which provides tools for generating Swagger


namespace PawfectCareLtd.Data // Define the namespace for the application.
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
        public DbSet <Location> Locations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PrescriptionMedication> PrescriptionMedications { get; set; }


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
                .HasForeignKey(m => m.SupplierID) // Foreign key in Medication table
                .OnDelete(DeleteBehavior.Cascade); // Delete all relevant key.


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

            // Configures relationships for the PrescriptionMedication table.
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
            modelBuilder.Entity<Pet>()
             .HasOne(p => p.Owner)  // Pet has ONE Owner
             .WithMany(o => o.Pets)  // Owner has MANY Pets
             .HasForeignKey(p => p.OwnerID);  // Foreign key

            // One Location can have multiple Appointments
            // One Appointment belongs to one Location
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Location)
                .WithMany(l => l.Appointments)
                .HasForeignKey(a => a.LocationID);

            // Relationship: One Appointment has One Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Appointment)
                .WithOne(a => a.Payment)
                .HasForeignKey<Payment>(p => p.AppointmentID);
        }
    }
}