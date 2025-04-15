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
            OwnerLabel.Location = new Point(12, 9);
            OwnerLabel.Name = "OwnerLabel";
            OwnerLabel.Size = new Size(183, 41);
            OwnerLabel.TabIndex = 0;
            OwnerLabel.Text = "Owner Table";
            // 
            // OwnerTableDataGridView
            // 
            OwnerTableDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OwnerTableDataGridView.Location = new Point(12, 53);
            OwnerTableDataGridView.Name = "OwnerTableDataGridView";
            OwnerTableDataGridView.RowHeadersWidth = 51;
            OwnerTableDataGridView.Size = new Size(761, 316);
            OwnerTableDataGridView.TabIndex = 1;
            // 
            // OwnerUpdateButton
            // 
            OwnerUpdateButton.Location = new Point(112, 375);
            OwnerUpdateButton.Name = "OwnerUpdateButton";
            OwnerUpdateButton.Size = new Size(94, 29);
            OwnerUpdateButton.TabIndex = 3;
            OwnerUpdateButton.Text = "Update";
            OwnerUpdateButton.UseVisualStyleBackColor = true;
            OwnerUpdateButton.Click += OwnerUpdateButton_Click;
            // 
            // OwnerDeleteButton
            // 
            OwnerDeleteButton.Location = new Point(12, 375);
            OwnerDeleteButton.Name = "OwnerDeleteButton";
            OwnerDeleteButton.Size = new Size(94, 29);
            OwnerDeleteButton.TabIndex = 4;
            OwnerDeleteButton.Text = "Delete";
            OwnerDeleteButton.UseVisualStyleBackColor = true;
            // 
            // SearchBarTextBox
            // 
            SearchBarTextBox.Location = new Point(201, 12);
            SearchBarTextBox.Name = "SearchBarTextBox";
            SearchBarTextBox.Size = new Size(125, 27);
            SearchBarTextBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(332, 11);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(94, 29);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            // 
            // OwnerTableInterface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SearchButton);
            Controls.Add(SearchBarTextBox);
            Controls.Add(OwnerDeleteButton);
            Controls.Add(OwnerUpdateButton);
            Controls.Add(OwnerTableDataGridView);
            Controls.Add(OwnerLabel);
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