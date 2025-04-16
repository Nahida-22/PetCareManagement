using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PawfectCareLimited
{
    public partial class PetTableInterface : Form
    {
        // Constructor.
        public PetTableInterface()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.PetTableInterface_Load);
        }


        // Method to initialise the Owner Windoe.
        private async void PetTableInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Call LoadPets 
                await Task.Run(() => LoadPets());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadPets()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://localhost:7038/api/pet/all";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        PetApiResponse apiResponse = JsonConvert.DeserializeObject<PetApiResponse>(json);

                        if (apiResponse.success)
                        {
                            // Binding to the grid
                            petTableDataGridView.Invoke(() =>
                            {
                                petTableDataGridView.AutoGenerateColumns = true;
                                petTableDataGridView.DataSource = apiResponse.data;
                            });
                        }
                        else
                        {
                            MessageBox.Show("Error: " + apiResponse.message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to fetch data. Status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }
            }
        }

        // Event Listener for when the UPDATE button is clicked.
        private void petUpdateButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected.
            if (petTableDataGridView.CurrentRow != null)
            {
                // Get values from selected row
                string petId = petTableDataGridView.CurrentRow.Cells[0].Value?.ToString();
                string ownerId = petTableDataGridView.CurrentRow.Cells[1].Value?.ToString();
                string petName = petTableDataGridView.CurrentRow.Cells[2].Value?.ToString();
                string petType = petTableDataGridView.CurrentRow.Cells[3].Value?.ToString();
                string breed = petTableDataGridView.CurrentRow.Cells[4].Value?.ToString();
                string age = petTableDataGridView.CurrentRow.Cells[5].Value?.ToString();


                // Call the UPDATE Window and pass the values of the selected row in its constructor.
                var petUpdateInterface = new PetUpdateForm(petId, ownerId, petName, petType, breed, age);

                // Subscribe to the event
                petUpdateInterface.AppointmentUpdated += (s, args) => LoadPets();

                // Show the window.
                petUpdateInterface.ShowDialog();
            }
            else
            {
                // Show error message.
                MessageBox.Show("Please select a row to update.");
            }
        }

        private async void petDeleteButton_Click(object sender, EventArgs e)
        {
            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this pet?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            // Get the id of the selected row.
            string id = petTableDataGridView.CurrentRow.Cells[0].Value?.ToString();

            // Check if the a row is selected.
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a valid pet.");
                return;
            }

            // Initialise an instance of HttpClient for API calls.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:7038/api/pet"; // Endpoint for deletion.
                    string deleteUrl = $"{baseUrl}?petId={id}";

                    HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pet deleted successfully.");

                        // Refresh the table.
                        await Task.Run(() => LoadPets());
                    }
                    else
                    {
                        // Show error message.
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete pet. Server says: {error}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during deletion: {ex.Message}");
                }

            }
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string fieldName = SearchFieldComboBox.SelectedItem?.ToString();
            string fieldValue = SearchBarTextBox.Text.Trim();

            if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(fieldValue))
            {
                MessageBox.Show("Please select a field and enter a value.");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:7038/api/pet";
                    string fullUrl = $"{baseUrl}?fieldName={fieldName}&fieldValue={fieldValue}";

                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<OperationResult>(json);

                        if (result.success)
                        {
                            var dataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(result.data.ToString());

                            DataTable dt = ConvertToDataTable(dataList);
                            petTableDataGridView.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show(result.message);
                            petTableDataGridView.DataSource = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No such record value was found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }

        // Method to convert the search results in the form of a table.
        public static DataTable ConvertToDataTable(List<Dictionary<string, object>> list)
        {
            DataTable table = new DataTable();

            if (list == null || list.Count == 0)
                return table;

            // Create columns
            foreach (var key in list[0].Keys)
            {
                table.Columns.Add(key);
            }

            // Add rows
            foreach (var dict in list)
            {
                var row = table.NewRow();
                foreach (var kvp in dict)
                {
                    if (kvp.Key == "ExpiryDate" && kvp.Value != null)
                    {
                        if (DateTime.TryParse(kvp.Value.ToString(), out DateTime date))
                        {
                            row[kvp.Key] = date;
                        }
                        else
                        {
                            row[kvp.Key] = DBNull.Value;
                        }
                    }
                    else
                    {
                        row[kvp.Key] = kvp.Value ?? DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private async void viewAllButton_Click(object sender, EventArgs e)
        {
            // Reset the table. 
            await Task.Run(() => LoadPets());
        }

        private void appointmentInsertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var medicationInsertForm = new MedicationInsertForm();
                medicationInsertForm.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }
    }

    public class Pet
    {
        public string PetID { get; set; }
        public string OwnerID { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }

    }

    public class PetApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Pet> data { get; set; }
    }
}

