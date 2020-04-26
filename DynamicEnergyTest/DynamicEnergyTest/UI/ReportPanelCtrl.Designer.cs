namespace DynamicEnergyTest.UI
{
    partial class ReportPanelCtrl
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
            this.testInfosPanel1 = new DynamicEnergyTest.UI.TestInfosPanel();
            this.queryCtrl1 = new DynamicEnergyTest.UI.QueryCtrl();
            this.SuspendLayout();
            // 
            // testInfosPanel1
            // 
            this.testInfosPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.testInfosPanel1.FailureCount = 0;
            this.testInfosPanel1.Location = new System.Drawing.Point(0, 0);
            this.testInfosPanel1.Name = "testInfosPanel1";
            this.testInfosPanel1.PassCount = 0;
            this.testInfosPanel1.Size = new System.Drawing.Size(1100, 122);
            this.testInfosPanel1.TabIndex = 0;
            this.testInfosPanel1.TestedCount = 0;
            this.testInfosPanel1.TestPlanCount = 0;
            this.testInfosPanel1.UnTestCount = 0;
            // 
            // queryCtrl1
            // 
            this.queryCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryCtrl1.Location = new System.Drawing.Point(0, 122);
            this.queryCtrl1.Name = "queryCtrl1";
            this.queryCtrl1.Size = new System.Drawing.Size(1100, 648);
            this.queryCtrl1.TabIndex = 1;
            // 
            // ReportPanelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.queryCtrl1);
            this.Controls.Add(this.testInfosPanel1);
            this.Name = "ReportPanelCtrl";
            this.Size = new System.Drawing.Size(1100, 770);
            this.ResumeLayout(false);

        }

        #endregion

        private TestInfosPanel testInfosPanel1;
        private QueryCtrl queryCtrl1;
    }
}
