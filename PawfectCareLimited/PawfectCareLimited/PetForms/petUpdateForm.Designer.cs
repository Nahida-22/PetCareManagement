namespace PawfectCareLimited
{
    partial class PetUpdateForm
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
            petNameLabel = new Label();
            changeToValueLabel = new Label();
            updatedPetName = new TextBox();
            petTypeLabel = new Label();
            breedLabel = new Label();
            updatedType = new TextBox();
            updatedBreed = new TextBox();
            updatedAge = new TextBox();
            updatePetButton = new Button();
            button1 = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            petAgeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // apppointmentUpdateLabel
            // 
            apppointmentUpdateLabel.AutoSize = true;
            apppointmentUpdateLabel.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            apppointmentUpdateLabel.ForeColor = Color.DarkCyan;
            apppointmentUpdateLabel.Location = new Point(227, 20);
            apppointmentUpdateLabel.Name = "apppointmentUpdateLabel";
            apppointmentUpdateLabel.Size = new Size(227, 28);
            apppointmentUpdateLabel.TabIndex = 0;
            apppointmentUpdateLabel.Text = "Update Pet Details";
            // 
            // UpdateDetailsLabel
            // 
            UpdateDetailsLabel.AutoSize = true;
            UpdateDetailsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateDetailsLabel.ForeColor = Color.DarkCyan;
            UpdateDetailsLabel.Location = new Point(236, 64);
            UpdateDetailsLabel.Name = "UpdateDetailsLabel";
            UpdateDetailsLabel.Size = new Size(221, 21);
            UpdateDetailsLabel.TabIndex = 1;
            UpdateDetailsLabel.Text = "Updating details for Pet ID: ";
            // 
            // petNameLabel
            // 
            petNameLabel.AutoSize = true;
            petNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            petNameLabel.ForeColor = SystemColors.ControlDarkDark;
            petNameLabel.Location = new Point(168, 150);
            petNameLabel.Name = "petNameLabel";
            petNameLabel.Size = new Size(80, 17);
            petNameLabel.TabIndex = 2;
            petNameLabel.Text = "Pet Name : ";
            // 
            // changeToValueLabel
            // 
            changeToValueLabel.AutoSize = true;
            changeToValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeToValueLabel.ForeColor = SystemColors.ControlDarkDark;
            changeToValueLabel.Location = new Point(375, 122);
            changeToValueLabel.Name = "changeToValueLabel";
            changeToValueLabel.Size = new Size(64, 15);
            changeToValueLabel.TabIndex = 5;
            changeToValueLabel.Text = "Change To";
            // 
            // updatedPetName
            // 
            updatedPetName.Location = new Point(304, 145);
            updatedPetName.Margin = new Padding(3, 2, 3, 2);
            updatedPetName.Name = "updatedPetName";
            updatedPetName.Size = new Size(229, 23);
            updatedPetName.TabIndex = 6;
            // 
            // petTypeLabel
            // 
            petTypeLabel.AutoSize = true;
            petTypeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            petTypeLabel.ForeColor = SystemColors.ControlDarkDark;
            petTypeLabel.Location = new Point(168, 182);
            petTypeLabel.Name = "petTypeLabel";
            petTypeLabel.Size = new Size(73, 17);
            petTypeLabel.TabIndex = 8;
            petTypeLabel.Text = "Pet Type : ";
            // 
            // breedLabel
            // 
            breedLabel.AutoSize = true;
            breedLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            breedLabel.ForeColor = SystemColors.ControlDarkDark;
            breedLabel.Location = new Point(172, 208);
            breedLabel.Name = "breedLabel";
            breedLabel.Size = new Size(55, 17);
            breedLabel.TabIndex = 9;
            breedLabel.Text = "Breed : ";
            // 
            // updatedType
            // 
            updatedType.Location = new Point(303, 176);
            updatedType.Margin = new Padding(3, 2, 3, 2);
            updatedType.Name = "updatedType";
            updatedType.Size = new Size(229, 23);
            updatedType.TabIndex = 16;
            // 
            // updatedBreed
            // 
            updatedBreed.Location = new Point(303, 208);
            updatedBreed.Margin = new Padding(3, 2, 3, 2);
            updatedBreed.Name = "updatedBreed";
            updatedBreed.Size = new Size(229, 23);
            updatedBreed.TabIndex = 17;
            // 
            // updatedAge
            // 
            updatedAge.Location = new Point(303, 237);
            updatedAge.Margin = new Padding(3, 2, 3, 2);
            updatedAge.Name = "updatedAge";
            updatedAge.Size = new Size(229, 23);
            updatedAge.TabIndex = 18;
            // 
            // updatePetButton
            // 
            updatePetButton.BackColor = Color.ForestGreen;
            updatePetButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updatePetButton.ForeColor = Color.White;
            updatePetButton.Location = new Point(294, 330);
            updatePetButton.Margin = new Padding(3, 2, 3, 2);
            updatePetButton.Name = "updatePetButton";
            updatePetButton.Size = new Size(131, 44);
            updatePetButton.TabIndex = 19;
            updatePetButton.Text = "UPDATE";
            updatePetButton.UseVisualStyleBackColor = false;
            updatePetButton.Click += updatePetButton_Click;
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
            panel1.Location = new Point(233, 84);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 1);
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
            // petAgeLabel
            // 
            petAgeLabel.AutoSize = true;
            petAgeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            petAgeLabel.ForeColor = SystemColors.ControlDarkDark;
            petAgeLabel.Location = new Point(172, 239);
            petAgeLabel.Name = "petAgeLabel";
            petAgeLabel.Size = new Size(44, 17);
            petAgeLabel.TabIndex = 10;
            petAgeLabel.Text = "Age : ";
            // 
            // PetUpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 386);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(updatePetButton);
            Controls.Add(updatedAge);
            Controls.Add(updatedBreed);
            Controls.Add(updatedType);
            Controls.Add(petAgeLabel);
            Controls.Add(breedLabel);
            Controls.Add(petTypeLabel);
            Controls.Add(updatedPetName);
            Controls.Add(changeToValueLabel);
            Controls.Add(petNameLabel);
            Controls.Add(UpdateDetailsLabel);
            Controls.Add(apppointmentUpdateLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "PetUpdateForm";
            Text = "UpdateOwnerForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label apppointmentUpdateLabel;
        private Label UpdateDetailsLabel;
        private Label petNameLabel;
        private Label changeToValueLabel;
        private TextBox updatedPetName;
        private Label petTypeLabel;
        private Label breedLabel;
        private TextBox updatedType;
        private TextBox updatedBreed;
        private TextBox updatedAge;
        private Button updatePetButton;
        private Button button1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label petAgeLabel;
    }
}
