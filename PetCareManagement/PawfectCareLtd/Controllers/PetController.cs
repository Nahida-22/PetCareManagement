//Import dependencies.
using Microsoft.AspNetCore.Mvc; // Import ASP.Net Core MVC.
using PawfectCareLtd.CRUD; // Import CRUD Operation
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.
using PawfectCareLtd.Services; // Import services layer logic.

namespace PawfectCareLtd.Controllers // Define the namespace for the application
{
    // Define the route prefix as apiController
    [Route("api/[controller]")]
    // Spwcifi that is an api controller,
    [ApiController]

    // Class of the Pet controler.
    public class PetController : Controller
    {

        // Declare a field for the Pet CRUD Operation
        private readonly PetCRUD _petCRUD;



        // Contructor for the Pet controller class.
        public PetController(PetCRUD petCRUD)
        {
            _petCRUD = petCRUD;// Assign the injected Pet CRUD operation.
        }



        // Post Pet API.
        [HttpPost]
        public IActionResult CreatePet([FromBody] PetDTO petDto)
        {

            // Create a dictionary is to hold the field names and their corresponding values for a Pet.
            var fieldValues = new Dictionary<string, object>
            {
                { "PetID", petDto.PetID },
                { "OwnerID", petDto.OwnerID },
                { "PetName", petDto.PetName },
                { "PetType", petDto.PetType },
                { "Breed", petDto.Breed },
                { "Age", petDto.Age }
            };

            // Define the primary key for the Pet Table.
            var primaryKeyName = "PetID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^P\d{5}$";

            // List of foreign key in the Pet table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)>
            {
                ("OwnerID", "Owner")
            };

            // Get the result of the insert operation in the Pet table.
            var result = _petCRUD.InsertOperationForPet(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Pet API.
        [HttpGet]
        public IActionResult ReadPet(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Pet table.
            var result = _petCRUD.ReadOperationForPet(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Pet API
        [HttpPut]
        public IActionResult UpdatePet(string petId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Pet table.
            var result = _petCRUD.UpdateOperationForPet(petId, fieldName, newValue, isForeignKey, referencedTableName);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // DELETE Pet API.
        [HttpDelete]
        public IActionResult DeletePet(string petId)
        {
            // Get the result of the read operation in the Pet table.
            var result = _petCRUD.DeletePetById(petId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Pet records API.
        [HttpGet("all")]
        public IActionResult GetAllPet()
        {
            // Get the result of getting all of the record from Appointment table.
            var result = _petCRUD.GetAllPetRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }




        // Class to represent data transfer object for pet.
        public class PetDTO
        {
            // Property to store the pet unique identifier.
            public string PetID { get; set; }

            // Property to store the Owner unique identifier.
            public string OwnerID { get; set; }

            // Property to store the name of the pet.
            public string PetName { get; set; }

            // Property to store type of the pet.
            public string PetType { get; set; }

            // Property to store the bread of the pet.
            public string Breed { get; set; }

            // Property to store the age of the pet.
            public int Age { get; set; }
        }
    }
}