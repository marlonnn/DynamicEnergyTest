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
using System.IO;
using System.IO.Compression;

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
        //private ExListView listView;
        private RichTextBox richTextBox1;

        private const int TextBoxMargin = 20;
        private TextBox uidTxtBox;
        private Rectangle uidTxtBoxRect;
        private string _uid;

        private Timer logViewTimer;
        private string esptool;
        private string _args;
        public string Args
        {
            get { return _args; }
            set { _args = value; }
        }

        protected readonly static string ExePath = Path.Combine(Directory.GetCurrentDirectory(), "tool-esptool");
        public event EventHandler<CustomEventArgs> ConsoleEvent;
        private delegate void SafeCallDelegate(object sender, CustomEventArgs a);

        private readonly static string _exe = "esptool.exe";

        //public string Com { get; set; }
        //public string Baund { get; set; }
        private StringBuilder _outStr = new StringBuilder();
        private bool _useComArgs = true;

        private SysConfig sysConfig;

        public FlashFilesCtrl()
        {
            sysConfig = SysConfig.GetConfig();
            InitializeComponent();
            _flashStatus = FlashStatus.UnFlash;
            InitializeTextBox();
            InitializeLoadButton();
            //InitializeExListView();
            InitializeRichTextBox();
            //Com = "COM4";
            //Baund = "115200";
            this.ConsoleEvent += HandleCustomEvent;
        }

        private void InitializeTextBox()
        {
            uidTxtBox = new TextBox();
            this.uidTxtBox.Location = new System.Drawing.Point(57, 21);
            this.uidTxtBox.Name = "textBox1";
            this.uidTxtBox.Size = new System.Drawing.Size(220, 21);
            this.uidTxtBox.TabIndex = 7;
            this.uidTxtBox.TextChanged += UidTxtBox_TextChanged;
        }

        private void UidTxtBox_TextChanged(object sender, EventArgs e)
        {
            _uid = uidTxtBox.Text;
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
            //this.listView = new ExListView();
            //this.listView.FullRowSelect = true;
            //this.listView.GridLines = true;
            //this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            //this.listView.HideSelection = false;
            ////this.listView.Location = new System.Drawing.Point(552, 138);
            //this.listView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            //this.listView.MaxLogRecords = 300;
            //this.listView.MultiSelect = false;
            //this.listView.Name = "listView";
            //this.listView.ShowGroups = false;
            ////this.listView.Size = new System.Drawing.Size(547, 511);
            //this.listView.TabIndex = 2;
            //this.listView.Timer = null;
            //this.listView.UseCompatibleStateImageBehavior = false;
            //this.listView.View = System.Windows.Forms.View.Details;

            //logViewTimer = new Timer();
            //logViewTimer.Interval = 300;
            //logViewTimer.Tick += Timer_Tick;
            //logViewTimer.Start();

            //ColumnHeader columnHeader = new ColumnHeader();
            //columnHeader.Text = "Messages: ";
            //columnHeader.Width = 500;
            //this.listView.Columns.Add(columnHeader);
            //this.listView.Timer = logViewTimer;
        }

        private void InitializeRichTextBox()
        {
            richTextBox1 = new RichTextBox();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            //this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(822, 191);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.ReadOnly = true;
            //this.richTextBox1.Text = "Output: ";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }

        private void FlashButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sysConfig.FlushSetting.DataFileName))
                {
                    MessageBox.Show("请导入设备有效的密钥清单。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //check uid
                if (string.IsNullOrEmpty(_uid) || _uid.Length != 14 || !_uid.ToLower().StartsWith("zs"))
                {
                    MessageBox.Show("请输入有效的插座ID。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!sysConfig.WriteNvsBin(_uid))
                {
                    MessageBox.Show(string.Format("插座ID: {0} 不存在，请重新输入。", _uid), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FormatParameter();

                string tempExeName = Path.Combine(ExePath, _exe);

                if (!File.Exists(Path.Combine(ExePath, "python37.dll")) || !Directory.Exists(Path.Combine(ExePath, "lib")))
                {
                    if (File.Exists(Path.Combine(ExePath, "python37.dll")))
                        File.Delete(Path.Combine(ExePath, "python37.dll"));
                    if (Directory.Exists(Path.Combine(ExePath, "lib")))
                        Directory.Delete(Path.Combine(ExePath, "lib"), true);
                    ZipFile.ExtractToDirectory(Path.Combine(ExePath, "cxfreeze.zip"), ExePath);
                }

                if (!File.Exists(Path.Combine(ExePath, "python37.dll")))
                {
                    ConsoleEvent?.Invoke(this, new CustomEventArgs { error = "Python DLL is not loaded." });
                }
                else if (!File.Exists(tempExeName))
                {
                    var errMsg = "[" + _exe + "] File '" + _exe + "' not found in directory " + ExePath + "! Unable to start request.";
                    ConsoleEvent.Invoke(this, new CustomEventArgs { error = errMsg });
                }
                else if (sysConfig.FlushSetting.Com.Length < 3)
                {
                    var errMsg = "[" + _exe + "] COM port is invalid (" + sysConfig.FlushSetting.Com + ") - please select the right port and try again.";
                    ConsoleEvent.Invoke(this, new CustomEventArgs { error = errMsg });
                }
                else
                {
                    int procId = 0;
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                    using (Process process = new Process())
                    {
                        _outStr.Clear();
                        _outStr.Append(" >>> " + _exe + " " + GetComParam() + Args + "\r\n");
                        ConsoleEvent.Invoke(this, new CustomEventArgs { input = _exe + " " + GetComParam() + Args });
                        process.StartInfo = new ProcessStartInfo
                        {
                            FileName = tempExeName,
                            UseShellExecute = false,
                            WorkingDirectory = ExePath,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            Arguments = GetComParam() + Args,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true
                        };

                        //p.StartInfo.RedirectStandardError = true;
                        //p.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                        process.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);
                        process.Start();
                        //p.BeginOutputReadLine();
                        process.BeginErrorReadLine();
                        procId = process.Id;

                        int dataReceived = 0;
                        var sTemp = "";

                        var outputReadTask = Task.Run(() =>
                        {
                            int iCh = 0;
                            var s2 = "";
                            var s3 = "";
                            try
                            {
                                do
                                {
                                    iCh = process.StandardOutput.Read();
                                    if (iCh >= 0)
                                    {
                                        if (iCh == 8)
                                        {
                                            s3 = "\r\n";
                                            s2 = " ";
                                        }
                                        else
                                        {
                                            s2 = s3 + char.ConvertFromUtf32(iCh);
                                            if (s3.Length > 0) s3 = "";
                                        }
                                        sTemp += s2;
                                    }
                                } while (iCh >= 0);
                            }
                            catch (Exception ex)
                            {
                                var errMsg = "[" + _exe + "] Exception: " + ex.Message;
                                ConsoleEvent.Invoke(this, new CustomEventArgs { error = errMsg });
                            }
                        });

                        do
                        {
                            try
                            {
                                if (sTemp.Length > 0)
                                {
                                    dataReceived++;
                                    var s = sTemp;
                                    sTemp = "";
                                    _outStr.Append(s);
                                    ConsoleEvent.Invoke(this, new CustomEventArgs { output = s });
                                }
                                else
                                {
                                    process.WaitForExit(200);
                                }
                            }
                            catch (Exception) { }

                            if (dataReceived == 0 && stopwatch.ElapsedMilliseconds > 3000)
                            {
                                ConsoleEvent.Invoke(this, new CustomEventArgs { error = "Request timeout." });
                                break;
                            }
                        } while (!process.HasExited);
                        if (sTemp.Length > 0)
                        {
                            _outStr.Append(sTemp);
                            ConsoleEvent.Invoke(this, new CustomEventArgs { output = sTemp });
                        }
                        sysConfig.DeleteNvsBin();
                    }
                }
                //esptool = System.Environment.CurrentDirectory + "\\tool-esptool\\esptool.exe";
                ////ProtocolFactory
                //Process process = new Process()
                //{
                //    StartInfo = new ProcessStartInfo()
                //    {
                //        FileName = esptool,
                //        Arguments = Arguments,
                //        UseShellExecute = false,
                //        RedirectStandardOutput = true,
                //        CreateNoWindow = true
                //    }
                //};
                //process.Start();
                //while (!process.StandardOutput.EndOfStream)
                //{
                //    var line = process.StandardOutput.ReadLine();
                //    this.listView.AppendLog(new string[] { line });
                //    Console.WriteLine(line);
                //}
                //process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ErrorHandler(object sender, DataReceivedEventArgs e)
        {
            // Prepend line numbers to each line of the output.
            if (e.Data != null)
            {
                ConsoleEvent.Invoke(this, new CustomEventArgs { error = e.Data });
                _outStr.Append("\r\n" + e.Data);
            }
        }

        private void HandleCustomEvent(object sender, CustomEventArgs a)
        {
            if (richTextBox1.InvokeRequired)
            {
                this.BeginInvoke(new SafeCallDelegate(HandleCustomEvent), new object[] { sender, a });
                return;
            }
            if (a.input.Length > 0)
            {
                string txt;
                txt = "\r\n > " + a.input + "\r\n";
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.AppendText(txt);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
                richTextBox1.ScrollToCaret();
            }
            if (a.error.Length > 0)
            {
                string txt;
                txt = "\r\n [E] " + a.error + "\r\n";
                richTextBox1.SelectionColor = Color.LightCoral;
                richTextBox1.AppendText(txt);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
                richTextBox1.ScrollToCaret();
                //HasError = true;
            }
            if (a.output.Length > 0)
            {
                string txt;
                txt = a.output;
                //if (txt.Contains("fatal error")) HasError = true;
                //else txt = a.output + "\r\n";
                richTextBox1.AppendText(txt);
                if (txt.Contains("\r\n")) richTextBox1.ScrollToCaret();
            }

        }
        private String GetComParam()
        {
            if (_useComArgs)
                return "--port " + sysConfig.FlushSetting.Com + " --baud " + sysConfig.FlushSetting.Baund + " ";
            else
                return "";
        }


        public void FormatParameter()
        {
            StringBuilder sb = new StringBuilder();
            string preFix = "--chip esp32 --port " + sysConfig.FlushSetting.Com + " --baud " + sysConfig.FlushSetting.Baund + " --before default_reset --after hard_reset write_flash -z --flash_mode dio --flash_freq 40m " +
                "--flash_size detect";
            sb.Append(preFix);
            var sortedFlushBins = sysConfig.FlashBins.OrderBy(bin => bin.FlushOrder).ToList();
            for (int i=0; i< sortedFlushBins.Count(); i++)
            {
                string binParams = (" " + sortedFlushBins[i].Address + " " + sortedFlushBins[i].FullName);
                sb.Append(binParams);
            }
            sb.Append(" 0x10000 " + sysConfig.TempNvsBinFile);
            Args = sb.ToString();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _flashOperate = new Rectangle(0, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            _flashLog = new Rectangle(this.Width / 2, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);
            _listViewRect = new Rectangle(this.Width / 2, MARGINTOP, this.Width / 2, this.Height - MARGINTOP);

            this.flashButton.Location = new Point((_flashOperate.Width - flashButton.Width) / 2, (_flashOperate.Height - flashButton.Height) / 2 - _flashOperate.Y);
            this.Controls.Add(flashButton);

            this.richTextBox1.Bounds = _listViewRect;
            this.Controls.Add(richTextBox1);

            //this.listView.Bounds = _listViewRect;
            //this.Controls.Add(listView);

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

            if (this.richTextBox1 != null)
                this.richTextBox1.Bounds = _listViewRect;
            //if (this.listView != null)
            //    this.listView.Bounds = _listViewRect;
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
