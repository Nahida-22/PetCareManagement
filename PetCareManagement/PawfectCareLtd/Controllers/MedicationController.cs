//Import depen//Import dependencies.
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

    // Class of the Medication controler.
    public class MedicationController : Controller
    {

        // Declare a field for the Medication CRUD Operation
        private readonly MedicationCRUD _medicationCRUD;



        // Contructor for the Medication controller class.
        public MedicationController(MedicationCRUD medicationCRUD)
        {
            _medicationCRUD = medicationCRUD;// Assign the injected Medication CRUD operation.
        }



        // Post Medication API.
        [HttpPost]
        public IActionResult CreateMedication([FromBody] MedicationDTO medicationDto)
        {
            // Create a dictionary is to hold the field names and their corresponding values for a Medication.
            var fieldValues = new Dictionary<string, object>
            {
                { "MedicationID", medicationDto.MedicationID },
                { "MedicationName", medicationDto.MedicationName },
                { "SupplierID", medicationDto.SupplierID },
                { "StockQuantity", medicationDto.StockQuantity },
                { "Category", medicationDto.Category },
                { "UnitPrice", medicationDto.UnitPrice },
                { "ExpiryDate", medicationDto.ExpiryDate }
            };

            // Define the primary key for the Medication Table.
            var primaryKeyName = "MedicationID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^M\d{5}$";

            // List of foreign key in the Medication table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)>
            {
                ("SupplierID", "Supplier")
            };

            // Get the result of the insert operation in the Medication table.
            var result = _medicationCRUD.InsertOperationForMedication(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Medication API.
        [HttpGet]
        public IActionResult ReadMedication(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Medication table.
            var result = _medicationCRUD.ReadOperationForMedication(fieldName, fieldValue);

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
        public IActionResult UpdateMedication(string medicationId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Medication table.
            var result = _medicationCRUD.UpdateOperationForMedication(medicationId, fieldName, newValue, isForeignKey, referencedTableName);

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
        public IActionResult DeleteMedication(string medicationId)
        {
            // Get the result of the read operation in the Medication table.
            var result = _medicationCRUD.DeleteMedicationById(medicationId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Medication records API.
        [HttpGet("all")]
        public IActionResult GetAllMedication()
        {
            // Get the result of getting all of the record from Medication table.
            var result = _medicationCRUD.GetAllMedicationRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }




        // Class to represent data transfer object for medication.
        public class MedicationDTO
        {
            // Property to store the unique identifier for the medication.
            public string MedicationID { get; set; }

            // Property to store the name of the medication.
            public string MedicationName { get; set; }

            // Property to store the unique identifier of the supplier.
            public string SupplierID { get; set; }

            // Property to store the stock quantity.
            public int StockQuantity { get; set; }

            // Property to store the category of the medication.
            public string Category { get; set; }

            // Property to store the unit price of the medication.
            public decimal UnitPrice { get; set; }

            // Property to store the expiry date of the medication.
            public DateTime ExpiryDate { get; set; }
        }
    }
}