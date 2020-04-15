using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicEnergyTest.Protocol;
using KoboldCom;
using System.Text.RegularExpressions;

namespace DynamicEnergyTest.UI
{
    public partial class SerialPortSetingCtrl : UserControl
    {
        private ProtocolFactory ProtocolsFactory;

        private const int MARGIN = 10;
        public SerialPortSetingCtrl()
        {
            InitializeComponent();
            ProtocolsFactory = Program.ProtocolsFactory;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeSerialPortSetting();
        }

        private void InitializeSerialPortSetting()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(ports);
            comboPort.Items.AddRange(ports);
            comboPort.SelectedIndex = comboPort.Items.Count > 0 ? 0 : -1;
            comboBaudrate.SelectedIndex = 0;

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
            g.DrawString("串口设置", this.Font, Brushes.Black, MARGIN, MARGIN);

            g.FillRectangle(Brushes.White, MARGIN, 3 * MARGIN, this.Width - 2 * MARGIN, this.Height - 4 * MARGIN);
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.Compare(this.btnConnect.Tag.ToString(), "OffLine", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    SerialPortSetting sps = new SerialPortSetting();
                    sps.Baudrate = int.Parse(comboBaudrate.Text);
                    sps.Port = int.Parse(Regex.Match(comboPort.Text, @"\d+").Value);
                    if (ProtocolsFactory.Communicator.Com.Open(sps))
                    {
                        btnConnect.Text = "Disconnect";
                        btnConnect.Tag = "OnLine";
                    }
                }
                else
                {
                    System.Windows.Forms.Application.DoEvents();
                    ProtocolsFactory.Communicator.Com.Close();
                    btnConnect.Tag = "OffLine";
                    btnConnect.Text = "Connect";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
