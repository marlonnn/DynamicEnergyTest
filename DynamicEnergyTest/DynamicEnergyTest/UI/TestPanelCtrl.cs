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
using static DynamicEnergyTest.SysSetting.SysConfig;
using DynamicEnergyTest.Protocol;

namespace DynamicEnergyTest.UI
{
    public partial class TestPanelCtrl : UserControl
    {
        private Timer logViewTimer;
        public Timer LogViewTimer
        {
            get { return logViewTimer; }
        }
        private Timer processTimer;

        private SysConfig sysConfig;

        private SysStatus _sysStatus;
        public SysStatus SystemStatus
        {
            get { return _sysStatus; }
            set
            {
                if (value != _sysStatus)
                {
                    _sysStatus = value;
                    AutoSetStatusCtrlBounds();
                    StatusSwitchCtrl.SystemStatus = value;
                    this.Invalidate();
                }
            }
        }

        public TestPanelCtrl()
        {
            sysConfig = SysConfig.GetConfig();

            InitializeComponent();
            logViewTimer = new Timer();
            logViewTimer.Interval = 300;
            logViewTimer.Tick += Timer_Tick;
            logViewTimer.Start();

            processTimer = new Timer();
            processTimer.Interval = 1000;
            processTimer.Tick += ProcessTimer_Tick;

            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "消息日志";
            columnHeader.Width = 500;
            this.listView.Columns.Add(columnHeader);
            this.listView.Timer = logViewTimer;

            this.statusSwitchCtrl.SystemStatus = sysConfig.SystemStatus;
            this.statusSwitchCtrl.StartProcessHandler += StartProcessHandler;

            ProtocolFactory.GetFactory().UpdateListViewHandler += UpdateListView;
        }

        private void StartProcessHandler(object sender, EventArgs e)
        {
            StartProcessTimer();
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {

        }

        public void StartProcessTimer()
        {
            processTimer.Start();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (logViewTimer != null) logViewTimer.Stop();
            if (processTimer != null) processTimer.Stop();
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
            this.listView.AppendLog(new string[] { info });
        }

        public void ResetListView()
        {
            this.listView.Clear();
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "消息日志";
            columnHeader.Width = 500;
            this.listView.Columns.Add(columnHeader);
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

        public void UpdateStatusSwitch(TestStatus testStatus)
        {
            this.statusSwitchCtrl.TestStatus = testStatus;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AutoSetStatusCtrlBounds();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AutoSetStatusCtrlBounds();
        }

        private void AutoSetStatusCtrlBounds()
        {
            switch (sysConfig.SystemStatus)
            {
                case SysConfig.SysStatus.NotReady:
                    SetNotReadyStatusCtrlBounds();
                    break;
                case SysConfig.SysStatus.GetReady:
                    SetGetReadyStatusCtrlBounds();
                    break;
            }
        }

        private void SetNotReadyStatusCtrlBounds()
        {
            this.statusSwitchCtrl.Bounds =
                new Rectangle(0, this.testProcessCtrl1.Location.Y + this.testProcessCtrl1.Height + 10, 
                this.Width, this.Height - this.testProcessCtrl1.Height - 10);
            this.listView.Visible = false;

        }

        private void SetGetReadyStatusCtrlBounds()
        {
            this.statusSwitchCtrl.Bounds =
                new Rectangle(0, this.testProcessCtrl1.Location.Y + this.testProcessCtrl1.Height + 10,
                this.Width / 2, this.Height - this.testProcessCtrl1.Height - 10);
            this.listView.Bounds =
                new Rectangle(this.Width / 2, this.testProcessCtrl1.Location.Y + this.testProcessCtrl1.Height + 10,
                this.Width / 2, this.Height - this.testProcessCtrl1.Height - 10);
            this.listView.Visible = true;
        }
    }
}
