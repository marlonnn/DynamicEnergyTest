using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KoboldCom;
using DynamicEnergyTest.UI;
using System.IO;
using System.Xml;
using DynamicEnergyTest.Protocol;
using DynamicEnergyTest.SysSetting;

namespace DynamicEnergyTest
{
    public partial class MainForm : Form
    {
        //private readonly Communicator communicator = new Communicator(new SerialPort(), new Protocols());
        private MainUIFactory UIFactory;
        public MainForm()
        {
            InitializeComponent();
            byte[] bytes = new byte[] {
                0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x54, 0x65, 0x73, 0x74
            };
            string result = System.Text.Encoding.UTF8.GetString(bytes);
            UIFactory = Program.UIFactory;

            this.toolBarCtrl1.EventHandler += SwitchPageEventHandler;
        }

        private void SwitchPageEventHandler(object sender, EventArgs e)
        {
            ToolBarItem toolBarItem = sender as ToolBarItem;
            if (toolBarItem != null)
            {
                switch (toolBarItem.ItemIndex)
                {
                    case 1:
                        this.panel.Controls.Clear();
                        this.panel.Controls.Add(UIFactory.TestPanelCtrl);
                        break;
                    case 2:
                        this.panel.Controls.Clear();
                        this.panel.Controls.Add(UIFactory.ReportPanelCtrl);
                        break;
                    case 3:
                        this.panel.Controls.Clear();
                        this.panel.Controls.Add(UIFactory.SettingPanelCtrl);
                        break;
                    case 4:
                        this.panel.Controls.Clear();
                        this.panel.Controls.Add(UIFactory.FlashPanelCtrl);
                        break;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SysConfig.GetConfig().SystemMode == SysMode.FullMode)
                this.panel.Controls.Add(UIFactory.TestPanelCtrl);
            else
                this.panel.Controls.Add(UIFactory.FlashPanelCtrl);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                base.OnClosing(e);
                SysSetting.SysConfig.GetConfig().WriteFlushConfig();
                SysSetting.SysConfig.GetConfig().WriteJsonConfig();
            }
            catch (Exception ex)
            {
            }
        }

    }
}