namespace DynamicEnergyTest.UI
{
    partial class StatusSwitchCtrl
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
            this.switchIndexCtrl = new DynamicEnergyTest.UI.SwitchIndexCtrl();
            this.SuspendLayout();
            // 
            // switchIndexCtrl
            // 
            this.switchIndexCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.switchIndexCtrl.Location = new System.Drawing.Point(175, 4);
            this.switchIndexCtrl.Margin = new System.Windows.Forms.Padding(5);
            this.switchIndexCtrl.Name = "switchIndexCtrl";
            this.switchIndexCtrl.Size = new System.Drawing.Size(227, 64);
            this.switchIndexCtrl.SwitchText = "条码校验";
            this.switchIndexCtrl.TabIndex = 0;
            // 
            // StatusSwitchCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.switchIndexCtrl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StatusSwitchCtrl";
            this.Size = new System.Drawing.Size(641, 618);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StatusSwitchCtrl_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusSwitchCtrl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StatusSwitchCtrl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusSwitchCtrl_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private SwitchIndexCtrl switchIndexCtrl;
    }
}
