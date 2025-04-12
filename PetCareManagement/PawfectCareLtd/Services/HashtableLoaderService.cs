// Import necessary namespaces.
using PawfectCareLtd.Data; // For accessing the application's database context.
using PawfectCareLtd.Repositories.HashTableDatabaseLoader; // Interface for loading data into in-memory hash tables.

namespace PawfectCareLtd.Services
{
    /// <summary>
    /// Service responsible for managing the loading of all tables
    /// from the database into the in-memory hash table structure.
    /// </summary>
    public class HashtableLoaderService
    {
        private readonly IHashTableDatabaseLoader _hashTableDatabaseLoader; // Dependency to perform the actual loading.
        private readonly DatabaseContext _dbContext; // Database context used to query data.

        // Constructor
        public HashtableLoaderService(IHashTableDatabaseLoader hashTableDatabaseLoader, DatabaseContext dbContext)
        {
            _hashTableDatabaseLoader = hashTableDatabaseLoader;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Loads all the relevant tables from the SQL database into in-memory hash tables.
        /// This method is called at startup to preload data for fast CRUD operations.
        /// </summary>
        public async Task LoadAllTablesAsync()
        {
            // Call each loader method to populate the in-memory hash tables.
            await _hashTableDatabaseLoader.LoadLocationTable(_dbContext);
            await _hashTableDatabaseLoader.LoadAppointmentTable(_dbContext);
            await _hashTableDatabaseLoader.LoadMedicationTable(_dbContext);
            await _hashTableDatabaseLoader.LoadOrderTable(_dbContext);
            await _hashTableDatabaseLoader.LoadOwnerTable(_dbContext);
            await _hashTableDatabaseLoader.LoadPaymentTable(_dbContext);
            await _hashTableDatabaseLoader.LoadPrescriptionTable(_dbContext);
            await _hashTableDatabaseLoader.LoadPetTable(_dbContext);
            await _hashTableDatabaseLoader.LoadSupplierTable(_dbContext);
            await _hashTableDatabaseLoader.LoadVetTable(_dbContext);
        }
    }
}
