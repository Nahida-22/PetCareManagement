using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add VetContext
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Build the app
        var app = builder.Build();

        // Apply migrations and seed data at startup
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            try
{
    // Apply any pending migrations and update the database
    context.Database.Migrate();
    Console.WriteLine("Database migration applied successfully.");

    // Corrected CSV file path
    string OwnerCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Owner.csv");
    string PetCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Pet.csv");
    string VetCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Vet.csv");
    string AppointmentCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Appointment.csv");
    string SupplierCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Supplier.csv");
    string OrderCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Order.csv");
    string MedicationCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Medication.csv");
    string PrescriptionCsvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Prescription.csv");

    // Check if the CSV file exists and perform the bulk insert
    if (File.Exists(VetCsvPath) && File.Exists(AppointmentCsvPath))
    {
        context.BulkInsertOwners(OwnerCsvPath);
        context.BulkInsertPets(PetCsvPath);
        context.BulkInsertVets(VetCsvPath);
        context.BulkInsertAppointments(AppointmentCsvPath);
        context.BulkInsertSuppliers(SupplierCsvPath);
        context.BulkInsertOrders(OrderCsvPath);
        context.BulkInsertMedications(MedicationCsvPath);
        context.BulkInsertPrescriptions(PrescriptionCsvPath);


        Console.WriteLine("Bulk insert completed successfully.");
    }
    else
    {
        Console.WriteLine($"CSV file not found");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error applying migrations or bulk inserting data: {ex.Message}");
}
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.MapControllers();

        // Run the app
        app.Run();
    }
}
