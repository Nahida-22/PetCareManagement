using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using Microsoft.AspNetCore.Http;
using PawfectCareLtd.Repositories;
using Humanizer;

namespace PawfectCareLtd.Controllers
{
    /// <summary>
    /// API Controller for managing veterinarians.
    /// Handles requests related to veterinarians (CRUD operations).
    /// </summary>
    
    [ApiController]
    [Route("api/[controller]")] // Route --> "api/vet"

    public class VetController : ControllerBase
    {
        // Inject the Vet repository interface.
        private readonly IVetRepository _vetRepository;

        // Constructor to inject the repository dependency.
        public VetController(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }

        // Retrieves a list of all veterinarians.
        [HttpGet]
        public async Task <IActionResult> GetAllVets()
        {
            // Call GetAllVetsAsync() to fetch all vets from the database.
            var vets = await _vetRepository.GetAllVetsAsync();

            // Returns HTTP 200 OK with the list of vets.
            return Ok(vets);
        }

    }
}