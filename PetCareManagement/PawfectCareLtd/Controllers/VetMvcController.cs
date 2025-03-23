using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Models;
using PawfectCareLtd.Repositories;
using System.Threading.Tasks;

namespace PawfectCareLtd.Controllers
{
    public class VetMvcController : Controller
    {
        private readonly IVetRepository _vetRepository;

        public VetMvcController(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }

        // GET: /VetMvc/Index
        public async Task<IActionResult> Index()
        {
            var vets = await _vetRepository.GetAllVetsAsync();
            return View(vets); // Pass data to the view
        }
    }
}
