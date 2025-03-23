using Microsoft.EntityFrameworkCore;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PawfectCareLtd.Repositories
{
    public class VetRepository : IVetRepository
    {
        // Field to hold the DatabaseContext instance.
        private readonly DatabaseContext _databaseContext;

        // Constructor
        public VetRepository(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Vet>> GetAllVetsAsync()
        {
            return await _databaseContext.Vet.ToListAsync();
        }

        public async Task<Vet> GetVetByIdAsync(string vetId)
        {
            var vet = await _databaseContext.Vet.FirstOrDefaultAsync( v=> v.VetID == vetId);
            if (vet == null)
            {
                throw new KeyNotFoundException($"DATA FOR VET WITH ID {vetId} IS NOT FOUND");
            }
            return vet;
        }

        public async Task AddVetAsync(Vet vet) 
        {
            await _databaseContext.AddAsync(vet);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateVetAsync(Vet vet)
        {
            _databaseContext.Vet.Update(vet);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteVetAsync(string vetId)
        {
            var vet = await _databaseContext.Vet.FindAsync(vetId);
            if (vet != null)
            {
                _databaseContext.Vet.Remove(vet);
                await _databaseContext.SaveChangesAsync();
            }
        }

    }
}
