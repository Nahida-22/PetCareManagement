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
            try
            {
                // Get all table records from the API.
                var owners = await _httpClient.GetFromJsonAsync<List<OwnerDto>>("https://localhost:7038/api/Owners");

                OwnerTableDataGridView.AutoGenerateColumns = true;

                // Populate the DataGridView with the retrieved data.
                OwnerTableDataGridView.DataSource = owners;
            }
            catch (Exception ex)
            {
                // Show error message.
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        // Event Listener for when the UPDATE button is clicked.
        private void OwnerUpdateButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected.
            if (OwnerTableDataGridView.CurrentRow != null)
            {
                // Get values from selected row
                string id= OwnerTableDataGridView.CurrentRow.Cells[0].Value?.ToString();
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

    }
}
