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

    // Class of the Owner controler.
    public class OwnerController : Controller
    {

        // Declare a field for the Owner CRUD Operation
        private readonly OwnerCRUD _ownerCRUD;



        // Contructor for the Owner controller class.
        public OwnerController(OwnerCRUD ownerCRUD)
        {
            _ownerCRUD = ownerCRUD;// Assign the injected Owner CRUD operation.
        }



        // Post Owner API.
        [HttpPost]
        public IActionResult CreateOwner([FromBody] OwnerDTO ownerDto)
        {

            // Create a dictionary is to hold the field names and their corresponding values for a Owner.
            var fieldValues = new Dictionary<string, object>
            {
                { "OwnerID", ownerDto.OwnerID },
                { "FirstName", ownerDto.FirstName },
                { "LastName", ownerDto.LastName },
                { "PhoneNo", ownerDto.PhoneNo },
                { "Email", ownerDto.Email },
                { "Address", ownerDto.Address }
            };

            // Define the primary key for the Owner Table.
            var primaryKeyName = "OwnerID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^O\d{5}$";

            // List of foreign key in the Owner table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)> {};

            // Get the result of the insert operation in the Owner table.
            var result = _ownerCRUD.InsertOperationForOwner(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Owner API.
        [HttpGet]
        public IActionResult ReadOwner(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Owner table.
            var result = _ownerCRUD.ReadOperationForOwner(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Owner API.
        [HttpPut]
        public IActionResult UpdateOwner(string ownerId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Owner table.
            var result = _ownerCRUD.UpdateOperationForOwner(ownerId, fieldName, newValue, isForeignKey, referencedTableName);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // DELETE Owner API.
        [HttpDelete]
        public IActionResult DeleteOwner(string ownerId)
        {
            // Get the result of the read operation in the Owner table.
            var result = _ownerCRUD.DeleteOwnerById(ownerId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Owner records API.
        [HttpGet("all")]
        public IActionResult GetAllLocation()
        {
            // Get the result of getting all of the record from Owner table.
            var result = _ownerCRUD.GetAllOwnerRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }




        // Class to represent data transfer object for owner.
        public class OwnerDTO
        {
            // Property to store the Owner unique identifier.
            public string OwnerID { get; set; }

            // Property to store the owner's first name.
            public string FirstName { get; set; }

            // Property to store the owner's last name.
            public string LastName { get; set; }

            // Property to store the owner's phone number.
            public string PhoneNo { get; set; }

            // Property to store the owner's email address.
            public string Email { get; set; }

            // Property to store the owner's physical address.
            public string Address { get; set; }
        }
    }
}
