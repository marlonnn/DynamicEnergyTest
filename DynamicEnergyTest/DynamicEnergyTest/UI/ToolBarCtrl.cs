using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicEnergyTest.SysSetting;

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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            bool isFullMode = SysConfig.GetConfig().SystemMode == SysMode.FullMode;
            this.toolBarItemReport.Visible = isFullMode;
            this.toolBarItemTest.Visible = isFullMode;
            this.toolBarItemSetting.Visible = isFullMode;
            if (!isFullMode)
            {
                this.toolBarItemFlash.Bounds = this.toolBarItemTest.Bounds;
                this.toolBarItemFlash.EnableFocus = true;
            }
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
