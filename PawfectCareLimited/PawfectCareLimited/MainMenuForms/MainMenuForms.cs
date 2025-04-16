namespace PawfectCareLimited
{
    public partial class MainMenuForms : Form
    {
        private Form loginForm;

        // Add this constructor
        public MainMenuForms(Form loginFormRef)
        {
            InitializeComponent();
            loginForm = loginFormRef; // Store reference to login form
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

        // Add a logout button handler
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
