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
            appointmentInsertButton = new Button();
            ((System.ComponentModel.ISupportInitialize)appointmentTableDataGridView).BeginInit();
            SuspendLayout();
            // 
            // appointmentLabel
            // 
            appointmentLabel.AutoSize = true;
            appointmentLabel.Font = new Font("Segoe UI", 18F);
            appointmentLabel.Location = new Point(12, 9);
            appointmentLabel.Name = "appointmentLabel";
            appointmentLabel.Size = new Size(271, 41);
            appointmentLabel.TabIndex = 0;
            appointmentLabel.Text = "Appointment Table";
            // 
            // appointmentTableDataGridView
            // 
            appointmentTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentTableDataGridView.Location = new Point(12, 53);
            appointmentTableDataGridView.Name = "appointmentTableDataGridView";
            appointmentTableDataGridView.RowHeadersWidth = 51;
            appointmentTableDataGridView.Size = new Size(776, 316);
            appointmentTableDataGridView.TabIndex = 1;
            // 
            // appointmentUpdateButton
            // 
            appointmentUpdateButton.Location = new Point(112, 389);
            appointmentUpdateButton.Name = "appointmentUpdateButton";
            appointmentUpdateButton.Size = new Size(94, 29);
            appointmentUpdateButton.TabIndex = 3;
            appointmentUpdateButton.Text = "Update";
            appointmentUpdateButton.UseVisualStyleBackColor = true;
            appointmentUpdateButton.Click += appointmentUpdateButton_Click;
            // 
            // appointmentDeleteButton
            // 
            appointmentDeleteButton.Location = new Point(12, 389);
            appointmentDeleteButton.Name = "appointmentDeleteButton";
            appointmentDeleteButton.Size = new Size(94, 29);
            appointmentDeleteButton.TabIndex = 4;
            appointmentDeleteButton.Text = "Delete";
            appointmentDeleteButton.UseVisualStyleBackColor = true;
            appointmentDeleteButton.Click += appointmentDeleteButton_Click;
            // 
            // SearchBarTextBox
            // 
            SearchBarTextBox.Location = new Point(279, 20);
            SearchBarTextBox.Name = "SearchBarTextBox";
            SearchBarTextBox.Size = new Size(182, 27);
            SearchBarTextBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(467, 19);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(94, 29);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchFieldComboBox
            // 
            SearchFieldComboBox.FormattingEnabled = true;
            SearchFieldComboBox.Items.AddRange(new object[] { "AppointmentID", "PetID", "VetID", "ServiceType", "ApptDate", "Status", "LocationID" });
            SearchFieldComboBox.Location = new Point(567, 19);
            SearchFieldComboBox.Name = "SearchFieldComboBox";
            SearchFieldComboBox.Size = new Size(151, 28);
            SearchFieldComboBox.TabIndex = 7;
            // 
            // viewAllButton
            // 
            viewAllButton.Location = new Point(694, 389);
            viewAllButton.Name = "viewAllButton";
            viewAllButton.Size = new Size(94, 29);
            viewAllButton.TabIndex = 8;
            viewAllButton.Text = "View All";
            viewAllButton.UseVisualStyleBackColor = true;
            viewAllButton.Click += viewAllButton_Click;
            // 
            // appointmentInsertButton
            // 
            appointmentInsertButton.Location = new Point(212, 389);
            appointmentInsertButton.Name = "appointmentInsertButton";
            appointmentInsertButton.Size = new Size(94, 29);
            appointmentInsertButton.TabIndex = 9;
            appointmentInsertButton.Text = "Insert";
            appointmentInsertButton.UseVisualStyleBackColor = true;
            appointmentInsertButton.Click += appointmentInsertButton_Click;
            // 
            // AppointmentTableInterface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(appointmentInsertButton);
            Controls.Add(viewAllButton);
            Controls.Add(SearchFieldComboBox);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(appointmentDeleteButton);
            Controls.Add(appointmentUpdateButton);
            Controls.Add(appointmentTableDataGridView);
            Controls.Add(appointmentLabel);
            Name = "AppointmentTableInterface";
            Text = "OwnerTableInterface";
            ((System.ComponentModel.ISupportInitialize)appointmentTableDataGridView).EndInit();
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
        private Button appointmentInsertButton;
    }
}
