namespace PawfectCareLimited
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ownersDataGridView = new DataGridView();
            displayOwnersButton = new Button();

            ((System.ComponentModel.ISupportInitialize)ownersDataGridView).BeginInit();
            SuspendLayout();

            // 
            // ownersDataGridView
            // 
            ownersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ownersDataGridView.Location = new Point(12, 12);
            ownersDataGridView.Name = "ownersDataGridView";
            ownersDataGridView.RowHeadersWidth = 51;
            ownersDataGridView.Size = new Size(758, 227);
            ownersDataGridView.TabIndex = 0;

            // 
            // displayOwnersButton
            // 
            displayOwnersButton.Location = new Point(12, 250);
            displayOwnersButton.Name = "displayOwnersButton";
            displayOwnersButton.Size = new Size(150, 30);
            displayOwnersButton.Text = "Display Owners";
            displayOwnersButton.UseVisualStyleBackColor = true;
            displayOwnersButton.Click += new EventHandler(this.displayOwnersButton_Click);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(displayOwnersButton);
            Controls.Add(ownersDataGridView);
            Name = "Form1";
            Text = "Form1";

            ((System.ComponentModel.ISupportInitialize)ownersDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ownersDataGridView;
        private Button displayOwnersButton; // <-- added this line
    }
}
