namespace DynamicEnergyTest
{
    partial class MainForm
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
            this.panel = new System.Windows.Forms.Panel();
            this.toolBarCtrl1 = new DynamicEnergyTest.UI.ToolBarCtrl();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 60);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1101, 678);
            this.panel.TabIndex = 1;
            // 
            // toolBarCtrl1
            // 
            this.toolBarCtrl1.BackColor = System.Drawing.Color.White;
            this.toolBarCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarCtrl1.Location = new System.Drawing.Point(0, 0);
            this.toolBarCtrl1.Name = "toolBarCtrl1";
            this.toolBarCtrl1.Size = new System.Drawing.Size(1101, 60);
            this.toolBarCtrl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 738);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolBarCtrl1);
            this.Name = "MainForm";
            this.AllowDrop = true;
            this.ShowIcon = false;
            this.Text = "动态能量标识产测软件";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ToolBarCtrl toolBarCtrl1;
        private System.Windows.Forms.Panel panel;
    }
}