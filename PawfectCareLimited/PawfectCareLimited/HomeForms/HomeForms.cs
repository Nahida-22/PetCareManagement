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
    public partial class HomeForms : Form
    {
        public HomeForms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Open the real LoginForm
                loginForm login = new loginForm();
                login.Show();

                // Close the current HomeForms screen
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
