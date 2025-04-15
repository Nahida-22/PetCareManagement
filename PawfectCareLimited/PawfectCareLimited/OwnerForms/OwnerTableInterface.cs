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
            // Initialise client.
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

                // Call the UPDATE Window and pass the values of the selected row in its constructor.
                var ownerUpdateInterface = new UpdateOwnerForm(id, firstName, lastName);

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
}
