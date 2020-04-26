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
    public partial class ReportPanelCtrl : UserControl
    {
        public ReportPanelCtrl()
        {
            InitializeComponent();
        }

        public void UpdateTestInfos()
        {
            this.testInfosPanel1.UpdateTestInfos();
        }
    }
}
