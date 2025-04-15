using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class UsersForms : Form
    {
        public UsersForms()
        {
            InitializeComponent();
        }

        private void UsersForms_Load(object sender, EventArgs e)
        {
            // Load the users and display them in the DataGridView in the UserForms.Designer.cs
            LoadUsers();
        }

        private void LoadUsers()
        {
            string filePath = "users.txt";

            // Check if the users.txt file exists
            if (File.Exists(filePath))
            {
                // Create a list to store the user data
                List<User> users = new List<User>();

                // Read all lines from the file "users.txt"
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // Split each line by ":" to get username and password
                    string[] userParts = line.Split(':');
                    if (userParts.Length == 2)
                    {
                        // Create a User object and add it to the list
                        users.Add(new User
                        {
                            Username = userParts[0],
                            Password = userParts[1]
                        });
                    }
                }

                // Bind the list of users to the DataGridView
                dataGridView1.DataSource = users;
            }
            else
            {
                // Show an error message if the users.txt file does not exist
                MessageBox.Show("No users found.", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Define a simple User class to store user data
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Create and show the MainForm
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Hide or close the current form
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
