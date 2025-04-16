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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(319, 37);
            label1.TabIndex = 0;
            label1.Text = "Enter a new Order Record";
            // 
            // medicationIdLabel
            // 
            medicationIdLabel.AutoSize = true;
            medicationIdLabel.Location = new Point(12, 78);
            medicationIdLabel.Name = "medicationIdLabel";
            medicationIdLabel.Size = new Size(73, 20);
            medicationIdLabel.TabIndex = 1;
            medicationIdLabel.Text = "Order ID :";
            // 
            // medicationNameLabel
            // 
            medicationNameLabel.AutoSize = true;
            medicationNameLabel.Location = new Point(12, 128);
            medicationNameLabel.Name = "medicationNameLabel";
            medicationNameLabel.Size = new Size(110, 20);
            medicationNameLabel.TabIndex = 2;
            medicationNameLabel.Text = "Medication ID :";
            // 
            // orderIdValue
            // 
            orderIdValue.Location = new Point(164, 78);
            orderIdValue.Name = "orderIdValue";
            orderIdValue.Size = new Size(193, 27);
            orderIdValue.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 174);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 4;
            label2.Text = "Quantity :";
            // 
            // medicationIdValue
            // 
            medicationIdValue.Location = new Point(164, 128);
            medicationIdValue.Name = "medicationIdValue";
            medicationIdValue.Size = new Size(193, 27);
            medicationIdValue.TabIndex = 5;
            // 
            // quantityValue
            // 
            quantityValue.Location = new Point(164, 171);
            quantityValue.Name = "quantityValue";
            quantityValue.Size = new Size(193, 27);
            quantityValue.TabIndex = 6;
            // 
            // stockQuantityLabel
            // 
            stockQuantityLabel.AutoSize = true;
            stockQuantityLabel.Location = new Point(12, 219);
            stockQuantityLabel.Name = "stockQuantityLabel";
            stockQuantityLabel.Size = new Size(98, 20);
            stockQuantityLabel.TabIndex = 7;
            stockQuantityLabel.Text = "Order Status :";
            // 
            // statusValue
            // 
            statusValue.Location = new Point(164, 216);
            statusValue.Name = "statusValue";
            statusValue.Size = new Size(193, 27);
            statusValue.TabIndex = 8;
            // 
            // expiryDateLabel
            // 
            expiryDateLabel.AutoSize = true;
            expiryDateLabel.Location = new Point(16, 265);
            expiryDateLabel.Name = "expiryDateLabel";
            expiryDateLabel.Size = new Size(94, 20);
            expiryDateLabel.TabIndex = 13;
            expiryDateLabel.Text = "Order Date : ";
            // 
            // orderDateValue
            // 
            orderDateValue.Location = new Point(164, 265);
            orderDateValue.Name = "orderDateValue";
            orderDateValue.Size = new Size(250, 27);
            orderDateValue.TabIndex = 14;
            // 
            // insertButton
            // 
            insertButton.Location = new Point(624, 380);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(127, 29);
            insertButton.TabIndex = 15;
            insertButton.Text = "Insert Record";
            insertButton.UseVisualStyleBackColor = true;
            insertButton.Click += insertButton_Click;
            // 
            // OrderInsertForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "OrderInsertForm";
            Text = "MedicationInsertForm";
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
}
}