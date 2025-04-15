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
    public partial class UpdateOwnerForm : Form
    {
        // Declare variables.
        private string OwnerId, ownerFirstName, ownerLastName;
        public UpdateOwnerForm(string id, string firstName, string lastName)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            OwnerId = id;
            ownerFirstName = firstName;
            ownerLastName = lastName;

            // Call the method UpdateOwnerInterface_Load to initalise the Window.
            this.Load += new EventHandler(this.UpdateOwnerInterface_Load);
        }

        /// <summary>
        /// Initialise the update interface when it is loaded.
        /// Update the labels for the current values to match the selected row values in the DataGridView in OwnerTableInterface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateOwnerInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Create an object of type OwnerTableInterface.
                var ownerTableInterface = new OwnerTableInterface();

                // Update owner ID in Label
                UpdateDetailsLabel.Text = "Updating Details for Owner ID : " + OwnerId;

                // Populate the current values to be updated.
                currentFirstNameValue.Text = ownerFirstName;
                currentLastNameValue.Text = ownerLastName;

                //!!!!!!!! THE REST OF THE CODE TO BE WRITTEN WHEN THE API ENDPOINT WORKS.
            }
            catch (Exception ex)
            {
                // Display error message.
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void OwnerUpdateLabel_Click(object sender, EventArgs e)
        {

        }

        private void UpdateOwnerForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create and show the MainForm
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Hide or close the current form
            this.Hide();
        }
    }
}
