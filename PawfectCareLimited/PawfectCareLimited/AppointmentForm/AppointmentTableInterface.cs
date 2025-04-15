using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace PawfectCareLimited
{
    public partial class AppointmentTableInterface : Form
    {
        // Initialise an instance of HttpClient for API calls.
        private readonly HttpClient _httpClient = new HttpClient();

        // Constructor.
        public AppointmentTableInterface()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.AppointmentTableInterface_Load);
        }


        // Method to initialise the Owner Windoe.
        private async void AppointmentTableInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Call LoadAppointments 
                await Task.Run(() => LoadAppointments());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadAppointments()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://localhost:7038/api/Appointment/all";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);

                        if (apiResponse.success)
                        {
                            // Binding to the grid
                            appointmentTableDataGridView.Invoke(() =>
                            {
                                appointmentTableDataGridView.AutoGenerateColumns = true;
                                appointmentTableDataGridView.DataSource = apiResponse.data;
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
            if (appointmentTableDataGridView.CurrentRow != null)
            {
                // Get values from selected row
                string id = appointmentTableDataGridView.CurrentRow.Cells[0].Value?.ToString();
                string vetId = appointmentTableDataGridView.CurrentRow.Cells[2].Value?.ToString();
                string serviceType = appointmentTableDataGridView.CurrentRow.Cells[3].Value?.ToString();
                DateTime appointmentDate = Convert.ToDateTime(appointmentTableDataGridView.CurrentRow.Cells[4].Value);
                string status = appointmentTableDataGridView.CurrentRow.Cells[5].Value?.ToString();
                string locationId = appointmentTableDataGridView.CurrentRow.Cells[6].Value?.ToString();


                // Call the UPDATE Window and pass the values of the selected row in its constructor.
                var appointmentUpdateInterface = new AppointmentUpdateForm(id, vetId, serviceType, appointmentDate, status, locationId);

                // Subscribe to the event
                appointmentUpdateInterface.AppointmentUpdated += (s, args) => LoadAppointments();

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
            var confirmResult = MessageBox.Show("Are you sure to delete this appointment?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            // Get the id of the selected row.
            string id = appointmentTableDataGridView.CurrentRow.Cells[0].Value?.ToString();

            // Check if the a row is selected.
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a valid appointment.");
                return;
            }

            // Initialise an instance of HttpClient for API calls.
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:7038/api/appointment"; // Endpoint for deletion.
                    string deleteUrl = $"{baseUrl}?appointmentId={id}";

                    HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Appointment deleted successfully.");

                        // Refresh the table.
                        await Task.Run(() => LoadAppointments());
                    }
                    else
                    {
                        // Show error message.
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete appointment. Server says: {error}");
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
                    string baseUrl = "https://localhost:7038/api/appointment";
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
                            appointmentTableDataGridView.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show(result.message);
                            appointmentTableDataGridView.DataSource = null;
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
                    if (kvp.Key == "ApptDate" && kvp.Value != null)
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
            await Task.Run(() => LoadAppointments());
        }

        private void appointmentInsertButton_Click(object sender, EventArgs e)
        {

        }

        private void appointmentLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class OperationResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }

    public class Appointment
    {
        public string AppointmentID { get; set; }
        public string PetID { get; set; }
        public string VetID { get; set; }
        public string ServiceType { get; set; }
        public DateTime ApptDate { get; set; }
        public string Status { get; set; }
        public string LocationID { get; set; }
    }

    public class ApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Appointment> data { get; set; }
    }



}