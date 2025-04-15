namespace PawfectCareLimited
{
    partial class HomeForms
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
            greetingLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(-1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 114);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // greetingLabel
            // 
            greetingLabel.AutoSize = true;
            greetingLabel.BackColor = Color.DimGray;
            greetingLabel.ForeColor = Color.White;
            greetingLabel.Location = new Point(269, 142);
            greetingLabel.Name = "greetingLabel";
            greetingLabel.Size = new Size(19, 15);
            greetingLabel.TabIndex = 27;
            greetingLabel.Text = "    ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DimGray;
            label2.ForeColor = Color.White;
            label2.Location = new Point(269, 184);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 29;
            label2.Text = "    ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.DimGray;
            label3.ForeColor = Color.White;
            label3.Location = new Point(269, 224);
            label3.Name = "label3";
            label3.Size = new Size(19, 15);
            label3.TabIndex = 30;
            label3.Text = "    ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Britannic Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(233, 52);
            label1.Name = "label1";
            label1.Size = new Size(88, 32);
            label1.TabIndex = 31;
            label1.Text = "HOME";
            // 
            // button1
            // 
            button1.BackColor = Color.Brown;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(233, 284);
            button1.Name = "button1";
            button1.Size = new Size(92, 46);
            button1.TabIndex = 32;
            button1.Text = "LOG OUT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // HomeForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(586, 367);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(greetingLabel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomeForms";
            Text = "HomeForms";
            Load += HomeForms_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label greetingLabel;
        private Label label2;
        private Label label3;
        private Label label1;
        private Button button1;
    }
}