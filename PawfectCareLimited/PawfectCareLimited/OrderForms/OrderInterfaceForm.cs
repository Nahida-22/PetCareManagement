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
    public partial class OrderInterfaceForm : Form
    {
        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        // Constructor.
        public OrderInterfaceForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.OwnerTableInterface_Load);
        }


        // Method to initialise the Owner Windoe.
        private async void OwnerTableInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Call LoadOrders 
                await Task.Run(() => LoadOrders());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadOrders()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://localhost:7038/api/order/all";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        OrderApiResponse apiResponse = JsonConvert.DeserializeObject<OrderApiResponse>(json);

                        if (apiResponse.success)
                        {
                            // Binding to the grid
                            orderTableDataGridView.Invoke(() =>
                            {
                                orderTableDataGridView.AutoGenerateColumns = true;
                                orderTableDataGridView.DataSource = apiResponse.data;
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
        private void orderUpdateButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected.
            if (orderTableDataGridView.CurrentRow != null)
            {
                // Get values from selected row
                string orderId = orderTableDataGridView.CurrentRow.Cells[0].Value?.ToString();
                string medicationId = orderTableDataGridView.CurrentRow.Cells[1].Value?.ToString();
                string quantity = orderTableDataGridView.CurrentRow.Cells[2].Value?.ToString();
                DateTime orderDate = Convert.ToDateTime(orderTableDataGridView.CurrentRow.Cells[4].Value);
                string orderStatus = orderTableDataGridView.CurrentRow.Cells[3].Value?.ToString();


                // Call the UPDATE Window and pass the values of the selected row in its constructor.
                var orderUpdateInterface = new OrderUpdateForm(orderId, medicationId, quantity, orderDate, orderStatus);

                // Subscribe to the event
                orderUpdateInterface.AppointmentUpdated += (s, args) => LoadOrders();

                // Show the window.
                orderUpdateInterface.ShowDialog();
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
            string id = orderTableDataGridView.CurrentRow.Cells[0].Value?.ToString();

            // Check if the a row is selected.
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a valid order.");
                return;
            }

            // Initialise an instance of HttpClient for API calls.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:7038/api/order"; // Endpoint for deletion.
                    string deleteUrl = $"{baseUrl}?orderId={id}";

                    HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order deleted successfully.");

                        // Refresh the table.
                        await Task.Run(() => LoadOrders());
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
                    string baseUrl = "https://localhost:7038/api/order";
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
                            orderTableDataGridView.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show(result.message);
                            orderTableDataGridView.DataSource = null;
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
                    if (kvp.Key == "OrderDate" && kvp.Value != null)
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
            await Task.Run(() => LoadOrders());
        }

        private void appointmentInsertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var orderInsertForm = new OrderInsertForm();
                orderInsertForm.ShowDialog();

            }
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

    public class Order
    {
        public string OrderID { get; set; }
        public string MedicationID { get; set; }
        public string Quantity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }

    }

    public class OrderApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Order> data { get; set; }
    }
}

