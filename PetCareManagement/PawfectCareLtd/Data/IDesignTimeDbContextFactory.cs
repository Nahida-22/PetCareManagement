// Import dependencies.
using Microsoft.EntityFrameworkCore; // Import the entity framework for databases related operation.
using Microsoft.EntityFrameworkCore.Design; // Import the design time factory interface for creating a DBContext.
using Microsoft.Extensions.Configuration; // Import the configurator to read the app settings.
using System.IO; // Import system IO to work with file directories.


namespace PawfectCareLtd.Data // Define the namespace for the application.
{
    // Class that implements the IDesignTimeDbContextFactory interface at design time.
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {

        // Method that is needed by IDesignTimeDbContextFactory interface to create an instance of databasecontext.
        public DatabaseContext CreateDbContext(string[] args)
        {

            // Create the configurator to load the configuration setting.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Give the directory.
                .AddJsonFile("appsettings.Development.json") // Set the JSON configuration file.
                .Build(); // Build the configuration.

            // Get the connection string the configurator.
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Create the Dbcontext option builder.
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            // Set up the Db context option builder to use the connection string.
            optionsBuilder.UseSqlServer(connectionString);

            // Return a new instance of DatabaseContext using the configured options.
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}