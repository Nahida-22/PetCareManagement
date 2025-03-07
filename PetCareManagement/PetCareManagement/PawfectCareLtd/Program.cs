using Microsoft.EntityFrameworkCore;

using PawfectCareLtd.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Set up database connection from configuration file
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add CSV reading service
            builder.Services.AddSingleton<CsvReaderService>();

        // Build the app
        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }


