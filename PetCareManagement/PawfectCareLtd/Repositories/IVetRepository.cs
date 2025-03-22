using PawfectCareLtd.Models;

namespace PawfectCareLtd.Repositories
{
    public interface IVetRepository
    {
        Task<IEnumerable<Vet>> GetAllVetsAsync();
        Task<Vet> GetVetByIdAsync(string vetId);
        Task AddVetAsync(Vet vet);
        Task UpdateVetAsync(Vet vet);
        Task DeleteVetAsync(string vetId);
    }
}
