namespace PawfectCareLimited
{
    partial class VetTableInterfaceForm
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
            vetTableDataGridView = new DataGridView();
            vetUpdateButton = new Button();
            SearchBarTextBox = new TextBox();
            SearchButton = new Button();
            SearchFieldComboBox = new ComboBox();
            viewAllButton = new Button();
            vetInsertButton = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)vetTableDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLabel
            // 
            tableLabel.AutoSize = true;
            tableLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableLabel.ForeColor = Color.DarkCyan;
            tableLabel.Location = new Point(277, 24);
            tableLabel.Name = "tableLabel";
            tableLabel.Size = new Size(144, 35);
            tableLabel.TabIndex = 0;
            tableLabel.Text = "Vet Table";
            // 
            // vetTableDataGridView
            // 
            vetTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            vetTableDataGridView.Location = new Point(14, 161);
            vetTableDataGridView.Name = "vetTableDataGridView";
            vetTableDataGridView.RowHeadersWidth = 51;
            vetTableDataGridView.Size = new Size(773, 405);
            vetTableDataGridView.TabIndex = 1;
            // 
            // vetUpdateButton
            // 
            vetUpdateButton.BackColor = Color.Orange;
            vetUpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vetUpdateButton.ForeColor = Color.White;
            vetUpdateButton.Location = new Point(329, 607);
            vetUpdateButton.Name = "vetUpdateButton";
            vetUpdateButton.Size = new Size(121, 57);
            vetUpdateButton.TabIndex = 3;
            vetUpdateButton.Text = "UPDATE";
            vetUpdateButton.UseVisualStyleBackColor = false;
            vetUpdateButton.Click += vetUpdateButton_Click;
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
            SearchFieldComboBox.Items.AddRange(new object[] { "VetID", "VetName", "Specialisation", "PhoneNo", "Email", "Address" });
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
            // vetInsertButton
            // 
            vetInsertButton.BackColor = Color.ForestGreen;
            vetInsertButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vetInsertButton.ForeColor = Color.White;
            vetInsertButton.Location = new Point(457, 607);
            vetInsertButton.Name = "vetInsertButton";
            vetInsertButton.Size = new Size(121, 57);
            vetInsertButton.TabIndex = 9;
            vetInsertButton.Text = "INSERT";
            vetInsertButton.UseVisualStyleBackColor = false;
            vetInsertButton.Click += vetInsertButton_Click;
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
            // VetTableInterfaceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 752);
            Controls.Add(button1);
            Controls.Add(vetInsertButton);
            Controls.Add(viewAllButton);
            Controls.Add(SearchFieldComboBox);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(vetUpdateButton);
            Controls.Add(vetTableDataGridView);
            Controls.Add(tableLabel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "VetTableInterfaceForm";
            Text = "OwnerTableInterface";
            ((System.ComponentModel.ISupportInitialize)vetTableDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tableLabel;
        private DataGridView vetTableDataGridView;
        private Button vetUpdateButton;
        private Button vetDeleteButton;
        private TextBox SearchBarTextBox;
        private Button SearchButton;
        private ComboBox SearchFieldComboBox;
        private Button viewAllButton;
        private Button vetInsertButton;
        private Button button1;
        private PictureBox pictureBox1;
    }
}
