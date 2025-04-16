namespace PawfectCareLimited
{
    partial class VetInsertForm
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
            vetIdLabel = new Label();
            vetNameLabel = new Label();
            vetIdValue = new TextBox();
            specialisationLabel = new Label();
            vetNameValue = new TextBox();
            specialisationValue = new TextBox();
            stockQuantityLabel = new Label();
            phoneNoValue = new TextBox();
            categoryLabel = new Label();
            emailValue = new TextBox();
            unitPriceLabel = new Label();
            addressValue = new TextBox();
            insertButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(289, 37);
            label1.TabIndex = 0;
            label1.Text = "Enter a new Vet Record";
            // 
            // vetIdLabel
            // 
            vetIdLabel.AutoSize = true;
            vetIdLabel.Location = new Point(12, 78);
            vetIdLabel.Name = "vetIdLabel";
            vetIdLabel.Size = new Size(56, 20);
            vetIdLabel.TabIndex = 1;
            vetIdLabel.Text = "Vet ID :";
            // 
            // vetNameLabel
            // 
            vetNameLabel.AutoSize = true;
            vetNameLabel.Location = new Point(12, 128);
            vetNameLabel.Name = "vetNameLabel";
            vetNameLabel.Size = new Size(81, 20);
            vetNameLabel.TabIndex = 2;
            vetNameLabel.Text = "Vet Name :";
            // 
            // vetIdValue
            // 
            vetIdValue.Location = new Point(164, 78);
            vetIdValue.Name = "vetIdValue";
            vetIdValue.Size = new Size(193, 27);
            vetIdValue.TabIndex = 3;
            // 
            // specialisationLabel
            // 
            specialisationLabel.AutoSize = true;
            specialisationLabel.Location = new Point(12, 174);
            specialisationLabel.Name = "specialisationLabel";
            specialisationLabel.Size = new Size(108, 20);
            specialisationLabel.TabIndex = 4;
            specialisationLabel.Text = "Specialisation :";
            // 
            // vetNameValue
            // 
            vetNameValue.Location = new Point(164, 128);
            vetNameValue.Name = "vetNameValue";
            vetNameValue.Size = new Size(193, 27);
            vetNameValue.TabIndex = 5;
            // 
            // specialisationValue
            // 
            specialisationValue.Location = new Point(164, 171);
            specialisationValue.Name = "specialisationValue";
            specialisationValue.Size = new Size(193, 27);
            specialisationValue.TabIndex = 6;
            // 
            // stockQuantityLabel
            // 
            stockQuantityLabel.AutoSize = true;
            stockQuantityLabel.Location = new Point(12, 219);
            stockQuantityLabel.Name = "stockQuantityLabel";
            stockQuantityLabel.Size = new Size(81, 20);
            stockQuantityLabel.TabIndex = 7;
            stockQuantityLabel.Text = "Phone No :";
            // 
            // phoneNoValue
            // 
            phoneNoValue.Location = new Point(164, 216);
            phoneNoValue.Name = "phoneNoValue";
            phoneNoValue.Size = new Size(193, 27);
            phoneNoValue.TabIndex = 8;
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(12, 268);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(53, 20);
            categoryLabel.TabIndex = 9;
            categoryLabel.Text = "Email :";
            // 
            // emailValue
            // 
            emailValue.Location = new Point(164, 265);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(193, 27);
            emailValue.TabIndex = 10;
            // 
            // unitPriceLabel
            // 
            unitPriceLabel.AutoSize = true;
            unitPriceLabel.Location = new Point(16, 317);
            unitPriceLabel.Name = "unitPriceLabel";
            unitPriceLabel.Size = new Size(73, 20);
            unitPriceLabel.TabIndex = 11;
            unitPriceLabel.Text = "Address : ";
            // 
            // addressValue
            // 
            addressValue.Location = new Point(164, 310);
            addressValue.Name = "addressValue";
            addressValue.Size = new Size(193, 27);
            addressValue.TabIndex = 12;
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
            // VetInsertForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(insertButton);
            Controls.Add(addressValue);
            Controls.Add(unitPriceLabel);
            Controls.Add(emailValue);
            Controls.Add(categoryLabel);
            Controls.Add(phoneNoValue);
            Controls.Add(stockQuantityLabel);
            Controls.Add(specialisationValue);
            Controls.Add(vetNameValue);
            Controls.Add(specialisationLabel);
            Controls.Add(vetIdValue);
            Controls.Add(vetNameLabel);
            Controls.Add(vetIdLabel);
            Controls.Add(label1);
            Name = "VetInsertForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MedicationInsertForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label vetIdLabel;
        private Label vetNameLabel;
        private TextBox vetIdValue;
        private Label specialisationLabel;
        private TextBox vetNameValue;
        private TextBox specialisationValue;
        private Label stockQuantityLabel;
        private TextBox phoneNoValue;
        private Label categoryLabel;
        private TextBox emailValue;
        private Label unitPriceLabel;
        private TextBox addressValue;
        private Button insertButton;
    }
}