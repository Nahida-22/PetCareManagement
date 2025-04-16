using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    // UPDATE window form.
    public partial class OwnerUpdateForm : Form
    {
        // UPDATE window form.
        // Declare variables.

        private string id, firstName, lastName, phoneNumber, email, address;

        public event EventHandler AppointmentUpdated;

        public OwnerUpdateForm(string ownerId, string ownerFirstName, string ownerLastName, string ownerPhoneNumber, string ownerEmail, string ownerAddress)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            id = ownerId;
            firstName = ownerFirstName;
            lastName = ownerLastName;
            phoneNumber = ownerPhoneNumber;
            email = ownerEmail;
            address = ownerAddress;


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
                UpdateDetailsLabel.Text = "Updating Details for Owner ID : " + id;

                // Populate the current values to be updated.
                updatedFirstName.Text = firstName;
                updatedLastName.Text = lastName;
                updatedPhoneNumber.Text = phoneNumber;
                updatedEmail.Text = email;
                updatedAddress.Text = address;

            }
            catch (Exception ex)
            {
                // Display error message.
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:7038/api/owner";
                var fieldsToUpdate = new List<(string fieldName, string newValue, bool isFK, string referencedTable)>
                {
                    ("FirstName", updatedFirstName.Text, false, null),
                    ("LastName", updatedLastName.Text, false, null),
                    ("PhoneNo", updatedPhoneNumber.Text, false, null),
                    ("Email", updatedEmail.Text, false, null),
                    ("Address", updatedAddress.Text, false, null)
                };

                foreach (var field in fieldsToUpdate)
                {
                    string url = $"{baseUrl}?ownerId={id}" +
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
                MessageBox.Show("Owner updated successfully!");

                // Raise the event to refresh the table to show the update changes.
                AppointmentUpdated?.Invoke(this, EventArgs.Empty);


                this.Close(); // Close the form.
            }
        }

    }
}
