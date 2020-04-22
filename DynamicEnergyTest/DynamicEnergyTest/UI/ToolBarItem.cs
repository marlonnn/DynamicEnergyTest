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
    public partial class ToolBarItem : UserControl
    {
        private int _itemIndex;
        public int ItemIndex
        {
            get { return _itemIndex; }
            set { _itemIndex = value; }
        }
        private string _itemText;
        [Description("Item Text"), Category("Appearance"), DefaultValue("Item Text")]
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

        private bool _enableFocus;
        public bool EnableFocus
        {
            get { return _enableFocus; }
            set
            {
                if (value != _enableFocus)
                {
                    _enableFocus = value;
                    this.Invalidate();
                }
            }
        }

        public EventHandler ClickEvent;

        public ToolBarItem()
        {
            InitializeComponent();
            EnableFocus = false;
            this.Click += ToolBarItem_Click;
        }

        private void ToolBarItem_Click(object sender, EventArgs e)
        {
            ClickEvent?.Invoke(sender, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            using (SolidBrush sb = new SolidBrush(GraphicFactory.DynamicBlue))
            {
                if (EnableFocus)
                    g.FillRectangle(sb, new Rectangle(0, this.Height - 4, this.Width, 4));
            }
            if (!string.IsNullOrEmpty(ItemText))
            {
                using (SolidBrush sb = new SolidBrush(EnableFocus ? GraphicFactory.DynamicBlue : Color.Black))
                {
                    using (Font font = new System.Drawing.Font("Courier New", 10F))
                    {
                        var sizeF = g.MeasureString(ItemText, font);
                        var x = (this.Width - sizeF.Width) / 2;
                        var y = (this.Height - sizeF.Height) / 2;
                        g.DrawString(ItemText, font, sb, x, y);

                    }
                }
            }
        }
    }
}
