namespace PixTracker
{
    partial class ScenarioPlayResult
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.playTest = new System.Windows.Forms.PictureBox();
            this.viewResult = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // playTest
            // 
            this.playTest.Image = global::PixTracker.Properties.Resources.play;
            this.playTest.Location = new System.Drawing.Point(131, 4);
            this.playTest.Name = "playTest";
            this.playTest.Size = new System.Drawing.Size(27, 23);
            this.playTest.TabIndex = 1;
            this.playTest.TabStop = false;
            this.playTest.Click += new System.EventHandler(this.playTest_Click);
            // 
            // viewResult
            // 
            this.viewResult.Image = global::PixTracker.Properties.Resources.ViewResults;
            this.viewResult.Location = new System.Drawing.Point(164, 3);
            this.viewResult.Name = "viewResult";
            this.viewResult.Size = new System.Drawing.Size(27, 24);
            this.viewResult.TabIndex = 2;
            this.viewResult.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(198, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ScenarioPlayResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.viewResult);
            this.Controls.Add(this.playTest);
            this.Controls.Add(this.label1);
            this.Name = "ScenarioPlayResult";
            this.Size = new System.Drawing.Size(369, 33);
            ((System.ComponentModel.ISupportInitialize)(this.playTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox playTest;
        private System.Windows.Forms.PictureBox viewResult;
        private System.Windows.Forms.Button btnDelete;
    }
}
