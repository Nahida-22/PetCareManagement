namespace PawfectCareLimited
{
    partial class LocationTableInterface
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
            locationLabel = new Label();
            locationTableDataGridView = new DataGridView();
            locationUpdateButton = new Button();
            locationDeleteButton = new Button();
            SearchBarTextBox = new TextBox();
            SearchButton = new Button();
            SearchFieldComboBox = new ComboBox();
            viewAllButton = new Button();
            locationInsertButton = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)locationTableDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            locationLabel.ForeColor = Color.DarkCyan;
            locationLabel.Location = new Point(242, 18);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(182, 29);
            locationLabel.TabIndex = 0;
            locationLabel.Text = "Location Table";
            locationLabel.Click += locationLabel_Click;
            // 
            // locationTableDataGridView
            // 
            locationTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            locationTableDataGridView.Location = new Point(12, 121);
            locationTableDataGridView.Margin = new Padding(3, 2, 3, 2);
            locationTableDataGridView.Name = "locationTableDataGridView";
            locationTableDataGridView.RowHeadersWidth = 51;
            locationTableDataGridView.Size = new Size(676, 304);
            locationTableDataGridView.TabIndex = 1;
            // 
            // locationUpdateButton
            // 
            locationUpdateButton.BackColor = Color.Orange;
            locationUpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            locationUpdateButton.ForeColor = Color.White;
            locationUpdateButton.Location = new Point(288, 455);
            locationUpdateButton.Margin = new Padding(3, 2, 3, 2);
            locationUpdateButton.Name = "locationUpdateButton";
            locationUpdateButton.Size = new Size(106, 43);
            locationUpdateButton.TabIndex = 3;
            locationUpdateButton.Text = "UPDATE";
            locationUpdateButton.UseVisualStyleBackColor = false;
            locationUpdateButton.Click += locationUpdateButton_Click;
            // 
            // locationDeleteButton
            // 
            locationDeleteButton.BackColor = Color.IndianRed;
            locationDeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            locationDeleteButton.ForeColor = Color.White;
            locationDeleteButton.Location = new Point(176, 455);
            locationDeleteButton.Margin = new Padding(3, 2, 3, 2);
            locationDeleteButton.Name = "locationDeleteButton";
            locationDeleteButton.Size = new Size(106, 43);
            locationDeleteButton.TabIndex = 4;
            locationDeleteButton.Text = "DELETE";
            locationDeleteButton.UseVisualStyleBackColor = false;
            locationDeleteButton.Click += locationDeleteButton_Click;
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
            SearchFieldComboBox.Items.AddRange(new object[] { "LocationID", "Name", "Address", "Phone", "Email" });
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
            // locationInsertButton
            // 
            locationInsertButton.BackColor = Color.ForestGreen;
            locationInsertButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            locationInsertButton.ForeColor = Color.White;
            locationInsertButton.Location = new Point(400, 455);
            locationInsertButton.Margin = new Padding(3, 2, 3, 2);
            locationInsertButton.Name = "locationInsertButton";
            locationInsertButton.Size = new Size(106, 43);
            locationInsertButton.TabIndex = 9;
            locationInsertButton.Text = "INSERT";
            locationInsertButton.UseVisualStyleBackColor = false;
            locationInsertButton.Click += locationInsertButton_Click;
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
            // LocationTableInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 564);
            Controls.Add(button1);
            Controls.Add(locationInsertButton);
            Controls.Add(viewAllButton);
            Controls.Add(SearchFieldComboBox);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(locationDeleteButton);
            Controls.Add(locationUpdateButton);
            Controls.Add(locationTableDataGridView);
            Controls.Add(locationLabel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "LocationTableInterface";
            Text = "LocationTableInterface";
            Load += LocationTableInterface_Load_1;
            ((System.ComponentModel.ISupportInitialize)locationTableDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label locationLabel;
        private DataGridView locationTableDataGridView;
        private Button locationUpdateButton;
        private Button locationDeleteButton;
        private TextBox SearchBarTextBox;
        private Button SearchButton;
        private ComboBox SearchFieldComboBox;
        private Button viewAllButton;
        private Button locationInsertButton;
        private Button button1;
        private PictureBox pictureBox1;
    }
}
