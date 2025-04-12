// Import dependencies.
using Microsoft.EntityFrameworkCore; // Import the entity framework for databases related operation.
using PawfectCareLtd.Data; // Import the database context used in the application.
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database used in the application.

using PawfectCareLtd.Models; // Import the data models used in the application.
using PawfectCareLtd.Repositories; // Import the repositories used in the application.
using PawfectCareLtd.Services; // Import the services used in the application.
using System.Threading; // Import threading.

namespace PawfectCareLtd // Define the namespace for the application.
{

    // Define the main entry point of the program.
    internal static class Program
    {
        // Main method... The entry point of the program.
        public static void Main(string[] args)
        {
            // Set up the web application for API
            var builder = WebApplication.CreateBuilder(args);

            // Get the connection to connect to the database.
            string connectionString = ConnectionStringProvider.ConnectionString(args);


            // Check if the connection string is not null.
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

                // Load the data from the SSMS database into the in memory database.
                LoadTablesFromDatabase(app.Services);

                // Check if the Read part from the LocationCRUD is working.
                PawfectCareLtd.CRUD.LocationCRUD.ReadOperationForLocation("Address", "123 Main St Downtown City");

                //Check if the Read part from the OwnerCRUD is working
                PawfectCareLtd.CRUD.OwnerCRUD.ReadOperationForOwner("FirstName", "John");

                //Check if the Read part from the PetCRUD is working
                PawfectCareLtd.CRUD.PetCRUD.ReadOperationForPet("PetName", "Carl");

                //Check if the Read part from the PrescriptionCRUD is working
                PawfectCareLtd.CRUD.PrescriptionCRUD.ReadOperationForPrescription("Diagnosis", "Fungal Infection");

                //Check if the Read part from the AppointmentCRUD is working
                PawfectCareLtd.CRUD.AppointmentCRUD.ReadOperationForAppointment("ServiceType", "Checkup");




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

        // Method to take data from SQL database and populate the in memory database.
        private static void LoadTablesFromDatabase(IServiceProvider services)
        {
            // Connect to the SSMS database.
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            // Create a new instance of the in-built database.
            var db = new Database();

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
            db.AddTable(locationTable);

            // Appointment Table
            Table appointmentTable = new Table("Appointment", "AppointmentID", dbContext);
            foreach (var appt in dbContext.Appointments.ToList())
            {
                var record = new Record
                {
                    ["AppointmentID"] = appt.AppointmentID,
                    ["PetID"] = appt.PetID,
                    ["VetID"] = appt.VetID,
                    ["ServiceType"] = appt.ServiceType,
                    ["ApptDate"] = appt.ApptDate,
                    ["Status"] = appt.Status,
                    ["LocationID"] = appt.LocationID
                };
                appointmentTable.Insert(record, skipDb: true);
            }
            db.AddTable(appointmentTable);

            // Medication Table
            Table medicationTable = new Table("Medication", "MedicationID", dbContext);
            foreach (var med in dbContext.Medications.ToList())
            {
                var record = new Record
                {
                    ["MedicationID"] = med.MedicationID,
                    ["MedicationName"] = med.MedicationName,
                    ["SupplierID"] = med.SupplierID,
                    ["StockQuantity"] = med.StockQuantity,
                    ["Category"] = med.Category,
                    ["UnitPrice"] = med.UnitPrice,
                    ["ExpiryDate"] = med.ExpiryDate
                };
                medicationTable.Insert(record, skipDb: true);
            }
            db.AddTable(medicationTable);

            // Order Table
            Table orderTable = new Table("Order", "OrderID", dbContext);
            foreach (var order in dbContext.Orders.ToList())
            {
                var record = new Record
                {
                    ["OrderID"] = order.OrderID,
                    ["MedicationID"] = order.MedicationID,
                    ["Quantity"] = order.Quantity,
                    ["OrderDate"] = order.OrderDate,
                    ["OrderStatus"] = order.OrderStatus
                };
                orderTable.Insert(record, skipDb: true);
            }
            db.AddTable(orderTable);

            // Owner Table
            Table ownerTable = new Table("Owner", "OwnerID", dbContext);
            foreach (var owner in dbContext.Owners.ToList())
            {
                var record = new Record
                {
                    ["OwnerID"] = owner.OwnerID,
                    ["FirstName"] = owner.FirstName,
                    ["LastName"] = owner.LastName,
                    ["PhoneNo"] = owner.PhoneNo,
                    ["Email"] = owner.Email,
                    ["Address"] = owner.Address
                };
                ownerTable.Insert(record, skipDb: true);
            }
            db.AddTable(ownerTable);

            // Payment Table
            Table paymentTable = new Table("Payment", "BillID", dbContext);
            foreach (var payment in dbContext.Payments.ToList())
            {
                var record = new Record
                {
                    ["BillID"] = payment.BillID,
                    ["AppointmentID"] = payment.AppointmentID,
                    ["Total_amt"] = payment.TotalAmount,
                    ["Payment_Date"] = payment.PaymentDate,
                    ["Payment_Status"] = payment.PaymentStatus
                };
                paymentTable.Insert(record, skipDb: true);
            }
            db.AddTable(paymentTable);

            // Prescription Table
            Table prescriptionTable = new Table("Prescription", "PrescriptionID", dbContext);
            foreach (var pres in dbContext.Prescriptions.ToList())
            {
                var record = new Record
                {
                    ["PrescriptionID"] = pres.PrescriptionID,
                    ["PetID"] = pres.PetID,
                    ["IssueDate"] = pres.DateIssued,
                    ["VetID"] = pres.VetID,
                    ["Diagnosis"] = pres.Diagnosis
                };
                prescriptionTable.Insert(record, skipDb: true);
            }
            db.AddTable(prescriptionTable);

            // Pet Table
            Table petTable = new Table("Pet", "PetID", dbContext);
            foreach (var pet in dbContext.Pets.ToList())
            {
                var record = new Record
                {
                    ["PetID"] = pet.PetID,
                    ["OwnerID"] = pet.OwnerID,
                    ["PetName"] = pet.PetName,
                    ["PetType"] = pet.PetType,
                    ["Breed"] = pet.Breed,
                    ["Age"] = pet.Age
                };
                petTable.Insert(record, skipDb: true);
            }
            db.AddTable(petTable);

            // Supplier Table
            Table supplierTable = new Table("Supplier", "SupplierID", dbContext);
            foreach (var supp in dbContext.Suppliers.ToList())
            {
                var record = new Record
                {
                    ["SupplierID"] = supp.SupplierID,
                    ["SupplierName"] = supp.SupplierName,
                    ["PhoneNumber"] = supp.PhoneNumber,
                    ["Address"] = supp.Address,
                    ["Email"] = supp.Email
                };
                supplierTable.Insert(record, skipDb: true);
            }
            db.AddTable(supplierTable);

            // Vet Table
            Table vetTable = new Table("Vet", "VetID", dbContext);
            foreach (var vet in dbContext.Vet.ToList())
            {
                var record = new Record
                {
                    ["VetID"] = vet.VetID,
                    ["VetName"] = vet.VetName,
                    ["Specialisation"] = vet.Specialisation,
                    ["PhoneNo"] = vet.PhoneNo,
                    ["Email"] = vet.Email,
                    ["Address"] = vet.Address
                };
                vetTable.Insert(record, skipDb: true);
            }
            db.AddTable(vetTable);


            // Make the database that in-built database a static so that it can be assess gobally.
            InMemoryDatabase.InMemoryDatabaseInstance = db;
        }


        // Test method to see if data has been inserted correctly into the database.
        private static void DisplayRecord(Table Table, string ID)
        {
            try
            {
                // Get the record from the hash table using the primary key (LocationID)
                var record = Table.Get(ID);

                // Display the record fields
                Console.WriteLine("Location Record:");
                foreach (var field in record.Fields)
                {
                    Console.WriteLine($"{field.Key}: {field.Value}");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"No record found for LocationID: {ID}");
            }
        }

    }
}