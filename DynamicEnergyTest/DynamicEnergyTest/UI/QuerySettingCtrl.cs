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
    public partial class QuerySettingCtrl : UserControl
    {
        private const int MARGIN = 10;

        public QuerySettingCtrl()
        {
            InitializeComponent();
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
    }
}
