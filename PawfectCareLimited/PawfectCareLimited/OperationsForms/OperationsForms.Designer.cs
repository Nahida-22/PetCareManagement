namespace PawfectCareLimited(Winforms).OperationsForms
{
    partial class OperationsForms
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
        pictureBox1 = new PictureBox();
        label1 = new Label();
        label2 = new Label();
        newOwnerRegisterButton = new Button();
        bookAppointmentButton = new Button();
        button1 = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
        pictureBox1.Location = new Point(-2, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(127, 108);
        pictureBox1.TabIndex = 1;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Britannic Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.DarkCyan;
        label1.Location = new Point(308, 52);
        label1.Name = "label1";
        label1.Size = new Size(175, 32);
        label1.TabIndex = 37;
        label1.Text = "OPERATIONS";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label2.ForeColor = Color.DarkCyan;
        label2.Location = new Point(166, 101);
        label2.Name = "label2";
        label2.Size = new Size(428, 25);
        label2.TabIndex = 38;
        label2.Text = "Register a new owner or book an appointment";
        // 
        // newOwnerRegisterButton
        // 
        newOwnerRegisterButton.BackColor = Color.ForestGreen;
        newOwnerRegisterButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        newOwnerRegisterButton.ForeColor = Color.White;
        newOwnerRegisterButton.Location = new Point(151, 196);
        newOwnerRegisterButton.Margin = new Padding(3, 2, 3, 2);
        newOwnerRegisterButton.Name = "newOwnerRegisterButton";
        newOwnerRegisterButton.Size = new Size(175, 48);
        newOwnerRegisterButton.TabIndex = 39;
        newOwnerRegisterButton.Text = "Register New Owner";
        newOwnerRegisterButton.UseVisualStyleBackColor = false;
        newOwnerRegisterButton.Click += newOwnerRegisterButton_Click;
        // 
        // bookAppointmentButton
        // 
        bookAppointmentButton.BackColor = Color.Brown;
        bookAppointmentButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        bookAppointmentButton.ForeColor = Color.White;
        bookAppointmentButton.Location = new Point(432, 196);
        bookAppointmentButton.Margin = new Padding(3, 2, 3, 2);
        bookAppointmentButton.Name = "bookAppointmentButton";
        bookAppointmentButton.Size = new Size(175, 48);
        bookAppointmentButton.TabIndex = 40;
        bookAppointmentButton.Text = "Book an Appointment";
        bookAppointmentButton.UseVisualStyleBackColor = false;
        bookAppointmentButton.Click += bookAppointmentButton_Click;
        // 
        // button1
        // 
        button1.BackColor = Color.DarkCyan;
        button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button1.ForeColor = Color.White;
        button1.Location = new Point(12, 395);
        button1.Name = "button1";
        button1.Size = new Size(76, 43);
        button1.TabIndex = 41;
        button1.Text = "BACK";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // OperationsForms
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(749, 450);
        Controls.Add(button1);
        Controls.Add(bookAppointmentButton);
        Controls.Add(newOwnerRegisterButton);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        FormBorderStyle = FormBorderStyle.None;
        Name = "OperationsForms";
        Text = "OperationsForms";
        Load += OperationsForms_Load;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Label label1;
    private Label label2;
    private Button newOwnerRegisterButton;
    private Button bookAppointmentButton;
    private Button button1;
}
}