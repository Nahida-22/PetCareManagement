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
    public partial class VetInsertForm : Form
    {
        public VetInsertForm()
        {
            InitializeComponent();
        }

        private async void insertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Gather data from UI controls
                string vedId = vetIdValue.Text;
                string vetName = vetNameValue.Text;
                string specialisation = specialisationValue.Text;
                string phoneNo = phoneNoValue.Text;
                string address = addressValue.Text;
                string email = emailValue.Text;

                // Construct the data as a Dictionary
                var vetData = new Dictionary<string, object>
                {
                    { "VetID", vedId },
                    { "VetName", vetName },
                    { "Specialisation", specialisation },
                    { "PhoneNo", phoneNo },
                    { "Email", email },
                    { "Address", address }
                };

                try
                {
                    string apiUrl = "https://localhost:7038/api/vet";

                    // Convert to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(vetData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Handle response
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Vet insert successful.");
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

