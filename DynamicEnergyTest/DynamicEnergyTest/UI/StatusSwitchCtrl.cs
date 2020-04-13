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
        [Description("Test status"), Category("Appearance"), DefaultValue(TestStatus.Unknow)]
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

        public StatusSwitchCtrl()
        {
            InitializeComponent();
            this.TestStatus = TestStatus.Test;
            this.SwitchText = "Test";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.switchIndexCtrl.Location = new Point((this.Width - this.switchIndexCtrl.Width) / 2, 0);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.switchIndexCtrl.Location = new Point((this.Width - this.switchIndexCtrl.Width) / 2, 0);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            SolidBrush topSolidBrush = new SolidBrush(ColorFactory.DynamicGray);
            graphics.FillRectangle(topSolidBrush, new RectangleF(0, 0, this.Width, this.Height / 2));

            Color bottomColor = ColorFactory.DynamicOrange;
            switch (TestStatus)
            {
                case TestStatus.Unknow:
                    bottomColor = ColorFactory.DynamicOrange;
                    break;
                case TestStatus.Test:
                    bottomColor = ColorFactory.DynamicOrange;
                    break;
                case TestStatus.Testing:
                    bottomColor = ColorFactory.DynamicOrange;
                    break;
                case TestStatus.Pass:
                    bottomColor = ColorFactory.DynamicGreen;
                    break;
                case TestStatus.Fail:
                    bottomColor = ColorFactory.DynamicRed;
                    break;
            }
            SolidBrush bottomSolidBrush = new SolidBrush(bottomColor);
            graphics.FillRectangle(bottomSolidBrush, new RectangleF(0, this.Height / 2, this.Width, this.Height / 2));

            if (!string.IsNullOrEmpty(this.TestContent))
            {
                using (Font font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular))
                using (SolidBrush textSolidBrush = new SolidBrush(Color.White))
                {
                    SizeF textSize = graphics.MeasureString(this.SwitchText, font);
                    graphics.DrawString(TestContent, font, textSolidBrush, new RectangleF(20, 70, this.Width - 20, this.Height - 70));

                }
            }

            if (!string.IsNullOrEmpty(this.SwitchText))
            {
                using (Font font = new Font("Microsoft Sans Serif", 60F, FontStyle.Bold))
                using (SolidBrush textSolidBrush = new SolidBrush(Color.White))
                {
                    SizeF textSize = graphics.MeasureString(this.SwitchText, font);
                    graphics.DrawString(SwitchText, font, textSolidBrush, (this.Width - textSize.Width) / 2, this.Height / 2 + (this.Height / 2 - textSize.Height) / 2);

                }
            }
            topSolidBrush.Dispose();
            bottomSolidBrush.Dispose();
        }
    }
}
