using System;
using System.IO;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class SignUpForms : Form
    {
        public SignUpForms()
        {
            InitializeComponent();
        }

        private void SignUpForms_Load(object sender, EventArgs e)
        {
            // Initialize placeholder text for the fields
            textBox1.PlaceholderText = "Username"; // Username field
            textBox2.PlaceholderText = "Email"; // Email field
            textBox3.PlaceholderText = "Full Name"; // Full Name field
            textBox4.PlaceholderText = "Password"; // Password field
            textBox4.PasswordChar = '*'; // Hide password characters
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();  // Username from textBox1
            string email = textBox2.Text.Trim();  // Email from textBox2
            string fullName = textBox3.Text.Trim();  // Full name from textBox3
            string password = textBox4.Text.Trim();  // Password from textBox4
            string filePath = "users.txt"; // Path to save user data

            // Validate the input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in both username and password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the user already exists in the file
            if (File.Exists(filePath))
            {
                var existingUsers = File.ReadAllLines(filePath);
                foreach (string user in existingUsers)
                {
                    if (user.Split(':')[0] == username)
                    {
                        MessageBox.Show("Username already exists. Please choose a different one.", "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Save the new user (username:password) to the file
            string userData = $"{username}:{password}";
            File.AppendAllLines(filePath, new[] { userData });

            // Notify the user about successful signup
            MessageBox.Show("Signup successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Clear the fields when "Clear fields" link is clicked
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Close the form when "Exit" link is clicked
            this.Close();
        }
    }
}
