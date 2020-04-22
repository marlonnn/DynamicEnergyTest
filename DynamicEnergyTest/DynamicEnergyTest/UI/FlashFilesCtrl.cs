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
    public partial class FlashFilesCtrl : UserControl
    {
        private const int MARGIN = 10;
        private const int MARGINTOP = 20;
        private Rectangle _flashOperate;
        private Rectangle _flashLog;
        private FlashStatus _flashStatus;

        private Button flashButton;

        private const int TextBoxMargin = 20;
        private TextBox uidTxtBox;
        private Rectangle uidTxtBoxRect;
        public FlashFilesCtrl()
        {
            InitializeComponent();
            _flashStatus = FlashStatus.UnFlash;
            InitializeTextBox();
            InitializeLoadButton();
        }

        private void InitializeTextBox()
        {
            uidTxtBox = new TextBox();
            this.uidTxtBox.Location = new System.Drawing.Point(57, 21);
            this.uidTxtBox.Name = "textBox1";
            this.uidTxtBox.Size = new System.Drawing.Size(220, 21);
            this.uidTxtBox.TabIndex = 7;
        }

        private void InitializeLoadButton()
        {
            flashButton = new Button();
            this.flashButton.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.flashButton.FlatStyle = FlatStyle.Flat;
            this.flashButton.ForeColor = Color.White;
            this.flashButton.Name = "loadButton";
            this.flashButton.Size = new Size(88, 30);
            this.flashButton.TabIndex = 1;
            this.flashButton.Text = "开始烧录";
            this.flashButton.UseVisualStyleBackColor = false;
            this.flashButton.Click += FlashButton_Click;
        }

        private void FlashButton_Click(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _flashOperate = new Rectangle(0, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            _flashLog = new Rectangle(this.Width / 2, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);

            this.flashButton.Location = new Point((_flashOperate.Width - flashButton.Width) / 2, (_flashOperate.Height - flashButton.Height) / 2 - _flashOperate.Y);
            this.Controls.Add(flashButton);

            uidTxtBoxRect = new Rectangle(TextBoxMargin, 60, _flashOperate.Width - 2 * TextBoxMargin, 21);
            uidTxtBox.Bounds = uidTxtBoxRect;
            this.Controls.Add(uidTxtBox);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _flashOperate = new Rectangle(0, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            _flashLog = new Rectangle(this.Width / 2, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            if (flashButton != null)
                this.flashButton.Location = new Point((_flashOperate.Width - flashButton.Width) / 2, (_flashOperate.Height - flashButton.Height) / 2 - _flashOperate.Y);
            if (uidTxtBox != null)
            {
                uidTxtBoxRect = new Rectangle(TextBoxMargin, 60, _flashOperate.Width - 2 * TextBoxMargin, 21);
                uidTxtBox.Bounds = uidTxtBoxRect;
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //flash operate
            SolidBrush topSolidBrush = new SolidBrush(GraphicFactory.DynamicGray);
            g.FillRectangle(topSolidBrush, new RectangleF(0, MARGINTOP, _flashOperate.Width, this.Height - MARGINTOP));
            Color bottomColor = GraphicFactory.DynamicOrange;
            switch (_flashStatus)
            {
                case FlashStatus.UnFlash:
                    bottomColor = GraphicFactory.DynamicBlue;
                    break;
                case FlashStatus.Flashing:
                    bottomColor = GraphicFactory.DynamicBlue;
                    break;
                case FlashStatus.Pass:
                    bottomColor = GraphicFactory.DynamicGreen;
                    break;
                case FlashStatus.Failure:
                    bottomColor = GraphicFactory.DynamicRed;
                    break;
            }

            SolidBrush bottomSolidBrush = new SolidBrush(bottomColor);
            g.FillRectangle(bottomSolidBrush, new RectangleF(0, _flashOperate.Y + _flashOperate.Height / 2, _flashOperate.Width, this.Height - MARGINTOP));

            g.DrawString("烧录操作", this.Font, Brushes.Black, 0, 0);
            g.DrawString("烧录日志", this.Font, Brushes.Black, _flashLog.X, 0);

            g.DrawString("动态能量标识UID", this.Font, Brushes.White, TextBoxMargin, TextBoxMargin + _flashOperate.Y);
            topSolidBrush.Dispose();
            bottomSolidBrush.Dispose();
        }
    }
}
