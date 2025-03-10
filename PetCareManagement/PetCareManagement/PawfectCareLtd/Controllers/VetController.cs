using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using Microsoft.AspNetCore.Http;

namespace PawfectCareLtd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VetController : ControllerBase
    {
        private readonly DatabaseContext vetContext;

        public VetController(DatabaseContext vetContext) 
        {
            this.vetContext = vetContext;
        }

        [HttpGet]
        [Route ("GetVets")]
        public List<Vet> GetVets()
        {
            return vetContext.Vet.ToList();
        }

        [HttpPost]
        [Route ("AddVet")]

        public string AddVet(Vet vet)
        {
            string response = string.Empty;
            vetContext.Vet.Add(vet);
            vetContext.SaveChanges();
            return "Vet added";
        }
    }
}
