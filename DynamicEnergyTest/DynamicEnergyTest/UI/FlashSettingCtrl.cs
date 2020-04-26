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
    public partial class FlashSettingCtrl : UserControl
    {
        private const int MARGIN = 10;
        private string _port;
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private string _baudrate;
        public string Baudrate
        {
            get { return _baudrate; }
            set { _baudrate = value; }
        }

        public FlashSettingCtrl()
        {
            InitializeComponent();
            InitializeSerialPortSetting();
        }

        private void InitializeSerialPortSetting()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(ports);
            comboPort.Items.AddRange(ports);
            comboPort.SelectedIndex = comboPort.Items.Count > 0 ? 0 : -1;
            comboBaudrate.SelectedIndex = 1;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawString("参数设置", this.Font, Brushes.Black, MARGIN, MARGIN);

            g.FillRectangle(Brushes.White, MARGIN, 3 * MARGIN, this.Width - 2 * MARGIN, this.Height - 4 * MARGIN);
        }

        private void ComboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Port = this.comboPort.SelectedItem.ToString();
        }

        private void ComboBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Baudrate = this.comboBaudrate.SelectedItem.ToString();
        }
    }
}
