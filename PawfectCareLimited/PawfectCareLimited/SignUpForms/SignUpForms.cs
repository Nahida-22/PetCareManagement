using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class SignUpForms : Form
    {
        private string filePath = Path.Combine(Application.StartupPath, "users.txt");

        public SignUpForms()
        {
            InitializeComponent();
        }

        private void SignUpForms_Load(object sender, EventArgs e)
        {
            textBox1.PlaceholderText = "Username";
            textBox2.PlaceholderText = "Email";
            textBox3.PlaceholderText = "Full Name";
            textBox4.PlaceholderText = "Password";
            textBox4.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string fullName = textBox3.Text.Trim();
            string password = textBox4.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (File.Exists(filePath))
                {
                    var existingUsers = File.ReadAllLines(filePath);
                    foreach (string user in existingUsers)
                    {
                        string[] parts = user.Split(':');
                        if (parts.Length >= 1 && parts[0] == username)
                        {
                            MessageBox.Show("Username already exists. Please choose a different one.", "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string hashedPassword = HashPassword(password);
                string userData = $"{username}:{hashedPassword}:{email}:{fullName}";
                File.AppendAllLines(filePath, new[] { userData });

                MessageBox.Show("Signup successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to login form
                this.Hide();
                loginForm login = new loginForm();
                login.Show();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Clear fields
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Go back to login without signing up
            loginForm login = new loginForm();
            login.Show();
            this.Hide();
        }

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
