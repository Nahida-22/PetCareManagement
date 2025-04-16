namespace PawfectCareLimited
{
    partial class OrderInsertForm
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
            medicationIdLabel = new Label();
            medicationNameLabel = new Label();
            orderIdValue = new TextBox();
            label2 = new Label();
            medicationIdValue = new TextBox();
            quantityValue = new TextBox();
            stockQuantityLabel = new Label();
            statusValue = new TextBox();
            expiryDateLabel = new Label();
            orderDateValue = new DateTimePicker();
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
            label1.Location = new Point(218, 32);
            label1.Name = "label1";
            label1.Size = new Size(273, 24);
            label1.TabIndex = 0;
            label1.Text = "Enter a new Order Record";
            // 
            // medicationIdLabel
            // 
            medicationIdLabel.AutoSize = true;
            medicationIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            medicationIdLabel.ForeColor = SystemColors.ControlDarkDark;
            medicationIdLabel.Location = new Point(177, 83);
            medicationIdLabel.Name = "medicationIdLabel";
            medicationIdLabel.Size = new Size(69, 17);
            medicationIdLabel.TabIndex = 1;
            medicationIdLabel.Text = "Order ID :";
            // 
            // medicationNameLabel
            // 
            medicationNameLabel.AutoSize = true;
            medicationNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            medicationNameLabel.ForeColor = SystemColors.ControlDarkDark;
            medicationNameLabel.Location = new Point(177, 121);
            medicationNameLabel.Name = "medicationNameLabel";
            medicationNameLabel.Size = new Size(103, 17);
            medicationNameLabel.TabIndex = 2;
            medicationNameLabel.Text = "Medication ID :";
            // 
            // orderIdValue
            // 
            orderIdValue.Location = new Point(311, 83);
            orderIdValue.Margin = new Padding(3, 2, 3, 2);
            orderIdValue.Name = "orderIdValue";
            orderIdValue.Size = new Size(219, 23);
            orderIdValue.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(177, 155);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 4;
            label2.Text = "Quantity :";
            // 
            // medicationIdValue
            // 
            medicationIdValue.Location = new Point(311, 121);
            medicationIdValue.Margin = new Padding(3, 2, 3, 2);
            medicationIdValue.Name = "medicationIdValue";
            medicationIdValue.Size = new Size(219, 23);
            medicationIdValue.TabIndex = 5;
            // 
            // quantityValue
            // 
            quantityValue.Location = new Point(311, 153);
            quantityValue.Margin = new Padding(3, 2, 3, 2);
            quantityValue.Name = "quantityValue";
            quantityValue.Size = new Size(219, 23);
            quantityValue.TabIndex = 6;
            // 
            // stockQuantityLabel
            // 
            stockQuantityLabel.AutoSize = true;
            stockQuantityLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            stockQuantityLabel.ForeColor = SystemColors.ControlDarkDark;
            stockQuantityLabel.Location = new Point(177, 189);
            stockQuantityLabel.Name = "stockQuantityLabel";
            stockQuantityLabel.Size = new Size(93, 17);
            stockQuantityLabel.TabIndex = 7;
            stockQuantityLabel.Text = "Order Status :";
            // 
            // statusValue
            // 
            statusValue.Location = new Point(311, 187);
            statusValue.Margin = new Padding(3, 2, 3, 2);
            statusValue.Name = "statusValue";
            statusValue.Size = new Size(219, 23);
            statusValue.TabIndex = 8;
            // 
            // expiryDateLabel
            // 
            expiryDateLabel.AutoSize = true;
            expiryDateLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            expiryDateLabel.ForeColor = SystemColors.ControlDarkDark;
            expiryDateLabel.Location = new Point(181, 224);
            expiryDateLabel.Name = "expiryDateLabel";
            expiryDateLabel.Size = new Size(88, 17);
            expiryDateLabel.TabIndex = 13;
            expiryDateLabel.Text = "Order Date : ";
            // 
            // orderDateValue
            // 
            orderDateValue.Location = new Point(311, 224);
            orderDateValue.Margin = new Padding(3, 2, 3, 2);
            orderDateValue.Name = "orderDateValue";
            orderDateValue.Size = new Size(219, 23);
            orderDateValue.TabIndex = 14;
            // 
            // insertButton
            // 
            insertButton.BackColor = Color.ForestGreen;
            insertButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            insertButton.ForeColor = Color.White;
            insertButton.Location = new Point(290, 278);
            insertButton.Margin = new Padding(3, 2, 3, 2);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(117, 49);
            insertButton.TabIndex = 15;
            insertButton.Text = "Insert Record";
            insertButton.UseVisualStyleBackColor = false;
            insertButton.Click += insertButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(-2, -2);
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
            button2.Location = new Point(12, 284);
            button2.Name = "button2";
            button2.Size = new Size(76, 43);
            button2.TabIndex = 35;
            button2.Text = "BACK";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // OrderInsertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 338);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(insertButton);
            Controls.Add(orderDateValue);
            Controls.Add(expiryDateLabel);
            Controls.Add(statusValue);
            Controls.Add(stockQuantityLabel);
            Controls.Add(quantityValue);
            Controls.Add(medicationIdValue);
            Controls.Add(label2);
            Controls.Add(orderIdValue);
            Controls.Add(medicationNameLabel);
            Controls.Add(medicationIdLabel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "OrderInsertForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MedicationInsertForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    private Label medicationIdLabel;
    private Label medicationNameLabel;
    private TextBox orderIdValue;
    private Label label2;
    private TextBox medicationIdValue;
    private TextBox quantityValue;
    private Label stockQuantityLabel;
    private TextBox statusValue;
    private Label expiryDateLabel;
    private DateTimePicker orderDateValue;
    private Button insertButton;
        private PictureBox pictureBox1;
        private Button button2;
    }
}