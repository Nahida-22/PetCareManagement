using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class UsersForms : Form
    {
        private string filePath = Path.Combine(Application.StartupPath, "users.txt");

        public UsersForms()
        {
            InitializeComponent();
        }

        private void UsersForms_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            if (File.Exists(filePath))
            {
                List<User> users = new List<User>();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // Each line is expected in the format: username:hashedPassword[:email][:fullName]
                    string[] userParts = line.Split(':');
                    if (userParts.Length >= 2)
                    {
                        users.Add(new User
                        {
                            Username = userParts[0],
                            Password = userParts[1]
                        });
                    }
                }

                dataGridView1.DataSource = users;
            }
            else
            {
                MessageBox.Show("No users found.", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Simple User model for DataGridView
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Or use this.Close(); depending on the navigation flow
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Add logic here for future interactivity
        }
    }
}
