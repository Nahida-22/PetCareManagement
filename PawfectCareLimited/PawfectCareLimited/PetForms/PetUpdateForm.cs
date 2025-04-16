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
    public partial class PetUpdateForm : Form
    {
        // UPDATE window form.
        // Declare variables.
        private string id, ownerId, petName, petType, petBreed, petAge;



        public event EventHandler AppointmentUpdated;

        public PetUpdateForm(string petId, string ownId, string name, string type, string breed, string age)
        {
            // Initialise the UI components.
            InitializeComponent();

            // Values retrieved from the table DataGridView.
            id = petId;
            ownerId = ownId;
            petName = name;
            petType = type;
            petBreed = breed;
            petAge = age;


            // Call the method UpdateOwnerInterface_Load to initalise the Window.
            this.Load += new EventHandler(this.UpdatePetInterface_Load);
        }

        /// <summary>
        /// Initialise the update interface when it is loaded.
        /// Update the labels for the current values to match the selected row values in the DataGridView in OwnerTableInterface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdatePetInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Create an object of type OwnerTableInterface.
                var appointmentTableInterface = new AppointmentTableInterface();

                // Update owner ID in Label
                UpdateDetailsLabel.Text = "Updating Details for Pet ID : " + id;

                // Populate the current values to be updated.
                updatedPetName.Text = petName;
                updatedType.Text = petType;
                updatedBreed.Text = petBreed;
                updatedAge.Text = petAge;
            }
            catch (Exception ex)
            {
                // Display error message.
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void updatePetButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string baseUrl = "https://localhost:7038/api/pet";
                var fieldsToUpdate = new List<(string fieldName, string newValue, bool isFK, string referencedTable)>
                {
                    ("PetName", updatedPetName.Text, false, null),
                    ("PetType", updatedType.Text, false, null),
                    ("Breed", updatedBreed.Text, false, null),
                    ("Age", updatedAge.Text, false, null)
                };

                foreach (var field in fieldsToUpdate)
                {
                    string url = $"{baseUrl}?petId={id}" +
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
                MessageBox.Show("Pet updated successfully!");

                // Raise the event to refresh the table to show the update changes.
                AppointmentUpdated?.Invoke(this, EventArgs.Empty);


                this.Close(); // Close the form.
            }
        }

        //private void AppointmentUpdateForm_Load(object sender, EventArgs e)
        //{

        //}

        //private void AppointmentUpdateForm_Load_1(object sender, EventArgs e)
        //{

        //}

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
