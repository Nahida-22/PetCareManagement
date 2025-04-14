//Import dependencies.
using Microsoft.AspNetCore.Mvc; // Import ASP.Net Core MVC.
using PawfectCareLtd.CRUD; // Import CRUD Operation
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.
using PawfectCareLtd.Models.DTO; // Import the Data-Transfer-Object.
using PawfectCareLtd.Services; // Import services layer logic.


namespace PawfectCareLtd.Controllers // Define the namespace for the application
{
    // Define the route prefix as apiController
    [Route("api/[controller]")]
    // Spwcifi that is an api controller,
    [ApiController]

    // Class of the Location controler.
    public class LocationController : Controller
    {

        // Declare a field for the Location CRUD Operation
        private readonly LocationCRUD _locationCRUD;



        // Contructor for the Appointment controller class.
        public LocationController(LocationCRUD locationCRUD)
        {
            _locationCRUD = locationCRUD;// Assign the injected Location CRUD operation.
        }



        // Post Appointment API.
        [HttpPost]
        public IActionResult CreateLocation([FromBody] Dictionary<string, object> fieldValues)
        {
            // Define the primary key for the Location Table.
            var primaryKeyName = "LocationID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^L\d{3}$";

            // List of foreign key in the Location table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)> {};

            // Get the result of the insert operation in the Location table.
            var result = _locationCRUD.InsertOperationForLocation(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Location API.
        [HttpGet]
        public IActionResult ReadLocation(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Location table.
            var result = _locationCRUD.ReadOperationForLocation(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Location API.
        [HttpPut]
        public IActionResult UpdateLocation(string appointmentId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Location table.
            var result = _locationCRUD.UpdateOperationForLocation(appointmentId, fieldName, newValue, isForeignKey, referencedTableName);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // DELETE Location API.
        [HttpDelete]
        public IActionResult DeleteLocation(string locationId)
        {
            // Get the result of the read operation in the Location table.
            var result = _locationCRUD.DeleteLocationtbyId(locationId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Location records API.
        [HttpGet("all")]
        public IActionResult GetAllLocation()
        {
            // Get the result of getting all of the record from Location table.
            var result = _locationCRUD.GetAllLocationRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }
    }
}
