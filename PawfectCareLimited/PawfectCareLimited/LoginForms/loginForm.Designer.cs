namespace PawfectCareLimited(Winforms).LoginForms
{
    partial class loginForm
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
        label1 = new Label();
        pictureBox2 = new PictureBox();
        pictureBox3 = new PictureBox();
        panel1 = new Panel();
        panel2 = new Panel();
        linkLabel1 = new LinkLabel();
        button1 = new Button();
        linkLabel2 = new LinkLabel();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        pictureBox1 = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Britannic Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.DarkCyan;
        label1.Location = new Point(123, 110);
        label1.Name = "label1";
        label1.Size = new Size(61, 21);
        label1.TabIndex = 1;
        label1.Text = "LOGIN";
        label1.Click += label1_Click;
        // 
        // pictureBox2
        // 
        pictureBox2.Image = PawfectCareLimited_Winforms_.Resource1.usernamePaw;
        pictureBox2.Location = new Point(26, 184);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(18, 23);
        pictureBox2.TabIndex = 2;
        pictureBox2.TabStop = false;
        // 
        // pictureBox3
        // 
        pictureBox3.Image = PawfectCareLimited_Winforms_.Resource1.passwordPAw;
        pictureBox3.Location = new Point(26, 241);
        pictureBox3.Name = "pictureBox3";
        pictureBox3.Size = new Size(18, 25);
        pictureBox3.TabIndex = 3;
        pictureBox3.TabStop = false;
        // 
        // panel1
        // 
        panel1.BackColor = Color.DarkCyan;
        panel1.Location = new Point(26, 213);
        panel1.Name = "panel1";
        panel1.Size = new Size(260, 1);
        panel1.TabIndex = 4;
        // 
        // panel2
        // 
        panel2.BackColor = Color.DarkCyan;
        panel2.Location = new Point(26, 272);
        panel2.Name = "panel2";
        panel2.Size = new Size(260, 1);
        panel2.TabIndex = 5;
        // 
        // linkLabel1
        // 
        linkLabel1.AutoSize = true;
        linkLabel1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        linkLabel1.LinkColor = Color.Teal;
        linkLabel1.Location = new Point(213, 288);
        linkLabel1.Name = "linkLabel1";
        linkLabel1.Size = new Size(73, 14);
        linkLabel1.TabIndex = 6;
        linkLabel1.TabStop = true;
        linkLabel1.Text = "Clear fields";
        // 
        // button1
        // 
        button1.BackColor = Color.DarkCyan;
        button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button1.ForeColor = Color.White;
        button1.Location = new Point(87, 345);
        button1.Name = "button1";
        button1.Size = new Size(131, 34);
        button1.TabIndex = 7;
        button1.Text = "LOGIN";
        button1.UseVisualStyleBackColor = false;
        // 
        // linkLabel2
        // 
        linkLabel2.AutoSize = true;
        linkLabel2.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        linkLabel2.LinkColor = Color.Teal;
        linkLabel2.Location = new Point(135, 392);
        linkLabel2.Name = "linkLabel2";
        linkLabel2.Size = new Size(34, 14);
        linkLabel2.TabIndex = 8;
        linkLabel2.TabStop = true;
        linkLabel2.Text = "EXIT";
        // 
        // textBox1
        // 
        textBox1.ForeColor = SystemColors.WindowFrame;
        textBox1.Location = new Point(50, 184);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(238, 23);
        textBox1.TabIndex = 9;
        // 
        // textBox2
        // 
        textBox2.ForeColor = SystemColors.WindowFrame;
        textBox2.Location = new Point(48, 241);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(238, 23);
        textBox2.TabIndex = 10;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = PawfectCareLimited_Winforms_.Resource1.image_7;
        pictureBox1.Location = new Point(98, -16);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(111, 123);
        pictureBox1.TabIndex = 11;
        pictureBox1.TabStop = false;
        // 
        // loginForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(306, 443);
        Controls.Add(pictureBox1);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(linkLabel2);
        Controls.Add(button1);
        Controls.Add(linkLabel1);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Controls.Add(pictureBox3);
        Controls.Add(pictureBox2);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.None;
        Name = "loginForm";
        Text = "loginForm";
        Load += loginForm_Load;
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Label label1;
    private PictureBox pictureBox2;
    private PictureBox pictureBox3;
    private Panel panel1;
    private Panel panel2;
    private LinkLabel linkLabel1;
    private Button button1;
    private LinkLabel linkLabel2;
    private TextBox textBox1;
    private TextBox textBox2;
    private PictureBox pictureBox1;
}
}