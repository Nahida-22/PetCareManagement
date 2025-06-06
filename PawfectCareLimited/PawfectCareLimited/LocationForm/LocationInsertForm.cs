﻿using System;
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
    public partial class LocationInsertForm : Form
    {
        public event EventHandler LocationInserted;

        public LocationInsertForm()
        {
            InitializeComponent();
        }

        private void OnLocationInserted()
        {
            LocationInserted?.Invoke(this, EventArgs.Empty);
        }

        private async void insertButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Gather data from UI controls
                string supplierId = locationIdValue.Text;
                string Name = branchNameValue.Text;
                string Address = AddressValue.Text;
                string Phone = phoneNumberValue.Text;
                string email = emailValue.Text;



                // Construct the data as a Dictionary
                var locationData = new Dictionary<string, object>
                {
                    { "LocationID", supplierId },
                    { "Name", Name },
                    { "Address", Address },
                    { "Phone", Phone },
                    { "Email", email },

                };

                try
                {
                    string apiUrl = "https://localhost:7038/api/location";

                    // Convert to JSON
                    var json = System.Text.Json.JsonSerializer.Serialize(locationData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Handle response
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Location Insert successful.");
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error: {error}");
                    }

                    OnLocationInserted();

                    this.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
