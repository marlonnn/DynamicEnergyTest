using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicEnergyTest.SysSetting;
using System.IO;
using ExcelDataReader;

namespace DynamicEnergyTest.UI
{
    public partial class FlashSettingCtrl : UserControl
    {
        private const int MARGIN = 10;

        private List<string> _ports;
        public List<string> Ports
        {
            get { return _ports; }
            set
            {
                if (value != _ports)
                {
                    _ports = value;
                    comboPort.Items.Clear();
                    comboPort.Items.AddRange(_ports.ToArray());
                    if (!string.IsNullOrEmpty(Port) && comboPort.Items.Contains(Port))
                    {
                        comboPort.SelectedItem = Port;
                    }
                    else
                    {
                        if (value.Count() > 0)
                            comboPort.SelectedIndex = 0;
                    }
                }
            }
        }
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

        private string safeFileName;
        private SysConfig sysConfig;
        public FlashSettingCtrl()
        {
            sysConfig = SysConfig.GetConfig();
            LoadFlushSetting();
            InitializeComponent();
            InitializeSerialPortSetting();
            this.comboPort.SelectedIndexChanged += new System.EventHandler(this.ComboPort_SelectedIndexChanged);
            this.comboBaudrate.SelectedIndexChanged += new System.EventHandler(this.ComboBaudrate_SelectedIndexChanged);

        }

        private void LoadFlushSetting()
        {
            var flushSetting = sysConfig.LoadFlushConfig();
            if (flushSetting != null)
            {
                sysConfig.FlushSetting = flushSetting;
            }
        }

        private void InitializeSerialPortSetting()
        {
            Ports = System.IO.Ports.SerialPort.GetPortNames().ToList();
            //Array.Sort(ports);
            if (sysConfig.FlushSetting != null && !string.IsNullOrEmpty(sysConfig.FlushSetting.Com))
                if (Ports.Contains(sysConfig.FlushSetting.Com)) comboPort.SelectedItem = sysConfig.FlushSetting.Com;
            else
                    comboPort.SelectedIndex = comboPort.Items.Count > 0 ? 0 : -1;

            if (sysConfig.FlushSetting != null && !string.IsNullOrEmpty(sysConfig.FlushSetting.Baund))
            {
                if (comboBaudrate.Items.Contains(sysConfig.FlushSetting.Baund)) comboBaudrate.SelectedItem = sysConfig.FlushSetting.Baund;
            }
            else
            {
                comboBaudrate.SelectedIndex = 4;
            }
            
            if (this.comboPort.SelectedItem != null)
                sysConfig.FlushSetting.Com = this.comboPort.SelectedItem.ToString();
            if (this.comboBaudrate.SelectedItem != null)
                sysConfig.FlushSetting.Baund = this.comboBaudrate.SelectedItem.ToString();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
            sysConfig.FlushSetting.Com = this.Port;
        }

        private void ComboBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Baudrate = this.comboBaudrate.SelectedItem.ToString();
            sysConfig.FlushSetting.Baund = this.Baudrate;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            //Import Flush UID 
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory + "\\DataBase";
                openFileDialog.Filter = @".db Sqilte File(*.db) | *.db";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    try
                    {
                        sysConfig.FlushSetting.DataFileName = openFileDialog.FileName;
                        var msg = string.Format("密钥清单文件：{0} 已成功导入。", openFileDialog.SafeFileName);
                        MessageBox.Show(msg, SysConfig.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.StackTrace, SysConfig.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CheckPortTimer_Tick(object sender, EventArgs e)
        {
            var ports = System.IO.Ports.SerialPort.GetPortNames().ToList(); 
            if (ports.Count() != this.Ports.Count)
            {
                this.Ports = ports;
            }
        }
    }
}
