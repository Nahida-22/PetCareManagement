namespace PawfectCareLimited
{
    partial class MedicationInterfaceForm
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
            tableLabel = new Label();
            medicationTableDataGridView = new DataGridView();
            petUpdateButton = new Button();
            appointmentDeleteButton = new Button();
            SearchBarTextBox = new TextBox();
            SearchButton = new Button();
            SearchFieldComboBox = new ComboBox();
            viewAllButton = new Button();
            appointmentInsertButton = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)medicationTableDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLabel
            // 
            tableLabel.AutoSize = true;
            tableLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableLabel.ForeColor = Color.DarkCyan;
            tableLabel.Location = new Point(242, 18);
            tableLabel.Name = "tableLabel";
            tableLabel.Size = new Size(208, 29);
            tableLabel.TabIndex = 0;
            tableLabel.Text = "Medication Table";
            // 
            // medicationTableDataGridView
            // 
            medicationTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            medicationTableDataGridView.Location = new Point(12, 121);
            medicationTableDataGridView.Margin = new Padding(3, 2, 3, 2);
            medicationTableDataGridView.Name = "medicationTableDataGridView";
            medicationTableDataGridView.RowHeadersWidth = 51;
            medicationTableDataGridView.Size = new Size(676, 304);
            medicationTableDataGridView.TabIndex = 1;
            // 
            // petUpdateButton
            // 
            petUpdateButton.BackColor = Color.Orange;
            petUpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            petUpdateButton.ForeColor = Color.White;
            petUpdateButton.Location = new Point(288, 455);
            petUpdateButton.Margin = new Padding(3, 2, 3, 2);
            petUpdateButton.Name = "petUpdateButton";
            petUpdateButton.Size = new Size(106, 43);
            petUpdateButton.TabIndex = 3;
            petUpdateButton.Text = "UPDATE";
            petUpdateButton.UseVisualStyleBackColor = false;
            petUpdateButton.Click += appointmentUpdateButton_Click;
            // 
            // appointmentDeleteButton
            // 
            appointmentDeleteButton.BackColor = Color.IndianRed;
            appointmentDeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentDeleteButton.ForeColor = Color.White;
            appointmentDeleteButton.Location = new Point(176, 455);
            appointmentDeleteButton.Margin = new Padding(3, 2, 3, 2);
            appointmentDeleteButton.Name = "appointmentDeleteButton";
            appointmentDeleteButton.Size = new Size(106, 43);
            appointmentDeleteButton.TabIndex = 4;
            appointmentDeleteButton.Text = "DELETE";
            appointmentDeleteButton.UseVisualStyleBackColor = false;
            appointmentDeleteButton.Click += appointmentDeleteButton_Click;
            // 
            // SearchBarTextBox
            // 
            SearchBarTextBox.Location = new Point(139, 76);
            SearchBarTextBox.Margin = new Padding(3, 2, 3, 2);
            SearchBarTextBox.Name = "SearchBarTextBox";
            SearchBarTextBox.Size = new Size(306, 23);
            SearchBarTextBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.DarkCyan;
            SearchButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(451, 66);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(96, 39);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "SEARCH";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchFieldComboBox
            // 
            SearchFieldComboBox.FormattingEnabled = true;
            SearchFieldComboBox.Items.AddRange(new object[] { "MedicationID", "MedicationName", "SupplierID", "StockQuantity", "Category", "UnitPrice", "ExpiryDate" });
            SearchFieldComboBox.Location = new Point(553, 76);
            SearchFieldComboBox.Margin = new Padding(3, 2, 3, 2);
            SearchFieldComboBox.Name = "SearchFieldComboBox";
            SearchFieldComboBox.Size = new Size(133, 23);
            SearchFieldComboBox.TabIndex = 7;
            // 
            // viewAllButton
            // 
            viewAllButton.BackColor = Color.DarkCyan;
            viewAllButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllButton.ForeColor = Color.White;
            viewAllButton.Location = new Point(601, 429);
            viewAllButton.Margin = new Padding(3, 2, 3, 2);
            viewAllButton.Name = "viewAllButton";
            viewAllButton.Size = new Size(87, 30);
            viewAllButton.TabIndex = 8;
            viewAllButton.Text = "View All";
            viewAllButton.UseVisualStyleBackColor = false;
            viewAllButton.Click += viewAllButton_Click;
            // 
            // appointmentInsertButton
            // 
            appointmentInsertButton.BackColor = Color.ForestGreen;
            appointmentInsertButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentInsertButton.ForeColor = Color.White;
            appointmentInsertButton.Location = new Point(400, 455);
            appointmentInsertButton.Margin = new Padding(3, 2, 3, 2);
            appointmentInsertButton.Name = "appointmentInsertButton";
            appointmentInsertButton.Size = new Size(106, 43);
            appointmentInsertButton.TabIndex = 9;
            appointmentInsertButton.Text = "INSERT";
            appointmentInsertButton.UseVisualStyleBackColor = false;
            appointmentInsertButton.Click += appointmentInsertButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 509);
            button1.Name = "button1";
            button1.Size = new Size(76, 43);
            button1.TabIndex = 10;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(-1, -9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 114);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // MedicationInterfaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 562);
            Controls.Add(button1);
            Controls.Add(appointmentInsertButton);
            Controls.Add(viewAllButton);
            Controls.Add(SearchFieldComboBox);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(appointmentDeleteButton);
            Controls.Add(petUpdateButton);
            Controls.Add(medicationTableDataGridView);
            Controls.Add(tableLabel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MedicationInterfaceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OwnerTableInterface";
            ((System.ComponentModel.ISupportInitialize)medicationTableDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tableLabel;
        private DataGridView medicationTableDataGridView;
        private Button petUpdateButton;
        private Button appointmentDeleteButton;
        private TextBox SearchBarTextBox;
        private Button SearchButton;
        private ComboBox SearchFieldComboBox;
        private Button viewAllButton;
        private Button appointmentInsertButton;
        private Button button1;
        private PictureBox pictureBox1;
    }
}