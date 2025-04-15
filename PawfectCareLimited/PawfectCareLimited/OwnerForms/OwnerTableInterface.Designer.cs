namespace PawfectCareLimited
{
    partial class OwnerTableInterface
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
            OwnerLabel = new Label();
            OwnerTableDataGridView = new DataGridView();
            OwnerUpdateButton = new Button();
            OwnerDeleteButton = new Button();
            SearchBarTextBox = new TextBox();
            SearchButton = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)OwnerTableDataGridView).BeginInit();
            SuspendLayout();
            // 
            // OwnerLabel
            // 
            OwnerLabel.AutoSize = true;
            OwnerLabel.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OwnerLabel.ForeColor = Color.DarkCyan;
            OwnerLabel.Location = new Point(275, 14);
            OwnerLabel.Name = "OwnerLabel";
            OwnerLabel.Size = new Size(190, 28);
            OwnerLabel.TabIndex = 0;
            OwnerLabel.Text = "OWNER TABLE";
            OwnerLabel.Click += OwnerLabel_Click;
            // 
            // OwnerTableDataGridView
            // 
            OwnerTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OwnerTableDataGridView.Location = new Point(28, 101);
            OwnerTableDataGridView.Margin = new Padding(3, 2, 3, 2);
            OwnerTableDataGridView.Name = "OwnerTableDataGridView";
            OwnerTableDataGridView.RowHeadersWidth = 51;
            OwnerTableDataGridView.Size = new Size(669, 236);
            OwnerTableDataGridView.TabIndex = 1;
            // 
            // OwnerUpdateButton
            // 
            OwnerUpdateButton.BackColor = Color.ForestGreen;
            OwnerUpdateButton.Location = new Point(223, 361);
            OwnerUpdateButton.Margin = new Padding(3, 2, 3, 2);
            OwnerUpdateButton.Name = "OwnerUpdateButton";
            OwnerUpdateButton.Size = new Size(100, 45);
            OwnerUpdateButton.TabIndex = 3;
            OwnerUpdateButton.Text = "UPDATE";
            OwnerUpdateButton.UseVisualStyleBackColor = false;
            OwnerUpdateButton.Click += OwnerUpdateButton_Click;
            // 
            // OwnerDeleteButton
            // 
            OwnerDeleteButton.BackColor = Color.IndianRed;
            OwnerDeleteButton.Location = new Point(406, 361);
            OwnerDeleteButton.Margin = new Padding(3, 2, 3, 2);
            OwnerDeleteButton.Name = "OwnerDeleteButton";
            OwnerDeleteButton.Size = new Size(105, 45);
            OwnerDeleteButton.TabIndex = 4;
            OwnerDeleteButton.Text = "DELETE";
            OwnerDeleteButton.UseVisualStyleBackColor = false;
            // 
            // SearchBarTextBox
            // 
            SearchBarTextBox.Location = new Point(165, 56);
            SearchBarTextBox.Margin = new Padding(3, 2, 3, 2);
            SearchBarTextBox.Name = "SearchBarTextBox";
            SearchBarTextBox.Size = new Size(356, 23);
            SearchBarTextBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.DarkCyan;
            SearchButton.Location = new Point(527, 48);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(91, 36);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "SEARCH";
            SearchButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Location = new Point(28, 432);
            button1.Name = "button1";
            button1.Size = new Size(76, 43);
            button1.TabIndex = 7;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // OwnerTableInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(727, 487);
            Controls.Add(button1);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(OwnerDeleteButton);
            Controls.Add(OwnerUpdateButton);
            Controls.Add(OwnerTableDataGridView);
            Controls.Add(OwnerLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "OwnerTableInterface";
            Text = "OwnerTableInterface";
            Load += OwnerTableInterface_Load_1;
            ((System.ComponentModel.ISupportInitialize)OwnerTableDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OwnerLabel;
        private DataGridView OwnerTableDataGridView;
        private Button OwnerUpdateButton;
        private Button OwnerDeleteButton;
        private TextBox SearchBarTextBox;
        private Button SearchButton;
        private Button button1;
    }
}