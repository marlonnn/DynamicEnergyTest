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
    public partial class TestProcessItem : UserControl
    {
        private const int diameter = 30;
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
        public TestProcessItem()
        {
            InitializeComponent();
            this.TestStatus = TestStatus.Unknow;
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
                    case TestStatus.Unknow:
                        using (Font font = new Font("Microsoft Sans Serif", 10F))
                        using (SolidBrush solidBrush = new SolidBrush(infotextColor))
                        {
                            SizeF textSize = graphics.MeasureString(InfoText, font);
                            graphics.DrawString(InfoText, font, solidBrush, (this.Width - textSize.Width) / 2, this.Height - textSize.Height);
                        }
                        break;
                    case TestStatus.Testing:
                    case TestStatus.Pass:
                    case TestStatus.Fail:
                        using (Font font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold))
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
            Color circleColor = ColorFactory.DynamicGray;
            switch (TestStatus)
            {
                case TestStatus.Unknow:
                    if (!string.IsNullOrEmpty(ItemText))
                    {
                        using (Pen pen = new Pen(circleColor, 2f))
                        using (Font font = new Font("Microsoft Sans Serif", 10F))
                        using (SolidBrush solidBrush = new SolidBrush(circleColor))
                        {
                            SizeF textSize = graphics.MeasureString(ItemText, font);
                            graphics.DrawEllipse(pen, new RectangleF((this.Width - diameter) / 2, (this.Height - diameter) / 2, diameter, diameter));
                            graphics.DrawString(ItemText, font, solidBrush, (this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2);
                        }
                    }

                    break;
                case TestStatus.Testing:
                    if (!string.IsNullOrEmpty(ItemText))
                    {
                        circleColor = ColorFactory.DynamicBlue;
                        using (Pen pen = new Pen(circleColor, 2f))
                        using (Font font = new Font("Microsoft Sans Serif", 10F))
                        using (SolidBrush solidBrush = new SolidBrush(circleColor))
                        {
                            SizeF textSize = graphics.MeasureString(ItemText, font);
                            graphics.FillEllipse(solidBrush, new RectangleF((this.Width - diameter) / 2, (this.Height - diameter) / 2, diameter, diameter));
                            using (SolidBrush textBrush = new SolidBrush(Color.White))
                                graphics.DrawString(ItemText, font, textBrush, (this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2);
                        }
                    }
                    break;
                case TestStatus.Pass:
                    //draw pass symbol
                    int correctWidth = 20;
                    int correctHeght = 15;
                    circleColor = ColorFactory.DynamicBlue;
                    using (Pen pen = new Pen(circleColor, 2f))
                    using (Font font = new Font("Microsoft Sans Serif", 10F))
                    using (SolidBrush solidBrush = new SolidBrush(circleColor))
                    {
                        graphics.DrawEllipse(pen, new RectangleF((this.Width - diameter) / 2, (this.Height - diameter) / 2, diameter, diameter));
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
                        using (Font font = new Font("Microsoft Sans Serif", 10F))
                        using (SolidBrush solidBrush = new SolidBrush(circleColor))
                        {
                            SizeF textSize = graphics.MeasureString(ItemText, font);
                            graphics.FillEllipse(solidBrush, new RectangleF((this.Width - diameter) / 2, (this.Height - diameter) / 2, diameter, diameter));
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
