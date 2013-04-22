namespace PixTracker
{
    partial class AssertBox
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
            this.picAssertScreenShot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAssertScreenShot)).BeginInit();
            this.SuspendLayout();
            // 
            // picAssertScreenShot
            // 
            this.picAssertScreenShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAssertScreenShot.Location = new System.Drawing.Point(0, 0);
            this.picAssertScreenShot.Name = "picAssertScreenShot";
            this.picAssertScreenShot.Size = new System.Drawing.Size(1384, 900);
            this.picAssertScreenShot.TabIndex = 0;
            this.picAssertScreenShot.TabStop = false;
            this.picAssertScreenShot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picAssertScreenShot_MouseDown);
            this.picAssertScreenShot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picAssertScreenShot_MouseUp);
            // 
            // AssertBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 900);
            this.Controls.Add(this.picAssertScreenShot);
            this.MaximizeBox = false;
            this.Name = "AssertBox";
            this.ShowInTaskbar = false;
            this.Text = "AssertBox";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picAssertScreenShot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picAssertScreenShot;
    }
}