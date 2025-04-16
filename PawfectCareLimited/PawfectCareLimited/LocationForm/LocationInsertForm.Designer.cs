namespace PawfectCareLimited
{
    partial class LocationInsertForm
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
            label1 = new Label();
            locationIdLabel = new Label();
            branchNameLabel = new Label();
            locationIdValue = new TextBox();
            label2 = new Label();
            branchNameValue = new TextBox();
            AddressValue = new TextBox();
            phoneNumberLabel = new Label();
            phoneNumberValue = new TextBox();
            emailLabel = new Label();
            emailValue = new TextBox();
            insertButton = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(201, 37);
            label1.Name = "label1";
            label1.Size = new Size(302, 24);
            label1.TabIndex = 0;
            label1.Text = "Enter a new Location Record";
            // 
            // locationIdLabel
            // 
            locationIdLabel.AutoSize = true;
            locationIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            locationIdLabel.ForeColor = SystemColors.ControlDarkDark;
            locationIdLabel.Location = new Point(201, 88);
            locationIdLabel.Name = "locationIdLabel";
            locationIdLabel.Size = new Size(87, 17);
            locationIdLabel.TabIndex = 1;
            locationIdLabel.Text = "Location ID :";
            // 
            // branchNameLabel
            // 
            branchNameLabel.AutoSize = true;
            branchNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            branchNameLabel.ForeColor = SystemColors.ControlDarkDark;
            branchNameLabel.Location = new Point(201, 126);
            branchNameLabel.Name = "branchNameLabel";
            branchNameLabel.Size = new Size(98, 17);
            branchNameLabel.TabIndex = 2;
            branchNameLabel.Text = "Branch Name :";
            // 
            // locationIdValue
            // 
            locationIdValue.Location = new Point(335, 88);
            locationIdValue.Margin = new Padding(3, 2, 3, 2);
            locationIdValue.Name = "locationIdValue";
            locationIdValue.Size = new Size(169, 23);
            locationIdValue.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(201, 160);
            label2.Name = "label2";
            label2.Size = new Size(69, 17);
            label2.TabIndex = 4;
            label2.Text = " Address :";
            // 
            // branchNameValue
            // 
            branchNameValue.Location = new Point(335, 126);
            branchNameValue.Margin = new Padding(3, 2, 3, 2);
            branchNameValue.Name = "branchNameValue";
            branchNameValue.Size = new Size(169, 23);
            branchNameValue.TabIndex = 5;
            // 
            // AddressValue
            // 
            AddressValue.Location = new Point(335, 158);
            AddressValue.Margin = new Padding(3, 2, 3, 2);
            AddressValue.Name = "AddressValue";
            AddressValue.Size = new Size(169, 23);
            AddressValue.TabIndex = 6;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            phoneNumberLabel.ForeColor = SystemColors.ControlDarkDark;
            phoneNumberLabel.Location = new Point(201, 194);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(109, 17);
            phoneNumberLabel.TabIndex = 7;
            phoneNumberLabel.Text = "Phone Number :";
            // 
            // phoneNumberValue
            // 
            phoneNumberValue.Location = new Point(335, 192);
            phoneNumberValue.Margin = new Padding(3, 2, 3, 2);
            phoneNumberValue.Name = "phoneNumberValue";
            phoneNumberValue.Size = new Size(169, 23);
            phoneNumberValue.TabIndex = 8;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            emailLabel.ForeColor = SystemColors.ControlDarkDark;
            emailLabel.Location = new Point(201, 231);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(50, 17);
            emailLabel.TabIndex = 9;
            emailLabel.Text = "Email :";
            // 
            // emailValue
            // 
            emailValue.Location = new Point(335, 229);
            emailValue.Margin = new Padding(3, 2, 3, 2);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(169, 23);
            emailValue.TabIndex = 10;
            // 
            // insertButton
            // 
            insertButton.BackColor = Color.ForestGreen;
            insertButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            insertButton.ForeColor = Color.White;
            insertButton.Location = new Point(287, 282);
            insertButton.Margin = new Padding(3, 2, 3, 2);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(117, 45);
            insertButton.TabIndex = 15;
            insertButton.Text = "INSERT";
            insertButton.UseVisualStyleBackColor = false;
            insertButton.Click += insertButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(-1, -5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 108);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkCyan;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(12, 282);
            button2.Name = "button2";
            button2.Size = new Size(76, 43);
            button2.TabIndex = 34;
            button2.Text = "BACK";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // LocationInsertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 338);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(insertButton);
            Controls.Add(emailValue);
            Controls.Add(emailLabel);
            Controls.Add(phoneNumberValue);
            Controls.Add(phoneNumberLabel);
            Controls.Add(AddressValue);
            Controls.Add(branchNameValue);
            Controls.Add(label2);
            Controls.Add(locationIdValue);
            Controls.Add(branchNameLabel);
            Controls.Add(locationIdLabel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "LocationInsertForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LocationInsertForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label locationIdLabel;
        private Label branchNameLabel;
        private TextBox locationIdValue;
        private Label label2;
        private TextBox branchNameValue;
        private TextBox AddressValue;
        private Label phoneNumberLabel;
        private TextBox phoneNumberValue;
        private Label emailLabel;
        private TextBox emailValue;
        private Button insertButton;
        private PictureBox pictureBox1;
        private Button button2;
    }
}