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

    // Class of the Payment controler.
    public class PaymentController : Controller
    {

        // Declare a field for the Payment CRUD Operation
        private readonly PaymentCRUD _paymentCRUD;



        // Contructor for the Payment controller class.
        public PaymentController(PaymentCRUD paymentCRUD)
        {
            _paymentCRUD = paymentCRUD;// Assign the injected Payment CRUD operation.
        }



        // Post Payment API.
        [HttpPost]
        public IActionResult CreatePayment([FromBody] PaymentDTO paymentDto)
        {
            // Create a dictionary is to hold the field names and their corresponding values for a Payment.
            var fieldValues = new Dictionary<string, object>
            {
                { "BillID", paymentDto.BillID },
                { "AppointmentID", paymentDto.AppointmentID },
                { "Total_amt", paymentDto.Total_amt },
                { "Payment_Date", paymentDto.Payment_Date },
                { "Payment_Status", paymentDto.Payment_Status }
            };

            // Define the primary key for the Payment Table.
            var primaryKeyName = "BillID";

            // Regex for the format that the primary key needs to follow.
            var primaryKeyFormat = @"^B\d{5}$";

            // List of foreign key in the Payment table.
            var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)>
            {
                ("AppointmentID", "Appointment")
            };

            // Get the result of the insert operation in the Payment table.
            var result = _paymentCRUD.InsertOperationForPayment(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // GET Payment API.
        [HttpGet]
        public IActionResult ReadPayment(string fieldName, string fieldValue)
        {
            // Get the result of the read operation in the Payment table.
            var result = _paymentCRUD.ReadOperationForPayment(fieldName, fieldValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // PUT Payment API.
        [HttpPut]
        public IActionResult UpdatePayment(string paymentId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
        {
            // Get the result of the read operation in the Payment table.
            var result = _paymentCRUD.UpdateOperationForPayment(paymentId, fieldName, newValue);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return BadRequest(result);
        }



        // DELETE Payment API.
        [HttpDelete]
        public IActionResult DeletePayment(string paymentId)
        {
            // Get the result of the read operation in the Payment table.
            var result = _paymentCRUD.DeletePaymentById(paymentId);

            // Return status 200 if the operation has been a success and the result of the operation.
            if (result.success)
            {
                return Ok(result);
            }

            // Return 400 BadRequest with result if there was an error and the result of the operation.
            return NotFound(result);
        }



        // GET all Payment records API.
        [HttpGet("all")]
        public IActionResult GetAllPayment()
        {
            // Get the result of getting all of the record from Payment table.
            var result = _paymentCRUD.GetAllPaymentRecord();

            // Return status 200 to the operation has been a success and the result of the operation.
            return Ok(result);
        }




        // Class to represent data transfer object for payment.
        public class PaymentDTO
        {
            // Property to store the unique identifier for the bill.
            public string BillID { get; set; }

            // Property to store the related appointment ID.
            public string AppointmentID { get; set; }

            // Property to store the total amount for the payment.
            public decimal Total_amt { get; set; }

            // Property to store the date of payment. Nullable for pending payments.
            public DateTime? Payment_Date { get; set; }

            // Property to store the status of the payment.
            public string Payment_Status { get; set; }
        }
    }
}
