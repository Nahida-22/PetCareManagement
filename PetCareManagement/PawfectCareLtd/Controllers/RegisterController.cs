using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.CRUD;

namespace PawfectCareLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly Register _registerService;

        public RegisterController(Register registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("new-owner-with-pet")]
        public IActionResult RegisterNewOwnerAndPet([FromBody] NewOwnerWithPetRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request payload.");

            _registerService.RegisterNewOwnerAndPet(
                request.FirstName,
                request.LastName,
                request.Phone,
                request.Email,
                request.Address,
                request.PetName,
                request.PetType,
                request.Breed,
                request.Age
            );

            return Ok("Owner and pet registered successfully.");
        }

        [HttpPost("existing-owner-add-pet")]
        public IActionResult RegisterPetForExistingOwner([FromBody] ExistingOwnerPetRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request payload.");

            _registerService.RegisterPetForExistingOwner(
                request.FirstName,
                request.LastName,
                request.PetName,
                request.PetType,
                request.Breed,
                request.Age
            );

            return Ok("Pet added to existing owner successfully.");
        }
    }

    // DTOs for request payloads
    public class NewOwnerWithPetRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string PetName { get; set; }
        public string PetType { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
    }

    public class ExistingOwnerPetRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PetName { get; set; }
        public string PetType { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
    }
}
