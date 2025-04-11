using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Data.DataRetrieval;

using PawfectCareLtd.Models;
using PawfectCareLtd.Repositories;
using PawfectCareLtd.Services;
using System.Threading;

namespace PawfectCareLtd
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // STEP 1: Build the app
            var builder = WebApplication.CreateBuilder(args);

            // STEP 2: Get the connection string
            string connectionString = ConnectionStringProvider.ConnectionString(args);

            if (connectionString != null)
            {
                // STEP 3: Register all services
                builder.Services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(connectionString));

                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddScoped<CsvImportService>();
                builder.Services.AddScoped<IBulkInsertRepository, BulkInsertRepository>();

                var app = builder.Build();

                // STEP 4: Run migrations and import CSVs
                DatabaseInitialiser.Initialise(app.Services);

                using (var scope = app.Services.CreateScope())
                {
                    var csvService = scope.ServiceProvider.GetRequiredService<CsvImportService>();
                    csvService.ImportData();
                }

                // STEP 5: Load data into Hash Tables
                LoadTablesFromDatabase(app.Services);

                // STEP 6: Start API thread
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                //app.UseHttpsRedirection();
                app.MapControllers();

                var webAppThread = new Thread(() => app.Run());
                webAppThread.Start();

                // STEP 7: Optionally run your WinForms app
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

                locationTable.Insert(record, skipDb: true); // skip inserting existing records

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