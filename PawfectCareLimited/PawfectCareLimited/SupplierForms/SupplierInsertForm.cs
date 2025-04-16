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
    public partial class SupplierInsertForm : Form
    {
        public SupplierInsertForm()
        {
            InitializeComponent();
        }

        private async void insertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Gather data from UI controls
                string supplierId = IdValue.Text;
                string supplierName = supplierNameValue.Text;
                string phoneNumber = PhoneNumberValue.Text;
                string adress = AddressValue.Text;
                string email = emailValue.Text;



                // Construct the data as a Dictionary
                var supplierData = new Dictionary<string, object>
                {
                    { "SupplierID", supplierId },
                    { "SupplierName", supplierName },
                    { "PhoneNumber", phoneNumber },
                    { "Address", adress},
                    { "Email", email },

                };

                try
                {
                    string apiUrl = "https://localhost:7038/api/supplier";

                    // Convert to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(supplierData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Handle response
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Supplier insert successful.");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }

    }
}
