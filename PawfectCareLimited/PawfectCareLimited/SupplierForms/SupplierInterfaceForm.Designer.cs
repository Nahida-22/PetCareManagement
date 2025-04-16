namespace PawfectCareLimited
{
    partial class SupplierInterfaceForm
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
            supplierTableDataGridView = new DataGridView();
            supplierUpdateButton = new Button();
            supplierDeleteButton = new Button();
            SearchBarTextBox = new TextBox();
            SearchButton = new Button();
            SearchFieldComboBox = new ComboBox();
            viewAllButton = new Button();
            supplierInsertButton = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)supplierTableDataGridView).BeginInit();
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
            tableLabel.Size = new Size(178, 29);
            tableLabel.TabIndex = 0;
            tableLabel.Text = "Supplier Table";
            // 
            // supplierTableDataGridView
            // 
            supplierTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            supplierTableDataGridView.Location = new Point(12, 121);
            supplierTableDataGridView.Margin = new Padding(3, 2, 3, 2);
            supplierTableDataGridView.Name = "supplierTableDataGridView";
            supplierTableDataGridView.RowHeadersWidth = 51;
            supplierTableDataGridView.Size = new Size(676, 304);
            supplierTableDataGridView.TabIndex = 1;
            // 
            // supplierUpdateButton
            // 
            supplierUpdateButton.BackColor = Color.Orange;
            supplierUpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierUpdateButton.ForeColor = Color.White;
            supplierUpdateButton.Location = new Point(288, 455);
            supplierUpdateButton.Margin = new Padding(3, 2, 3, 2);
            supplierUpdateButton.Name = "supplierUpdateButton";
            supplierUpdateButton.Size = new Size(106, 43);
            supplierUpdateButton.TabIndex = 3;
            supplierUpdateButton.Text = "UPDATE";
            supplierUpdateButton.UseVisualStyleBackColor = false;
            supplierUpdateButton.Click += supplierUpdateButton_Click;
            // 
            // supplierDeleteButton
            // 
            supplierDeleteButton.BackColor = Color.IndianRed;
            supplierDeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierDeleteButton.ForeColor = Color.White;
            supplierDeleteButton.Location = new Point(176, 455);
            supplierDeleteButton.Margin = new Padding(3, 2, 3, 2);
            supplierDeleteButton.Name = "supplierDeleteButton";
            supplierDeleteButton.Size = new Size(106, 43);
            supplierDeleteButton.TabIndex = 4;
            supplierDeleteButton.Text = "DELETE";
            supplierDeleteButton.UseVisualStyleBackColor = false;
            supplierDeleteButton.Click += supplierDeleteButton_Click;
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
            SearchFieldComboBox.Items.AddRange(new object[] { "SupplierID", "SupplierName", "PhoneNumber", "Address ", "Email" });
            SearchFieldComboBox.Location = new Point(553, 76);
            SearchFieldComboBox.Margin = new Padding(3, 2, 3, 2);
            SearchFieldComboBox.Name = "SearchFieldComboBox";
            SearchFieldComboBox.Size = new Size(133, 23);
            SearchFieldComboBox.TabIndex = 7;
            SearchFieldComboBox.SelectedIndexChanged += SearchFieldComboBox_SelectedIndexChanged;
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
            // supplierInsertButton
            // 
            supplierInsertButton.BackColor = Color.ForestGreen;
            supplierInsertButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierInsertButton.ForeColor = Color.White;
            supplierInsertButton.Location = new Point(400, 455);
            supplierInsertButton.Margin = new Padding(3, 2, 3, 2);
            supplierInsertButton.Name = "supplierInsertButton";
            supplierInsertButton.Size = new Size(106, 43);
            supplierInsertButton.TabIndex = 9;
            supplierInsertButton.Text = "INSERT";
            supplierInsertButton.UseVisualStyleBackColor = false;
            supplierInsertButton.Click += supplierInsertButton_Click;
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
            // SupplierInterfaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 564);
            Controls.Add(button1);
            Controls.Add(supplierInsertButton);
            Controls.Add(viewAllButton);
            Controls.Add(SearchFieldComboBox);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(supplierDeleteButton);
            Controls.Add(supplierUpdateButton);
            Controls.Add(supplierTableDataGridView);
            Controls.Add(tableLabel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "SupplierInterfaceForm";
            Text = "OwnerTableInterface";
            ((System.ComponentModel.ISupportInitialize)supplierTableDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tableLabel;
        private DataGridView supplierTableDataGridView;
        private Button supplierUpdateButton;
        private Button supplierDeleteButton;
        private TextBox SearchBarTextBox;
        private Button SearchButton;
        private ComboBox SearchFieldComboBox;
        private Button viewAllButton;
        private Button supplierInsertButton;
        private Button button1;
        private PictureBox pictureBox1;
    }
}