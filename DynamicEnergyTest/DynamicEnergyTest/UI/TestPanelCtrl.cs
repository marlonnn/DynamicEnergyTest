using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KoboldCom;
using DynamicEnergyTest.SysSetting;

namespace DynamicEnergyTest.UI
{
    public partial class TestPanelCtrl : UserControl
    {
        private Timer timer;

        public TestPanelCtrl()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 300;
            timer.Tick += Timer_Tick;
            timer.Start();
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "消息日志";
            columnHeader.Width = 500;
            this.listView.Columns.Add(columnHeader);
            this.listView.Timer = timer;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (timer != null) timer.Stop();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<ProcessEntry> GetProcessEntrys()
        {
            return this.testProcessCtrl1.GetProcessEntrys();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }

        public StatusSwitchCtrl StatusSwitchCtrl
        {
            get { return this.statusSwitchCtrl; }
        }

        public void UpdateListView(string info)
        {
            //ListViewItem lvi = new ListViewItem();
            //lvi.Text = info;
            this.listView.AppendLog(new string[] { info });
        }

        public void UpdateStatusSwitch(ComCode comCode)
        {
            switch (comCode)
            {
                case ComCode.ComNotExist:
                    this.statusSwitchCtrl.TestStatus = TestStatus.Fail;
                    break;
                case ComCode.ComNotOpen:
                    this.statusSwitchCtrl.TestStatus = TestStatus.Fail;
                    break;
                case ComCode.TimeOut:
                    this.statusSwitchCtrl.TestStatus = TestStatus.Fail;
                    break;
                case ComCode.SendOK:
                    break;
                case ComCode.ReceivedOK:
                    this.statusSwitchCtrl.TestStatus = TestStatus.Pass;
                    break;
            }
        }
    }
}
