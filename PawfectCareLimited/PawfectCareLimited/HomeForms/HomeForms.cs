using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class HomeForms : Form
    {
        private string currentUsername;
        private string currentEmail;

        // Constructor that receives username and email
        public HomeForms(string username, string email)
        {
            InitializeComponent();
            currentUsername = username;
            currentEmail = email;
        }

        private void HomeForms_Load(object sender, EventArgs e)
        {
            // Ensure you have these labels added in the Designer
            greetingLabel.Text = $"Hello, {currentUsername}!";
            label2.Text = $"Email: {currentEmail}";
            label3.Text = $"Username: {currentUsername}";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
