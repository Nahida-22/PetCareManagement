using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.Hide(); // Hide the current MainMenuForms
            HomeForms homeForm = new HomeForms();
            homeForm.ShowDialog();
            this.Show(); // Show the MainMenu again after HomeForms closes
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the current MainMenuForms
            // Create and show the TablesForms window
            TablesForms tablesForm = new TablesForms();
            tablesForm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the current MainMenuForms
            OperationsForms operationsForm = new OperationsForms();
            operationsForm.ShowDialog(); // Open operations form modally
            this.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForms usersForm = new UsersForms();
            usersForm.ShowDialog(); // Opens the form modally
            this.Show();

        }

    }
}
