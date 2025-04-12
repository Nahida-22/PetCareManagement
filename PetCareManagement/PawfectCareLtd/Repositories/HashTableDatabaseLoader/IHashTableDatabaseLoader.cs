// Import dependencies.
using PawfectCareLtd.Data; // Imports the application's database context.


namespace PawfectCareLtd.Repositories.HashTableDatabaseLoader // Define the namespace for the application.
{

    // Declare an interface for loading data from SSMS into into the custom in memory database.
    public interface IHashTableDatabaseLoader
    {
        // Methods to load all tables from SQL Database into the in-memory hash table.
        Task LoadLocationTable(DatabaseContext dbContext);
        Task LoadAppointmentTable(DatabaseContext dbContext);
        Task LoadMedicationTable(DatabaseContext dbContext);
        Task LoadOrderTable(DatabaseContext dbContext);
        Task LoadOwnerTable(DatabaseContext dbContext);
        Task LoadPaymentTable(DatabaseContext dbContext);
        Task LoadPrescriptionTable(DatabaseContext dbContext);
        Task LoadPetTable(DatabaseContext dbContext);
        Task LoadSupplierTable(DatabaseContext dbContext);
        Task LoadVetTable(DatabaseContext dbContext);
    }
}
