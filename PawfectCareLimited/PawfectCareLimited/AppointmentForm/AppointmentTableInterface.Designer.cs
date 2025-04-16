namespace PawfectCareLimited
{
    partial class AppointmentTableInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            appointmentLabel = new Label();
            appointmentTableDataGridView = new DataGridView();
            appointmentUpdateButton = new Button();
            appointmentDeleteButton = new Button();
            SearchBarTextBox = new TextBox();
            SearchButton = new Button();
            SearchFieldComboBox = new ComboBox();
            viewAllButton = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)appointmentTableDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // appointmentLabel
            // 
            appointmentLabel.AutoSize = true;
            appointmentLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentLabel.ForeColor = Color.DarkCyan;
            appointmentLabel.Location = new Point(277, 24);
            appointmentLabel.Name = "appointmentLabel";
            appointmentLabel.Size = new Size(281, 35);
            appointmentLabel.TabIndex = 0;
            appointmentLabel.Text = "Appointment Table";
            appointmentLabel.Click += appointmentLabel_Click;
            // 
            // appointmentTableDataGridView
            // 
            appointmentTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentTableDataGridView.Location = new Point(14, 161);
            appointmentTableDataGridView.Name = "appointmentTableDataGridView";
            appointmentTableDataGridView.RowHeadersWidth = 51;
            appointmentTableDataGridView.Size = new Size(773, 405);
            appointmentTableDataGridView.TabIndex = 1;
            // 
            // appointmentUpdateButton
            // 
            appointmentUpdateButton.BackColor = Color.Orange;
            appointmentUpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentUpdateButton.ForeColor = Color.White;
            appointmentUpdateButton.Location = new Point(329, 607);
            appointmentUpdateButton.Name = "appointmentUpdateButton";
            appointmentUpdateButton.Size = new Size(121, 57);
            appointmentUpdateButton.TabIndex = 3;
            appointmentUpdateButton.Text = "UPDATE";
            appointmentUpdateButton.UseVisualStyleBackColor = false;
            appointmentUpdateButton.Click += appointmentUpdateButton_Click;
            // 
            // appointmentDeleteButton
            // 
            appointmentDeleteButton.BackColor = Color.IndianRed;
            appointmentDeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentDeleteButton.ForeColor = Color.White;
            appointmentDeleteButton.Location = new Point(201, 607);
            appointmentDeleteButton.Name = "appointmentDeleteButton";
            appointmentDeleteButton.Size = new Size(121, 57);
            appointmentDeleteButton.TabIndex = 4;
            appointmentDeleteButton.Text = "DELETE";
            appointmentDeleteButton.UseVisualStyleBackColor = false;
            appointmentDeleteButton.Click += appointmentDeleteButton_Click;
            // 
            // SearchBarTextBox
            // 
            SearchBarTextBox.Location = new Point(159, 101);
            SearchBarTextBox.Name = "SearchBarTextBox";
            SearchBarTextBox.Size = new Size(349, 27);
            SearchBarTextBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.DarkCyan;
            SearchButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(515, 88);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(110, 52);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "SEARCH";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchFieldComboBox
            // 
            SearchFieldComboBox.FormattingEnabled = true;
            SearchFieldComboBox.Items.AddRange(new object[] { "AppointmentID", "PetID", "VetID", "ServiceType", "ApptDate", "Status", "LocationID" });
            SearchFieldComboBox.Location = new Point(632, 101);
            SearchFieldComboBox.Name = "SearchFieldComboBox";
            SearchFieldComboBox.Size = new Size(151, 28);
            SearchFieldComboBox.TabIndex = 7;
            // 
            // viewAllButton
            // 
            viewAllButton.BackColor = Color.DarkCyan;
            viewAllButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllButton.ForeColor = Color.White;
            viewAllButton.Location = new Point(687, 572);
            viewAllButton.Name = "viewAllButton";
            viewAllButton.Size = new Size(99, 40);
            viewAllButton.TabIndex = 8;
            viewAllButton.Text = "View All";
            viewAllButton.UseVisualStyleBackColor = false;
            viewAllButton.Click += viewAllButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(14, 679);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(87, 57);
            button1.TabIndex = 10;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(-1, -12);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 152);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // AppointmentTableInterface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 752);
            Controls.Add(button1);
            Controls.Add(viewAllButton);
            Controls.Add(SearchFieldComboBox);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(appointmentDeleteButton);
            Controls.Add(appointmentUpdateButton);
            Controls.Add(appointmentTableDataGridView);
            Controls.Add(appointmentLabel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AppointmentTableInterface";
            Text = "OwnerTableInterface";
            Load += AppointmentTableInterface_Load_1;
            ((System.ComponentModel.ISupportInitialize)appointmentTableDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appointmentLabel;
        private DataGridView appointmentTableDataGridView;
        private Button appointmentUpdateButton;
        private Button appointmentDeleteButton;
        private TextBox SearchBarTextBox;
        private Button SearchButton;
        private ComboBox SearchFieldComboBox;
        private Button viewAllButton;
        private Button button1;
        private PictureBox pictureBox1;
    }
}
