namespace PawfectCareLtd.Repositories
{
    // Interface to define the bulk insert operations for various entities of the PetCare Management System.
    public interface IBulkInsertRepository
    {
        // Methods to bulk insert all entities data into tables from CSV files.
        void BulkInsertOwners(string filePath);
        void BulkInsertPets(string filePath);
        void BulkInsertVets(string filePath);
        void BulkInsertAppointments(string filePath);
        void BulkInsertSuppliers(string filePath);
        void BulkInsertOrders(string filePath);
        void BulkInsertMedications(string filePath);
        void BulkInsertPrescriptions(string filePath);
        void BulkInsertLocations(string filePath);
    }

}
