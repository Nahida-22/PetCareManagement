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
    public partial class SupplierInterfaceForm : Form
    {
        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        // Constructor.
        public SupplierInterfaceForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.SupplierTableInterface_Load);
        }


        // Method to initialise the Owner Windoe.
        private async void SupplierTableInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Call LoadMedications 
                await Task.Run(() => LoadSuppliers());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadSuppliers()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://localhost:7038/api/supplier/all";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        SupplierApiResponse apiResponse = JsonConvert.DeserializeObject<SupplierApiResponse>(json);

                        if (apiResponse.success)
                        {
                            // Binding to the grid
                            supplierTableDataGridView.Invoke(() =>
                            {
                                supplierTableDataGridView.AutoGenerateColumns = true;
                                supplierTableDataGridView.DataSource = apiResponse.data;
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
        private void supplierUpdateButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected.
            if (supplierTableDataGridView.CurrentRow != null)
            {
                // Get values from selected row
                string id = supplierTableDataGridView.CurrentRow.Cells[0].Value?.ToString();
                string supplierName = supplierTableDataGridView.CurrentRow.Cells[1].Value?.ToString();
                string phoneNumber = supplierTableDataGridView.CurrentRow.Cells[2].Value?.ToString();
                string Address = supplierTableDataGridView.CurrentRow.Cells[3].Value?.ToString();
                string Email = supplierTableDataGridView.CurrentRow.Cells[4].Value?.ToString();


                // Call the UPDATE Window and pass the values of the selected row in its constructor.
                var supplierUpdateInterface = new SupplierUpdateForm(id, supplierName, phoneNumber, Address, Email);

                // Subscribe to the event
                supplierUpdateInterface.SupplierUpdated += (s, args) => LoadSuppliers();

                //// Show the window.
                supplierUpdateInterface.ShowDialog();
            }
            else
            {
                // Show error message.
                MessageBox.Show("Please select a row to update.");
            }
        }

        private async void supplierDeleteButton_Click(object sender, EventArgs e)
        {
            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this supplier?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            // Get the id of the selected row.
            string id = supplierTableDataGridView.CurrentRow.Cells[0].Value?.ToString();

            // Check if the a row is selected.
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a valid supplier.");
                return;
            }

            // Initialise an instance of HttpClient for API calls.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:7038/api/supplier"; // Endpoint for deletion.
                    string deleteUrl = $"{baseUrl}?supplierId={id}";

                    HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Supplier deleted successfully.");

                        // Refresh the table.
                        await Task.Run(() => LoadSuppliers());
                    }
                    else
                    {
                        // Show error message.
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete supplier. Server says: {error}");
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
                    string baseUrl = "https://localhost:7038/api/supplier";
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
                            supplierTableDataGridView.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show(result.message);
                            supplierTableDataGridView.DataSource = null;
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
            await Task.Run(() => LoadSuppliers());
        }

        private void supplierInsertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var supplierInsertForm = new SupplierInsertForm();
                supplierInsertForm.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }


        private void SearchFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class Supplier
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
     

    }

    public class SupplierApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Supplier> data { get; set; }
    }

}

