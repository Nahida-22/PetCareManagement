using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.CRUD;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.Helpers;


namespace PawfectCareLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly Database _database;
        private readonly AppointmentCRUD _appointmentCRUD;

        public AppointmentController(Database database, AppointmentCRUD appointmentCRUD)
        {
            _database = database;
            _appointmentCRUD = appointmentCRUD;
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
        public IActionResult SearchOwners([FromQuery] Dictionary<string, string> query)
        {
            if (query.Count == 0)
                return BadRequest("Please provide at least one search field and value.");

            // Define expected field types (optional: you can also make this dynamic later)
            var fieldTypes = new Dictionary<string, string>
            {
                { "FirstName", "string" },
                { "LastName", "string" },
                { "Email", "string" },
                { "PhoneNo", "string" },
                { "Address", "string" }

            };

            // Filter the query only to include valid fields from your system
            var searchFields = query
                .Where(q => fieldTypes.ContainsKey(q.Key) && !string.IsNullOrEmpty(q.Value))
                .ToDictionary(q => q.Key, q => q.Value);

            if (searchFields.Count == 0)
                return BadRequest("None of the provided fields are valid or non-empty.");

            var helper = new InMemorySearchHelper(_database);
            var results = helper.FindRecordsByFields("Owner", searchFields);

            if (results.Count == 0)
                return NotFound("No matching owners found.");

            return Ok(results);
        }
    }
}
