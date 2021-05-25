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
    public partial class QuerySettingCtrl : UserControl
    {
        private const int MARGIN = 10;
        private SysConfig sysConfig;
        public QuerySettingCtrl()
        {
            InitializeComponent();

            sysConfig = SysConfig.GetConfig();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, MARGIN, MARGIN, this.Width - 2 * MARGIN, this.Height - 2 * MARGIN);
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            QueryEnter(sender, e);
        }

        private void QueryEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtUID.Text) || !string.IsNullOrEmpty(this.txtStatus.Text))
            {
                string uidCode = this.txtUID.Text.ToUpper();
                //string status = this.txtStatus.Text.ToUpper();
                var dataTable = sysConfig.QueryProcessTestsItem(uidCode);
                sysConfig.UpdateQueryUIDItemHandler?.Invoke(dataTable, e);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.txtUID.Text = "";
            this.txtStatus.Text = "";

            var dt = sysConfig.QueryProcessTests();
            sysConfig.UpdateQueryUIDItemHandler?.Invoke(dt, e);
        }

        private void TxtUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                QueryEnter(sender, e);
                e.Handled = true;
            }
        }
    }
}
