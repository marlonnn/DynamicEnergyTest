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
    public partial class ToolBarCtrl : UserControl
    {
        public EventHandler EventHandler;
        public ToolBarCtrl()
        {
            InitializeComponent();
            this.toolBarItemTest.EnableFocus = true;
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            ToolBarItem toolBarItem = sender as ToolBarItem;
            if (toolBarItem != null )
            {
                toolBarItem.EnableFocus = true;
                foreach (var ctrl in this.Controls)
                {
                    ToolBarItem barItem = ctrl as ToolBarItem;
                    if (barItem != null && barItem != toolBarItem)
                    {
                        barItem.EnableFocus = false;
                    }
                }
            }
            EventHandler?.Invoke(sender, e);
        }
    }
}
