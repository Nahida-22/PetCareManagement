using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.Data
{
    public class VetContext :DbContext
    {
        public VetContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vet> Vet { get; set; }

    }
}
