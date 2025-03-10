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
                string csvPath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "Vet.csv");

                // Check if the CSV file exists and perform the bulk insert
                if (File.Exists(csvPath))
                {
                    context.BulkInsertVets(csvPath);
                    Console.WriteLine("Bulk insert completed successfully.");
                }
                else
                {
                    Console.WriteLine($"CSV file not found at: {csvPath}");
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
