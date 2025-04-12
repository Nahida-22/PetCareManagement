// Import required namespaces.
using PawfectCareLtd.Data;

namespace PawfectCareLtd.Repositories.HashTableDatabaseLoader
{
    /// <summary>
    /// Interface defining methods for loading different tables from the database
    /// into an in-memory hash table structure for fast access and manipulation.
    /// </summary>
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
