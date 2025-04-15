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
            ((System.ComponentModel.ISupportInitialize)OwnerTableDataGridView).BeginInit();
            SuspendLayout();
            // 
            // OwnerLabel
            // 
            OwnerLabel.AutoSize = true;
            OwnerLabel.Font = new Font("Segoe UI", 18F);
            OwnerLabel.Location = new Point(10, 7);
            OwnerLabel.Name = "OwnerLabel";
            OwnerLabel.Size = new Size(146, 32);
            OwnerLabel.TabIndex = 0;
            OwnerLabel.Text = "Owner Table";
            OwnerLabel.Click += OwnerLabel_Click;
            // 
            // OwnerTableDataGridView
            // 
            OwnerTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OwnerTableDataGridView.Location = new Point(10, 40);
            OwnerTableDataGridView.Margin = new Padding(3, 2, 3, 2);
            OwnerTableDataGridView.Name = "OwnerTableDataGridView";
            OwnerTableDataGridView.RowHeadersWidth = 51;
            OwnerTableDataGridView.Size = new Size(666, 237);
            OwnerTableDataGridView.TabIndex = 1;
            // 
            // OwnerUpdateButton
            // 
            OwnerUpdateButton.Location = new Point(98, 281);
            OwnerUpdateButton.Margin = new Padding(3, 2, 3, 2);
            OwnerUpdateButton.Name = "OwnerUpdateButton";
            OwnerUpdateButton.Size = new Size(82, 22);
            OwnerUpdateButton.TabIndex = 3;
            OwnerUpdateButton.Text = "Update";
            OwnerUpdateButton.UseVisualStyleBackColor = true;
            OwnerUpdateButton.Click += OwnerUpdateButton_Click;
            // 
            // OwnerDeleteButton
            // 
            OwnerDeleteButton.Location = new Point(10, 281);
            OwnerDeleteButton.Margin = new Padding(3, 2, 3, 2);
            OwnerDeleteButton.Name = "OwnerDeleteButton";
            OwnerDeleteButton.Size = new Size(82, 22);
            OwnerDeleteButton.TabIndex = 4;
            OwnerDeleteButton.Text = "Delete";
            OwnerDeleteButton.UseVisualStyleBackColor = true;
            // 
            // SearchBarTextBox
            // 
            SearchBarTextBox.Location = new Point(176, 9);
            SearchBarTextBox.Margin = new Padding(3, 2, 3, 2);
            SearchBarTextBox.Name = "SearchBarTextBox";
            SearchBarTextBox.Size = new Size(110, 23);
            SearchBarTextBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(290, 8);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(82, 22);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            // 
            // OwnerTableInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(OwnerDeleteButton);
            Controls.Add(OwnerUpdateButton);
            Controls.Add(OwnerTableDataGridView);
            Controls.Add(OwnerLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "OwnerTableInterface";
            Text = "OwnerTableInterface";
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
    }
}