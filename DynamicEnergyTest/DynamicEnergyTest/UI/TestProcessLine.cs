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
    public partial class TestProcessLine : UserControl
    {
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

        public TestProcessLine()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Color circleColor = Color.Gray;
            switch (TestStatus)
            {
                case TestStatus.Unknow:
                    using (Pen pen = new Pen(circleColor, 2f))
                    {
                        graphics.DrawLine(pen, 0, 2, this.Width, 2);
                    }
                    break;
                case TestStatus.Testing:
                case TestStatus.Pass:
                case TestStatus.Fail:
                    circleColor = ColorFactory.DynamicBlue;
                    using (Pen pen = new Pen(circleColor, 2f))
                    {
                        graphics.DrawLine(pen, 0, 2, this.Width, 2);
                    }
                    break;
            }
        }
    }
}
