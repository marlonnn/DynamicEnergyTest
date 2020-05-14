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
using DynamicEnergyTest.SysSetting;

namespace DynamicEnergyTest.UI
{
    public partial class SerialPortSetingCtrl : UserControl
    {
        private ProtocolFactory ProtocolsFactory;

        private const int MARGIN = 10;

        private SysConfig sysConfig;

        public SerialPortSetingCtrl()
        {
            InitializeComponent();
            sysConfig = SysConfig.GetConfig();
            ProtocolsFactory = Program.ProtocolsFactory;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeSerialPortSetting();
        }

        private void InitializeSerialPortSetting()
        {
            //LoadSerialPortSetting();

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(ports);
            comboPort.Items.AddRange(ports);

            if (sysConfig.JsonConfig.SerialPortSetting != null)
            {
                var port = "COM" + sysConfig.JsonConfig.SerialPortSetting.Port;
                if (ports.Contains(port))
                {
                    comboPort.SelectedItem = port;
                }
                else
                {
                    comboPort.SelectedIndex = comboPort.Items.Count > 0 ? 0 : -1;
                }

                var baud = sysConfig.JsonConfig.SerialPortSetting.Baudrate.ToString();
                if (comboBaudrate.Items.Contains(baud))
                {
                    comboBaudrate.SelectedItem = baud;
                }
                else
                {
                    comboBaudrate.SelectedIndex = 0;
                }

                var parity = sysConfig.JsonConfig.SerialPortSetting.Parity;
                if (comboParity.Items.Contains(parity))
                {
                    comboParity.SelectedItem = parity;
                }
                else
                {
                    comboParity.SelectedIndex = 0;
                }

                var dataBits = sysConfig.JsonConfig.SerialPortSetting.DataBits.ToString();
                if (comboData.Items.Contains(dataBits))
                {
                    comboData.SelectedItem = dataBits;
                }
                else
                {
                    comboData.SelectedIndex = 0;
                }

                var stopBits = sysConfig.JsonConfig.SerialPortSetting.StopBits;
                if (comboStopBits.Items.Contains(stopBits))
                {
                    comboStopBits.SelectedItem = stopBits;
                }
                else
                {
                    comboStopBits.SelectedIndex = 0;
                }
            }
            else
            {
                comboPort.SelectedIndex = comboPort.Items.Count > 0 ? 0 : -1;
                comboBaudrate.SelectedIndex = 0;
                comboParity.SelectedIndex = 0;
                comboData.SelectedIndex = 0;
                comboStopBits.SelectedIndex = 0;
            }

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
                //if (String.Compare(this.btnConnect.Tag.ToString(), "OffLine", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    SerialPortSetting sps = new SerialPortSetting();
                    sps.Baudrate = int.Parse(comboBaudrate.Text);
                    sps.Port = int.Parse(Regex.Match(comboPort.Text, @"\d+").Value);
                    sps.Parity = System.IO.Ports.Parity.None;
                    sps.StopBits = System.IO.Ports.StopBits.One;
                    sps.DataBits = int.Parse(comboData.Text);
                    sysConfig.JsonConfig.SerialPortSetting = sps;
                    sysConfig.WriteJsonConfig();
                    //if (ProtocolsFactory.Communicator.Com.Open(sps))
                    //{
                    //    btnConnect.Text = "Disconnect";
                    //    btnConnect.Tag = "OnLine";
                    //}
                    //else
                    //{
                    //    MessageBox.Show("串口连接失败，请检查串口是否被占用。", SysConfig.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                //else
                //{
                //    System.Windows.Forms.Application.DoEvents();
                //    ProtocolsFactory.Communicator.Com.Close();
                //    btnConnect.Tag = "OffLine";
                //    btnConnect.Text = "Connect";
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
