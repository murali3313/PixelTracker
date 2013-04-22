namespace PixTracker
{
    partial class ReasonBox
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
            this.txtFailureReason = new System.Windows.Forms.TextBox();
            this.lblReasonForFailure = new System.Windows.Forms.Label();
            this.btnSaveReason = new System.Windows.Forms.Button();
            this.lblFailureNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFailureReason
            // 
            this.txtFailureReason.Location = new System.Drawing.Point(16, 28);
            this.txtFailureReason.MaxLength = 1000;
            this.txtFailureReason.Multiline = true;
            this.txtFailureReason.Name = "txtFailureReason";
            this.txtFailureReason.Size = new System.Drawing.Size(687, 120);
            this.txtFailureReason.TabIndex = 0;
            // 
            // lblReasonForFailure
            // 
            this.lblReasonForFailure.AutoEllipsis = true;
            this.lblReasonForFailure.AutoSize = true;
            this.lblReasonForFailure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.lblReasonForFailure.Location = new System.Drawing.Point(12, 5);
            this.lblReasonForFailure.Name = "lblReasonForFailure";
            this.lblReasonForFailure.Size = new System.Drawing.Size(248, 20);
            this.lblReasonForFailure.TabIndex = 1;
            this.lblReasonForFailure.Text = "Please enter the reason for failure";
            this.lblReasonForFailure.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnSaveReason
            // 
            this.btnSaveReason.Location = new System.Drawing.Point(616, 154);
            this.btnSaveReason.Name = "btnSaveReason";
            this.btnSaveReason.Size = new System.Drawing.Size(87, 34);
            this.btnSaveReason.TabIndex = 2;
            this.btnSaveReason.Text = "Save reason";
            this.btnSaveReason.UseVisualStyleBackColor = true;
            this.btnSaveReason.Click += new System.EventHandler(this.btnSaveReason_Click);
            // 
            // lblFailureNum
            // 
            this.lblFailureNum.AutoSize = true;
            this.lblFailureNum.Location = new System.Drawing.Point(280, 9);
            this.lblFailureNum.Name = "lblFailureNum";
            this.lblFailureNum.Size = new System.Drawing.Size(0, 13);
            this.lblFailureNum.TabIndex = 3;
            // 
            // ReasonBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 209);
            this.Controls.Add(this.lblFailureNum);
            this.Controls.Add(this.btnSaveReason);
            this.Controls.Add(this.lblReasonForFailure);
            this.Controls.Add(this.txtFailureReason);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReasonBox";
            this.Text = "ReasonBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFailureReason;
        private System.Windows.Forms.Label lblReasonForFailure;
        private System.Windows.Forms.Button btnSaveReason;
        private System.Windows.Forms.Label lblFailureNum;
    }
}