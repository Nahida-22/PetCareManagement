using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Models;
using System.IO;
using System.Linq;

namespace PawfectCareLtd.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Vet> Vet { get; set; }

        public void BulkInsertVets(string csvFilePath)
        {
            if (!Vet.Any()) // Ensure data is inserted only once
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
                this.BulkInsert(vets, bulkConfig);
            }
        }
    }
}
