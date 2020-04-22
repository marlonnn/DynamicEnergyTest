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
    public partial class SwitchIndexCtrl : UserControl
    {
        private const int diameter = 30;

        private string _switchIndex;
        [Description("Switch Index"), Category("Appearance"), DefaultValue("1")]
        public string SwitchIndex
        {
            get { return _switchIndex; }
            set
            {
                if (value != _switchIndex)
                {
                    this._switchIndex = value;
                    this.Invalidate();
                    this.InvokeInvalidate(SwitchIndex, value);
                }
            }
        }

        private string _switchText;
        [Description("Switch Text"), Category("Appearance"), DefaultValue("Test")]
        public string SwitchText
        {
            get { return _switchText; }
            set
            {
                if (value != _switchText)
                {
                    this._switchText = value;
                    this.Invalidate();
                    this.InvokeInvalidate(SwitchText, value);
                }
            }
        }

        public SwitchIndexCtrl()
        {
            InitializeComponent();
            this.SwitchIndex = "1";
            this.SwitchText = "Text";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.BackColor = GraphicFactory.DynamicGray;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Color circleColor = GraphicFactory.DynamicGray;
            if (!string.IsNullOrEmpty(SwitchText) && !string.IsNullOrEmpty(SwitchIndex))
            {
                using (Pen pen = new Pen(Color.White, 2f))
                using (Font font = GraphicFactory.CreateFont())
                {
                    SolidBrush ellipseBrush = new SolidBrush(Color.White);
                    SolidBrush indexSolidBrush = new SolidBrush(circleColor);
                    SolidBrush textSolidBrush = new SolidBrush(Color.White);
                    SizeF indexSize = graphics.MeasureString(SwitchIndex, font);
                    SizeF blackSpaceSize = graphics.MeasureString("    ", font);
                    SizeF textSize = graphics.MeasureString(SwitchText, font);
                    graphics.FillEllipse(ellipseBrush, new RectangleF((this.Width - textSize.Width - blackSpaceSize.Width - diameter) / 2, (this.Height - diameter) / 2, diameter, diameter));
                    graphics.DrawString(SwitchIndex, font, indexSolidBrush, (this.Width - indexSize.Width - blackSpaceSize.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2);
                    graphics.DrawString(SwitchText, font, textSolidBrush, (this.Width - textSize.Width - diameter - blackSpaceSize.Width) / 2 + diameter + blackSpaceSize.Width, (this.Height - textSize.Height) / 2);
                    ellipseBrush.Dispose();
                    indexSolidBrush.Dispose();
                    textSolidBrush.Dispose();
                }
            }
        }
    }
}
