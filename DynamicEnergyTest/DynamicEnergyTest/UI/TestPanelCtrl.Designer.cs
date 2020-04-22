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
            this.statusSwitchCtrl = new DynamicEnergyTest.UI.StatusSwitchCtrl();
            this.listView = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testProcessCtrl1
            // 
            this.testProcessCtrl1.BackColor = System.Drawing.Color.White;
            this.testProcessCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.testProcessCtrl1.Location = new System.Drawing.Point(0, 0);
            this.testProcessCtrl1.Margin = new System.Windows.Forms.Padding(5);
            this.testProcessCtrl1.Name = "testProcessCtrl1";
            this.testProcessCtrl1.Size = new System.Drawing.Size(1467, 162);
            this.testProcessCtrl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.statusSwitchCtrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 162);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1467, 644);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // statusSwitchCtrl
            // 
            this.statusSwitchCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusSwitchCtrl.Index = 0;
            this.statusSwitchCtrl.Location = new System.Drawing.Point(4, 4);
            this.statusSwitchCtrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusSwitchCtrl.Name = "statusSwitchCtrl";
            this.statusSwitchCtrl.Size = new System.Drawing.Size(725, 636);
            this.statusSwitchCtrl.TabIndex = 0;
            this.statusSwitchCtrl.TestContent = null;
            this.statusSwitchCtrl.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(736, 3);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(728, 638);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            // 
            // TestPanelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.testProcessCtrl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TestPanelCtrl";
            this.Size = new System.Drawing.Size(1467, 806);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TestProcessCtrl testProcessCtrl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private StatusSwitchCtrl statusSwitchCtrl;
        private System.Windows.Forms.ListView listView;
    }
}
