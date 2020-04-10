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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.importTestPlanCtrl1 = new DynamicEnergyTest.UI.ImportTestPlanCtrl();
            this.label2 = new System.Windows.Forms.Label();
            this.parameterSettingCtrl1 = new DynamicEnergyTest.UI.ParameterSettingCtrl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.importTestPlanCtrl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.parameterSettingCtrl1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.36434F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.63566F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 501F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 645);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "新建测试计划：";
            // 
            // importTestPlanCtrl1
            // 
            this.importTestPlanCtrl1.BackColor = System.Drawing.Color.White;
            this.importTestPlanCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importTestPlanCtrl1.Location = new System.Drawing.Point(3, 24);
            this.importTestPlanCtrl1.Name = "importTestPlanCtrl1";
            this.importTestPlanCtrl1.Size = new System.Drawing.Size(1094, 94);
            this.importTestPlanCtrl1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "参数设置：";
            // 
            // parameterSettingCtrl1
            // 
            this.parameterSettingCtrl1.BackColor = System.Drawing.Color.White;
            this.parameterSettingCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parameterSettingCtrl1.Location = new System.Drawing.Point(3, 146);
            this.parameterSettingCtrl1.Name = "parameterSettingCtrl1";
            this.parameterSettingCtrl1.Size = new System.Drawing.Size(1094, 496);
            this.parameterSettingCtrl1.TabIndex = 3;
            // 
            // SettingPanelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingPanelCtrl";
            this.Size = new System.Drawing.Size(1100, 645);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private ImportTestPlanCtrl importTestPlanCtrl1;
        private System.Windows.Forms.Label label2;
        private ParameterSettingCtrl parameterSettingCtrl1;
    }
}
