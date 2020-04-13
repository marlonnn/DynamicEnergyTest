namespace DynamicEnergyTest.UI
{
    partial class FlashPanelCtrl
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
            this.flashFilesCtrl1 = new DynamicEnergyTest.UI.FlashFilesCtrl();
            this.flashBinFilesCtrl1 = new DynamicEnergyTest.UI.FlashBinFilesCtrl();
            this.flashSettingCtrl1 = new DynamicEnergyTest.UI.FlashSettingCtrl();
            this.SuspendLayout();
            // 
            // flashFilesCtrl1
            // 
            this.flashFilesCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flashFilesCtrl1.Location = new System.Drawing.Point(10, 329);
            this.flashFilesCtrl1.Name = "flashFilesCtrl1";
            this.flashFilesCtrl1.Size = new System.Drawing.Size(950, 321);
            this.flashFilesCtrl1.TabIndex = 2;
            // 
            // flashBinFilesCtrl1
            // 
            this.flashBinFilesCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flashBinFilesCtrl1.Location = new System.Drawing.Point(0, 116);
            this.flashBinFilesCtrl1.Name = "flashBinFilesCtrl1";
            this.flashBinFilesCtrl1.Size = new System.Drawing.Size(973, 207);
            this.flashBinFilesCtrl1.TabIndex = 1;
            // 
            // flashSettingCtrl1
            // 
            this.flashSettingCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flashSettingCtrl1.Location = new System.Drawing.Point(0, 0);
            this.flashSettingCtrl1.Name = "flashSettingCtrl1";
            this.flashSettingCtrl1.Size = new System.Drawing.Size(973, 110);
            this.flashSettingCtrl1.TabIndex = 0;
            // 
            // FlashPanelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flashFilesCtrl1);
            this.Controls.Add(this.flashBinFilesCtrl1);
            this.Controls.Add(this.flashSettingCtrl1);
            this.Name = "FlashPanelCtrl";
            this.Size = new System.Drawing.Size(973, 653);
            this.ResumeLayout(false);

        }

        #endregion

        private FlashSettingCtrl flashSettingCtrl1;
        private FlashBinFilesCtrl flashBinFilesCtrl1;
        private FlashFilesCtrl flashFilesCtrl1;
    }
}
