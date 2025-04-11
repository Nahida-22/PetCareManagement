using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval.cs;
using PawfectCareLtd.Models;
using PawfectCareLtd.Repositories;
using PawfectCareLtd.Services;
using System.Threading;
using System.IO;
//using System.Windows.Forms;

namespace PawfectCareLtd
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // Set up the web application for API
            var builder = WebApplication.CreateBuilder(args);

            // Get the connection to connect to the database.
            string connectionString = ConnectionStringProvider.ConnectionString(args);

            if (connectionString != null)
            {
                // Add Database Context to the service container and configure to use default connection string.
                builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));

                // Add controller services for API requests.
                builder.Services.AddControllers();

                // Add Swagger for API documentation.
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                // Register CsvImportService as a scoped service (one instance per request).
                builder.Services.AddScoped<CsvImportService>();

                // Register IBulkInsertRepository with its implementation BulkInsertRepository for dependency injection.
                builder.Services.AddScoped<IBulkInsertRepository, BulkInsertRepository>();


                // Build the app
                var app = builder.Build();

                // Apply any pending database migrations at application startup.
                DatabaseInitialiser.Initialise(app.Services);

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

                // Run the web application in a separate thread
                var webAppThread = new Thread(() =>
                {
                    app.Run();
                });

                webAppThread.Start();

                // Run the WinForms application
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());
            }
        }


        private static void LoadTablesFromDatabase(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            // Create Location Table
            Table locationTable = new Table("Location", "LocationID", dbContext);

            foreach (var loc in dbContext.Locations.ToList())
            {
                var record = new Record();
                record["LocationID"] = loc.LocationID;
                record["Name"] = loc.Name;
                record["Address"] = loc.Address;
                record["Phone"] = loc.Phone;
                record["Email"] = loc.Email;

                locationTable.Insert(record, skipDb: true);
            }

            Console.WriteLine("Locations loaded into hash table successfully!");

            // Display one data from the Location table (e.g., using LocationID = "L001")
            DisplayLocationRecord(locationTable, "L001");
        }

        private static void DisplayLocationRecord(Table locationTable, string locationID)
        {
            try
            {
                // Get the record from the hash table using the primary key (LocationID)
                var record = locationTable.Get(locationID);

                // Display the record fields
                Console.WriteLine("Location Record:");
                foreach (var field in record.Fields)
                {
                    Console.WriteLine($"{field.Key}: {field.Value}");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"No record found for LocationID: {locationID}");
            }
        }
    }
}
