namespace DynamicEnergyTest.UI
{
    partial class SettingPanelCtrl
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
            this.parameterSettingCtrl1 = new DynamicEnergyTest.UI.ParameterSettingCtrl();
            this.importTestPlanCtrl1 = new DynamicEnergyTest.UI.ImportTestPlanCtrl();
            this.SuspendLayout();
            // 
            // parameterSettingCtrl1
            // 
            this.parameterSettingCtrl1.Location = new System.Drawing.Point(0, 107);
            this.parameterSettingCtrl1.Name = "parameterSettingCtrl1";
            this.parameterSettingCtrl1.Size = new System.Drawing.Size(1097, 660);
            this.parameterSettingCtrl1.TabIndex = 1;
            // 
            // importTestPlanCtrl1
            // 
            this.importTestPlanCtrl1.BackColor = System.Drawing.SystemColors.Control;
            this.importTestPlanCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.importTestPlanCtrl1.Location = new System.Drawing.Point(0, 0);
            this.importTestPlanCtrl1.Name = "importTestPlanCtrl1";
            this.importTestPlanCtrl1.Size = new System.Drawing.Size(1100, 101);
            this.importTestPlanCtrl1.TabIndex = 0;
            // 
            // SettingPanelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.parameterSettingCtrl1);
            this.Controls.Add(this.importTestPlanCtrl1);
            this.Name = "SettingPanelCtrl";
            this.Size = new System.Drawing.Size(1100, 645);
            this.ResumeLayout(false);

        }

        #endregion

        private ImportTestPlanCtrl importTestPlanCtrl1;
        private ParameterSettingCtrl parameterSettingCtrl1;
    }
}
