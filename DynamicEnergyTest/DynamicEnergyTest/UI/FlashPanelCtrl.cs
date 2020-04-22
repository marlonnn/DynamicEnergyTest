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
    public partial class FlashPanelCtrl : UserControl
    {
        public FlashPanelCtrl()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.flashFilesCtrl1.Bounds =
                new Rectangle(10, flashBinFilesCtrl1.Location.Y + flashBinFilesCtrl1.Height + 10, this.Width - 20, this.Height - flashBinFilesCtrl1.Location.Y - flashBinFilesCtrl1.Height - 20);
        }
    }
}
