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
    public partial class OperationsForms : Form
    {
        public OperationsForms()
        {
            InitializeComponent();
        }

        private void OperationsForms_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }

        private void newOwnerRegisterButton_Click(object sender, EventArgs e)
        {
            var registerInterfaceForm = new RegisterInterfaceForm();
            registerInterfaceForm.ShowDialog();
        }

        private void bookAppointmentButton_Click(object sender, EventArgs e)
        {
            var appointmentInsertForm = new AppointmentBookingForm();
            appointmentInsertForm.ShowDialog();
        }
    }
}
