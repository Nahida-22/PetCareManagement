using Microsoft.EntityFrameworkCore;

namespace PawfectCareLtd.Models
{
   
        public class DatabaseContext : DbContext
        {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
            public DbSet<Owner> Owners { get; set; }
            public DbSet<Pet> Pets { get; set; }
            public DbSet<Appointment> Appointments { get; set; }
            public DbSet<Prescription> Prescriptions { get; set; }
            public DbSet<Medication> Medications { get; set; }
            public DbSet<Vet> Vets { get; set; }
            public DbSet<Supplier> Suppliers { get; set; }
            public DbSet<Order> orders { get; set; }
            public DbSet<Location> Locations { get; set; }



        }
    
}
