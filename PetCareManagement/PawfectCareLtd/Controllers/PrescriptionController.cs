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

    // Class of the Prescription controler.
    public class PrescriptionController : Controller
    {

        // Declare a field for the Prescription CRUD Operation
        private readonly PrescriptionCRUD _prescriptionCRUD;



        // Contructor for the Prescription controller class.
        public PrescriptionController(PrescriptionCRUD prescriptionCRUD)
        {
            _prescriptionCRUD = prescriptionCRUD;// Assign the injected Prescription CRUD operation.
        }



        // Post Prescription API.
        [HttpPost]
        public IActionResult CreatePrescription([FromBody] PrescriptionDTO prescriptionDto)
        {
            // Create a dictionary is to hold the field names and their corresponding values for a Prescription.
            var fieldValues = new Dictionary<string, object>
            {
                { "PrescriptionID", prescriptionDto.PrescriptionID },
                { "PetID", prescriptionDto.PetID },
                { "VetID", prescriptionDto.VetID },
                { "Diagnosis", prescriptionDto.Diagnosis },
                { "Dosage", prescriptionDto.Dosage },
                { "DateIssued", prescriptionDto.DateIssued },
                { "MedicationID", prescriptionDto.MedicationID }
            };

            // Define the primary key for the Prescription Table.
            var primaryKeyName = "PrescriptionID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^PR\d{5,}$";

            // List of foreign key in the Prescription table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)>
            {
                ("PetID", "Pet"),
                ("VetID", "Vet")
            };

            // Get the result of the insert operation in the Prescription table.
            var result = _prescriptionCRUD.InsertOperationForPrescription(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Prescription API.
        [HttpGet]
        public IActionResult ReadPrescription(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Prescription table.
            var result = _prescriptionCRUD.ReadOperationForPrescription(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Prescription API
        [HttpPut]
        public IActionResult UpdatePrescription(string prescriptionId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Prescription table.
            var result = _prescriptionCRUD.UpdateOperationForPrescription(prescriptionId, fieldName, newValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // DELETE Prescription API.
        [HttpDelete]
        public IActionResult DeletePrescription(string prescriptionId)
        {
            // Get the result of the read operation in the Prescription table.
            var result = _prescriptionCRUD.DeletePrescriptionById(prescriptionId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Prescription records API.
        [HttpGet("all")]
        public IActionResult GetAllPrescription()
        {
            // Get the result of getting all of the record from Prescription table.
            var result = _prescriptionCRUD.GetAllPrescriptionRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }




        // Class to represent data transfer object for prescription.
        public class PrescriptionDTO
        {
            // Property to store the unique prescription identifier.
            public string PrescriptionID { get; set; }

            // Property to store the pet's unique identifier.
            public string PetID { get; set; }

            // Property to store the vet's unique identifier.
            public string VetID { get; set; }

            // Property to store the diagnosis.
            public string Diagnosis { get; set; }

            // Property to store the dosage instructions.
            public string Dosage { get; set; }

            // Property to store the date the prescription was issued.
            public DateTime DateIssued { get; set; }

            // Property to store the prescribed medication's ID.
            public string MedicationID { get; set; }
        }
    }
}