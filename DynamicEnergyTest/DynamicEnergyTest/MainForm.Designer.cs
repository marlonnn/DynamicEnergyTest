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
            this.toolBarCtrl1 = new DynamicEnergyTest.UI.ToolBarCtrl();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // toolBarCtrl1
            // 
            this.toolBarCtrl1.BackColor = System.Drawing.Color.White;
            this.toolBarCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarCtrl1.Location = new System.Drawing.Point(0, 0);
            this.toolBarCtrl1.Name = "toolBarCtrl1";
            this.toolBarCtrl1.Size = new System.Drawing.Size(1284, 70);
            this.toolBarCtrl1.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 70);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1284, 791);
            this.panel.TabIndex = 1;
            // 
            // MainForm
            // 
            //this.Appearance.BackColor = System.Drawing.Color.White;
            //this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 861);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolBarCtrl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ToolBarCtrl toolBarCtrl1;
        private System.Windows.Forms.Panel panel;
    }
}