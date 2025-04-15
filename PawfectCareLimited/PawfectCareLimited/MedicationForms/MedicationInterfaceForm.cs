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
    public partial class MedicationInterfaceForm : Form
    {
        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        // Constructor.
        public MedicationInterfaceForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.MedicationTableInterface_Load);
        }


        // Method to initialise the Owner Windoe.
        private async void MedicationTableInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Call LoadMedications 
                await Task.Run(() => LoadMedications());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadMedications()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://localhost:7038/api/medication/all";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MedicationApiResponse apiResponse = JsonConvert.DeserializeObject<MedicationApiResponse>(json);

                        if (apiResponse.success)
                        {
                            // Binding to the grid
                            medicationTableDataGridView.Invoke(() =>
                            {
                                medicationTableDataGridView.AutoGenerateColumns = true;
                                medicationTableDataGridView.DataSource = apiResponse.data;
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
        private void appointmentUpdateButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected.
            if (medicationTableDataGridView.CurrentRow != null)
            {
                // Get values from selected row
                string id = medicationTableDataGridView.CurrentRow.Cells[0].Value?.ToString();
                string medicationName= medicationTableDataGridView.CurrentRow.Cells[1].Value?.ToString();
                string stockQuantity = medicationTableDataGridView.CurrentRow.Cells[3].Value?.ToString();
                DateTime expiryDate = Convert.ToDateTime(medicationTableDataGridView.CurrentRow.Cells[6].Value);
                string category = medicationTableDataGridView.CurrentRow.Cells[4].Value?.ToString();
                string unitPrice = medicationTableDataGridView.CurrentRow.Cells[5].Value?.ToString();


                // Call the UPDATE Window and pass the values of the selected row in its constructor.
                var appointmentUpdateInterface = new MedicationUpdateForm(id, medicationName, stockQuantity, expiryDate, category, unitPrice);

                // Subscribe to the event
                appointmentUpdateInterface.AppointmentUpdated += (s, args) => LoadMedications();

                // Show the window.
                appointmentUpdateInterface.ShowDialog();
            }
            else
            {
                // Show error message.
                MessageBox.Show("Please select a row to update.");
            }
        }

        private async void appointmentDeleteButton_Click(object sender, EventArgs e)
        {
            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this medication?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            // Get the id of the selected row.
            string id = medicationTableDataGridView.CurrentRow.Cells[0].Value?.ToString();

            // Check if the a row is selected.
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a valid medication.");
                return;
            }

            // Initialise an instance of HttpClient for API calls.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:7038/api/medication"; // Endpoint for deletion.
                    string deleteUrl = $"{baseUrl}?medicationId={id}";

                    HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Medication deleted successfully.");

                        // Refresh the table.
                        await Task.Run(() => LoadMedications());
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
                    string baseUrl = "https://localhost:7038/api/medication";
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
                            medicationTableDataGridView.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show(result.message);
                            medicationTableDataGridView.DataSource = null;
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
            await Task.Run(() => LoadMedications());
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

        }
    }

    public class Medication
    {
        public string MedicationID { get; set; }
        public string MedicationName { get; set; }
        public string SupplierID { get; set; }
        public string StockQuantity { get; set; }
        public string Category { get; set; }
        public string UnitPrice { get; set; }
        public DateTime ExpiryDate { get; set; }

    }

    public class MedicationApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Medication> data { get; set; }
    }

}

