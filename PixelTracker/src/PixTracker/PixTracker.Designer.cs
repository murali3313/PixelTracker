namespace PixTracker
{
    partial class PixTracker
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewTestSuiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpAutomationTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scenarioToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.newToolStripMenuItem.Text = "View/Edit";
            // 
            // scenarioToolStripMenuItem
            // 
            this.scenarioToolStripMenuItem.Name = "scenarioToolStripMenuItem";
            this.scenarioToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.scenarioToolStripMenuItem.Text = "Scenario";
            this.scenarioToolStripMenuItem.Click += new System.EventHandler(this.ViewEditScenario);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scenarioToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.viewToolStripMenuItem.Text = "New";
            // 
            // scenarioToolStripMenuItem1
            // 
            this.scenarioToolStripMenuItem1.Name = "scenarioToolStripMenuItem1";
            this.scenarioToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.scenarioToolStripMenuItem1.Text = "Scenario";
            this.scenarioToolStripMenuItem1.Click += new System.EventHandler(this.CreateNewScenario);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewTestSuiteToolStripMenuItem,
            this.backUpAutomationTestsToolStripMenuItem,
            this.restoreTestsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // createNewTestSuiteToolStripMenuItem
            // 
            this.createNewTestSuiteToolStripMenuItem.Name = "createNewTestSuiteToolStripMenuItem";
            this.createNewTestSuiteToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.createNewTestSuiteToolStripMenuItem.Text = "Create New Test Suite";
            // 
            // backUpAutomationTestsToolStripMenuItem
            // 
            this.backUpAutomationTestsToolStripMenuItem.Name = "backUpAutomationTestsToolStripMenuItem";
            this.backUpAutomationTestsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.backUpAutomationTestsToolStripMenuItem.Text = "Backup Automation Tests";
            // 
            // restoreTestsToolStripMenuItem
            // 
            this.restoreTestsToolStripMenuItem.Name = "restoreTestsToolStripMenuItem";
            this.restoreTestsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.restoreTestsToolStripMenuItem.Text = "Restore Tests";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Location = new System.Drawing.Point(3, 27);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(439, 179);
            this.pnlContainer.TabIndex = 8;
            // 
            // PixTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 211);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PixTracker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PixTracker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createNewTestSuiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpAutomationTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreTestsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlContainer;
    }
}

