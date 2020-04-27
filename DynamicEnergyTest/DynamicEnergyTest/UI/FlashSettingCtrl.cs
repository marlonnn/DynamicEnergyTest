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
            InitializeComponent();
            InitializeSerialPortSetting();
        }

        private void InitializeSerialPortSetting()
        {
            Ports = System.IO.Ports.SerialPort.GetPortNames().ToList();
            //Array.Sort(ports);
            comboPort.SelectedIndex = comboPort.Items.Count > 0 ? 0 : -1;
            comboBaudrate.SelectedIndex = 4;

            sysConfig.Com = this.comboPort.SelectedItem.ToString();
            sysConfig.Baund = this.comboBaudrate.SelectedItem.ToString();
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
            sysConfig.Com = this.Port;
        }

        private void ComboBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Baudrate = this.comboBaudrate.SelectedItem.ToString();
            sysConfig.Baund = this.Baudrate;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            //Import Flush UID 
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog.Filter = @".xls Files(*.xls) | *.xls";
                if (openFileDialog.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    try
                    {
                        sysConfig.FlushUIDs.Clear();
                        //SysConfig.UIDs
                        string fileName = openFileDialog.FileName;
                        using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                        {
                            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                            //...
                            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                            //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            //...
                            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
                            DataSet result = excelReader.AsDataSet();
                            //...
                            //4. DataSet - Create column names from first row
                            //excelReader.IsFirstRowAsColumnNames = true;
                            //DataSet result = excelReader.AsDataSet();

                            //5. Data Reader methods
                            while (excelReader.Read())
                            {
                                var sn = excelReader.GetString(0);
                                var str = excelReader.GetString(0);
                                if (!string.IsNullOrEmpty(sn) && sn.ToLower().StartsWith("zs"))
                                {
                                    UID uID = new UID(sn);
                                    if (!sysConfig.FlushUIDs.Contains(uID))
                                        sysConfig.FlushUIDs.Add(uID);
                                }
                            }

                            //6. Free resources (IExcelDataReader is IDisposable)
                            excelReader.Close();
                            safeFileName = openFileDialog.SafeFileName;
                            MessageBox.Show("文件： " + safeFileName + "已成功导入" + sysConfig.FlushUIDs.Count + " 个UID", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //ImportedFile = "文件： " + openFileDialog.SafeFileName + " 已成功导入 " + SysConfig.UIDs.Count + " 个UID";
                            //ProgressBarVisiable(true);
                            //this.backgroundWorker.RunWorkerAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.StackTrace, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
