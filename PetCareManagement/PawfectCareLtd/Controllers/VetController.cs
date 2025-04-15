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

    // Class of the Vet controler.
    public class VetController : Controller
    {

        // Declare a field for the Vet CRUD Operation
        private readonly VetCRUD _vetCRUD;



        // Contructor for the Vet controller class.
        public VetController(VetCRUD vetCRUD)
        {
            _vetCRUD = vetCRUD;// Assign the injected Vet CRUD operation.
        }



        // Post Vet API.
        [HttpPost]
        public IActionResult CreateVet([FromBody] VetDTO vetDto)
        {

            // Create a dictionary is to hold the field names and their corresponding values for a Suppplier.
            var fieldValues = new Dictionary<string, object>
            {
                { "VetID", vetDto.VetID },
                { "VetName", vetDto.VetName },
                { "Specialisation", vetDto.Specialisation },
                { "PhoneNo", vetDto.PhoneNo },
                { "Email", vetDto.Email },
                { "Address", vetDto.Address }
            };

            // Define the primary key for the Vet Table.
            var primaryKeyName = "VetID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^V\d{4}$";

            // List of foreign key in the Vet table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)> { };

            // Get the result of the insert operation in the Vet table.
            var result = _vetCRUD.InsertOperationForVet(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Vet API.
        [HttpGet]
        public IActionResult ReadVet(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Vet table.
            var result = _vetCRUD.ReadOperationForVet(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Vet API
        [HttpPut]
        public IActionResult UpdateVet(string vetId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Vet table.
            var result = _vetCRUD.UpdateOperationForVet(vetId, fieldName, newValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        



        // GET all Vet records API.
        [HttpGet("all")]
        public IActionResult GetAllVet()
        {
            // Get the result of getting all of the record from Vet table.
            var result = _vetCRUD.GetAllVetRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }




        // Class to represent data transfer object for veterinarian.
        public class VetDTO
        {
            // Property to store the unique identifier for the vet.
            public string VetID { get; set; }

            // Property to store the vet's full name.
            public string VetName { get; set; }

            // Property to store the vet's specialisation.
            public string Specialisation { get; set; }

            // Property to store the vet's phone number.
            public string PhoneNo { get; set; }

            // Property to store the vet's email address.
            public string Email { get; set; }

            // Property to store the vet's address.
            public string Address { get; set; }
        }

    }
}