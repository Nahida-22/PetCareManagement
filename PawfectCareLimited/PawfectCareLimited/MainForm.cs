using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient;
        public MainForm()
        {
            // Initialise the components.
            InitializeComponent();
        }

        // Event to open tables based on the table dropdown option.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected option from the dropdown.
            string selected = comboBox1.SelectedItem.ToString();

            // IF statement to show appropriate windows based on the selected option from the dropdown.
            if (selected == "Owner")
            {
                // Create an object of the type OwnerTableInterface.
                var ownerTableInterface = new OwnerTableInterface();

                // Show the window.
                ownerTableInterface.ShowDialog();
            }
            else if (selected == "Appointment")
            {
                // Create an object of the type AppointmentTableInterface.
                var appointmentTableInterface = new AppointmentTableInterface();

                // Show the window.
                appointmentTableInterface.ShowDialog();
            }
            else if(selected == "Medication")
            {
                var medicationTableInterface = new MedicationInterfaceForm();
                medicationTableInterface.ShowDialog();
            }
            else if (selected == "Location")
            {
                var locationTableInterface = new LocationTableInterface();
                locationTableInterface.ShowDialog();
            }
        }

        private void bookAppointmentButton_Click(object sender, EventArgs e)
        {
            // Call the INSERT Form.
            var appointmentInsertForm = new AppointmentBookingForm();
            appointmentInsertForm.ShowDialog(); // Show the window.
        }

        private void newOwnerRegisterButton_Click(object sender, EventArgs e)
        {
            // Call the REGISTER Form.
            var registerInterfaceForm = new RegisterInterfaceForm();
            registerInterfaceForm.ShowDialog();
        }
    }

    public class OwnerDto
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
