using System.Data;
using Newtonsoft.Json;

namespace PawfectCareLimited
{
    public partial class VetTableInterfaceForm : Form
    {
        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        // Constructor.
        public VetTableInterfaceForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.VetTableInterface_Load);
        }


        // Method to initialise the Owner Windoe.
        private async void VetTableInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Call LoadVets 
                await Task.Run(() => LoadVets());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadVets()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://localhost:7038/api/vet/all";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        VetApiResponse apiResponse = JsonConvert.DeserializeObject<VetApiResponse>(json);

                        if (apiResponse.success)
                        {
                            // Binding to the grid
                            vetTableDataGridView.Invoke(() =>
                            {
                                vetTableDataGridView.AutoGenerateColumns = true;
                                vetTableDataGridView.DataSource = apiResponse.data;
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
                    string baseUrl = "https://localhost:7038/api/vet";
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
                            vetTableDataGridView.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show(result.message);
                            vetTableDataGridView.DataSource = null;
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
            await Task.Run(() => LoadVets());
        }

        private void vetInsertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var vetInsertForm = new VetInsertForm();
                vetInsertForm.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }

        // Event Listener for when the UPDATE button is clicked.
        private void vetUpdateButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected.
            if (vetTableDataGridView.CurrentRow != null)
            {
                // Get values from selected row
                string id = vetTableDataGridView.CurrentRow.Cells[0].Value?.ToString();
                string vetName = vetTableDataGridView.CurrentRow.Cells[1].Value?.ToString();
                string specialisation = vetTableDataGridView.CurrentRow.Cells[2].Value?.ToString();
                string phoneNo = vetTableDataGridView.CurrentRow.Cells[3].Value?.ToString();
                string email = vetTableDataGridView.CurrentRow.Cells[4].Value?.ToString();
                string address = vetTableDataGridView.CurrentRow.Cells[5].Value?.ToString();


                // Call the UPDATE Window and pass the values of the selected row in its constructor.
                var vetUpdateInterface = new VetUpdateForm(id, vetName, specialisation, phoneNo, email, address);

                // Subscribe to the event
                vetUpdateInterface.AppointmentUpdated += (s, args) => LoadVets();

                // Show the window.
                vetUpdateInterface.ShowDialog();
            }
            else
            {
                // Show error message.
                MessageBox.Show("Please select a row to update.");
            }
        }

        private async void vetDeleteButton_Click(object sender, EventArgs e)
        {
            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this vet?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            // Get the id of the selected row.
            string id = vetTableDataGridView.CurrentRow.Cells[0].Value?.ToString();

            // Check if the a row is selected.
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a valid vet.");
                return;
            }

            // Initialise an instance of HttpClient for API calls.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:7038/api/vet"; // Endpoint for deletion.
                    string deleteUrl = $"{baseUrl}?vetId={id}";

                    HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Vet deleted successfully.");

                        // Refresh the table.
                        await Task.Run(() => LoadVets());
                    }
                    else
                    {
                        // Show error message.
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete Vet. Server says: {error}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during deletion: {ex.Message}");
                }

            }
        }
    }

    public class Vet
    {
        public string VetID { get; set; }
        public string VetName { get; set; }
        public string Specialisation { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }

    public class VetApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Vet> data { get; set; }
    }
}

