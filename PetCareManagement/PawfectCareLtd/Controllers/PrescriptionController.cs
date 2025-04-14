using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PawfectCareLtd.Data;
using PawfectCareLtd.Models;
using Microsoft.AspNetCore.Http;
using PawfectCareLtd.Data.DataRetrieval;
using PawfectCareLtd.CRUD;
using PawfectCareLtd.Helpers;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace PawfectCareLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly Database _database;
        private readonly PrescriptionCRUD _prescriptionCrud;

        public PrescriptionController(Database database, PrescriptionCRUD prescriptionCrud)
        {
            _database = database;
            _prescriptionCrud = prescriptionCrud;
        }

        // GET: api/prescription
        [HttpGet]
        public IActionResult GetAllPrescriptions()
        {
            var prescriptionTable = _database.GetTable("Prescription");

            var prescriptions = prescriptionTable.GetAll().Select(r => new
            {
                PrescriptionID = r["PrescriptionID"],
                PetID = r["PetID"],
                MedicationID = r["MedicationID"],
                AppointmentID = r["AppointmentID"],
                DatePrescribed = r["DatePrescribed"],
                Dosage = r["Dosage"],
                
            }).ToList();

            return Ok(prescriptions);
        }

        // GET: api/prescription/search?PetID=PET10001
        [HttpGet("search")]
        public IActionResult SearchPrescriptions([FromQuery] Dictionary<string, string> query)
        {
            if (query.Count == 0)
                return BadRequest("Please provide at least one search field and value.");

            var validFields = new Dictionary<string, string>
            {
                { "PrescriptionID", "string" },
                { "PetID", "string" },
                { "MedicationID", "string" },
                { "AppointmentID", "string" },
                { "DatePrescribed", "string" },
                { "Dosage", "string" },
                { "Duration", "string" }
            };

            var filtered = query
                .Where(q => validFields.ContainsKey(q.Key) && !string.IsNullOrEmpty(q.Value))
                .ToDictionary(q => q.Key, q => q.Value);

            if (filtered.Count == 0)
                return BadRequest("None of the provided fields are valid or non-empty.");

            var helper = new InMemorySearchHelper(_database);
            var results = helper.FindRecordsByFields("Prescription", filtered);

            if (results.Count == 0)
                return NotFound("No matching prescriptions found.");

            return Ok(results);
        }

        // DELETE: api/prescription/PR20001
        [HttpDelete("{id}")]
        public IActionResult DeletePrescription(string id)
        {
            var result = _prescriptionCrud.DeletePrescriptionById(id);
            if (result.Success)
                return Ok(result.Message);

            return NotFound(result.Message);
        }

        // POST: api/prescription/insert
        [HttpPost("insert")]
        public IActionResult InsertPrescription([FromBody] PrescriptionDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid prescription data.");

            var fieldValues = new Dictionary<string, object>
            {
                { "PrescriptionID", dto.PrescriptionID },
                { "PetID", dto.PetID },
                { "MedicationID", dto.MedicationID },
                { "AppointmentID", dto.AppointmentID },
                { "DatePrescribed", dto.DatePrescribed },
                { "Dosage", dto.Dosage },
                { "Duration", dto.Duration }
            };

            string primaryKeyName = "PrescriptionID";
            string primaryKeyFormat = @"^PR\d{5}$";
            var foreignKeys = new List<(string, string)>
            {
                ("PetID", "Pet"),
                ("MedicationID", "Medication"),
                ("AppointmentID", "Appointment")
            };

            _prescriptionCrud.InsertOperationForPrescription(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            return Ok("Insert operation completed. Check console for detailed output.");
        }
        public class PrescriptionDTO
        {
            public string PrescriptionID { get; set; }
            public string PetID { get; set; }
            public string MedicationID { get; set; }
            public string AppointmentID { get; set; }
            public string DatePrescribed { get; set; }
            public string Dosage { get; set; }
            public string Duration { get; set; }
        }
    }
}
