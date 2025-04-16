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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(287, 30);
            label1.TabIndex = 0;
            label1.Text = "Enter a new Location Record";
            // 
            // locationIdLabel
            // 
            locationIdLabel.AutoSize = true;
            locationIdLabel.Location = new Point(10, 58);
            locationIdLabel.Name = "locationIdLabel";
            locationIdLabel.Size = new Size(73, 15);
            locationIdLabel.TabIndex = 1;
            locationIdLabel.Text = "Location ID :";
            // 
            // branchNameLabel
            // 
            branchNameLabel.AutoSize = true;
            branchNameLabel.Location = new Point(10, 96);
            branchNameLabel.Name = "branchNameLabel";
            branchNameLabel.Size = new Size(85, 15);
            branchNameLabel.TabIndex = 2;
            branchNameLabel.Text = "Branch Name :";
            // 
            // locationIdValue
            // 
            locationIdValue.Location = new Point(144, 58);
            locationIdValue.Margin = new Padding(3, 2, 3, 2);
            locationIdValue.Name = "locationIdValue";
            locationIdValue.Size = new Size(169, 23);
            locationIdValue.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 130);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = " Address :";
            // 
            // branchNameValue
            // 
            branchNameValue.Location = new Point(144, 96);
            branchNameValue.Margin = new Padding(3, 2, 3, 2);
            branchNameValue.Name = "branchNameValue";
            branchNameValue.Size = new Size(169, 23);
            branchNameValue.TabIndex = 5;
            // 
            // AddressValue
            // 
            AddressValue.Location = new Point(144, 128);
            AddressValue.Margin = new Padding(3, 2, 3, 2);
            AddressValue.Name = "AddressValue";
            AddressValue.Size = new Size(169, 23);
            AddressValue.TabIndex = 6;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(10, 164);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(94, 15);
            phoneNumberLabel.TabIndex = 7;
            phoneNumberLabel.Text = "Phone Number :";
            // 
            // phoneNumberValue
            // 
            phoneNumberValue.Location = new Point(144, 162);
            phoneNumberValue.Margin = new Padding(3, 2, 3, 2);
            phoneNumberValue.Name = "phoneNumberValue";
            phoneNumberValue.Size = new Size(169, 23);
            phoneNumberValue.TabIndex = 8;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(10, 201);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(42, 15);
            emailLabel.TabIndex = 9;
            emailLabel.Text = "Email :";
            // 
            // emailValue
            // 
            emailValue.Location = new Point(144, 199);
            emailValue.Margin = new Padding(3, 2, 3, 2);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(169, 23);
            emailValue.TabIndex = 10;
            // 
            // insertButton
            // 
            insertButton.Location = new Point(546, 285);
            insertButton.Margin = new Padding(3, 2, 3, 2);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(111, 22);
            insertButton.TabIndex = 15;
            insertButton.Text = "Insert Record";
            insertButton.UseVisualStyleBackColor = true;
            insertButton.Click += insertButton_Click;
            // 
            // LocationInsertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "LocationInsertForm";
            Text = "LocationInsertForm";
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
    }
}