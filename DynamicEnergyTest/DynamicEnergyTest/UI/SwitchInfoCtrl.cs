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
    public partial class SwitchInfoCtrl : UserControl
    {
        private const int offset = 20;
        private string _infoText;
        [Description("Info Text"), Category("Appearance"), DefaultValue("Test")]
        public string InfoText
        {
            get { return _infoText; }
            set
            {
                if (value != _infoText)
                {
                    this._infoText = value;
                    this.Invalidate();
                    this.InvokeInvalidate(InfoText, value);
                }
            }
        }

        public SwitchInfoCtrl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.BackColor = GraphicFactory.DynamicGray;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!string.IsNullOrEmpty(InfoText))
            {
                base.OnPaint(e);
                Graphics graphics = e.Graphics;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                using (Font font = GraphicFactory.CreateFont())
                using (SolidBrush solidBrush = new SolidBrush(Color.White))
                {
                    graphics.DrawString(InfoText, font, solidBrush, new RectangleF(offset, offset, this.Width - offset , this.Height - offset));
                }
            }
        }
    }
}
