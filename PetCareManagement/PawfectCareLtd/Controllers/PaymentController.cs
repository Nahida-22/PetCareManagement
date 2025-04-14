//Import dependencies.
using Microsoft.AspNetCore.Mvc; // Import ASP.Net Core MVC.
using PawfectCareLtd.CRUD; // Import CRUD Operation
using PawfectCareLtd.Data.DataRetrieval; // Import the custom in memory database.
using PawfectCareLtd.Models;
using PawfectCareLtd.Models.DTO; // Import the Data-Transfer-Object.
using PawfectCareLtd.Services; // Import services layer logic.


namespace PawfectCareLtd.Controllers // Define the namespace for the application
{
    //// Define the route prefix as apiController
    //[Route("api/[controller]")]
    //// Spwcifi that is an api controller,
    //[ApiController]

    //// Class of the Payment controler.
    //public class PaymentController : Controller
    //{

    //    // Declare a field for the Payment CRUD Operation
    //    private readonly PaymentCRUD _paymentCRUD;



    //    // Contructor for the Payment controller class.
    //    public PaymentController(PaymentCRUD paymentCRUD)
    //    {
    //        _paymentCRUD = paymentCRUD;// Assign the injected Payment CRUD operation.
    //    }



    //    // Post Payment API.
    //    [HttpPost]
    //    public IActionResult CreatePayment([FromBody] Dictionary<string, object> fieldValues)
    //    {
    //        // Define the primary key for the Payment Table.
    //        var primaryKeyName = "PaymentID";

    //        // Regex for the format that the primary key needs to follow.
    //        var primaryKeyFormat = @"^B\d{5}$";

    //        // List of foreign key in the Payment table.
    //        var foreignKeys = new List<(string ForeignKeyField, string ReferencedTableName)> 
    //        {
    //            ("AppointmentID", "Appointment")
    //        };

    //        // Get the result of the insert operation in the Payment table.
    //        var result = _paymentCRUD.InsertOperationForPayment(fieldValues, primaryKeyName, primaryKeyFormat, foreignKeys);

    //        // Return status 200 if the operation has been a success and the result of the operation.
    //        if (result.success)
    //        {
    //            return Ok(result);
    //        }

    //        // Return 400 BadRequest with result if there was an error and the result of the operation.
    //        return BadRequest(result);
    //    }



    //    // GET Payment API.
    //    [HttpGet]
    //    public IActionResult ReadPayment(string fieldName, string fieldValue)
    //    {
    //        // Get the result of the read operation in the Payment table.
    //        var result = _paymentCRUD.ReadOperationForPayment(fieldName, fieldValue);

    //        // Return status 200 if the operation has been a success and the result of the operation.
    //        if (result.success)
    //        {
    //            return Ok(result);
    //        }

    //        // Return 400 BadRequest with result if there was an error and the result of the operation.
    //        return NotFound(result);
    //    }



    //    // PUT Payment API.
    //    [HttpPut]
    //    public IActionResult UpdatePayment(string paymentId, [FromQuery] string fieldName, [FromQuery] string newValue, [FromQuery] bool isForeignKey = false, [FromQuery] string referencedTableName = null)
    //    {
    //        // Get the result of the read operation in the Payment table.
    //        var result = _paymentCRUD.UpdateOperationForPayment(paymentId, fieldName, newValue, isForeignKey, referencedTableName);

    //        // Return status 200 if the operation has been a success and the result of the operation.
    //        if (result.success)
    //        {
    //            return Ok(result);
    //        }

    //        // Return 400 BadRequest with result if there was an error and the result of the operation.
    //        return BadRequest(result);
    //    }



    //    // DELETE Payment API.
    //    [HttpDelete]
    //    public IActionResult DeletePayment(string paymentId)
    //    {
    //        // Get the result of the read operation in the Payment table.
    //        var result = _paymentCRUD.DeletePaymentbyId(paymentId);

    //        // Return status 200 if the operation has been a success and the result of the operation.
    //        if (result.success)
    //        {
    //            return Ok(result);
    //        }

    //        // Return 400 BadRequest with result if there was an error and the result of the operation.
    //        return NotFound(result);
    //    }



    //    // GET all Payment records API.
    //    [HttpGet("all")]
    //    public IActionResult GetAllPayment()
    //    {
    //        // Get the result of getting all of the record from Payment table.
    //        var result = _paymentCRUD.GetAllPaymentRecord();

    //        // Return status 200 to the operation has been a success and the result of the operation.
    //        return Ok(result);
    //    }
    //}
}
