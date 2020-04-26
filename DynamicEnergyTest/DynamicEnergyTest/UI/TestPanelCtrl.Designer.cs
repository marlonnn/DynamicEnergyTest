namespace DynamicEnergyTest.UI
{
    partial class TestPanelCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.testProcessCtrl1 = new DynamicEnergyTest.UI.TestProcessCtrl();
            this.statusSwitchCtrl = new DynamicEnergyTest.UI.StatusSwitchCtrl();
            this.listView = new DynamicEnergyTest.UI.ExListView();
            this.SuspendLayout();
            // 
            // testProcessCtrl1
            // 
            this.testProcessCtrl1.BackColor = System.Drawing.Color.White;
            this.testProcessCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.testProcessCtrl1.Location = new System.Drawing.Point(0, 0);
            this.testProcessCtrl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.testProcessCtrl1.Name = "testProcessCtrl1";
            this.testProcessCtrl1.Size = new System.Drawing.Size(1100, 130);
            this.testProcessCtrl1.TabIndex = 0;
            // 
            // statusSwitchCtrl
            // 
            this.statusSwitchCtrl.Alpha = 255;
            this.statusSwitchCtrl.Index = 0;
            this.statusSwitchCtrl.Location = new System.Drawing.Point(0, 138);
            this.statusSwitchCtrl.Name = "statusSwitchCtrl";
            this.statusSwitchCtrl.Size = new System.Drawing.Size(544, 509);
            this.statusSwitchCtrl.SystemStatus = DynamicEnergyTest.SysSetting.SysConfig.SysStatus.NotReady;
            this.statusSwitchCtrl.TabIndex = 0;
            this.statusSwitchCtrl.TestContent = null;
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(552, 138);
            this.listView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView.MaxLogRecords = 300;
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(547, 511);
            this.listView.TabIndex = 2;
            this.listView.Timer = null;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // TestPanelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.testProcessCtrl1);
            this.Controls.Add(this.statusSwitchCtrl);
            this.Controls.Add(this.listView);
            this.Name = "TestPanelCtrl";
            this.Size = new System.Drawing.Size(1100, 645);
            this.ResumeLayout(false);

        }

        #endregion

        private TestProcessCtrl testProcessCtrl1;
        private StatusSwitchCtrl statusSwitchCtrl;
        private ExListView listView;
    }
}
