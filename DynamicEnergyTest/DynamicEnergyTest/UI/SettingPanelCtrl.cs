using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicEnergyTest.UI
{
    public partial class SettingPanelCtrl : UserControl
    {
        public SettingPanelCtrl()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.parameterSettingCtrl1.Bounds =
                new Rectangle(0, this.importTestPlanCtrl1.Location.Y + importTestPlanCtrl1.Height, this.Width, this.Height - this.importTestPlanCtrl1.Location.Y - importTestPlanCtrl1.Height);
        }
    }
}
