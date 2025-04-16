namespace PawfectCareLimited
{
    partial class AppointmentBookingForm
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
            bookAppointmentLabel = new Label();
            lastNameLabel = new Label();
            petDetailsLabel = new Label();
            petIdLabel = new Label();
            petIdValue = new TextBox();
            appointmentDetailsLabel = new Label();
            appointmentDateBooking = new Label();
            appointmentDateValue = new DateTimePicker();
            serviceTypeBooking = new Label();
            serviceTypeBookingValue = new TextBox();
            locationBookingLabel = new Label();
            locationIdBookingValue = new TextBox();
            assignedToVetBooking = new Label();
            assignedToVetIdBookingValue = new TextBox();
            bookAppointmentButton = new Button();
            appointmentIdBooking = new Label();
            appointmentIdValue = new TextBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // bookAppointmentLabel
            // 
            bookAppointmentLabel.AutoSize = true;
            bookAppointmentLabel.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bookAppointmentLabel.ForeColor = Color.DarkCyan;
            bookAppointmentLabel.Location = new Point(224, 9);
            bookAppointmentLabel.Name = "bookAppointmentLabel";
            bookAppointmentLabel.Size = new Size(255, 28);
            bookAppointmentLabel.TabIndex = 0;
            bookAppointmentLabel.Text = "Book an appointment";
            // 
            // lastNameLabel
            // 
            lastNameLabel.Location = new Point(0, 0);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(100, 23);
            lastNameLabel.TabIndex = 26;
            // 
            // petDetailsLabel
            // 
            petDetailsLabel.AutoSize = true;
            petDetailsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            petDetailsLabel.ForeColor = Color.DarkCyan;
            petDetailsLabel.Location = new Point(10, 116);
            petDetailsLabel.Name = "petDetailsLabel";
            petDetailsLabel.Size = new Size(92, 21);
            petDetailsLabel.TabIndex = 6;
            petDetailsLabel.Text = "Pet Details";
            // 
            // petIdLabel
            // 
            petIdLabel.AutoSize = true;
            petIdLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            petIdLabel.ForeColor = SystemColors.ControlDarkDark;
            petIdLabel.Location = new Point(10, 150);
            petIdLabel.Name = "petIdLabel";
            petIdLabel.Size = new Size(71, 15);
            petIdLabel.TabIndex = 7;
            petIdLabel.Text = "Pet Name : ";
            // 
            // petIdValue
            // 
            petIdValue.Location = new Point(94, 148);
            petIdValue.Margin = new Padding(3, 2, 3, 2);
            petIdValue.Name = "petIdValue";
            petIdValue.Size = new Size(154, 23);
            petIdValue.TabIndex = 8;
            // 
            // appointmentDetailsLabel
            // 
            appointmentDetailsLabel.AutoSize = true;
            appointmentDetailsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appointmentDetailsLabel.ForeColor = Color.DarkCyan;
            appointmentDetailsLabel.Location = new Point(304, 102);
            appointmentDetailsLabel.Name = "appointmentDetailsLabel";
            appointmentDetailsLabel.Size = new Size(169, 21);
            appointmentDetailsLabel.TabIndex = 9;
            appointmentDetailsLabel.Text = "Appointment Details";
            // 
            // appointmentDateBooking
            // 
            appointmentDateBooking.AutoSize = true;
            appointmentDateBooking.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            appointmentDateBooking.ForeColor = Color.DimGray;
            appointmentDateBooking.Location = new Point(304, 136);
            appointmentDateBooking.Name = "appointmentDateBooking";
            appointmentDateBooking.Size = new Size(120, 15);
            appointmentDateBooking.TabIndex = 10;
            appointmentDateBooking.Text = "Appointment Date : ";
            // 
            // appointmentDateValue
            // 
            appointmentDateValue.Location = new Point(435, 132);
            appointmentDateValue.Margin = new Padding(3, 2, 3, 2);
            appointmentDateValue.Name = "appointmentDateValue";
            appointmentDateValue.Size = new Size(219, 23);
            appointmentDateValue.TabIndex = 11;
            // 
            // serviceTypeBooking
            // 
            serviceTypeBooking.AutoSize = true;
            serviceTypeBooking.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            serviceTypeBooking.ForeColor = Color.DimGray;
            serviceTypeBooking.Location = new Point(304, 171);
            serviceTypeBooking.Name = "serviceTypeBooking";
            serviceTypeBooking.Size = new Size(87, 15);
            serviceTypeBooking.TabIndex = 12;
            serviceTypeBooking.Text = "Service Type : ";
            // 
            // serviceTypeBookingValue
            // 
            serviceTypeBookingValue.Location = new Point(435, 166);
            serviceTypeBookingValue.Margin = new Padding(3, 2, 3, 2);
            serviceTypeBookingValue.Name = "serviceTypeBookingValue";
            serviceTypeBookingValue.Size = new Size(219, 23);
            serviceTypeBookingValue.TabIndex = 13;
            // 
            // locationBookingLabel
            // 
            locationBookingLabel.AutoSize = true;
            locationBookingLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            locationBookingLabel.ForeColor = Color.DimGray;
            locationBookingLabel.Location = new Point(304, 207);
            locationBookingLabel.Name = "locationBookingLabel";
            locationBookingLabel.Size = new Size(63, 15);
            locationBookingLabel.TabIndex = 14;
            locationBookingLabel.Text = "Location : ";
            // 
            // locationIdBookingValue
            // 
            locationIdBookingValue.Location = new Point(435, 199);
            locationIdBookingValue.Margin = new Padding(3, 2, 3, 2);
            locationIdBookingValue.Name = "locationIdBookingValue";
            locationIdBookingValue.Size = new Size(219, 23);
            locationIdBookingValue.TabIndex = 15;
            // 
            // assignedToVetBooking
            // 
            assignedToVetBooking.AutoSize = true;
            assignedToVetBooking.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            assignedToVetBooking.ForeColor = Color.DimGray;
            assignedToVetBooking.Location = new Point(304, 238);
            assignedToVetBooking.Name = "assignedToVetBooking";
            assignedToVetBooking.Size = new Size(85, 15);
            assignedToVetBooking.TabIndex = 16;
            assignedToVetBooking.Text = "Assign to Vet :";
            // 
            // assignedToVetIdBookingValue
            // 
            assignedToVetIdBookingValue.Location = new Point(435, 230);
            assignedToVetIdBookingValue.Margin = new Padding(3, 2, 3, 2);
            assignedToVetIdBookingValue.Name = "assignedToVetIdBookingValue";
            assignedToVetIdBookingValue.Size = new Size(219, 23);
            assignedToVetIdBookingValue.TabIndex = 17;
            // 
            // bookAppointmentButton
            // 
            bookAppointmentButton.BackColor = SystemColors.HotTrack;
            bookAppointmentButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bookAppointmentButton.ForeColor = Color.White;
            bookAppointmentButton.Location = new Point(291, 325);
            bookAppointmentButton.Margin = new Padding(3, 2, 3, 2);
            bookAppointmentButton.Name = "bookAppointmentButton";
            bookAppointmentButton.Size = new Size(114, 46);
            bookAppointmentButton.TabIndex = 18;
            bookAppointmentButton.Text = "BOOK";
            bookAppointmentButton.UseVisualStyleBackColor = false;
            bookAppointmentButton.Click += bookAppointmentButton_Click;
            // 
            // appointmentIdBooking
            // 
            appointmentIdBooking.AutoSize = true;
            appointmentIdBooking.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            appointmentIdBooking.ForeColor = Color.DimGray;
            appointmentIdBooking.Location = new Point(304, 271);
            appointmentIdBooking.Name = "appointmentIdBooking";
            appointmentIdBooking.Size = new Size(106, 15);
            appointmentIdBooking.TabIndex = 19;
            appointmentIdBooking.Text = "Appointment ID : ";
            // 
            // appointmentIdValue
            // 
            appointmentIdValue.Location = new Point(435, 263);
            appointmentIdValue.Margin = new Padding(3, 2, 3, 2);
            appointmentIdValue.Name = "appointmentIdValue";
            appointmentIdValue.Size = new Size(219, 23);
            appointmentIdValue.TabIndex = 20;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(21, 328);
            button1.Name = "button1";
            button1.Size = new Size(76, 43);
            button1.TabIndex = 21;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(2, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 102);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // AppointmentBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 385);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(appointmentIdValue);
            Controls.Add(appointmentIdBooking);
            Controls.Add(bookAppointmentButton);
            Controls.Add(assignedToVetIdBookingValue);
            Controls.Add(assignedToVetBooking);
            Controls.Add(locationIdBookingValue);
            Controls.Add(locationBookingLabel);
            Controls.Add(serviceTypeBookingValue);
            Controls.Add(serviceTypeBooking);
            Controls.Add(appointmentDateValue);
            Controls.Add(appointmentDateBooking);
            Controls.Add(appointmentDetailsLabel);
            Controls.Add(petIdValue);
            Controls.Add(petIdLabel);
            Controls.Add(petDetailsLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(bookAppointmentLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AppointmentBookingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AppointmentInsertForm";
            Load += AppointmentBookingForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label bookAppointmentLabel;
        private Label lastNameLabel;
        private Label petDetailsLabel;
        private Label petIdLabel;
        private TextBox petIdValue;
        private Label appointmentDetailsLabel;
        private Label appointmentDateBooking;
        private DateTimePicker appointmentDateValue;
        private Label serviceTypeBooking;
        private TextBox serviceTypeBookingValue;
        private Label locationBookingLabel;
        private TextBox locationIdBookingValue;
        private Label assignedToVetBooking;
        private TextBox assignedToVetIdBookingValue;
        private Button bookAppointmentButton;
        private Label appointmentIdBooking;
        private TextBox appointmentIdValue;
        private Button button1;
        private PictureBox pictureBox1;
    }
}