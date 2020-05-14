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
using DynamicEnergyTest.SysSetting;
using static DynamicEnergyTest.SysSetting.SysConfig;

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

        public void ResetProcessItem()
        {
            this._index = 0;
            this.switchIndexCtrl.SwitchIndex = "";
            this.switchIndexCtrl.SwitchText = "";
            this.TestContent = "";
            this.TestStatus = TestStatus.UnTest;
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
                    StartAlpha = value;
                    //this.Invalidate();
                    this.InvokeInvalidate(Alpha, value);
                    this.Invalidate(bottomRectangle);
                }
            }
        }

        private int _startAlpha;
        public int StartAlpha
        {
            get { return _startAlpha; }
            set
            {
                if (value != _startAlpha)
                {
                    this._startAlpha = value;
                    //this.Invalidate();
                    this.InvokeInvalidate(_startAlpha, value);
                    this.Invalidate(_inEllipseRect);
                }
            }
        }

        private Rectangle _inEllipseRect;
        public Rectangle InEllipseRect
        {
            get { return _inEllipseRect; }
            set { _inEllipseRect = value; }
        }

        private SysStatus _sysStatus;
        public SysStatus SystemStatus
        {
            get { return _sysStatus; }
            set
            {
                if (value != _sysStatus)
                {
                    _sysStatus = value;
                    this.Invalidate();
                }
            }
        }
        private SysConfig sysConfig;

        public StatusSwitchCtrl()
        {
            sysConfig = SysConfig.GetConfig();

            InitializeComponent();
            this.TestStatus = TestStatus.UnTest;
            this.SwitchText = "Test";
            this.DoubleBuffered = true;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.switchIndexCtrl.Location = new Point((this.Width - this.switchIndexCtrl.Width) / 2, 10);
            topRectangle = new RectangleF(0, 0, this.Width, this.Height / 2);
            bottomRectangle = new Rectangle(0, this.Height / 2, this.Width, this.Height / 2);
            Alpha = 255;
            this.SystemStatus = sysConfig.SystemStatus;
            this.switchIndexCtrl.Visible = SystemStatus == SysStatus.GetReady;
            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.switchIndexCtrl.Location = new Point((this.Width - this.switchIndexCtrl.Width) / 2, 10);
            topRectangle = new RectangleF(0, 0, this.Width, this.Height / 2);
            bottomRectangle = new Rectangle(0, this.Height / 2, this.Width, this.Height / 2);
            Alpha = 255;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            SolidBrush topSolidBrush = new SolidBrush(GraphicFactory.DynamicGray);

            if (SystemStatus == SysStatus.GetReady)
            {
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
                bottomSolidBrush.Dispose();

            }
            else if (SystemStatus == SysStatus.NotReady)
            {
                graphics.FillRectangle(topSolidBrush, new RectangleF(0, 0, this.Bounds.Width, this.Bounds.Height));

                int OutEllipseRadiu = this.Bounds.Height / 2 - 130;
                int inEllipseRadiu = this.Bounds.Height / 2 - 150;

                graphics.FillEllipse(Brushes.White, this.Width / 2  - OutEllipseRadiu, this.Height / 2 - OutEllipseRadiu, 2 * OutEllipseRadiu, 2 * OutEllipseRadiu);

                Color color = Color.FromArgb(Alpha, GraphicFactory.DynamicBlue);
                SolidBrush inSolidBrush = new SolidBrush(color);

                this.InEllipseRect = new Rectangle(this.Width / 2 - inEllipseRadiu, this.Height / 2 - inEllipseRadiu, 2 * inEllipseRadiu, 2 * inEllipseRadiu);
                graphics.FillEllipse(inSolidBrush, InEllipseRect);

                using (Font font = GraphicFactory.CreateFont(40, FontStyle.Bold))
                {
                    string start = "START";
                    var size = graphics.MeasureString(start, font);
                    graphics.DrawString(start, font, Brushes.White, InEllipseRect.X + (InEllipseRect.Width - size.Width) / 2, InEllipseRect.Y + (InEllipseRect.Height - size.Height) / 2);
                }

                inSolidBrush.Dispose();
            }

            topSolidBrush.Dispose();
        }

        private void StatusSwitchCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            Alpha = bottomRectangle.Contains(e.Location) ? 200 : 255;
        }

        private void StatusSwitchCtrl_MouseClick(object sender, MouseEventArgs e)
        {

            if (SystemStatus == SysStatus.NotReady && InEllipseRect.Contains(e.Location))
            {
                sysConfig.SystemStatus = SysStatus.GetReady;
                SystemStatus = sysConfig.SystemStatus;
                this.switchIndexCtrl.Visible = SystemStatus == SysStatus.GetReady;
                StartProcessHandler?.Invoke(sender, e);
            }
        }

        public EventHandler StartProcessHandler;

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
