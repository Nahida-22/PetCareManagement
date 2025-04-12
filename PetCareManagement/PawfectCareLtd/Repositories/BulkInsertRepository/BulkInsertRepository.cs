using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.Repositories.BulkInsertRepository
{
    /// <summary>
    /// Repository for performing bulk insert operations into the database for various entities.
    /// Uses EFCore.BulkExtensions to efficiently insert large datasets from CSV files.
    /// </summary>
    public class BulkInsertRepository : IBulkInsertRepository
    {
        // Field to hold the DatabaseContext instance.
        private readonly DatabaseContext _databaseContext;

        // Constructor: Initialises the BulkInsertRepository with the provided DatabaseContext.
        // This provides access to the database context for performing operations.
        public BulkInsertRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Method to bulk insert Owners data from a CSV file into the Owners table
        public void BulkInsertOwners(string csvFilePath)
        {
            if (!_databaseContext.Owners.Any()) // Ensure data is inserted only once
            {
                var owners = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Owner
                    {
                        OwnerID = data[0].Trim(),
                        FirstName = data[1].Trim(),
                        LastName = data[2].Trim(),
                        PhoneNo = data[3].Trim(),
                        Email = data[4].Trim(),
                        Address = data[5].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(owners, bulkConfig);
                _databaseContext.SaveChanges();

            }
        }

        //Method to bulk insert Vets data from a CSV file into the Vet table
        public void BulkInsertVets(string csvFilePath)
        {
            if (!_databaseContext.Vet.Any()) // Ensure data is inserted only once
            {
                var vets = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Vet
                    {
                        VetID = data[0].Trim(),
                        VetName = data[1].Trim(),
                        Specialisation = data[2].Trim(),
                        PhoneNo = data[3].Trim(),
                        Email = data[4].Trim(),
                        Address = data[5].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(vets, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }

        // Method to bulk insert Pets data from a CSV file into the Pet table
        public void BulkInsertPets(string csvFilePath)
        {
            if (!_databaseContext.Pets.Any()) // Ensure data is inserted only once
            {
                var pets = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Pet
                    {
                        PetID = data[0].Trim(),
                        OwnerID = data[1].Trim(),
                        PetName = data[2].Trim(),
                        PetType = data[3].Trim(),
                        Breed = data[4].Trim(),
                        Age = data[5].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(pets, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }

        // Method to bulk insert Appointments data from a CSV file into the Appointment table
        public void BulkInsertAppointments(string csvFilePath)
        {
            if (!_databaseContext.Appointments.Any()) // Ensure data is inserted only once
            {
                var appointments = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Appointment
                    {
                        AppointmentID = data[0].Trim(),
                        PetID = data[1].Trim(),
                        VetID = data[2].Trim(),
                        ServiceType = data[3].Trim(),
                        ApptDate = DateTime.ParseExact(data[4].Trim(),
                               new[] { "M/d/yyyy", "MM/dd/yyyy" },
                               System.Globalization.CultureInfo.InvariantCulture,
                               System.Globalization.DateTimeStyles.None),
                        Status = data[5].Trim(),
                        LocationID = data[6].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(appointments, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }

        // Method to bulk insert Suppliers data from a CSV file into the Supplier table
        public void BulkInsertSuppliers(string csvFilePath)
        {
            if (!_databaseContext.Suppliers.Any()) // Ensure data is inserted only once
            {
                var suppliers = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Supplier
                    {
                        SupplierID = data[0].Trim(),
                        SupplierName = data[1].Trim(),
                        PhoneNumber = data[2].Trim(),
                        Address = data[3].Trim(),
                        Email = data[4].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(suppliers, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }

        // Method to bulk insert Orders data from a CSV file into the Order table
        public void BulkInsertOrders(string csvFilePath)
        {
            if (!_databaseContext.Orders.Any()) // Ensure data is inserted only once
            {
                var orders = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Order
                    {
                        OrderID = data[0].Trim(),
                        MedicationID = data[1].Trim(),
                        Quantity = int.Parse(data[2].Trim()),
                        OrderDate = DateTime.Parse(data[3].Trim()),
                        OrderStatus = data[4].Trim()
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(orders, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }

        // Method to bulk insert Medications data from a CSV file into the Medication table.
        public void BulkInsertMedications(string csvFilePath)
        {
            if (!_databaseContext.Medications.Any()) // Ensure data is inserted only once
            {
                var medications = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Medication
                    {
                        MedicationID = data[0].Trim(),
                        MedicationName = data[1].Trim(),
                        SupplierID = data[2].Trim(),
                        StockQuantity = int.Parse(data[3].Trim()),
                        Category = data[4].Trim(),
                        UnitPrice = decimal.Parse(data[5].Trim()),
                        ExpiryDate = DateTime.ParseExact(data[6].Trim(),
                            "dd/MM/yyyy", // Parsing the date in the specified format
                            System.Globalization.CultureInfo.InvariantCulture)
                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(medications, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }

        // Method to bulk insert Prescriptions data from a CSV file into the Prescription table.
        public void BulkInsertPrescriptions(string csvFilePath)
        {
            if (!_databaseContext.Prescriptions.Any()) // Ensure data is inserted only once
            {
                var prescriptionList = new List<Prescription>();
                var prescriptionMedicationsList = new List<PrescriptionMedication>();

                var lines = File.ReadAllLines(csvFilePath).Skip(1); // Skip header

                foreach (var line in lines)
                {
                    var data = line.Split(',');

                    var prescription = new Prescription
                    {
                        PrescriptionID = data[0].Trim(),
                        PetID = data[1].Trim(),
                        VetID = data[2].Trim(),
                        Diagnosis = data[3].Trim(),
                        Dosage = data[4].Trim(),
                        DateIssued = DateTime.Parse(data[5].Trim())
                    };

                    prescriptionList.Add(prescription);

                    // Handle Many-to-Many Medication Relationship
                    var medicationIDs = data[6].Trim().Split(',');
                    foreach (var medID in medicationIDs)
                    {
                        prescriptionMedicationsList.Add(new PrescriptionMedication
                        {
                            PrescriptionID = prescription.PrescriptionID,
                            MedicationID = medID.Trim()
                        });
                    }
                }

                var bulkConfig = new BulkConfig { SetOutputIdentity = false };

                // Insert Prescriptions
                _databaseContext.BulkInsert(prescriptionList, bulkConfig);

                // Insert Prescription-Medication Relationships
                _databaseContext.BulkInsert(prescriptionMedicationsList, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }

        // Method to bulk insert Locations data from a CSV file into the Location table
        public void BulkInsertLocations(string csvFilePath)
        {
            if (!_databaseContext.Locations.Any()) // Ensure data is inserted only once
            {
                var locations = File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Location
                    {
                        LocationID = data[0].Trim(),
                        Name = data[1].Trim(),
                        Address = data[2].Trim(),
                        Phone = (data[3].Trim()),
                        Email = data[4].Trim(),

                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(locations, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }

        // Method to bulk insert payments data from a CSV file into the Payment table
        public void BulkInsertPayments(string csvFilePath)
        {
            if (!_databaseContext.Payments.Any()) // Ensure data is inserted only once
            {
                var payments =  File.ReadAllLines(csvFilePath)
                    .Skip(1) // Skip CSV header
                    .Select(line => line.Split(','))
                    .Select(data => new Payment
                    {
                        BillID = data[0].Trim(),
                        AppointmentID = data[1].Trim(),
                        TotalAmount = decimal.TryParse(data[2].Trim(), out decimal amount) ? amount : 0m, // Convert to decimal

                        PaymentDate = DateTime.TryParseExact(data[3].Trim(),
                            new[] { "M/d/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" }, // Multiple formats
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out DateTime parsedDate) ? parsedDate : (DateTime?)null, // Handle null date

                        PaymentStatus = data[4].Trim() 

                    }).ToList();

                var bulkConfig = new BulkConfig { SetOutputIdentity = false }; // Ensure no identity issue
                _databaseContext.BulkInsert(payments, bulkConfig);
                _databaseContext.SaveChanges();
            }
        }
    }
}

