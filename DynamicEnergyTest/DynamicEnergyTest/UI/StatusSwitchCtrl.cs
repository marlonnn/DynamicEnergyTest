using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicEnergyTest.TestModel;

namespace DynamicEnergyTest.UI
{
    public partial class StatusSwitchCtrl : UserControl
    {
        private int _index;
        public int Index
        {
            get { return _index; }
            set
            {
                if (value != _index)
                {
                    _index = value;
                }
            }
        }
        private TestStatus _testStatus;
        [Description("Test status"), Category("Appearance"), DefaultValue(TestStatus.UnTest)]
        public TestStatus TestStatus
        {
            get { return _testStatus; }
            set
            {
                if (value != _testStatus)
                {
                    _testStatus = value;
                    this.Invalidate();
                    this.InvokeInvalidate(TestStatus, value);
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

        private string _testContent;
        [Description("Test Content"), Category("Appearance"), DefaultValue(" ")]
        public string TestContent
        {
            get { return _testContent; }
            set
            {
                if (value != _testContent)
                {
                    this._testContent = value;
                    this.Invalidate();
                    this.InvokeInvalidate(TestContent, value);
                }
            }
        }

        public void UpdateProcessItem(ProcessItem processItem)
        {
            this._index = processItem.Index;
            this.switchIndexCtrl.SwitchIndex = processItem.Index.ToString();
            this.switchIndexCtrl.SwitchText = processItem.TestTitle;
            this.TestContent = processItem.TestContent;
        }

        private Rectangle bottomRectangle;
        private RectangleF topRectangle;
        private int _alpha;
        public int Alpha
        {
            get { return _alpha; }
            set
            {
                if (value != _alpha)
                {
                    this._alpha = value;
                    //this.Invalidate();
                    this.InvokeInvalidate(Alpha, value);
                    this.Invalidate(bottomRectangle);
                }
            }
        }

        public StatusSwitchCtrl()
        {
            InitializeComponent();
            this.TestStatus = TestStatus.UnTest;
            this.SwitchText = "Test";
            this.DoubleBuffered = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.switchIndexCtrl.Location = new Point((this.Width - this.switchIndexCtrl.Width) / 2, 0);
            topRectangle = new RectangleF(0, 0, this.Width, this.Height / 2);
            bottomRectangle = new Rectangle(0, this.Height / 2, this.Width, this.Height / 2);
            Alpha = 255;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.switchIndexCtrl.Location = new Point((this.Width - this.switchIndexCtrl.Width) / 2, 0);
            topRectangle = new RectangleF(0, 0, this.Width, this.Height / 2);
            bottomRectangle = new Rectangle(0, this.Height / 2, this.Width, this.Height / 2);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            SolidBrush topSolidBrush = new SolidBrush(GraphicFactory.DynamicGray);
            graphics.FillRectangle(topSolidBrush, topRectangle);

            Color bottomColor = GraphicFactory.DynamicOrange;
            switch (TestStatus)
            {
                case TestStatus.UnTest:
                    bottomColor = GraphicFactory.DynamicOrange;
                    this.SwitchText = "UNTEST";
                    break;
                case TestStatus.Testing:
                    bottomColor = GraphicFactory.DynamicOrange;
                    this.SwitchText = "Testing";
                    break;
                case TestStatus.Pass:
                    bottomColor = GraphicFactory.DynamicGreen;
                    this.SwitchText = "PASS";
                    break;
                case TestStatus.Fail:
                    bottomColor = GraphicFactory.DynamicRed;
                    this.SwitchText = "FAIL";
                    break;
            }
            bottomColor = Color.FromArgb(Alpha, bottomColor.R, bottomColor.G, bottomColor.B);
            SolidBrush bottomSolidBrush = new SolidBrush(bottomColor);
            graphics.FillRectangle(bottomSolidBrush, bottomRectangle);

            if (!string.IsNullOrEmpty(this.TestContent))
            {
                using (Font font = GraphicFactory.CreateFont(10F, FontStyle.Regular))
                using (SolidBrush textSolidBrush = new SolidBrush(Color.White))
                {
                    SizeF textSize = graphics.MeasureString(this.SwitchText, font);
                    graphics.DrawString(TestContent, font, textSolidBrush, new RectangleF(20, 70, this.Width - 20, this.Height - 70));

                }
            }

            if (!string.IsNullOrEmpty(this.SwitchText))
            {
                using (Font font = GraphicFactory.CreateFont(60F, FontStyle.Bold))
                using (SolidBrush textSolidBrush = new SolidBrush(Color.White))
                {
                    SizeF textSize = graphics.MeasureString(this.SwitchText, font);
                    graphics.DrawString(SwitchText, font, textSolidBrush, (this.Width - textSize.Width) / 2, this.Height / 2 + (this.Height / 2 - textSize.Height) / 2);

                }
            }
            topSolidBrush.Dispose();
            bottomSolidBrush.Dispose();
        }

        private void StatusSwitchCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            Alpha = bottomRectangle.Contains(e.Location) ? 200 : 255;
        }

        private void StatusSwitchCtrl_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void StatusSwitchCtrl_MouseUp(object sender, MouseEventArgs e)
        {
            Alpha = 255;
        }

        private void StatusSwitchCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            Alpha = 100;
        }
    }
}
