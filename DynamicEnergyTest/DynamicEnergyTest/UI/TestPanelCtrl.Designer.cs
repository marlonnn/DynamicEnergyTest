namespace DynamicEnergyTest.UI
{
    partial class TestPanelCtrl
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
            this.testProcessCtrl1 = new DynamicEnergyTest.UI.TestProcessCtrl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusSwitchCtrl1 = new DynamicEnergyTest.UI.StatusSwitchCtrl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testProcessCtrl1
            // 
            this.testProcessCtrl1.BackColor = System.Drawing.Color.White;
            this.testProcessCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.testProcessCtrl1.Location = new System.Drawing.Point(0, 0);
            this.testProcessCtrl1.Name = "testProcessCtrl1";
            this.testProcessCtrl1.Size = new System.Drawing.Size(1100, 130);
            this.testProcessCtrl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.statusSwitchCtrl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 130);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 515);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // statusSwitchCtrl1
            // 
            this.statusSwitchCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusSwitchCtrl1.Index = 0;
            this.statusSwitchCtrl1.Location = new System.Drawing.Point(3, 3);
            this.statusSwitchCtrl1.Name = "statusSwitchCtrl1";
            this.statusSwitchCtrl1.Size = new System.Drawing.Size(544, 509);
            this.statusSwitchCtrl1.TabIndex = 0;
            this.statusSwitchCtrl1.TestStatus = DynamicEnergyTest.TestStatus.Test;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(553, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(544, 509);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // TestPanelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.testProcessCtrl1);
            this.Name = "TestPanelCtrl";
            this.Size = new System.Drawing.Size(1100, 645);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TestProcessCtrl testProcessCtrl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private StatusSwitchCtrl statusSwitchCtrl1;
        private System.Windows.Forms.ListView listView1;
    }
}
