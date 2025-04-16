namespace PawfectCareLimited
{
    partial class MainMenuForms
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
            pictureBox1.Location = new Point(283, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 108);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Font = new Font("Arial Rounded MT Bold", 14.25F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(164, 205);
            button1.Name = "button1";
            button1.Size = new Size(159, 66);
            button1.TabIndex = 1;
            button1.Text = "HOME";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkCyan;
            button2.Font = new Font("Arial Rounded MT Bold", 14.25F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(347, 205);
            button2.Name = "button2";
            button2.Size = new Size(159, 66);
            button2.TabIndex = 2;
            button2.Text = "TABLES";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkCyan;
            button3.Font = new Font("Arial Rounded MT Bold", 14.25F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(164, 284);
            button3.Name = "button3";
            button3.Size = new Size(159, 66);
            button3.TabIndex = 3;
            button3.Text = "OPERATIONS";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkCyan;
            button4.Font = new Font("Arial Rounded MT Bold", 14.25F);
            button4.ForeColor = Color.White;
            button4.Location = new Point(347, 284);
            button4.Name = "button4";
            button4.Size = new Size(159, 66);
            button4.TabIndex = 4;
            button4.Text = "USERS";
            button4.UseVisualStyleBackColor = false;
            // 
            // MainMenuForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(693, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "MainMenuForms";
            Text = "MainMenuForms";
            Load += MainMenuForms_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
}
}