namespace PawfectCareLimited
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
            ExisitngOwnerButton = new Button();
            NewOwnerButton = new Button();
            RegistrationLabel = new Label();
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
            Registration.Margin = new Padding(3, 2, 3, 2);
            Registration.Multiline = true;
            Registration.Name = "Registration";
            Registration.RightToLeft = RightToLeft.No;
            Registration.SelectedIndex = 0;
            Registration.Size = new Size(690, 338);
            Registration.SizeMode = TabSizeMode.Fixed;
            Registration.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.Controls.Add(ExisitngOwnerButton);
            tabPage1.Controls.Add(NewOwnerButton);
            tabPage1.Controls.Add(RegistrationLabel);
            tabPage1.Location = new Point(27, 4);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(659, 330);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Operations";
            // 
            // ExisitngOwnerButton
            // 
            ExisitngOwnerButton.Location = new Point(360, 140);
            ExisitngOwnerButton.Margin = new Padding(3, 2, 3, 2);
            ExisitngOwnerButton.Name = "ExisitngOwnerButton";
            ExisitngOwnerButton.Size = new Size(165, 39);
            ExisitngOwnerButton.TabIndex = 3;
            ExisitngOwnerButton.Text = "Existing Owner";
            ExisitngOwnerButton.UseVisualStyleBackColor = true;
            // 
            // NewOwnerButton
            // 
            NewOwnerButton.Location = new Point(125, 140);
            NewOwnerButton.Margin = new Padding(3, 2, 3, 2);
            NewOwnerButton.Name = "NewOwnerButton";
            NewOwnerButton.Size = new Size(107, 39);
            NewOwnerButton.TabIndex = 2;
            NewOwnerButton.Text = "New Owner";
            NewOwnerButton.UseVisualStyleBackColor = true;
            // 
            // RegistrationLabel
            // 
            RegistrationLabel.AutoSize = true;
            RegistrationLabel.Font = new Font("Segoe UI", 16F);
            RegistrationLabel.Location = new Point(238, 22);
            RegistrationLabel.Name = "RegistrationLabel";
            RegistrationLabel.Size = new Size(144, 30);
            RegistrationLabel.TabIndex = 1;
            RegistrationLabel.Text = "Register a Pet";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(TablesLabel);
            tabPage2.Location = new Point(27, 4);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(659, 330);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Database";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Owner", "Pet", "Appointment" });
            comboBox1.Location = new Point(13, 41);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(133, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Select a table";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // TablesLabel
            // 
            TablesLabel.AutoSize = true;
            TablesLabel.Font = new Font("Segoe UI", 16F);
            TablesLabel.Location = new Point(13, 11);
            TablesLabel.Name = "TablesLabel";
            TablesLabel.Size = new Size(73, 30);
            TablesLabel.TabIndex = 0;
            TablesLabel.Text = "Tables";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(Registration);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Form2";
            Registration.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl Registration;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label RegistrationLabel;
        private Button ExisitngOwnerButton;
        private Button NewOwnerButton;
        private Label TablesLabel;
        private ComboBox comboBox1;
    }
}