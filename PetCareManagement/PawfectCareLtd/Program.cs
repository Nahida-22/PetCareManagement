using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using PawfectCareLtd.Repositories;
using PawfectCareLtd.Services;
using System.IO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly;
using Microsoft.AspNetCore.Builder;


public class Program
{
    public static void Main(string[] args)
    {
        // Create builder for the web application.
        var builder = WebApplication.CreateBuilder(args);

        // Add Database Context to the service container and configure to use default connection string.
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register MVC controllers and Blazor components
        builder.Services.AddRazorComponents();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        // Register HttpClient for dependency injection
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7038/") });

        // Add support for MVC Controllers AND Razor Views
        builder.Services.AddControllersWithViews();

        // Add Swagger for API documentation.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register CsvImportService as a scoped service (one instance per request).
        builder.Services.AddScoped<CsvImportService>();

        // Register IBulkInsertRepository with its implementation BulkInsertRepository for dependency injection.
        builder.Services.AddScoped<IBulkInsertRepository, BulkInsertRepository>();

        // Register IVetRepository with its implementation VetRepository for dependency injection.
        builder.Services.AddScoped<IVetRepository, VetRepository>();

        // Register VetService.
        builder.Services.AddScoped<VetService>();


        // Build the web application.
        var app = builder.Build();

        // Apply any pending database migrations at application startup.
        DatabaseInitializer.Initialize(app.Services);

        // Import CSV data into the database on startup.
        using (var scope = app.Services.CreateScope())
        {
            // Retrieve the CsvImportService from DI container and run the import process.
            var csvService = scope.ServiceProvider.GetRequiredService<CsvImportService>();
            csvService.ImportData();
        }


        // Use Swagger for API documentation only in development environment.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Enable HTTPS redirection for secure communication
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();


        // Enable Blazor component routing
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

        // Run the application.
        app.Run();
    }
}
