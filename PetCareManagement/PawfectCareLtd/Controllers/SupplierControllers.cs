//Import dependencies.
using Microsoft.AspNetCore.Mvc; // Import ASP.Net Core MVC.
using PawfectCareLtd.CRUD; // Import CRUD Operation
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.
using PawfectCareLtd.Models;
using PawfectCareLtd.Models.DTO; // Import the Data-Transfer-Object.
using PawfectCareLtd.Services; // Import services layer logic.


namespace PawfectCareLtd.Controllers // Define the namespace for the application
{
    // Define the route prefix as apiController
    [Route("api/[controller]")]
    // Spwcifi that is an api controller,
    [ApiController]

    // Class of the Supplier controler.
    public class SupplierController : Controller
    {

        // Declare a field for the Supplier CRUD Operation
        private readonly SupplierCRUD _supplierCRUD;



        // Contructor for the Appointment controller class.
        public SupplierController(SupplierCRUD supplierCRUD)
        {
            _supplierCRUD = supplierCRUD;// Assign the injected Supplier CRUD operation.
        }



        // Post Supplier API.
        [HttpPost]
        public IActionResult CreateSupplier([FromBody] Dictionary<string, object> fieldValues)
        {
            // Define the primary key for the Supplier Table.
            var primaryKeyName = "SupplierID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^S\d{5}$";

            // List of foreign key in the Supplier table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)> { };

            // Get the result of the insert operation in the Supplier table.
            var result = _supplierCRUD.InsertOperationForSupplier(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Supplier API.
        [HttpGet]
        public IActionResult ReadSupplier(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Supplier table.
            var result = _supplierCRUD.ReadOperationForSupplier(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Supplier API
        [HttpPut]
        public IActionResult UpdateSupplier(string supplierId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Supplier table.
            var result = _supplierCRUD.UpdateOperationForSupplier(supplierId, fieldName, newValue, isForeignKey, referencedTableName);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // DELETE Supplier API.
        [HttpDelete]
        public IActionResult DeleteSupplier(string supplierId)
        {
            // Get the result of the read operation in the Supplier table.
            var result = _supplierCRUD.DeleteSupplierbyId(supplierId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Supplier records API.
        [HttpGet("all")]
        public IActionResult GetAllSupplier()
        {
            // Get the result of getting all of the record from Supplier table.
            var result = _supplierCRUD.GetAllSupplierRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }
    }
}