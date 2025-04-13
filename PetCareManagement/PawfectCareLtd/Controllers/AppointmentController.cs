using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.CRUD;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Helpers;
using PawfectCareLtd.Models.DTO;
using PawfectCareLtd.Services;


namespace PawfectCareLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly Database _database;
        private readonly AppointmentCRUD _appointmentCRUD;
        private readonly BookAppointmentService _bookAppointmentService;

        public AppointmentController(Database database, AppointmentCRUD appointmentCRUD, BookAppointmentService bookAppointmentService)
        {
            _database = database;
            _appointmentCRUD = appointmentCRUD;
            _bookAppointmentService = bookAppointmentService;
        }

        [HttpGet] // Get all Appointments.
        public IActionResult GetAllOwners()
        {
            var appointmentsTable = _database.GetTable("Appointment");

            var appointmentsList = appointmentsTable.GetAll().Select(r => new
            {
                AppointmentID = r["AppointmentID"],
                PetID = r["PetID"],
                VetID = r["VetID"],
                ServiceType = r["ServiceType"],
                ApptDate = r["ApptDate"],
                Status = r["Status"],
                LocationID = r["LocationID"],

            }).ToList();

            return Ok(appointmentsList);
        }


        [HttpGet("search")]
        public IActionResult SearchAppointments([FromQuery] Dictionary<string, string> query)
        {
            if (query.Count == 0)
                return BadRequest("Please provide at least one search field and value.");

            // Define expected field types (optional: you can also make this dynamic later)
            var fieldTypes = new Dictionary<string, string>
            {
                { "AppointmentID", "string" },
                { "PetID", "string" },
                { "VetID", "string" },
                { "ServiceType", "string" },
                { "ApptDate", "string" },
                { "Status", "string" },
                { "LocationID", "string" }
            };

            // Filter the query only to include valid fields from your system
            var searchFields = query
                .Where(q => fieldTypes.ContainsKey(q.Key) && !string.IsNullOrEmpty(q.Value))
                .ToDictionary(q => q.Key, q => q.Value);

            if (searchFields.Count == 0)
                return BadRequest("None of the provided fields are valid or non-empty.");

            var helper = new InMemorySearchHelper(_database);
            var results = helper.FindRecordsByFields("Appointment", searchFields);

            if (results.Count == 0)
                return NotFound("No matching appointments found.");

            return Ok(results);
        }

        [HttpPost("book")]
        public IActionResult BookAppointment([FromBody] AppointmentRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request data.");

            if (string.IsNullOrWhiteSpace(request.VetID))
                return BadRequest("VetID is required.");

            var resultMessage = _bookAppointmentService.BookAppointment(
                request.FirstName,
                request.LastName,
                request.PetName,
                request.AppointmentDate,
                request.Location,
                request.ServiceType,
                request.VetID 
            );

            return Ok(resultMessage);
        }


    }

    public class AppointmentRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PetName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Location { get; set; }
        public string ServiceType { get; set; }
        public string VetID { get; set; }  // <-- Add this
    }


}
