using System;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class MainMenuForms : Form
    {
        public MainMenuForms()
        {
            InitializeComponent();
        }

        private void MainMenuForms_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeForms homeForm = new HomeForms();
            homeForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TablesForms tablesForm = new TablesForms();
            tablesForm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            OperationsForms operationsForm = new OperationsForms();
            operationsForm.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForms usersForm = new UsersForms();
            usersForm.ShowDialog();
            this.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Ends Application.Run(mainMenu)
                // The loop in Program.cs will trigger login again
            }
        }
    }
}
