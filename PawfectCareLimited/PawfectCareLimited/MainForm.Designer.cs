﻿namespace PawfectCareLimited
{
    partial class MainForm
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
            Registration = new TabControl();
            tabPage1 = new TabPage();
            bookAppointmentButton = new Button();
            newOwnerRegisterButton = new Button();
            tabPage2 = new TabPage();
            comboBox1 = new ComboBox();
            TablesLabel = new Label();
            Registration.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // Registration
            // 
            Registration.Alignment = TabAlignment.Left;
            Registration.Controls.Add(tabPage1);
            Registration.Controls.Add(tabPage2);
            Registration.Dock = DockStyle.Left;
            Registration.Location = new Point(0, 0);
            Registration.Multiline = true;
            Registration.Name = "Registration";
            Registration.RightToLeft = RightToLeft.No;
            Registration.SelectedIndex = 0;
            Registration.Size = new Size(789, 451);
            Registration.SizeMode = TabSizeMode.Fixed;
            Registration.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.Controls.Add(bookAppointmentButton);
            tabPage1.Controls.Add(newOwnerRegisterButton);
            tabPage1.Location = new Point(30, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new Size(755, 443);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Operations";
            tabPage1.Click += tabPage1_Click;
            // 
            // bookAppointmentButton
            // 
            bookAppointmentButton.Location = new Point(414, 45);
            bookAppointmentButton.Name = "bookAppointmentButton";
            bookAppointmentButton.Size = new Size(185, 37);
            bookAppointmentButton.TabIndex = 1;
            bookAppointmentButton.Text = "Book an Appointment";
            bookAppointmentButton.UseVisualStyleBackColor = true;
            bookAppointmentButton.Click += bookAppointmentButton_Click;
            // 
            // newOwnerRegisterButton
            // 
            newOwnerRegisterButton.Location = new Point(55, 45);
            newOwnerRegisterButton.Name = "newOwnerRegisterButton";
            newOwnerRegisterButton.Size = new Size(197, 37);
            newOwnerRegisterButton.TabIndex = 0;
            newOwnerRegisterButton.Text = "Register New Owner";
            newOwnerRegisterButton.UseVisualStyleBackColor = true;
            newOwnerRegisterButton.Click += newOwnerRegisterButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(TablesLabel);
            tabPage2.Location = new Point(30, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new Size(755, 443);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Database";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Owner", "Pet", "Appointment", "Medication", "Location", "Owner", "Order", "Supplier", "Vet" });
            comboBox1.Location = new Point(17, 73);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Select a table";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // TablesLabel
            // 
            TablesLabel.AutoSize = true;
            TablesLabel.Font = new Font("Segoe UI", 16F);
            TablesLabel.Location = new Point(15, 15);
            TablesLabel.Name = "TablesLabel";
            TablesLabel.Size = new Size(90, 37);
            TablesLabel.TabIndex = 0;
            TablesLabel.Text = "Tables";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(Registration);
            Name = "MainForm";
            Text = "Form2";
            Registration.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl Registration;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label TablesLabel;
        private ComboBox comboBox1;
        private Button bookAppointmentButton;
        private Button newOwnerRegisterButton;
    }
}