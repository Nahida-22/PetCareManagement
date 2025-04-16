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
    public partial class VetUpdateForm : Form
    {
        // UPDATE window form.
        // Declare variables.
        private string id, name, specialisation, phoneNo, email, address;
       
        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        public event EventHandler AppointmentUpdated;

        public VetUpdateForm(string vetId, string vetName, string vetSpecialisation, string vetPhoneNo, string petEmail, string petAddress)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            id = vetId;
            name = vetName;
            specialisation = vetSpecialisation;
            phoneNo = vetPhoneNo;
            email = petEmail;
            address = petAddress;


            // Call the method UpdateOwnerInterface_Load to initalise the Window.
            this.Load += new EventHandler(this.UpdateVetInterface_Load);
        }

        /// <summary>
        /// Initialise the update interface when it is loaded.
        /// Update the labels for the current values to match the selected row values in the DataGridView in OwnerTableInterface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateVetInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Create an object of type VetTableInterface.
                var appointmentTableInterface = new AppointmentTableInterface();

                // Update owner ID in Label
                UpdateDetailsLabel.Text = "Updating Details for Vet ID : " + id;

                // Populate the current values to be updated.
                updatedVetName.Text = name;
                updatedSpecialisation.Text = specialisation;
                updatedEmail.Text = email;
                updatedPhone.Text = phoneNo;
                updatedAddress.Text = address;

            }
            catch (Exception ex)
            {
                // Display error message.
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void updateVetButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:7038/api/vet";
                var fieldsToUpdate = new List<(string fieldName, string newValue, bool isFK, string referencedTable)>
                {
                    ("VetName", updatedVetName.Text, false, null),
                    ("Specialisation", updatedSpecialisation.Text, false, null),
                    ("PhoneNo", updatedPhone.Text, false, null),
                    ("Email", updatedEmail.Text, false, null),
                    ("Address", updatedAddress.Text, false, null)
                };

                foreach (var field in fieldsToUpdate)
                {
                    string url = $"{baseUrl}?vetId={id}" +
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
                MessageBox.Show("Vet updated successfully!");

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

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }
    }
}
