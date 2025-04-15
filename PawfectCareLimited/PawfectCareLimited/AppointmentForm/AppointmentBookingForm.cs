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
    public partial class AppointmentBookingForm : Form
    {
        public AppointmentBookingForm()
        {
            InitializeComponent();
        }

        // Event listener for booking appointment.
        private async void bookAppointmentButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Gather data from UI controls
                string appointmentId = appointmentIdValue.Text;
                string petId = petIdValue.Text;
                DateTime appointmentDate = appointmentDateValue.Value;
                string serviceType = serviceTypeBookingValue.Text;
                string locationId = locationIdBookingValue.Text;
                string vetId = assignedToVetIdBookingValue.Text;

                // Construct the data as a Dictionary
                var appointmentData = new Dictionary<string, object>
                {
                    { "AppointmentID", appointmentId },
                    { "PetID", petId },
                    { "ApptDate", appointmentDate.ToString("yyyy-MM-ddTHH:mm:ss") },
                    { "ServiceType", serviceType },
                    { "LocationID", locationId },
                    { "VetID", vetId },
                    { "Status", "Scheduled" }, // Default status.
                };

                try
                {
                    string apiUrl = "https://localhost:7038/api/Appointment";

                    // Convert to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(appointmentData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Handle response
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Appointment booked successfully!");
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error: {error}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void AppointmentBookingForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create and show the MainForm
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Hide or close the current form
            this.Hide();  
        }

    }
}

