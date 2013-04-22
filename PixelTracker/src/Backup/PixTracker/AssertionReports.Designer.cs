namespace PixTracker
{
    partial class AssertionReports
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
            this.dgReports = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgReports)).BeginInit();
            this.SuspendLayout();
            // 
            // dgReports
            // 
            this.dgReports.AllowUserToAddRows = false;
            this.dgReports.AllowUserToDeleteRows = false;
            this.dgReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgReports.Location = new System.Drawing.Point(0, 0);
            this.dgReports.Name = "dgReports";
            this.dgReports.ReadOnly = true;
            this.dgReports.Size = new System.Drawing.Size(1020, 458);
            this.dgReports.TabIndex = 0;
            // 
            // AssertionReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 458);
            this.Controls.Add(this.dgReports);
            this.Name = "AssertionReports";
            this.Text = "AssertionReports";
            ((System.ComponentModel.ISupportInitialize)(this.dgReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgReports;
    }
}