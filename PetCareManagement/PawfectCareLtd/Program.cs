using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using PawfectCareLtd.Repositories;
using PawfectCareLtd.Services;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        // Create builder for the web application.
        var builder = WebApplication.CreateBuilder(args);

        // Add Database Context to the service container and configure to use default connection string.
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add controller services for API requests.
        builder.Services.AddControllers();

        // Add Swagger for API documentation.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register CsvImportService as a scoped service (one instance per request).
        builder.Services.AddScoped<CsvImportService>();

        // Register IBulkInsertRepository with its implementation BulkInsertRepository for dependency injection.
        builder.Services.AddScoped<IBulkInsertRepository, BulkInsertRepository>();


        // Build the web application.
        var app = builder.Build();

        // Apply any pending database migrations at application startup.
        DatabaseInitializer.Initialize(app.Services);

        // Import CSV data into the database on startup.
        using (var scope = app.Services.CreateScope())
        {
            // Retrieve the CsvImportService from DI container and run the import process.
            var csvService = scope.ServiceProvider.GetRequiredService<CsvImportService>();
            csvService.ImportData();
        }


        // Use Swagger for API documentation only in development environment.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Enable HTTPS redirection for secure communication
        app.UseHttpsRedirection();
        app.MapControllers();


        // Run the application.
        app.Run();
    }
}
