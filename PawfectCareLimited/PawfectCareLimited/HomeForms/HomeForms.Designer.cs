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
        label2 = new Label();
        button2 = new Button();
        button1 = new Button();
        label1 = new Label();
        pictureBox1 = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Britannic Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label2.ForeColor = Color.DarkCyan;
        label2.Location = new Point(164, 159);
        label2.Name = "label2";
        label2.Size = new Size(278, 23);
        label2.TabIndex = 39;
        label2.Text = "Welcome to PawfectCare Ltd!";
        // 
        // button2
        // 
        button2.BackColor = Color.DarkCyan;
        button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button2.ForeColor = Color.White;
        button2.Location = new Point(12, 392);
        button2.Name = "button2";
        button2.Size = new Size(76, 43);
        button2.TabIndex = 38;
        button2.Text = "BACK";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // button1
        // 
        button1.BackColor = Color.Brown;
        button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button1.ForeColor = Color.White;
        button1.Location = new Point(261, 392);
        button1.Name = "button1";
        button1.Size = new Size(92, 46);
        button1.TabIndex = 37;
        button1.Text = "LOG OUT";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Britannic Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.DarkCyan;
        label1.Location = new Point(261, 66);
        label1.Name = "label1";
        label1.Size = new Size(88, 32);
        label1.TabIndex = 36;
        label1.Text = "HOME";
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = Color.White;
        pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.logoPawfectCare;
        pictureBox1.Location = new Point(12, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(134, 114);
        pictureBox1.TabIndex = 35;
        pictureBox1.TabStop = false;
        // 
        // HomeForms
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(609, 450);
        Controls.Add(label2);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "HomeForms";
        Text = "HomeForms";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label2;
    private Button button2;
    private Button button1;
    private Label label1;
    private PictureBox pictureBox1;
}
}