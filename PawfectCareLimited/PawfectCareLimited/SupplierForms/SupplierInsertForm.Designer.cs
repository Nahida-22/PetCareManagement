namespace PawfectCareLimited
{
    partial class SupplierInsertForm
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
            supplierIdLabel = new Label();
            supplierNameLabel = new Label();
            IdValue = new TextBox();
            label2 = new Label();
            supplierNameValue = new TextBox();
            PhoneNumberValue = new TextBox();
            addressLabel = new Label();
            AddressValue = new TextBox();
            emailLabel = new Label();
            emailValue = new TextBox();
            insertButton = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(198, 23);
            label1.Name = "label1";
            label1.Size = new Size(299, 24);
            label1.TabIndex = 0;
            label1.Text = "Enter a new Supplier Record";
            label1.Click += label1_Click;
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            supplierIdLabel.ForeColor = SystemColors.ControlDarkDark;
            supplierIdLabel.Location = new Point(198, 74);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new Size(85, 17);
            supplierIdLabel.TabIndex = 1;
            supplierIdLabel.Text = "Supplier ID :";
            // 
            // supplierNameLabel
            // 
            supplierNameLabel.AutoSize = true;
            supplierNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            supplierNameLabel.ForeColor = SystemColors.ControlDarkDark;
            supplierNameLabel.Location = new Point(198, 112);
            supplierNameLabel.Name = "supplierNameLabel";
            supplierNameLabel.Size = new Size(107, 17);
            supplierNameLabel.TabIndex = 2;
            supplierNameLabel.Text = "Supplier Name :";
            // 
            // IdValue
            // 
            IdValue.Location = new Point(332, 74);
            IdValue.Margin = new Padding(3, 2, 3, 2);
            IdValue.Name = "IdValue";
            IdValue.Size = new Size(169, 23);
            IdValue.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(198, 146);
            label2.Name = "label2";
            label2.Size = new Size(106, 17);
            label2.TabIndex = 4;
            label2.Text = "Phone Number:";
            // 
            // supplierNameValue
            // 
            supplierNameValue.Location = new Point(332, 112);
            supplierNameValue.Margin = new Padding(3, 2, 3, 2);
            supplierNameValue.Name = "supplierNameValue";
            supplierNameValue.Size = new Size(169, 23);
            supplierNameValue.TabIndex = 5;
            // 
            // PhoneNumberValue
            // 
            PhoneNumberValue.Location = new Point(332, 144);
            PhoneNumberValue.Margin = new Padding(3, 2, 3, 2);
            PhoneNumberValue.Name = "PhoneNumberValue";
            PhoneNumberValue.Size = new Size(169, 23);
            PhoneNumberValue.TabIndex = 6;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addressLabel.ForeColor = SystemColors.ControlDarkDark;
            addressLabel.Location = new Point(198, 180);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(65, 17);
            addressLabel.TabIndex = 7;
            addressLabel.Text = "Address :";
            // 
            // AddressValue
            // 
            AddressValue.Location = new Point(332, 178);
            AddressValue.Margin = new Padding(3, 2, 3, 2);
            AddressValue.Name = "AddressValue";
            AddressValue.Size = new Size(169, 23);
            AddressValue.TabIndex = 8;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            emailLabel.ForeColor = SystemColors.ControlDarkDark;
            emailLabel.Location = new Point(198, 217);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(50, 17);
            emailLabel.TabIndex = 9;
            emailLabel.Text = "Email :";
            // 
            // emailValue
            // 
            emailValue.Location = new Point(332, 215);
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
            insertButton.Location = new Point(291, 286);
            insertButton.Margin = new Padding(3, 2, 3, 2);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(113, 42);
            insertButton.TabIndex = 15;
            insertButton.Text = "INSERT";
            insertButton.UseVisualStyleBackColor = false;
            insertButton.Click += insertButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 285);
            button1.Name = "button1";
            button1.Size = new Size(76, 43);
            button1.TabIndex = 23;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // SupplierInsertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 338);
            Controls.Add(button1);
            Controls.Add(insertButton);
            Controls.Add(emailValue);
            Controls.Add(emailLabel);
            Controls.Add(AddressValue);
            Controls.Add(addressLabel);
            Controls.Add(PhoneNumberValue);
            Controls.Add(supplierNameValue);
            Controls.Add(label2);
            Controls.Add(IdValue);
            Controls.Add(supplierNameLabel);
            Controls.Add(supplierIdLabel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "SupplierInsertForm";
            Text = "SupplierInsertForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    private Label supplierIdLabel;
    private Label supplierNameLabel;
    private TextBox IdValue;
    private Label label2;
    private TextBox supplierNameValue;
    private TextBox PhoneNumberValue;
    private Label addressLabel;
    private TextBox AddressValue;
    private Label emailLabel;
    private TextBox emailValue;
    private Button insertButton;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion

        private Button button1;
    }
}