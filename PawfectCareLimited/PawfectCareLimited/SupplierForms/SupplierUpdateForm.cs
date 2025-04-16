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
    public partial class SupplierUpdateForm : Form
    {
        // UPDATE window form.
        // Declare variables.
        private string id, name , number, address, email;
       

        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        public event EventHandler SupplierUpdated;

        public SupplierUpdateForm(string supplierId, string SupplierName, string PhoneNumber, string Address, string Email)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            id = supplierId;
            name = SupplierName;
            number = PhoneNumber;
            address = Address;
            email = Email;
           


            // Call the method UpdateOwnerInterface_Load to initalise the Window.
            this.Load += new EventHandler(this.UpdateSupplierInterface_Load);
        }

        /// <summary>
        /// Initialise the update interface when it is loaded.
        /// Update the labels for the current values to match the selected row values in the DataGridView in OwnerTableInterface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateSupplierInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Create an object of type OwnerTableInterface.
                var supplierTableInterface = new SupplierInterfaceForm();

                // Update owner ID in Label
                UpdateDetailsLabel.Text = "Updating Details for Supplier ID : " + id;

                // Populate the current values to be updated.
                updatedMedicationName.Text = name;
               
                updatedStockQuantity.Text = number;
                updatedPrice.Text = address;
                updatedCategory.Text = email;

            }
            catch (Exception ex)
            {
                // Display error message.
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void updateSupplierButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:7038/api/supplier";
                var fieldsToUpdate = new List<(string fieldName, string newValue, bool isFK, string referencedTable)>
                {
                    ("SupplierName", updatedMedicationName.Text, false, null),
                    ("PhoneNumber", updatedStockQuantity.Text, false, null),
                    ("Address", updatedPrice.Text, false, null),
                    ("Email", updatedCategory.Text, false, null)
                };

                foreach (var field in fieldsToUpdate)
                {
                    string url = $"{baseUrl}?supplierId={id}" +
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
                SupplierUpdated?.Invoke(this, EventArgs.Empty);


                this.Close(); // Close the form.
            }
        }

        private void SupplierUpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void SupplierUpdateForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
