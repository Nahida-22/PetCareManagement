using Microsoft.EntityFrameworkCore;

namespace PawfectCareLtd.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                try
                {
                    context.Database.Migrate();
                    Console.WriteLine("Database migration applied successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error applying migrations: {ex.Message}");
                }
            }
        }
    }

}
