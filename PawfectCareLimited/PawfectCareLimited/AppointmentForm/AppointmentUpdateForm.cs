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
    public partial class AppointmentUpdateForm : Form
    {
        // UPDATE window form.
        // Declare variables.
        private string appointmentId, appointmentVetId, appointmentServiceType, appointmentStatus, appointmentLocation;
        private DateTime appointmentDate;

        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        public event EventHandler AppointmentUpdated;

        public AppointmentUpdateForm(string id, string vetId, string serviceType, DateTime date, string status, string location)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            appointmentId = id;
            appointmentVetId = vetId;
            appointmentServiceType = serviceType;
            appointmentDate = date;
            appointmentStatus = status;
            appointmentLocation = location;


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
                UpdateDetailsLabel.Text = "Updating Details for Appointment ID : " + appointmentId;

                // Populate the current values to be updated.
                updatedServiceType.Text = appointmentServiceType;
                updatedAppointmentDate.Value = appointmentDate;
                updatedStatus.Text = appointmentStatus;
                updatedLocation.Text = appointmentLocation;
                updatedVetName.Text = appointmentVetId;
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

        private async void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:7038/api/appointment";
                var fieldsToUpdate = new List<(string fieldName, string newValue, bool isFK, string referencedTable)>
                {
                    ("ServiceType", updatedServiceType.Text, false, null),
                    ("ApptDate", updatedAppointmentDate.Text, false, null),
                    ("Status", updatedStatus.Text, false, null),
                    ("LocationID", updatedLocation.Text, false, null),
                    ("VetID", updatedVetName.Text, true, "Vet")
                };

                foreach (var field in fieldsToUpdate)
                {
                    string url = $"{baseUrl}?appointmentId={appointmentId}" +
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
