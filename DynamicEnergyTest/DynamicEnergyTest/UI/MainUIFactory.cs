using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicEnergyTest.UI
{
    public class MainUIFactory
    {
        public static MainUIFactory factory;

        private TestPanelCtrl testPanelCtrl;
        public TestPanelCtrl TestPanelCtrl
        {
            get { return testPanelCtrl; }
        }

        private SettingPanelCtrl settingPanelCtrl;
        public SettingPanelCtrl SettingPanelCtrl
        {
            get { return settingPanelCtrl; }
        }

        private ReportPanelCtrl reportPanelCtrl;
        public ReportPanelCtrl ReportPanelCtrl
        {
            get { return reportPanelCtrl; }
        }

        private FlashPanelCtrl flashPanelCtrl;
        public FlashPanelCtrl FlashPanelCtrl
        {
            get { return flashPanelCtrl; }
        }

        public MainUIFactory()
        {
            testPanelCtrl = new TestPanelCtrl();
            reportPanelCtrl = new ReportPanelCtrl();
            settingPanelCtrl = new SettingPanelCtrl();
            flashPanelCtrl = new FlashPanelCtrl();

            testPanelCtrl.Dock = DockStyle.Fill;
            reportPanelCtrl.Dock = DockStyle.Fill;
            settingPanelCtrl.Dock = DockStyle.Fill;
            flashPanelCtrl.Dock = DockStyle.Fill;
        }

        public static MainUIFactory Get()
        {
            if (factory == null)
                factory = new MainUIFactory();
            return factory;
        }
    }
}
