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

namespace DynamicEnergyTest.UI
{
    public partial class TestProcessItem : UserControl
    {
        private const int diameter = 30;
        private RectangleF EclipseRectangle { set; get; }
        private string _itemText;
        [Description("Item Text"), Category("Appearance"), DefaultValue("0")]
        public string ItemText
        {
            get { return _itemText; }
            set
            {
                if (value != _itemText)
                {
                    this._itemText = value;
                    this.Invalidate();
                    this.InvokeInvalidate(ItemText, value);
                }
            }
        }

        private string _infoText;
        [Description("Info Text"), Category("Appearance"), DefaultValue("Info Text")]
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
                    this.ProcessEntry.TestStatus = value;
                    this.Invalidate();
                    this.InvokeInvalidate(TestStatus, value);
                }
            }
        }

        private ProcessItem _processItem;
        public ProcessItem ProcessItem
        {
            get { return _processItem; }
            set { _processItem = value; }
        }

        private ProcessEntry _processEntry;
        public ProcessEntry ProcessEntry
        {
            get { return _processEntry; }
            set { _processEntry = value; }
        }

        public MouseEventHandler MouseEventClick;

        public TestProcessItem()
        {
            InitializeComponent();
            this.TestStatus = TestStatus.UnTest;
            this.ProcessItem = new ProcessItem();
            this.MouseClick += TestProcessItem_MouseClick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ProcessEntry = new ProcessEntry(Int32.Parse(ItemText), InfoText, this.TestStatus);

            this.EclipseRectangle = new RectangleF((this.Width - diameter) / 2, (this.Height - diameter) / 2, diameter, diameter);
        }

        private void TestProcessItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.EclipseRectangle.Contains(e.Location))
            {
                MouseEventClick?.Invoke(sender, e);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = this.Height;
        }

        private void DrawInfoText(Graphics graphics)
        {
            if (!string.IsNullOrEmpty(InfoText))
            {
                Color infotextColor = Color.Black;
                switch (TestStatus)
                {
                    case TestStatus.UnTest:
                        using (Font font = GraphicFactory.CreateFont())
                        using (SolidBrush solidBrush = new SolidBrush(infotextColor))
                        {
                            SizeF textSize = graphics.MeasureString(InfoText, font);
                            graphics.DrawString(InfoText, font, solidBrush, (this.Width - textSize.Width) / 2, this.Height - textSize.Height);
                        }
                        break;
                    case TestStatus.Testing:
                    case TestStatus.Pass:
                    case TestStatus.Fail:
                        using (Font font = GraphicFactory.CreateFont(10F, FontStyle.Bold))
                        using (SolidBrush solidBrush = new SolidBrush(infotextColor))
                        {
                            SizeF textSize = graphics.MeasureString(InfoText, font);
                            graphics.DrawString(InfoText, font, solidBrush, (this.Width - textSize.Width) / 2, this.Height - textSize.Height);
                        }
                        break;
                }
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Color circleColor = GraphicFactory.DynamicGray;
            switch (TestStatus)
            {
                case TestStatus.UnTest:
                    if (!string.IsNullOrEmpty(ItemText))
                    {
                        using (Pen pen = new Pen(circleColor, 2f))
                        using (Font font = GraphicFactory.CreateFont())
                        using (SolidBrush solidBrush = new SolidBrush(circleColor))
                        {
                            SizeF textSize = graphics.MeasureString(ItemText, font);
                            graphics.DrawEllipse(pen, this.EclipseRectangle);
                            graphics.DrawString(ItemText, font, solidBrush, (this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2);
                        }
                    }

                    break;
                case TestStatus.Testing:
                    if (!string.IsNullOrEmpty(ItemText))
                    {
                        circleColor = GraphicFactory.DynamicBlue;
                        using (Pen pen = new Pen(circleColor, 2f))
                        using (Font font = GraphicFactory.CreateFont())
                        using (SolidBrush solidBrush = new SolidBrush(circleColor))
                        {
                            SizeF textSize = graphics.MeasureString(ItemText, font);
                            graphics.FillEllipse(solidBrush, this.EclipseRectangle);
                            using (SolidBrush textBrush = new SolidBrush(Color.White))
                                graphics.DrawString(ItemText, font, textBrush, (this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2);
                        }
                    }
                    break;
                case TestStatus.Pass:
                    //draw pass symbol
                    int correctWidth = 20;
                    int correctHeght = 15;
                    circleColor = GraphicFactory.DynamicBlue;
                    using (Pen pen = new Pen(circleColor, 2f))
                    using (Font font = GraphicFactory.CreateFont())
                    using (SolidBrush solidBrush = new SolidBrush(circleColor))
                    {
                        graphics.DrawEllipse(pen, this.EclipseRectangle);
                        Rectangle rectangle = new Rectangle((this.Width - correctHeght) / 2, (this.Height - correctWidth) / 2, correctHeght, correctWidth);
                        graphics.DrawLine(pen, rectangle.X, rectangle.Y + rectangle.Height * 2 / 3, rectangle.X + rectangle.Width / 3, rectangle.Y + rectangle.Height);
                        graphics.DrawLine(pen, rectangle.X + rectangle.Width / 3, rectangle.Y + rectangle.Height, rectangle.X + rectangle.Width, rectangle.Y);
                    }
                    break;
                case TestStatus.Fail:
                    if (!string.IsNullOrEmpty(ItemText))
                    {
                        circleColor = Color.Red;
                        using (Pen pen = new Pen(circleColor, 2f))
                        using (Font font = GraphicFactory.CreateFont())
                        using (SolidBrush solidBrush = new SolidBrush(circleColor))
                        {
                            SizeF textSize = graphics.MeasureString(ItemText, font);
                            graphics.FillEllipse(solidBrush, this.EclipseRectangle);
                            using (SolidBrush textBrush = new SolidBrush(Color.White))
                                graphics.DrawString(ItemText, font, textBrush, (this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2);
                        }
                    }
                    break;
            }
            DrawInfoText(graphics);
        }
    }
}
