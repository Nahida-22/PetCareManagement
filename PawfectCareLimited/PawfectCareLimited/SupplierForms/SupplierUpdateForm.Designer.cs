namespace PawfectCareLimited
{
    partial class SupplierUpdateForm
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
            apppointmentUpdateLabel = new Label();
            UpdateDetailsLabel = new Label();
            medicationNameLabel = new Label();
            changeToValueLabel = new Label();
            updatedMedicationName = new TextBox();
            stockQuantityLabel = new Label();
            categoryLabel = new Label();
            updatedStockQuantity = new TextBox();
            updatedCategory = new TextBox();
            updatedPrice = new TextBox();
            updateMedicationButton = new Button();
         
            button1 = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            expiryDateLabel = new Label();
            unitPriceLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // apppointmentUpdateLabel
            // 
            apppointmentUpdateLabel.AutoSize = true;
            apppointmentUpdateLabel.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            apppointmentUpdateLabel.ForeColor = Color.DarkCyan;
            apppointmentUpdateLabel.Location = new Point(213, 32);
            apppointmentUpdateLabel.Name = "apppointmentUpdateLabel";
            apppointmentUpdateLabel.Size = new Size(401, 34);
            apppointmentUpdateLabel.TabIndex = 0;
            apppointmentUpdateLabel.Text = "Update Medication Details";
            // 
            // UpdateDetailsLabel
            // 
            UpdateDetailsLabel.AutoSize = true;
            UpdateDetailsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateDetailsLabel.ForeColor = Color.DarkCyan;
            UpdateDetailsLabel.Location = new Point(219, 80);
            UpdateDetailsLabel.Name = "UpdateDetailsLabel";
            UpdateDetailsLabel.Size = new Size(353, 28);
            UpdateDetailsLabel.TabIndex = 1;
            UpdateDetailsLabel.Text = "Updating details for Medication ID: ";
            // 
            // medicationNameLabel
            // 
            medicationNameLabel.AutoSize = true;
            medicationNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            medicationNameLabel.ForeColor = Color.DarkCyan;
            medicationNameLabel.Location = new Point(192, 168);
            medicationNameLabel.Name = "medicationNameLabel";
            medicationNameLabel.Size = new Size(145, 20);
            medicationNameLabel.TabIndex = 2;
            medicationNameLabel.Text = "Medication Name : ";
            // 
            // changeToValueLabel
            // 
            changeToValueLabel.AutoSize = true;
            changeToValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeToValueLabel.ForeColor = SystemColors.ControlDarkDark;
            changeToValueLabel.Location = new Point(429, 131);
            changeToValueLabel.Name = "changeToValueLabel";
            changeToValueLabel.Size = new Size(82, 20);
            changeToValueLabel.TabIndex = 5;
            changeToValueLabel.Text = "Change To";
            // 
            // updatedMedicationName
            // 
            updatedMedicationName.Location = new Point(347, 161);
            updatedMedicationName.Name = "updatedMedicationName";
            updatedMedicationName.Size = new Size(261, 27);
            updatedMedicationName.TabIndex = 6;
            // 
            // stockQuantityLabel
            // 
            stockQuantityLabel.AutoSize = true;
            stockQuantityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            stockQuantityLabel.ForeColor = Color.DarkCyan;
            stockQuantityLabel.Location = new Point(192, 210);
            stockQuantityLabel.Name = "stockQuantityLabel";
            stockQuantityLabel.Size = new Size(128, 20);
            stockQuantityLabel.TabIndex = 8;
            stockQuantityLabel.Text = " Stock Quantity : ";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            categoryLabel.ForeColor = Color.DarkCyan;
            categoryLabel.Location = new Point(200, 246);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(85, 20);
            categoryLabel.TabIndex = 9;
            categoryLabel.Text = "Category : ";
            // 
            // updatedStockQuantity
            // 
            updatedStockQuantity.Location = new Point(346, 203);
            updatedStockQuantity.Name = "updatedStockQuantity";
            updatedStockQuantity.Size = new Size(261, 27);
            updatedStockQuantity.TabIndex = 16;
            // 
            // updatedCategory
            // 
            updatedCategory.Location = new Point(346, 246);
            updatedCategory.Name = "updatedCategory";
            updatedCategory.Size = new Size(261, 27);
            updatedCategory.TabIndex = 17;
            // 
            // updatedPrice
            // 
            updatedPrice.Location = new Point(346, 284);
            updatedPrice.Name = "updatedPrice";
            updatedPrice.Size = new Size(261, 27);
            updatedPrice.TabIndex = 18;
            // 
            // updateMedicationButton
            // 
            updateMedicationButton.BackColor = Color.DarkCyan;
            updateMedicationButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateMedicationButton.ForeColor = Color.White;
            updateMedicationButton.Location = new Point(584, 439);
            updateMedicationButton.Name = "updateMedicationButton";
            updateMedicationButton.Size = new Size(150, 59);
            updateMedicationButton.TabIndex = 19;
            updateMedicationButton.Text = "UPDATE";
            updateMedicationButton.UseVisualStyleBackColor = false;
            updateMedicationButton.Click += updateSupplierButton_Click;
            // 
            // updatedExpiryDate
            // 
          
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(14, 441);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(87, 57);
            button1.TabIndex = 22;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkCyan;
            panel1.Location = new Point(231, 112);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 1);
            panel1.TabIndex = 23;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(-2, -1);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 152);
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
           
            // unitPriceLabel
            // 
            unitPriceLabel.AutoSize = true;
            unitPriceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            unitPriceLabel.ForeColor = Color.DarkCyan;
            unitPriceLabel.Location = new Point(196, 287);
            unitPriceLabel.Name = "unitPriceLabel";
            unitPriceLabel.Size = new Size(89, 20);
            unitPriceLabel.TabIndex = 10;
            unitPriceLabel.Text = "Unit Price : ";
            // 
            // MedicationUpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 515);
            Controls.Add(expiryDateLabel);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(button1);
         
            Controls.Add(updateMedicationButton);
            Controls.Add(updatedPrice);
            Controls.Add(updatedCategory);
            Controls.Add(updatedStockQuantity);
            Controls.Add(unitPriceLabel);
            Controls.Add(categoryLabel);
            Controls.Add(stockQuantityLabel);
            Controls.Add(updatedMedicationName);
            Controls.Add(changeToValueLabel);
            Controls.Add(medicationNameLabel);
            Controls.Add(UpdateDetailsLabel);
            Controls.Add(apppointmentUpdateLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SupplierUpdateForm";
            Text = "UpdateOwnerForm";
            Load += SupplierUpdateForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label apppointmentUpdateLabel;
        private Label UpdateDetailsLabel;
        private Label medicationNameLabel;
        private Label changeToValueLabel;
        private TextBox updatedMedicationName;
        private Label stockQuantityLabel;
        private Label categoryLabel;
        private TextBox updatedStockQuantity;
        private TextBox updatedCategory;
        private TextBox updatedPrice;
        private Button updateMedicationButton;
      
        private Button button1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label expiryDateLabel;
        private Label unitPriceLabel;
    }
}