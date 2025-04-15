namespace PawfectCareLimited
{
    partial class UsersForms
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
            dataGridView1 = new DataGridView();
            apppointmentUpdateLabel = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 114);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(152, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(511, 361);
            dataGridView1.TabIndex = 26;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // apppointmentUpdateLabel
            // 
            apppointmentUpdateLabel.AutoSize = true;
            apppointmentUpdateLabel.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            apppointmentUpdateLabel.ForeColor = Color.DarkCyan;
            apppointmentUpdateLabel.Location = new Point(355, 23);
            apppointmentUpdateLabel.Name = "apppointmentUpdateLabel";
            apppointmentUpdateLabel.Size = new Size(95, 28);
            apppointmentUpdateLabel.TabIndex = 27;
            apppointmentUpdateLabel.Text = "USERS";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 436);
            button1.Name = "button1";
            button1.Size = new Size(76, 43);
            button1.TabIndex = 28;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // UsersForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 491);
            Controls.Add(button1);
            Controls.Add(apppointmentUpdateLabel);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UsersForms";
            Text = "UsersForms";
            Load += UsersForms_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Label apppointmentUpdateLabel;
        private Button button1;
    }
}