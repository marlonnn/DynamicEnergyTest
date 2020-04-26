using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DynamicEnergyTest.SysSetting;
using DynamicEnergyTest.Protocol;

namespace DynamicEnergyTest.UI
{
    public partial class FlashFilesCtrl : UserControl
    {
        private const int MARGIN = 10;
        private const int MARGINTOP = 20;
        private Rectangle _flashOperate;
        private Rectangle _flashLog;
        private Rectangle _listViewRect;

        private FlashStatus _flashStatus;

        private Button flashButton;
        private ExListView listView;

        private const int TextBoxMargin = 20;
        private TextBox uidTxtBox;
        private Rectangle uidTxtBoxRect;

        private Timer logViewTimer;
        private string esptool;
        private string _arguments;
        public string Arguments
        {
            get { return _arguments; }
            set { _arguments = value; }
        }

        private SysConfig sysConfig;

        public FlashFilesCtrl()
        {
            sysConfig = SysConfig.GetConfig();
            InitializeComponent();
            _flashStatus = FlashStatus.UnFlash;
            InitializeTextBox();
            InitializeLoadButton();
            InitializeExListView();
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

        private void InitializeExListView()
        {
            this.listView = new ExListView();
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            //this.listView.Location = new System.Drawing.Point(552, 138);
            this.listView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView.MaxLogRecords = 300;
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            //this.listView.Size = new System.Drawing.Size(547, 511);
            this.listView.TabIndex = 2;
            this.listView.Timer = null;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;

            logViewTimer = new Timer();
            logViewTimer.Interval = 300;
            logViewTimer.Tick += Timer_Tick;
            logViewTimer.Start();

            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "Messages: ";
            columnHeader.Width = 500;
            this.listView.Columns.Add(columnHeader);
            this.listView.Timer = logViewTimer;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }

        private void FlashButton_Click(object sender, EventArgs e)
        {
            try
            {
                FormatParameter();
                esptool = System.Environment.CurrentDirectory + "\\tool-esptool\\esptool.exe";
                //ProtocolFactory
                Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = esptool,
                        Arguments = Arguments,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    this.listView.AppendLog(new string[] { line });
                    Console.WriteLine(line);
                }
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void FormatParameter()
        {
            StringBuilder sb = new StringBuilder();
            string preFix = "--chip esp32 --port COM4 --baud 921600 --before default_reset --after hard_reset write_flash -z --flash_mode dio --flash_freq 40m " +
                "--flash_size detect";
            sb.Append(preFix);
            for (int i=0; i<sysConfig.FlashBins.Count(); i++)
            {
                string binParams = (" " + sysConfig.FlashBins[i].Address + " " + sysConfig.FlashBins[i].FullName);
                sb.Append(binParams);
            }
            Arguments = sb.ToString();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _flashOperate = new Rectangle(0, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            _flashLog = new Rectangle(this.Width / 2, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            _listViewRect = new Rectangle(this.Width / 2, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);

            this.flashButton.Location = new Point((_flashOperate.Width - flashButton.Width) / 2, (_flashOperate.Height - flashButton.Height) / 2 - _flashOperate.Y);
            this.Controls.Add(flashButton);

            this.listView.Bounds = _listViewRect;
            this.Controls.Add(listView);

            uidTxtBoxRect = new Rectangle(TextBoxMargin, 60, _flashOperate.Width - 2 * TextBoxMargin, 21);
            uidTxtBox.Bounds = uidTxtBoxRect;
            this.Controls.Add(uidTxtBox);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _flashOperate = new Rectangle(0, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            _flashLog = new Rectangle(this.Width / 2, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            _listViewRect = new Rectangle(this.Width / 2, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);

            if (flashButton != null)
                this.flashButton.Location = new Point((_flashOperate.Width - flashButton.Width) / 2, (_flashOperate.Height - flashButton.Height) / 2 - _flashOperate.Y);
            if (uidTxtBox != null)
            {
                uidTxtBoxRect = new Rectangle(TextBoxMargin, 60, _flashOperate.Width - 2 * TextBoxMargin, 21);
                uidTxtBox.Bounds = uidTxtBoxRect;
            }

            if (this.listView != null)
                this.listView.Bounds = _listViewRect;
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

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (logViewTimer != null) logViewTimer.Stop();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
