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
    public partial class OrderInsertForm : Form
    {
        public OrderInsertForm()
        {
            InitializeComponent();
        }

        private async void insertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Gather data from UI controls
                string orderId = orderIdValue.Text;
                string medicationId = medicationIdValue.Text;
                string quantity = quantityValue.Text;
                string stockQuantity = statusValue.Text;
                DateTime orderDate = orderDateValue.Value;
                string orderStatus = statusValue.Text;


                // Construct the data as a Dictionary
                var orderData = new Dictionary<string, object>
                {
                    { "OrderID", orderId },
                    { "MedicationID", medicationId },
                    { "Quantity", quantity },
                    { "OrderStatus", orderStatus },
                    { "OrderDate", orderDate.ToString("yyyy-MM-ddTHH:mm:ss") },
                };

                try
                {
                    string apiUrl = "https://localhost:7038/api/order";

                    // Convert to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(orderData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Handle response
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Order insert successful.");
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error: {error}");
                    }

                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}

