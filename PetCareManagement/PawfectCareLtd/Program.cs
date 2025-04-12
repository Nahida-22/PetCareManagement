// Import dependencies.
using Microsoft.EntityFrameworkCore; // For database-related operations using Entity Framework.
using PawfectCareLtd.CRUD; // For CRUD operations on various entities.
using PawfectCareLtd.Data; // For the application's database context.
using PawfectCareLtd.Data.DataRetrieval; // For the in-memory hash table database structure.
using PawfectCareLtd.Models; // For data models used in the application.
using PawfectCareLtd.Repositories.BulkInsertRepository; // For bulk insert operations from CSV.
using PawfectCareLtd.Repositories.HashTableDatabaseLoader; // For loading data from SQL to the hash table.
using PawfectCareLtd.Services; // For services like CsvImport and HashTableLoader.
using System.Threading; // For multithreading.


namespace PawfectCareLtd // Define the namespace for the application.
{
    // Define the main entry point of the program.
    internal static class Program
    {
        // Main method: Entry point of the program.
        public static async Task Main(string[] args)
        {
            // Set up the web application for API
            var builder = WebApplication.CreateBuilder(args);

            // Get the connection to connect to the database.
            string connectionString = ConnectionStringProvider.ConnectionString(args);


            // Check if the connection string is not null.
            if (connectionString != null)
            {
                // Register EF DbContext with the provided connection string.
                builder.Services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(connectionString));

                // Add necessary services for API controllers.
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(); // For Swagger documentation.

                // Register custom services in the DI container.
                builder.Services.AddScoped<Database>(); // In-memory hash table.
                builder.Services.AddScoped<CsvImportService>(); // CSV import service.
                builder.Services.AddScoped<IBulkInsertRepository, BulkInsertRepository>(); // Repository for CSV bulk inserts.
                builder.Services.AddScoped<IHashTableDatabaseLoader, HashTableDatabaseLoader>(); // Loader for SQL to hash table.
                builder.Services.AddScoped<HashtableLoaderService>(); // Service that wraps hashtable loader logic.

                // Register all CRUD services.
                builder.Services.AddScoped<LocationCRUD>();
                builder.Services.AddScoped<OwnerCRUD>();
                builder.Services.AddScoped<PetCRUD>();
                builder.Services.AddScoped<PrescriptionCRUD>();
                builder.Services.AddScoped<AppointmentCRUD>();

                // Build the app
                var app = builder.Build();

                // Apply any pending database migrations at application startup.
                DatabaseInitialiser.Initialise(app.Services);

                // Define scope.
                using (var scope = app.Services.CreateScope())
                {
                    // Import data from CSV files into SQL.
                    var csvService = scope.ServiceProvider.GetRequiredService<CsvImportService>();
                    csvService.ImportData();

                    // Load SQL data into the in-memory hash tables.
                    var tableLoaderService = scope.ServiceProvider.GetRequiredService<HashtableLoaderService>();
                    await tableLoaderService.LoadAllTablesAsync();

                    // Check if the Read part from the LocationCRUD is working.
                    var locationCrud = scope.ServiceProvider.GetRequiredService<LocationCRUD>();
                    locationCrud.ReadOperationForLocation("Address", "123 Main St Downtown City");

                    // Check if the Read part from the OwnerCRUD is working
                    var ownerCrud = scope.ServiceProvider.GetRequiredService<OwnerCRUD>();
                    ownerCrud.ReadOperationForOwner("FirstName", "John");

                    // Check if the Read part from the PetCRUD is working
                    var petCrud = scope.ServiceProvider.GetRequiredService<PetCRUD>();
                    petCrud.ReadOperationForPet("PetName", "Carl");

                    // Check if the Read part from the PrescriptionCRUD is working
                    var prescriptionCrud = scope.ServiceProvider.GetRequiredService<PrescriptionCRUD>();
                    prescriptionCrud.ReadOperationForPrescription("Diagnosis", "Fungal Infection");

                    // Check if the Read part from the AppointmentCRUD is working
                    var appointmentCrud = scope.ServiceProvider.GetRequiredService<AppointmentCRUD>();
                    appointmentCrud.ReadOperationForAppointment("ServiceType", "Checkup");
                }

                // Use Swagger for API documentation only in development environment.
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
    }
}