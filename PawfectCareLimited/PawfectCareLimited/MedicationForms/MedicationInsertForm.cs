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
    public partial class MedicationInsertForm : Form
    {
        public MedicationInsertForm()
        {
            InitializeComponent();
        }

        private async void insertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Gather data from UI controls
                string medicationId = medicationIdValue.Text;
                string medicationName = medicationNameValue.Text;
                string supplierID = supplierIdValue.Text;
                string stockQuantity = stockQuantityValue.Text;
                string unitPrice = unitPriceValue.Text;
                string category = categoryValue.Text;
                DateTime expiryDate = expiryDateValue.Value;


                // Construct the data as a Dictionary
                var medicationtData = new Dictionary<string, object>
                {
                    { "MedicationID", medicationId },
                    { "MedicationName", medicationName },
                    { "SupplierID", supplierID },
                    { "StockQuantity", stockQuantity },
                    { "Category", category },
                    { "UnitPrice", unitPrice },
                    { "ExpiryDate", expiryDate.ToString("yyyy-MM-ddTHH:mm:ss") },
                };

                try
                {
                    string apiUrl = "https://localhost:7038/api/medication";

                    // Convert to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(medicationtData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Handle response
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Medication insert successful.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }
    }
}
