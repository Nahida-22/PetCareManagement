// Import dependencies.
using Microsoft.EntityFrameworkCore; // Import the entity framework for databases related operation.


namespace PawfectCareLtd.Data // Define the namespace for the application.
{
    public static class DatabaseInitialiser
    {

        // Method that initialise the database using dependency injection.
        public static void Initialise(IServiceProvider serviceProvider)
        {
            // Create a scope 
            using (var scope = serviceProvider.CreateScope())
            {
                // Get the database context instance from the service provider.
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                try
                {
                    // Add every migration.
                    context.Database.Migrate();
                    Console.WriteLine("Database migration applied successfully."); // Output that migration has been a success.
                }
                catch (Exception ex) // Handle any exception.
                {
                    Console.WriteLine($"Error applying migrations: {ex.Message}"); // Output the error.
                }
            }
        }
    }
}