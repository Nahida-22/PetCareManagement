namespace PawfectCareLimited
{
    partial class AppointmentUpdateForm
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
            serviceTypeLabel = new Label();
            changeToValueLabel = new Label();
            updatedServiceType = new TextBox();
            appointmentDateLabel = new Label();
            appointmentStatusLabel = new Label();
            vetLabel = new Label();
            addressLabel = new Label();
            updatedStatus = new TextBox();
            updatedVetName = new TextBox();
            updatedLocation = new TextBox();
            updateAppointmentButton = new Button();
            updatedAppointmentDate = new DateTimePicker();
            SuspendLayout();
            // 
            // apppointmentUpdateLabel
            // 
            apppointmentUpdateLabel.AutoSize = true;
            apppointmentUpdateLabel.Font = new Font("Segoe UI", 18F);
            apppointmentUpdateLabel.Location = new Point(3, 9);
            apppointmentUpdateLabel.Name = "apppointmentUpdateLabel";
            apppointmentUpdateLabel.Size = new Size(397, 41);
            apppointmentUpdateLabel.TabIndex = 0;
            apppointmentUpdateLabel.Text = "Update Appointment Details";
            // 
            // UpdateDetailsLabel
            // 
            UpdateDetailsLabel.AutoSize = true;
            UpdateDetailsLabel.Location = new Point(12, 62);
            UpdateDetailsLabel.Name = "UpdateDetailsLabel";
            UpdateDetailsLabel.Size = new Size(260, 20);
            UpdateDetailsLabel.TabIndex = 1;
            UpdateDetailsLabel.Text = "Updating details for Appointment ID: ";
            // 
            // serviceTypeLabel
            // 
            serviceTypeLabel.AutoSize = true;
            serviceTypeLabel.Location = new Point(12, 151);
            serviceTypeLabel.Name = "serviceTypeLabel";
            serviceTypeLabel.Size = new Size(102, 20);
            serviceTypeLabel.TabIndex = 2;
            serviceTypeLabel.Text = "Service Type : ";
            // 
            // changeToValueLabel
            // 
            changeToValueLabel.AutoSize = true;
            changeToValueLabel.Location = new Point(223, 111);
            changeToValueLabel.Name = "changeToValueLabel";
            changeToValueLabel.Size = new Size(79, 20);
            changeToValueLabel.TabIndex = 5;
            changeToValueLabel.Text = "Change To";
            // 
            // updatedServiceType
            // 
            updatedServiceType.Location = new Point(209, 148);
            updatedServiceType.Name = "updatedServiceType";
            updatedServiceType.Size = new Size(109, 27);
            updatedServiceType.TabIndex = 6;
            // 
            // appointmentDateLabel
            // 
            appointmentDateLabel.AutoSize = true;
            appointmentDateLabel.Location = new Point(12, 188);
            appointmentDateLabel.Name = "appointmentDateLabel";
            appointmentDateLabel.Size = new Size(144, 20);
            appointmentDateLabel.TabIndex = 7;
            appointmentDateLabel.Text = "Appointment Date : ";
            // 
            // appointmentStatusLabel
            // 
            appointmentStatusLabel.AutoSize = true;
            appointmentStatusLabel.Location = new Point(13, 223);
            appointmentStatusLabel.Name = "appointmentStatusLabel";
            appointmentStatusLabel.Size = new Size(56, 20);
            appointmentStatusLabel.TabIndex = 8;
            appointmentStatusLabel.Text = "Status :";
            // 
            // vetLabel
            // 
            vetLabel.AutoSize = true;
            vetLabel.Location = new Point(13, 255);
            vetLabel.Name = "vetLabel";
            vetLabel.Size = new Size(85, 20);
            vetLabel.TabIndex = 9;
            vetLabel.Text = "Vet Name : ";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(13, 286);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(77, 20);
            addressLabel.TabIndex = 10;
            addressLabel.Text = "Location : ";
            // 
            // updatedStatus
            // 
            updatedStatus.Location = new Point(209, 216);
            updatedStatus.Name = "updatedStatus";
            updatedStatus.Size = new Size(109, 27);
            updatedStatus.TabIndex = 16;
            // 
            // updatedVetName
            // 
            updatedVetName.Location = new Point(209, 248);
            updatedVetName.Name = "updatedVetName";
            updatedVetName.Size = new Size(109, 27);
            updatedVetName.TabIndex = 17;
            // 
            // updatedLocation
            // 
            updatedLocation.Location = new Point(209, 279);
            updatedLocation.Name = "updatedLocation";
            updatedLocation.Size = new Size(109, 27);
            updatedLocation.TabIndex = 18;
            // 
            // updateAppointmentButton
            // 
            updateAppointmentButton.Location = new Point(588, 343);
            updateAppointmentButton.Name = "updateAppointmentButton";
            updateAppointmentButton.Size = new Size(139, 49);
            updateAppointmentButton.TabIndex = 19;
            updateAppointmentButton.Text = "Update";
            updateAppointmentButton.UseVisualStyleBackColor = true;
            updateAppointmentButton.Click += updateAppointmentButton_Click;
            // 
            // updatedAppointmentDate
            // 
            updatedAppointmentDate.Location = new Point(162, 183);
            updatedAppointmentDate.Name = "updatedAppointmentDate";
            updatedAppointmentDate.Size = new Size(261, 27);
            updatedAppointmentDate.TabIndex = 20;
            // 
            // AppointmentUpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(updatedAppointmentDate);
            Controls.Add(updateAppointmentButton);
            Controls.Add(updatedLocation);
            Controls.Add(updatedVetName);
            Controls.Add(updatedStatus);
            Controls.Add(addressLabel);
            Controls.Add(vetLabel);
            Controls.Add(appointmentStatusLabel);
            Controls.Add(appointmentDateLabel);
            Controls.Add(updatedServiceType);
            Controls.Add(changeToValueLabel);
            Controls.Add(serviceTypeLabel);
            Controls.Add(UpdateDetailsLabel);
            Controls.Add(apppointmentUpdateLabel);
            Name = "AppointmentUpdateForm";
            Text = "UpdateOwnerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label apppointmentUpdateLabel;
        private Label UpdateDetailsLabel;
        private Label serviceTypeLabel;
        private Label changeToValueLabel;
        private TextBox updatedServiceType;
        private Label appointmentDateLabel;
        private Label appointmentStatusLabel;
        private Label vetLabel;
        private Label addressLabel;
        private TextBox updatedStatus;
        private TextBox updatedVetName;
        private TextBox updatedLocation;
        private Button updateAppointmentButton;
        private DateTimePicker updatedAppointmentDate;
    }
}
