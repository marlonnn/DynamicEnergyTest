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

namespace DynamicEnergyTest.UI
{
    public partial class TestPanelCtrl : UserControl
    {
        public TestPanelCtrl()
        {
            InitializeComponent();
        }

        public StatusSwitchCtrl StatusSwitchCtrl
        {
            get { return this.statusSwitchCtrl; }
        }

        public void UpdateListView(string info)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = info;
            this.listView.Items.Add(lvi);
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
