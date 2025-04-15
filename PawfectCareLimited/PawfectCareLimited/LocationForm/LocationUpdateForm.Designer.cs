namespace PawfectCareLimited
{
    partial class LocationUpdateForm
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
            locationUpdateLabel = new Label();
            UpdateDetailsLabel = new Label();
            NameTypeLabel = new Label();
            changeToValueLabel = new Label();
            updatedBranchName = new TextBox();
            phoneLabel = new Label();
            emailLabel = new Label();
            addressLabel = new Label();
            updatedAddress = new TextBox();
            updatedPhone = new TextBox();
            updatedEmail = new TextBox();
            updateLocationButton = new Button();
            button1 = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // locationUpdateLabel
            // 
            locationUpdateLabel.AutoSize = true;
            locationUpdateLabel.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            locationUpdateLabel.ForeColor = Color.DarkCyan;
            locationUpdateLabel.Location = new Point(186, 24);
            locationUpdateLabel.Name = "locationUpdateLabel";
            locationUpdateLabel.Size = new Size(288, 28);
            locationUpdateLabel.TabIndex = 0;
            locationUpdateLabel.Text = "Update Location Details";
            locationUpdateLabel.Click += locationUpdateLabel_Click;
            // 
            // UpdateDetailsLabel
            // 
            UpdateDetailsLabel.AutoSize = true;
            UpdateDetailsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateDetailsLabel.ForeColor = Color.DarkCyan;
            UpdateDetailsLabel.Location = new Point(202, 73);
            UpdateDetailsLabel.Name = "UpdateDetailsLabel";
            UpdateDetailsLabel.Size = new Size(262, 21);
            UpdateDetailsLabel.TabIndex = 1;
            UpdateDetailsLabel.Text = "Updating details for Location ID: ";
            // 
            // NameTypeLabel
            // 
            NameTypeLabel.AutoSize = true;
            NameTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            NameTypeLabel.ForeColor = Color.DarkCyan;
            NameTypeLabel.Location = new Point(172, 144);
            NameTypeLabel.Name = "NameTypeLabel";
            NameTypeLabel.Size = new Size(91, 15);
            NameTypeLabel.TabIndex = 2;
            NameTypeLabel.Text = "Branch Name : ";
            // 
            // changeToValueLabel
            // 
            changeToValueLabel.AutoSize = true;
            changeToValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeToValueLabel.ForeColor = SystemColors.ControlDarkDark;
            changeToValueLabel.Location = new Point(385, 114);
            changeToValueLabel.Name = "changeToValueLabel";
            changeToValueLabel.Size = new Size(64, 15);
            changeToValueLabel.TabIndex = 5;
            changeToValueLabel.Text = "Change To";
            // 
            // updatedBranchName
            // 
            updatedBranchName.Location = new Point(304, 142);
            updatedBranchName.Margin = new Padding(3, 2, 3, 2);
            updatedBranchName.Name = "updatedBranchName";
            updatedBranchName.Size = new Size(229, 23);
            updatedBranchName.TabIndex = 6;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            phoneLabel.ForeColor = Color.DarkCyan;
            phoneLabel.Location = new Point(173, 201);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(48, 15);
            phoneLabel.TabIndex = 8;
            phoneLabel.Text = "Phone :";
            phoneLabel.Click += locationStatusLabel_Click;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            emailLabel.ForeColor = Color.DarkCyan;
            emailLabel.Location = new Point(173, 237);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(45, 15);
            emailLabel.TabIndex = 9;
            emailLabel.Text = "Email : ";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            addressLabel.ForeColor = Color.DarkCyan;
            addressLabel.Location = new Point(172, 172);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(60, 15);
            addressLabel.TabIndex = 10;
            addressLabel.Text = "Address : ";
            // 
            // updatedAddress
            // 
            updatedAddress.Location = new Point(304, 169);
            updatedAddress.Margin = new Padding(3, 2, 3, 2);
            updatedAddress.Name = "updatedAddress";
            updatedAddress.Size = new Size(229, 23);
            updatedAddress.TabIndex = 16;
            // 
            // updatedPhone
            // 
            updatedPhone.Location = new Point(304, 198);
            updatedPhone.Margin = new Padding(3, 2, 3, 2);
            updatedPhone.Name = "updatedPhone";
            updatedPhone.Size = new Size(229, 23);
            updatedPhone.TabIndex = 17;
            updatedPhone.TextChanged += updatedVetName_TextChanged;
            // 
            // updatedEmail
            // 
            updatedEmail.Location = new Point(304, 237);
            updatedEmail.Margin = new Padding(3, 2, 3, 2);
            updatedEmail.Name = "updatedEmail";
            updatedEmail.Size = new Size(229, 23);
            updatedEmail.TabIndex = 18;
            // 
            // updateLocationButton
            // 
            updateLocationButton.BackColor = Color.DarkCyan;
            updateLocationButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateLocationButton.ForeColor = Color.White;
            updateLocationButton.Location = new Point(303, 330);
            updateLocationButton.Margin = new Padding(3, 2, 3, 2);
            updateLocationButton.Name = "updateLocationButton";
            updateLocationButton.Size = new Size(131, 44);
            updateLocationButton.TabIndex = 19;
            updateLocationButton.Text = "UPDATE";
            updateLocationButton.UseVisualStyleBackColor = false;
            updateLocationButton.Click += updateLocationButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 331);
            button1.Name = "button1";
            button1.Size = new Size(76, 43);
            button1.TabIndex = 22;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkCyan;
            panel1.Location = new Point(202, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(298, 1);
            panel1.TabIndex = 23;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(-2, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 114);
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // LocationUpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 386);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(updateLocationButton);
            Controls.Add(updatedEmail);
            Controls.Add(updatedPhone);
            Controls.Add(updatedAddress);
            Controls.Add(addressLabel);
            Controls.Add(emailLabel);
            Controls.Add(phoneLabel);
            Controls.Add(updatedBranchName);
            Controls.Add(changeToValueLabel);
            Controls.Add(NameTypeLabel);
            Controls.Add(UpdateDetailsLabel);
            Controls.Add(locationUpdateLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "LocationUpdateForm";
            Text = "UpdateOwnerForm";
            Load += locationUpdateForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label locationUpdateLabel;
        private Label UpdateDetailsLabel;
        private Label NameTypeLabel;
        private Label changeToValueLabel;
        private TextBox updatedBranchName;
        private Label phoneLabel;
        private Label emailLabel;
        private Label addressLabel;
        private TextBox updatedAddress;
        private TextBox updatedPhone;
        private TextBox updatedEmail;
        private Button updateLocationButton;
        private Button button1;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}
