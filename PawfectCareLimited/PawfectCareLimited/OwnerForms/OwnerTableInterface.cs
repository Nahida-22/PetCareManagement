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
using Newtonsoft.Json;

namespace PawfectCareLimited
{
    public partial class OwnerTableInterface : Form
    {
        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        // Constructor.
        public OwnerTableInterface()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.OwnerTableInterface_Load);
        }


        // Method to initialise the Owner Windoe.
        private async void OwnerTableInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Call LoadOwners 
                await LoadOwners();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadOwners()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://localhost:7038/api/owner/all";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        OwnerApiResponse apiResponse = JsonConvert.DeserializeObject<OwnerApiResponse>(json);

                        if (apiResponse.success)
                        {
                            // Binding to the grid
                            OwnerTableDataGridView.Invoke(() =>
                            {
                                OwnerTableDataGridView.AutoGenerateColumns = true;
                                OwnerTableDataGridView.DataSource = apiResponse.data;
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
        private void OwnerUpdateButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected.
            if (OwnerTableDataGridView.CurrentRow != null)
            {
                // Get values from selected row
                string id = OwnerTableDataGridView.CurrentRow.Cells[0].Value?.ToString();
                string firstName = OwnerTableDataGridView.CurrentRow.Cells[1].Value?.ToString();
                string lastName = OwnerTableDataGridView.CurrentRow.Cells[2].Value?.ToString();
                string phoneNumber = OwnerTableDataGridView.CurrentRow.Cells[3].Value?.ToString();
                string email = OwnerTableDataGridView.CurrentRow.Cells[4].Value?.ToString();
                string address = OwnerTableDataGridView.CurrentRow.Cells[5].Value?.ToString();

                // Call the UPDATE Window and pass the values of the selected row in its constructor.
                var ownerUpdateInterface = new OwnerUpdateForm(id, firstName, lastName, phoneNumber, email, address);

                // Show the window.
                ownerUpdateInterface.ShowDialog();
            }
            else
            {
                // Show error message.
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void OwnerLabel_Click(object sender, EventArgs e)
        {

        }

        private void OwnerTableInterface_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }


        private async void OwnerDeleteButton_Click(object sender, EventArgs e)
        {
            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this medication?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            // Get the id of the selected row.
            string id = OwnerTableDataGridView.CurrentRow.Cells[0].Value?.ToString();

            // Check if the a row is selected.
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a valid owner.");
                return;
            }

            // Initialise an instance of HttpClient for API calls.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:7038/api/owner"; // Endpoint for deletion.
                    string deleteUrl = $"{baseUrl}?ownerId={id}";

                    HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Owner deleted successfully.");

                        // Refresh the table.
                        await Task.Run(() => LoadOwners());
                    }
                    else
                    {
                        // Show error message.
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete medication. Server says: {error}");
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
                    string baseUrl = "https://localhost:7038/api/owner";
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
                            OwnerTableDataGridView.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show(result.message);
                            OwnerTableDataGridView.DataSource = null;
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


        public class Owner
        {
            public string OwnerID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNo { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }

        }
        public class OwnerApiResponse
        {
            public bool success { get; set; }
            public string message { get; set; }
            public List<Owner> data { get; set; }
        }

        private async void viewAllButton_Click(object sender, EventArgs e)
        {
            // Reset the table. 
            await Task.Run(() => LoadOwners());
        }
    }
}
