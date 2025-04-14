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

            // Register EF DbContext with the provided connection string.
            builder.Services.AddDbContext<DatabaseContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add necessary services for API controllers.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); // For Swagger documentation.

            // Register custom services in the DI container.
            builder.Services.AddSingleton<Database>(); // In-memory hash table.
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
            builder.Services.AddScoped<RegisterService>();
            builder.Services.AddScoped<BookAppointmentService>();
            builder.Services.AddScoped<VetCRUD>();
            builder.Services.AddScoped<SupplierCRUD>();



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

                // Load SQL data into the in memory hash tables.
                var tableLoaderService = scope.ServiceProvider.GetRequiredService<HashtableLoaderService>();
                await tableLoaderService.LoadAllTablesAsync();


                // TESTING FOR INSERT AND READ.

                //var appointmentCrud = scope.ServiceProvider.GetRequiredService<AppointmentCRUD>();

                //appointmentCrud.ReadOperationForAppointment("AppointmentID", "A22000");

                //var validAppointed = new Dictionary<string, object>
                //{
                //    ["AppointmentID"] = "A22000",
                //    ["PetID"] = "P00267",
                //    ["VetID"] = "V1000",
                //    ["ServiceType"] = "Heart Screening",
                //    ["ApptDate"] = "7/27/2025",
                //    ["Status"] = "Scheduled",
                //    ["LocationID"] = "L001"
                //};

                //appointmentCrud.InsertOperationForAppointment(
                //    validAppointed,
                //    primaryKeyName: "AppointmentID",
                //    primaryKeyFormat: @"^A\d{5,}$",
                //    foreignKeys: new List<(string, string)>
                //    {
                //        ("LocationID", "Location"),
                //        ("PetID", "Pet"),
                //        ("VetID", "Vet")
                //    }
                //);

                //appointmentCrud.ReadOperationForAppointment("AppointmentID", "A22000");



                // TESTING FOR UPDATE AND READ.


                //var appointmentCrud = scope.ServiceProvider.GetRequiredService<AppointmentCRUD>();
                //appointmentCrud.ReadOperationForAppointment("AppointmentID", "A10000");
                //appointmentCrud.UpdateOperationForAppointment("A10000", "LocationID", "L002", true, "Location");
                //appointmentCrud.ReadOperationForAppointment("AppointmentID", "A10000");


                //// Check if the Read part from the AppointmentCRUD is working
                //var appointmentCrud = scope.ServiceProvider.GetRequiredService<AppointmentCRUD>();
                //appointmentCrud.ReadOperationForAppointment("ServiceType", "Checkup");
                //var supplierCrud = scope.ServiceProvider.GetRequiredService<SupplierCRUD>();

                //// READ test before inserting
                //supplierCrud.ReadOperationForSupplier("SupplierID", "S10013");

                //// INSERT test
                //var supplierData = new Dictionary<string, object>
                //    {
                //        { "SupplierID", "S10013" },
                //        { "SupplierName", "Dr. Samantha Holmes" },
                //        { "PhoneNumber", "58443312" },
                //        { "Address", "Wa" },
                //        { "Email", "mandyrivera@yahoo.com" }
                //    };
                //supplierCrud.InsertOperationForSupplier(supplierData, "SupplierID", @"^S\d{5}$");


                //// READ to confirm insert
                //supplierCrud.ReadOperationForSupplier("SupplierID", "S10013");

                //// UPDATE test
                //supplierCrud.UpdateOperationForSupplier("S10003", "PhoneNumber", "59887766");

                //// READ again to confirm update
                //supplierCrud.ReadOperationForSupplier("SupplierID", "S10013");


                // TESTING FOR DELETE AND READ.w



                //// 2. Perform deletion
                //ownerCrud.DeleteOwnerById("O00001");

                //// 3. Confirm deletion
                //Console.WriteLine("\nAfter deletion:");
                //ownerCrud.ReadOperationForOwner("OwnerID", "O00001");


                var petCrud = scope.ServiceProvider.GetRequiredService<PetCRUD>();

                // READ test before inserting
                petCrud.ReadOperationForPet("PetID", "P00002");
                petCrud.DeletePetById("P00002");

                // INSERT test
                var petData = new Dictionary<string, object>
                        {
                            { "PetID", "P00002" },
                            { "OwnerID", "O00001" },
                            { "PetName", "Buddy" },
                            { "PetType", "Dog" },
                            { "Breed", "Labrador" },
                            { "Age", "10" },
                            
                        };
                petCrud.InsertOperationForPet(petData, "PetID", @"^P\d{5}$", new List<(string, string)>
{
    ("OwnerID", "Owner")
});

                // READ to confirm insert
                petCrud.ReadOperationForPet("PetID", "P00002");

                // UPDATE test
                petCrud.UpdateOperationForPet("P00002", "Breed", "Golden Retriever");

                // READ again to confirm update
                petCrud.ReadOperationForPet("PetID", "P00002");




                //// 2. Delete the pet
                //petCrud.DeletePetById("P00002");

                //var ownerCrud = scope.ServiceProvider.GetRequiredService<OwnerCRUD>();

                //// DELETE test to clean up any existing OwnerID
                //try
                //{
                //    ownerCrud.DeleteOwnerById("O00001");
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Delete failed or not needed: {ex.Message}");
                //}

                //// READ test to confirm deletion
                //ownerCrud.ReadOperationForOwner("OwnerID", "O00001");

                //// INSERT test
                //var ownerData = new Dictionary<string, object>
                //    {
                //        { "OwnerID", "O00001" },
                //        { "FirstName", "Tom" },
                //        { "LastName", "Sar" },
                //        { "PhoneNo", "58849714" },
                //        { "Email", "TomSawyer@yahoo.com" },
                //        { "Address", "La Marie Road, Flether" }
                //    };
                //ownerCrud.InsertOperationForOwner(ownerData, "OwnerID", @"^O\d{5}$", new List<(string, string)>());
                //ownerCrud.ReadOperationForOwner("OwnerID", "O00001");

                //// UPDATE test
                //ownerCrud.UpdateOperationForOwner("O00001", "PhoneNo", "59999999");
                //ownerCrud.ReadOperationForOwner("OwnerID", "O00001");

                //var crud = scope.ServiceProvider.GetRequiredService<AppointmentCRUD>();

                //// 1. READ before any changes
                //crud.ReadOperationForAppointment("AppointmentID", "A10000");

                //// 2. DELETE Appointment if it exists
                //crud.DeleteAppointmentbyId("A10000");

                //// 3. INSERT new Appointment
                //var appointmentData = new Dictionary<string, object>
                //{
                //    { "AppointmentID", "A10000" },
                //    { "PetID", "P08628" },
                //    { "VetID", "V1007" },
                //    { "ServiceType", "Checkup" },
                //    { "ApptDate", DateTime.Parse("2025-03-09") },
                //    { "Status", "Scheduled" },
                //    { "LocationID", "L002" }
                //};

                //crud.InsertOperationForAppointment(
                //    fieldValues: appointmentData,
                //    primaryKeyName: "AppointmentID",
                //    primaryKeyFormat: @"^A\d{5}$",
                //    foreignKeys: new List<(string, string)>
                //    {
                //        ("PetID", "Pet"),
                //        ("VetID", "Vet"),
                //        ("LocationID", "Location")
                //    }
                //);

                //// 4. READ after insert
                //crud.ReadOperationForAppointment("AppointmentID", "A10000");

                //// 5. UPDATE status to "Completed"
                //crud.UpdateOperationForAppointment("A10000", "Status", "Completed");

                //// 6. READ after update
                //crud.ReadOperationForAppointment("AppointmentID", "A10000");

                //var crud = scope.ServiceProvider.GetRequiredService<LocationCRUD>();

                //// 1. READ before any changes
                //crud.ReadOperationForLocation("LocationID", "L001");

                //// 2. DELETE if exists (optional — if you have a delete function)
                //crud.ReadOperationForLocation("LocationID", "L001");

                //// 3. INSERT new Location
                //var locationData = new Dictionary<string, object>
                //    {
                //        { "LocationID", "L001" },  // Keeping this as-is
                //        { "Name", "Pawfect Care Ltd 1" },
                //        { "Address", "La Marie Road, Flic-en-Flac" },  // Fixed spelling
                //        { "Phone", "56785432" },
                //        { "Email", "eastside@email.com" }
                //    };

                //crud.InsertOperationForLocation(
                //    fieldValues: locationData,
                //    primaryKeyName: "LocationID",
                //    primaryKeyFormat: @"^L\d{3}$",  // Updated regex to match "L001"
                //    foreignKeys: new List<(string, string)>()  // No foreign keys
                //);

                //// 4. READ after insert
                //crud.ReadOperationForLocation("LocationID", "L001");

                //// 5. UPDATE address to "Royal Road"
                //crud.UpdateOperationForLocation("L001", "Address", "Royal Road");

                //// 6. READ after update
                //crud.ReadOperationForLocation("LocationID", "L001");



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