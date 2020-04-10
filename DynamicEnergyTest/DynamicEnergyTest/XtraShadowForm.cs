using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicEnergyTest
{
    public partial class XtraShadowForm : DevExpress.XtraEditors.XtraForm
    {
        private Color _BorderColor = ColorTranslator.FromHtml("#A1A7AF");

        private Color _HotColor = ColorTranslator.FromHtml("#0085D5");

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public XtraShadowForm()
        {
            InitializeComponent();
            this.MouseDown += XtraShadowForm_MouseDown;
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        private void XtraShadowForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
