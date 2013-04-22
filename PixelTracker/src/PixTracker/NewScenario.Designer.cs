namespace PixTracker
{
    partial class NewScenario
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
            this.btnEndTest = new System.Windows.Forms.Button();
            this.btnFlushAll = new System.Windows.Forms.Button();
            this.btnRecordStart = new System.Windows.Forms.Button();
            this.btnStartAssertion = new System.Windows.Forms.Button();
            this.btnStartPlayBack = new System.Windows.Forms.Button();
            this.globalEventProvider = new Gma.UserActivityMonitor.GlobalEventProvider();
            this.btnSaveTest = new System.Windows.Forms.Button();
            this.txtScenarioDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEndTest
            // 
            this.btnEndTest.Location = new System.Drawing.Point(197, 114);
            this.btnEndTest.Name = "btnEndTest";
            this.btnEndTest.Size = new System.Drawing.Size(77, 23);
            this.btnEndTest.TabIndex = 12;
            this.btnEndTest.Text = "End Test";
            this.btnEndTest.UseVisualStyleBackColor = true;
            this.btnEndTest.Click += new System.EventHandler(this.BtnEndTestClick);
            // 
            // btnFlushAll
            // 
            this.btnFlushAll.Location = new System.Drawing.Point(9, 152);
            this.btnFlushAll.Name = "btnFlushAll";
            this.btnFlushAll.Size = new System.Drawing.Size(68, 23);
            this.btnFlushAll.TabIndex = 11;
            this.btnFlushAll.Text = "Flush All";
            this.btnFlushAll.UseVisualStyleBackColor = true;
            this.btnFlushAll.Click += new System.EventHandler(this.flushAll_Click);
            // 
            // btnRecordStart
            // 
            this.btnRecordStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecordStart.Location = new System.Drawing.Point(9, 116);
            this.btnRecordStart.Name = "btnRecordStart";
            this.btnRecordStart.Size = new System.Drawing.Size(68, 21);
            this.btnRecordStart.TabIndex = 10;
            this.btnRecordStart.Text = "Start Test";
            this.btnRecordStart.UseVisualStyleBackColor = true;
            this.btnRecordStart.Click += new System.EventHandler(this.btnRecordStart_Click);
            // 
            // btnStartAssertion
            // 
            this.btnStartAssertion.Enabled = false;
            this.btnStartAssertion.Location = new System.Drawing.Point(94, 114);
            this.btnStartAssertion.Name = "btnStartAssertion";
            this.btnStartAssertion.Size = new System.Drawing.Size(97, 23);
            this.btnStartAssertion.TabIndex = 9;
            this.btnStartAssertion.Text = "Start Assertion";
            this.btnStartAssertion.UseVisualStyleBackColor = true;
            this.btnStartAssertion.Click += new System.EventHandler(this.AssertionStart);
            // 
            // btnStartPlayBack
            // 
            this.btnStartPlayBack.Location = new System.Drawing.Point(95, 152);
            this.btnStartPlayBack.Name = "btnStartPlayBack";
            this.btnStartPlayBack.Size = new System.Drawing.Size(96, 23);
            this.btnStartPlayBack.TabIndex = 8;
            this.btnStartPlayBack.Text = "Play back";
            this.btnStartPlayBack.UseVisualStyleBackColor = true;
            this.btnStartPlayBack.Click += new System.EventHandler(this.playBack);
            // 
            // btnSaveTest
            // 
            this.btnSaveTest.Location = new System.Drawing.Point(197, 152);
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.Size = new System.Drawing.Size(77, 23);
            this.btnSaveTest.TabIndex = 13;
            this.btnSaveTest.Text = "Save Test";
            this.btnSaveTest.UseVisualStyleBackColor = true;
            this.btnSaveTest.Click += new System.EventHandler(this.BtnSaveTestClick);
            // 
            // txtScenarioDesc
            // 
            this.txtScenarioDesc.Location = new System.Drawing.Point(9, 37);
            this.txtScenarioDesc.Multiline = true;
            this.txtScenarioDesc.Name = "txtScenarioDesc";
            this.txtScenarioDesc.Size = new System.Drawing.Size(265, 71);
            this.txtScenarioDesc.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Scenario Description";
            // 
            // NewScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScenarioDesc);
            this.Controls.Add(this.btnSaveTest);
            this.Controls.Add(this.btnEndTest);
            this.Controls.Add(this.btnFlushAll);
            this.Controls.Add(this.btnRecordStart);
            this.Controls.Add(this.btnStartAssertion);
            this.Controls.Add(this.btnStartPlayBack);
            this.Name = "NewScenario";
            this.Size = new System.Drawing.Size(286, 186);
            this.Load += new System.EventHandler(this.NewScenario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEndTest;
        private System.Windows.Forms.Button btnFlushAll;
        private System.Windows.Forms.Button btnRecordStart;
        private System.Windows.Forms.Button btnStartAssertion;
        private System.Windows.Forms.Button btnStartPlayBack;
        private Gma.UserActivityMonitor.GlobalEventProvider globalEventProvider;
        private System.Windows.Forms.Button btnSaveTest;
        private System.Windows.Forms.TextBox txtScenarioDesc;
        private System.Windows.Forms.Label label1;
    }
}
