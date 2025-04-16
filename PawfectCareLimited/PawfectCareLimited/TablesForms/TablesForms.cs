using System;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class TablesForms : Form
    {
        public TablesForms()
        {
            InitializeComponent();
        }

        private void TablesForms_Load(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();

            if (selected == "Owner")
            {
                // Create an object of the type OwnerTableInterface.
                var ownerTableInterface = new OwnerTableInterface();

                // Show the window.
                ownerTableInterface.ShowDialog();
            }
            else if (selected == "Appointment")
            {
                // Create an object of the type AppointmentTableInterface.
                var appointmentTableInterface = new AppointmentTableInterface();

                // Show the window.
                appointmentTableInterface.ShowDialog();
            }
            else if (selected == "Medication")
            {
                var medicationTableInterface = new MedicationInterfaceForm();
                medicationTableInterface.ShowDialog();

            }
            else if (selected == "Order")
            {
                var orderTableInterface = new OrderInterfaceForm();
                orderTableInterface.ShowDialog();
            }
            else if (selected == "Location")
            {
                var locationTableInterface = new LocationTableInterface();
                locationTableInterface.ShowDialog();
            }
            else if (selected == "Supplier")
            {
                var supplierTableInterface = new SupplierInterfaceForm();
                supplierTableInterface.ShowDialog();
            }
            else if (selected == "Pet")
            {
                var petTableInterface = new PetTableInterface();
                petTableInterface.ShowDialog();
            }
            else if (selected == "Vet")
            {
                var vetTableInterface = new VetTableInterfaceForm();
                vetTableInterface.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }

    }
}
