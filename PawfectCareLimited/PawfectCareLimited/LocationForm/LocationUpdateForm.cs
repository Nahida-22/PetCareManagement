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
    public partial class LocationUpdateForm : Form
    {
        // UPDATE window form.
        // Declare variables.
        private string LocationId, Name, Address, Phone, Email;


        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        public event EventHandler LocationUpdated;

        public LocationUpdateForm(string id, string name, string address, string phone, string email)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            LocationId = id;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;


            // Call the method UpdateOwnerInterface_Load to initalise the Window.
            this.Load += new EventHandler(this.UpdateLocationInterface_Load);
        }

        /// <summary>
        /// Initialise the update interface when it is loaded.
        /// Update the labels for the current values to match the selected row values in the DataGridView in OwnerTableInterface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateLocationInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Create an object of type OwnerTableInterface.
                var locationtTableInterface = new LocationTableInterface();

                // Update owner ID in Label
                UpdateDetailsLabel.Text = "Updating Details for Location ID : " + LocationId;

                // Populate the current values to be updated.
                updatedBranchName.Text = Name;
                
                updatedAddress.Text = Address;
                updatedEmail.Text = Email;
                updatedPhone.Text = Phone;
                //currentFirstNameValue.Text = ownerFirstName;
                //currentLastNameValue.Text = ownerLastName;

                //!!!!!!!! THE REST OF THE CODE TO BE WRITTEN WHEN THE API ENDPOINT WORKS.
            }
            catch (Exception ex)
            {
                // Display error message.
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void updateLocationButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:7038/api/location";
                var fieldsToUpdate = new List<(string fieldName, string newValue, bool isFK, string referencedTable)>
                {
                    ("Name", updatedBranchName.Text, false, null),   
                    ("Address", updatedAddress.Text, false, null),
                    ("Email", updatedEmail.Text, false, null),
                    ("Phone", updatedPhone.Text, false, null)
                };

                foreach (var field in fieldsToUpdate)
                {
                    string url = $"{baseUrl}?locationId={LocationId}" +
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
                MessageBox.Show("Location updated successfully!");

                // Raise the event to refresh the table to show the update changes.
                LocationUpdated?.Invoke(this, EventArgs.Empty);


                this.Close(); // Close the form.
            }
        }

        private void locationUpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void locationUpdateForm_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }

        private void locationUpdateLabel_Click(object sender, EventArgs e)
        {

        }

        private void locationStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void updatedVetName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
