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
            //Populate the comboBox
            comboBox1.Items.AddRange(new string[]
            {
                "Owner", "Appointment", "Medication", "Order", "Location", "Supplier", "Pet"
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();

            if (selected == "Owner")
            {
                var ownerTableInterface = new OwnerTableInterface();
                ownerTableInterface.ShowDialog();
            }
            else if (selected == "Appointment")
            {
                var appointmentTableInterface = new AppointmentTableInterface();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide or close the current form
            this.Hide();
        }

    }
}
