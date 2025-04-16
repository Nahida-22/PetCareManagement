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
                Application.Exit();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void HomeForms_Load(object sender, EventArgs e)
        {

        }

        private void HomeForms_Load_1(object sender, EventArgs e)
        {

        }
    }
}
