// Define the namespace for the controller.
namespace PawfectCareLtd.Controllers
{
    // Class that handles the result of operation.
    public class OperationResult
    {
        // Property to show whether an operation was a success or not.
        public bool success { get; set; }

        // Property to hold a message.
        public string message { get; set; }

        // Property to hold additional data.
        public object data { get; set; }
    }
}
