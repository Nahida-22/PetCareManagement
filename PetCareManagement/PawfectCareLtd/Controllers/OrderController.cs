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

    // Class of the Order controler.
    public class OrderController : Controller
    {

        // Declare a field for the Order CRUD Operation
        private readonly OrderCRUD _orderCRUD;



        // Contructor for the Order controller class.
        public OrderController(OrderCRUD orderCRUD)
        {
            _orderCRUD = orderCRUD;// Assign the injected Order CRUD operation.
        }



        // Post Order API.
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Dictionary<string, object> fieldValues)
        {
            // Define the primary key for the Order Table.
            var primaryKeyName = "OrderID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^O\d{5}$";

            // List of foreign key in the Order table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)>
            {("MedicationIDID", "Medication")};

            // Get the result of the insert operation in the Order table.
            var result = _orderCRUD.InsertOperationForOrder(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Order API.
        [HttpGet]
        public IActionResult ReadOrder(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Order table.
            var result = _orderCRUD.ReadOperationForOrder(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Order API.
        [HttpPut]
        public IActionResult UpdateOrder(string orderId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Order table.
            var result = _orderCRUD.UpdateOperationForOrder(orderId, fieldName, newValue, isForeignKey, referencedTableName);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // DELETE Order API.
        [HttpDelete]
        public IActionResult DeleteOrder(string orderId)
        {
            // Get the result of the read operation in the Order table.
            var result = _orderCRUD.DeleteOrderById(orderId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Order records API.
        [HttpGet("all")]
        public IActionResult GetAllMedication()
        {
            // Get the result of getting all of the record from Order table.
            var result = _orderCRUD.GetAllOrderRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }
    }
}
