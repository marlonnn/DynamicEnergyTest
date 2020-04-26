namespace DynamicEnergyTest.UI
{
    partial class FlashSettingCtrl
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
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBaudrate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(40, 50);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(128, 30);
            this.btnImport.TabIndex = 11;
            this.btnImport.Text = "导入设备密钥清单";
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(292, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "COM端口";
            // 
            // comboPort
            // 
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(345, 56);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(121, 20);
            this.comboPort.TabIndex = 13;
            this.comboPort.SelectedIndexChanged += new System.EventHandler(this.ComboPort_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(562, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "波特率";
            // 
            // comboBaudrate
            // 
            this.comboBaudrate.FormattingEnabled = true;
            this.comboBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "115200",
            "921600"});
            this.comboBaudrate.Location = new System.Drawing.Point(609, 56);
            this.comboBaudrate.Name = "comboBaudrate";
            this.comboBaudrate.Size = new System.Drawing.Size(121, 20);
            this.comboBaudrate.TabIndex = 15;
            this.comboBaudrate.SelectedIndexChanged += new System.EventHandler(this.ComboBaudrate_SelectedIndexChanged);
            // 
            // FlashSettingCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBaudrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Name = "FlashSettingCtrl";
            this.Size = new System.Drawing.Size(1006, 99);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBaudrate;
    }
}
