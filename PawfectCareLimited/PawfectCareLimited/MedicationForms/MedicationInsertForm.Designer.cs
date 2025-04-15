namespace PawfectCareLimited
{
    partial class MedicationInsertForm
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
        medicationIdValue = new TextBox();
        label2 = new Label();
        medicationNameValue = new TextBox();
        supplierIdValue = new TextBox();
        stockQuantityLabel = new Label();
        stockQuantityValue = new TextBox();
        categoryLabel = new Label();
        categoryValue = new TextBox();
        unitPriceLabel = new Label();
        unitPriceValue = new TextBox();
        expiryDateLabel = new Label();
        expiryDateValue = new DateTimePicker();
        insertButton = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 16F);
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(385, 37);
        label1.TabIndex = 0;
        label1.Text = "Enter a new Medication Record";
        // 
        // medicationIdLabel
        // 
        medicationIdLabel.AutoSize = true;
        medicationIdLabel.Location = new Point(12, 78);
        medicationIdLabel.Name = "medicationIdLabel";
        medicationIdLabel.Size = new Size(110, 20);
        medicationIdLabel.TabIndex = 1;
        medicationIdLabel.Text = "Medication ID :";
        // 
        // medicationNameLabel
        // 
        medicationNameLabel.AutoSize = true;
        medicationNameLabel.Location = new Point(12, 128);
        medicationNameLabel.Name = "medicationNameLabel";
        medicationNameLabel.Size = new Size(135, 20);
        medicationNameLabel.TabIndex = 2;
        medicationNameLabel.Text = "Medication Name :";
        // 
        // medicationIdValue
        // 
        medicationIdValue.Location = new Point(164, 78);
        medicationIdValue.Name = "medicationIdValue";
        medicationIdValue.Size = new Size(193, 27);
        medicationIdValue.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 174);
        label2.Name = "label2";
        label2.Size = new Size(90, 20);
        label2.TabIndex = 4;
        label2.Text = "Supplier ID :";
        // 
        // medicationNameValue
        // 
        medicationNameValue.Location = new Point(164, 128);
        medicationNameValue.Name = "medicationNameValue";
        medicationNameValue.Size = new Size(193, 27);
        medicationNameValue.TabIndex = 5;
        // 
        // supplierIdValue
        // 
        supplierIdValue.Location = new Point(164, 171);
        supplierIdValue.Name = "supplierIdValue";
        supplierIdValue.Size = new Size(193, 27);
        supplierIdValue.TabIndex = 6;
        // 
        // stockQuantityLabel
        // 
        stockQuantityLabel.AutoSize = true;
        stockQuantityLabel.Location = new Point(12, 219);
        stockQuantityLabel.Name = "stockQuantityLabel";
        stockQuantityLabel.Size = new Size(112, 20);
        stockQuantityLabel.TabIndex = 7;
        stockQuantityLabel.Text = "Stock Quantity :";
        // 
        // stockQuantityValue
        // 
        stockQuantityValue.Location = new Point(164, 216);
        stockQuantityValue.Name = "stockQuantityValue";
        stockQuantityValue.Size = new Size(193, 27);
        stockQuantityValue.TabIndex = 8;
        // 
        // categoryLabel
        // 
        categoryLabel.AutoSize = true;
        categoryLabel.Location = new Point(12, 268);
        categoryLabel.Name = "categoryLabel";
        categoryLabel.Size = new Size(76, 20);
        categoryLabel.TabIndex = 9;
        categoryLabel.Text = "Category :";
        // 
        // categoryValue
        // 
        categoryValue.Location = new Point(164, 265);
        categoryValue.Name = "categoryValue";
        categoryValue.Size = new Size(193, 27);
        categoryValue.TabIndex = 10;
        // 
        // unitPriceLabel
        // 
        unitPriceLabel.AutoSize = true;
        unitPriceLabel.Location = new Point(16, 317);
        unitPriceLabel.Name = "unitPriceLabel";
        unitPriceLabel.Size = new Size(72, 20);
        unitPriceLabel.TabIndex = 11;
        unitPriceLabel.Text = "Unit Price";
        // 
        // unitPriceValue
        // 
        unitPriceValue.Location = new Point(164, 310);
        unitPriceValue.Name = "unitPriceValue";
        unitPriceValue.Size = new Size(193, 27);
        unitPriceValue.TabIndex = 12;
        // 
        // expiryDateLabel
        // 
        expiryDateLabel.AutoSize = true;
        expiryDateLabel.Location = new Point(16, 365);
        expiryDateLabel.Name = "expiryDateLabel";
        expiryDateLabel.Size = new Size(96, 20);
        expiryDateLabel.TabIndex = 13;
        expiryDateLabel.Text = "Expiry Date : ";
        // 
        // expiryDateValue
        // 
        expiryDateValue.Location = new Point(164, 358);
        expiryDateValue.Name = "expiryDateValue";
        expiryDateValue.Size = new Size(250, 27);
        expiryDateValue.TabIndex = 14;
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
        // MedicationInsertForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(insertButton);
        Controls.Add(expiryDateValue);
        Controls.Add(expiryDateLabel);
        Controls.Add(unitPriceValue);
        Controls.Add(unitPriceLabel);
        Controls.Add(categoryValue);
        Controls.Add(categoryLabel);
        Controls.Add(stockQuantityValue);
        Controls.Add(stockQuantityLabel);
        Controls.Add(supplierIdValue);
        Controls.Add(medicationNameValue);
        Controls.Add(label2);
        Controls.Add(medicationIdValue);
        Controls.Add(medicationNameLabel);
        Controls.Add(medicationIdLabel);
        Controls.Add(label1);
        Name = "MedicationInsertForm";
        Text = "MedicationInsertForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label medicationIdLabel;
    private Label medicationNameLabel;
    private TextBox medicationIdValue;
    private Label label2;
    private TextBox medicationNameValue;
    private TextBox supplierIdValue;
    private Label stockQuantityLabel;
    private TextBox stockQuantityValue;
    private Label categoryLabel;
    private TextBox categoryValue;
    private Label unitPriceLabel;
    private TextBox unitPriceValue;
    private Label expiryDateLabel;
    private DateTimePicker expiryDateValue;
    private Button insertButton;
}
}