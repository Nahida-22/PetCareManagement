using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            // Initialize placeholder text for the fields
            textBox1.PlaceholderText = "Username"; // Username field
            textBox2.PlaceholderText = "Password"; // Password field
            textBox2.PasswordChar = '*'; // Hide password characters
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();  // Username from textBox1
            string password = textBox2.Text.Trim();  // Password from textBox2
            string filePath = "users.txt"; // Path to the user data file

            // Validate the input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the users.txt file exists
            if (!File.Exists(filePath))
            {
                MessageBox.Show("No users found. Please sign up first.", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Check if the username and hashed password match any user in the file
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && parts[0] == username && parts[1] == HashPassword(password))
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Redirect to the main form
                    MainForm mainForm = new MainForm();
                    mainForm.Show();  // Show the main form
                    this.Hide();      // Hide the login form
                    return;
                }
            }

            // If the username and password don't match, show an error message
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            // Clear the fields when the 'Clear' link is clicked
            textBox1.Clear();
            textBox2.Clear();
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            // Confirm before exiting the application
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Method to hash the password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
