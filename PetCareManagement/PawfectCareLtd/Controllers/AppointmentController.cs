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

    // Class of the Appointment controler.
    public class AppointmentController : Controller
    {

        // Declare a field for the Appointment CRUD Operation
        private readonly AppointmentCRUD _appointmentCRUD;



        // Contructor for the Appointment controller class.
        public AppointmentController(AppointmentCRUD appointmentCRUD)
        {
            _appointmentCRUD = appointmentCRUD;// Assign the injected Appointment CRUD operation.
        }



        // Post Appointment API.
        [HttpPost]
        public IActionResult CreateAppointment([FromBody] Dictionary<string, object> fieldValues)
        {
            // Define the primary key for the Appointment Table.
            var primaryKeyName = "AppointmentID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^A\d{5,}$";

            // List of foreign key in the Appointment table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)>
            {
                ("LocationID", "Location"),
                ("PetID", "Pet"),
                ("VetID", "Vet")
            };

            // Get the result of the insert operation in the Appointment table.
            var result = _appointmentCRUD.InsertOperationForAppointment(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Appointment API.
        [HttpGet]
        public IActionResult ReadAppointment(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Appointment table.
            var result = _appointmentCRUD.ReadOperationForAppointment(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Appointment API
        [HttpPut]
        public IActionResult UpdateAppointment(string appointmentId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Appointment table.
            var result = _appointmentCRUD.UpdateOperationForAppointment(appointmentId, fieldName, newValue, isForeignKey, referencedTableName);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // DELETE Appointment API.
        [HttpDelete]
        public IActionResult DeleteAppointment(string appointmentId)
        {
            // Get the result of the read operation in the Appointment table.
            var result = _appointmentCRUD.DeleteAppointmentbyId(appointmentId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Appointment records API.
        [HttpGet("all")]
        public IActionResult GetAllAppointments()
        {
            // Get the result of getting all of the record from Appointment table.
            var result = _appointmentCRUD.GetAllAppointmentRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }
    }
}