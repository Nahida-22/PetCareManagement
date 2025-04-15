namespace PawfectCareLimited
{
    partial class UpdateOwnerForm
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
            OwnerUpdateLabel = new Label();
            UpdateDetailsLabel = new Label();
            firstNameLabel = new Label();
            currentFirstNameValue = new Label();
            currentValueLabel = new Label();
            changeToValueLabel = new Label();
            updatedFirstName = new TextBox();
            lastNameLabel = new Label();
            phoneNumberLabel = new Label();
            emailLabel = new Label();
            addressLabel = new Label();
            currentLastNameValue = new Label();
            currentPhoneNoValue = new Label();
            currentEmailValue = new Label();
            currentAddressValue = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // OwnerUpdateLabel
            // 
            OwnerUpdateLabel.AutoSize = true;
            OwnerUpdateLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OwnerUpdateLabel.ForeColor = Color.DarkCyan;
            OwnerUpdateLabel.Location = new Point(205, 9);
            OwnerUpdateLabel.Name = "OwnerUpdateLabel";
            OwnerUpdateLabel.Size = new Size(263, 32);
            OwnerUpdateLabel.TabIndex = 0;
            OwnerUpdateLabel.Text = "Update Owner Details";
            OwnerUpdateLabel.Click += OwnerUpdateLabel_Click;
            // 
            // UpdateDetailsLabel
            // 
            UpdateDetailsLabel.AutoSize = true;
            UpdateDetailsLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateDetailsLabel.ForeColor = Color.DarkCyan;
            UpdateDetailsLabel.Location = new Point(254, 41);
            UpdateDetailsLabel.Name = "UpdateDetailsLabel";
            UpdateDetailsLabel.Size = new Size(171, 15);
            UpdateDetailsLabel.TabIndex = 1;
            UpdateDetailsLabel.Text = "Updating details for Owner ID: ";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            firstNameLabel.ForeColor = Color.DarkCyan;
            firstNameLabel.Location = new Point(130, 117);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(73, 15);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name : ";
            // 
            // currentFirstNameValue
            // 
            currentFirstNameValue.AutoSize = true;
            currentFirstNameValue.ForeColor = Color.DarkSlateGray;
            currentFirstNameValue.Location = new Point(278, 117);
            currentFirstNameValue.Name = "currentFirstNameValue";
            currentFirstNameValue.Size = new Size(107, 15);
            currentFirstNameValue.TabIndex = 3;
            currentFirstNameValue.Text = "Current First Name";
            // 
            // currentValueLabel
            // 
            currentValueLabel.AutoSize = true;
            currentValueLabel.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentValueLabel.Location = new Point(306, 82);
            currentValueLabel.Name = "currentValueLabel";
            currentValueLabel.Size = new Size(51, 14);
            currentValueLabel.TabIndex = 4;
            currentValueLabel.Text = "Current";
            // 
            // changeToValueLabel
            // 
            changeToValueLabel.AutoSize = true;
            changeToValueLabel.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            changeToValueLabel.Location = new Point(480, 82);
            changeToValueLabel.Name = "changeToValueLabel";
            changeToValueLabel.Size = new Size(70, 14);
            changeToValueLabel.TabIndex = 5;
            changeToValueLabel.Text = "Change To";
            // 
            // updatedFirstName
            // 
            updatedFirstName.ForeColor = SystemColors.WindowFrame;
            updatedFirstName.Location = new Point(442, 109);
            updatedFirstName.Margin = new Padding(3, 2, 3, 2);
            updatedFirstName.Name = "updatedFirstName";
            updatedFirstName.Size = new Size(144, 23);
            updatedFirstName.TabIndex = 6;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lastNameLabel.ForeColor = Color.DarkCyan;
            lastNameLabel.Location = new Point(130, 145);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(72, 15);
            lastNameLabel.TabIndex = 7;
            lastNameLabel.Text = "Last Name : ";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            phoneNumberLabel.ForeColor = Color.DarkCyan;
            phoneNumberLabel.Location = new Point(131, 171);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(97, 15);
            phoneNumberLabel.TabIndex = 8;
            phoneNumberLabel.Text = "Phone Number : ";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            emailLabel.ForeColor = Color.DarkCyan;
            emailLabel.Location = new Point(131, 195);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(45, 15);
            emailLabel.TabIndex = 9;
            emailLabel.Text = "Email : ";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            addressLabel.ForeColor = Color.DarkCyan;
            addressLabel.Location = new Point(131, 218);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(58, 15);
            addressLabel.TabIndex = 10;
            addressLabel.Text = "Address : ";
            // 
            // currentLastNameValue
            // 
            currentLastNameValue.AutoSize = true;
            currentLastNameValue.ForeColor = Color.DarkSlateGray;
            currentLastNameValue.Location = new Point(278, 145);
            currentLastNameValue.Name = "currentLastNameValue";
            currentLastNameValue.Size = new Size(106, 15);
            currentLastNameValue.TabIndex = 11;
            currentLastNameValue.Text = "Current Last Name";
            // 
            // currentPhoneNoValue
            // 
            currentPhoneNoValue.AutoSize = true;
            currentPhoneNoValue.ForeColor = Color.DarkSlateGray;
            currentPhoneNoValue.Location = new Point(278, 171);
            currentPhoneNoValue.Name = "currentPhoneNoValue";
            currentPhoneNoValue.Size = new Size(100, 15);
            currentPhoneNoValue.TabIndex = 12;
            currentPhoneNoValue.Text = "Current PhoneNo";
            // 
            // currentEmailValue
            // 
            currentEmailValue.AutoSize = true;
            currentEmailValue.ForeColor = Color.DarkSlateGray;
            currentEmailValue.Location = new Point(278, 195);
            currentEmailValue.Name = "currentEmailValue";
            currentEmailValue.Size = new Size(79, 15);
            currentEmailValue.TabIndex = 13;
            currentEmailValue.Text = "Current Email";
            // 
            // currentAddressValue
            // 
            currentAddressValue.AutoSize = true;
            currentAddressValue.ForeColor = Color.DarkSlateGray;
            currentAddressValue.Location = new Point(278, 218);
            currentAddressValue.Name = "currentAddressValue";
            currentAddressValue.Size = new Size(92, 15);
            currentAddressValue.TabIndex = 14;
            currentAddressValue.Text = "Current Address";
            // 
            // textBox1
            // 
            textBox1.ForeColor = SystemColors.WindowFrame;
            textBox1.Location = new Point(442, 136);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 23);
            textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.ForeColor = SystemColors.WindowFrame;
            textBox2.Location = new Point(442, 163);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(144, 23);
            textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            textBox3.ForeColor = SystemColors.WindowFrame;
            textBox3.Location = new Point(442, 190);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(144, 23);
            textBox3.TabIndex = 17;
            // 
            // textBox4
            // 
            textBox4.ForeColor = SystemColors.WindowFrame;
            textBox4.Location = new Point(442, 217);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(144, 23);
            textBox4.TabIndex = 18;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.ForeColor = Color.White;
            button1.Location = new Point(294, 270);
            button1.Name = "button1";
            button1.Size = new Size(102, 31);
            button1.TabIndex = 19;
            button1.Text = "UPDATE";
            button1.UseVisualStyleBackColor = false;
            // 
            // UpdateOwnerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 338);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(currentAddressValue);
            Controls.Add(currentEmailValue);
            Controls.Add(currentPhoneNoValue);
            Controls.Add(currentLastNameValue);
            Controls.Add(addressLabel);
            Controls.Add(emailLabel);
            Controls.Add(phoneNumberLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(updatedFirstName);
            Controls.Add(changeToValueLabel);
            Controls.Add(currentValueLabel);
            Controls.Add(currentFirstNameValue);
            Controls.Add(firstNameLabel);
            Controls.Add(UpdateDetailsLabel);
            Controls.Add(OwnerUpdateLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UpdateOwnerForm";
            Text = "UpdateOwnerForm";
            Load += UpdateOwnerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OwnerUpdateLabel;
        private Label UpdateDetailsLabel;
        private Label firstNameLabel;
        private Label currentFirstNameValue;
        private Label currentValueLabel;
        private Label changeToValueLabel;
        private TextBox updatedFirstName;
        private Label lastNameLabel;
        private Label phoneNumberLabel;
        private Label emailLabel;
        private Label addressLabel;
        private Label currentLastNameValue;
        private Label currentPhoneNoValue;
        private Label currentEmailValue;
        private Label currentAddressValue;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
    }
}