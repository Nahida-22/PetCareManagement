

using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using Microsoft.AspNetCore.Http;

namespace PawfectCareLtd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PetController : ControllerBase
    {
        private readonly DatabaseContext petContext;

        public PetController(DatabaseContext petContext)
        {
            this.petContext = petContext;
        }

        [HttpGet]
        [Route("GetPets")]
        public List<Pet> GetPets()
        {
            return petContext.Pets.ToList();
        }

        [HttpPost]
        [Route("AddPet")]

        public string AddPet(Pet pet)
        {
            string response = string.Empty;
            petContext.Pets.Add(pet);
            petContext.SaveChanges();
            return "Vet added";
        }
    }
}
