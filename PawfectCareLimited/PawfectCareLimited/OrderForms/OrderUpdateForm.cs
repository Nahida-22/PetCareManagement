using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PawfectCareLimited
{
    public partial class OrderUpdateForm : Form
       {
        // UPDATE window form.
        // Declare variables.
        private string ordId, medId, orderId, name, quanity, status;
        private DateTime date;

        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        public event EventHandler AppointmentUpdated;
        public OrderUpdateForm(string orderId, string medicationId, string stockQuantity, DateTime orderDate, string orderStatus)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            ordId = orderId;
            medId = medicationId;
            quanity = stockQuantity;
            date = orderDate;
            status = orderStatus;

            // Call the method UpdateOwnerInterface_Load to initalise the Window.
            this.Load += new EventHandler(this.UpdateOrderInterface_Load);
        }

        /// <summary>
        /// Initialise the update interface when it is loaded.
        /// Update the labels for the current values to match the selected row values in the DataGridView in OwnerTableInterface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateOrderInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Create an object of type OwnerTableInterface.
                var orderUpdateInterface = new OrderInterfaceForm();

                // Update owner ID in Label
                UpdateDetailsLabel.Text = "Updating Details for Order ID : " + ordId;

                // Populate the current values to be updated.
                updatedMedicationId.Text = medId;
                updatedQuantity.Text = quanity;
                updatedOrderStatus.Text = status;
                updatedOrderDate.Value = date;


            }
            catch (Exception ex)
            {
                // Display error message.
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void updateMedicationButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:7038/api/order";
                var fieldsToUpdate = new List<(string fieldName, string newValue, bool isFK, string referencedTable)>
                {
                    ("MedicationID", updatedMedicationId.Text, false, null),
                    ("Quantity", updatedQuantity.Text, false, null),
                    ("OrderDate", updatedOrderDate.Text, false, null),
                    ("OrderStatus", updatedOrderStatus.Text, false, null)
                };

                foreach (var field in fieldsToUpdate)
                {
                    string url = $"{baseUrl}?orderId={ordId}" +
                                 $"&fieldName={field.fieldName}" +
                                 $"&newValue={field.newValue}" +
                                 $"&isForeignKey={field.isFK}" +
                                 (field.referencedTable != null ? $"&referencedTableName={field.referencedTable}" : "");

                    HttpResponseMessage response = await client.PutAsync(url, null);
                    if (!response.IsSuccessStatusCode)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to update {field.fieldName}: {error}");
                        return;
                    }
                }
                MessageBox.Show("Order record updated successfully!");

                // Raise the event to refresh the table to show the update changes.
                AppointmentUpdated?.Invoke(this, EventArgs.Empty);


                this.Close(); // Close the form.
            }
        }
    }
}
