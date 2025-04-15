using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class MedicationUpdateForm : Form
    {
        // UPDATE window form.
        // Declare variables.
        private string id, name , quanity, category, price;
        private DateTime expiry;

        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        public event EventHandler AppointmentUpdated;

        public MedicationUpdateForm(string medicationId, string medicationName, string stockQuantity, DateTime expiryDate, string medicationCategory, string unitPrice)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            id = medicationId;
            name = medicationName;
            quanity = stockQuantity;
            category = medicationCategory;
            price = unitPrice;
            expiry = expiryDate;


            // Call the method UpdateOwnerInterface_Load to initalise the Window.
            this.Load += new EventHandler(this.UpdateAppointmentInterface_Load);
        }

        /// <summary>
        /// Initialise the update interface when it is loaded.
        /// Update the labels for the current values to match the selected row values in the DataGridView in OwnerTableInterface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateAppointmentInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Create an object of type OwnerTableInterface.
                var appointmentTableInterface = new AppointmentTableInterface();

                // Update owner ID in Label
                UpdateDetailsLabel.Text = "Updating Details for Medication ID : " + id;

                // Populate the current values to be updated.
                updatedMedicationName.Text = name;
                updatedExpiryDate.Value = expiry;
                updatedStockQuantity.Text = quanity;
                updatedPrice.Text = price;
                updatedCategory.Text = category;

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
                string baseUrl = "https://localhost:7038/api/medication";
                var fieldsToUpdate = new List<(string fieldName, string newValue, bool isFK, string referencedTable)>
                {
                    ("MedicationName", updatedMedicationName.Text, false, null),
                    ("ExpiryDate", updatedExpiryDate.Text, false, null),
                    ("StockQuantity", updatedStockQuantity.Text, false, null),
                    ("UnitPrice", updatedPrice.Text, false, null),
                    ("Category", updatedCategory.Text, false, null)
                };

                foreach (var field in fieldsToUpdate)
                {
                    string url = $"{baseUrl}?medicationId={id}" +
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
                MessageBox.Show("Appointment updated successfully!");

                // Raise the event to refresh the table to show the update changes.
                AppointmentUpdated?.Invoke(this, EventArgs.Empty);


                this.Close(); // Close the form.
            }
        }

        private void AppointmentUpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void AppointmentUpdateForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
