using System.Net.Http.Json;

namespace PawfectCareLimited
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7038/") };

        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var owners = await _httpClient.GetFromJsonAsync<List<OwnerDto>>("api/Owners");
                ownersDataGridView.AutoGenerateColumns = true; // <-- Add this
                ownersDataGridView.DataSource = owners;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void displayOwnersButton_Click(object sender, EventArgs e)
        {
            try
            {
                var owners = await _httpClient.GetFromJsonAsync<List<OwnerDto>>("api/Owners");
                ownersDataGridView.AutoGenerateColumns = true;
                ownersDataGridView.DataSource = owners;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

    }

    public class OwnerDto
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
