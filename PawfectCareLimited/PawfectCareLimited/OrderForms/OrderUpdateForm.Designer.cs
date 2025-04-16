namespace PawfectCareLimited
{
    partial class OrderUpdateForm
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
            updatedMedicationId = new TextBox();
            stockQuantityLabel = new Label();
            updatedQuantity = new TextBox();
            updatedOrderStatus = new TextBox();
            updateOrderButton = new Button();
            updatedOrderDate = new DateTimePicker();
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
            apppointmentUpdateLabel.Location = new Point(216, 21);
            apppointmentUpdateLabel.Name = "apppointmentUpdateLabel";
            apppointmentUpdateLabel.Size = new Size(259, 28);
            apppointmentUpdateLabel.TabIndex = 0;
            apppointmentUpdateLabel.Text = "Update Order Details";
            // 
            // UpdateDetailsLabel
            // 
            UpdateDetailsLabel.AutoSize = true;
            UpdateDetailsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateDetailsLabel.ForeColor = Color.DarkCyan;
            UpdateDetailsLabel.Location = new Point(202, 60);
            UpdateDetailsLabel.Name = "UpdateDetailsLabel";
            UpdateDetailsLabel.Size = new Size(283, 21);
            UpdateDetailsLabel.TabIndex = 1;
            UpdateDetailsLabel.Text = "Updating details for Medication ID: ";
            // 
            // medicationNameLabel
            // 
            medicationNameLabel.AutoSize = true;
            medicationNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            medicationNameLabel.ForeColor = Color.DarkCyan;
            medicationNameLabel.Location = new Point(168, 126);
            medicationNameLabel.Name = "medicationNameLabel";
            medicationNameLabel.Size = new Size(94, 15);
            medicationNameLabel.TabIndex = 2;
            medicationNameLabel.Text = "Medication ID : ";
            // 
            // changeToValueLabel
            // 
            changeToValueLabel.AutoSize = true;
            changeToValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeToValueLabel.ForeColor = SystemColors.ControlDarkDark;
            changeToValueLabel.Location = new Point(375, 98);
            changeToValueLabel.Name = "changeToValueLabel";
            changeToValueLabel.Size = new Size(64, 15);
            changeToValueLabel.TabIndex = 5;
            changeToValueLabel.Text = "Change To";
            // 
            // updatedMedicationId
            // 
            updatedMedicationId.Location = new Point(304, 121);
            updatedMedicationId.Margin = new Padding(3, 2, 3, 2);
            updatedMedicationId.Name = "updatedMedicationId";
            updatedMedicationId.Size = new Size(229, 23);
            updatedMedicationId.TabIndex = 6;
            // 
            // stockQuantityLabel
            // 
            stockQuantityLabel.AutoSize = true;
            stockQuantityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            stockQuantityLabel.ForeColor = Color.DarkCyan;
            stockQuantityLabel.Location = new Point(172, 154);
            stockQuantityLabel.Name = "stockQuantityLabel";
            stockQuantityLabel.Size = new Size(64, 15);
            stockQuantityLabel.TabIndex = 8;
            stockQuantityLabel.Text = "Quantity : ";
            // 
            // updatedQuantity
            // 
            updatedQuantity.Location = new Point(303, 152);
            updatedQuantity.Margin = new Padding(3, 2, 3, 2);
            updatedQuantity.Name = "updatedQuantity";
            updatedQuantity.Size = new Size(229, 23);
            updatedQuantity.TabIndex = 16;
            // 
            // updatedOrderStatus
            // 
            updatedOrderStatus.Location = new Point(303, 194);
            updatedOrderStatus.Margin = new Padding(3, 2, 3, 2);
            updatedOrderStatus.Name = "updatedOrderStatus";
            updatedOrderStatus.Size = new Size(229, 23);
            updatedOrderStatus.TabIndex = 18;
            // 
            // updateOrderButton
            // 
            updateOrderButton.BackColor = Color.DarkCyan;
            updateOrderButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateOrderButton.ForeColor = Color.White;
            updateOrderButton.Location = new Point(511, 329);
            updateOrderButton.Margin = new Padding(3, 2, 3, 2);
            updateOrderButton.Name = "updateOrderButton";
            updateOrderButton.Size = new Size(131, 44);
            updateOrderButton.TabIndex = 19;
            updateOrderButton.Text = "UPDATE";
            updateOrderButton.UseVisualStyleBackColor = false;
            updateOrderButton.Click += updateMedicationButton_Click;
            // 
            // updatedOrderDate
            // 
            updatedOrderDate.Location = new Point(303, 235);
            updatedOrderDate.Margin = new Padding(3, 2, 3, 2);
            updatedOrderDate.Name = "updatedOrderDate";
            updatedOrderDate.Size = new Size(229, 23);
            updatedOrderDate.TabIndex = 20;
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
            panel1.Location = new Point(202, 84);
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
            // expiryDateLabel
            // 
            expiryDateLabel.AutoSize = true;
            expiryDateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            expiryDateLabel.ForeColor = Color.DarkCyan;
            expiryDateLabel.Location = new Point(172, 235);
            expiryDateLabel.Name = "expiryDateLabel";
            expiryDateLabel.Size = new Size(79, 15);
            expiryDateLabel.TabIndex = 26;
            expiryDateLabel.Text = "Order Date : ";
            // 
            // unitPriceLabel
            // 
            unitPriceLabel.AutoSize = true;
            unitPriceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            unitPriceLabel.ForeColor = Color.DarkCyan;
            unitPriceLabel.Location = new Point(172, 194);
            unitPriceLabel.Name = "unitPriceLabel";
            unitPriceLabel.Size = new Size(87, 15);
            unitPriceLabel.TabIndex = 10;
            unitPriceLabel.Text = "Order Status : ";
            // 
            // OrderUpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 386);
            Controls.Add(expiryDateLabel);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(updatedOrderDate);
            Controls.Add(updateOrderButton);
            Controls.Add(updatedOrderStatus);
            Controls.Add(updatedQuantity);
            Controls.Add(unitPriceLabel);
            Controls.Add(stockQuantityLabel);
            Controls.Add(updatedMedicationId);
            Controls.Add(changeToValueLabel);
            Controls.Add(medicationNameLabel);
            Controls.Add(UpdateDetailsLabel);
            Controls.Add(apppointmentUpdateLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "OrderUpdateForm";
            Text = "UpdateOwnerForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label apppointmentUpdateLabel;
        private Label UpdateDetailsLabel;
        private Label medicationNameLabel;
        private Label changeToValueLabel;
        private TextBox updatedMedicationId;
        private Label stockQuantityLabel;
        private TextBox updatedQuantity;
        private TextBox updatedOrderStatus;
        private Button updateOrderButton;
        private DateTimePicker updatedOrderDate;
        private Button button1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label expiryDateLabel;
        private Label unitPriceLabel;
    }
}