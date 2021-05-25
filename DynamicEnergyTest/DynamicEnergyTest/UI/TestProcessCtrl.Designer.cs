namespace DynamicEnergyTest.UI
{
    partial class TestProcessCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                this.checkTimer.Stop();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry21 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem21 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry22 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem22 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry23 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem23 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry24 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem24 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry25 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem25 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry26 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem26 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry27 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem27 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry28 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem28 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry29 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem29 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.SysSetting.ProcessEntry processEntry30 = new DynamicEnergyTest.SysSetting.ProcessEntry();
            DynamicEnergyTest.TestModel.ProcessItem processItem30 = new DynamicEnergyTest.TestModel.ProcessItem();
            this.testProcessLine1 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemBar = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessItemVersion = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessLine2 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemLight = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessLine3 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemMeasure = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessLine4 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemICCID = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessLine5 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemNB = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessLine6 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemWIFI = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessLine7 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemBlueTooth = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessLine8 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemBattery = new DynamicEnergyTest.UI.TestProcessItem();
            this.testProcessLine9 = new DynamicEnergyTest.UI.TestProcessLine();
            this.testProcessItemSleep = new DynamicEnergyTest.UI.TestProcessItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkTimer = new System.Windows.Forms.Timer(this.components);
            this.lblStartTest = new System.Windows.Forms.LinkLabel();
            this.lblStopTest = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // testProcessLine1
            // 
            this.testProcessLine1.BackColor = System.Drawing.Color.White;
            this.testProcessLine1.Location = new System.Drawing.Point(68, 48);
            this.testProcessLine1.Name = "testProcessLine1";
            this.testProcessLine1.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine1.TabIndex = 1;
            // 
            // testProcessItemBar
            // 
            this.testProcessItemBar.BackColor = System.Drawing.Color.White;
            this.testProcessItemBar.InfoText = "条码测试";
            this.testProcessItemBar.ItemText = "1";
            this.testProcessItemBar.Location = new System.Drawing.Point(0, 0);
            this.testProcessItemBar.Name = "testProcessItemBar";
            processEntry21.InfoText = "条码测试";
            processEntry21.ItemIndex = 1;
            processEntry21.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemBar.ProcessEntry = processEntry21;
            processItem21.FunCode = 0;
            processItem21.Index = 0;
            processItem21.TestContent = null;
            processItem21.TestTitle = null;
            this.testProcessItemBar.ProcessItem = processItem21;
            this.testProcessItemBar.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemBar.TabIndex = 0;
            // 
            // testProcessItemVersion
            // 
            this.testProcessItemVersion.BackColor = System.Drawing.Color.White;
            this.testProcessItemVersion.InfoText = "版本测试";
            this.testProcessItemVersion.ItemText = "2";
            this.testProcessItemVersion.Location = new System.Drawing.Point(109, 0);
            this.testProcessItemVersion.Name = "testProcessItemVersion";
            processEntry22.InfoText = "版本测试";
            processEntry22.ItemIndex = 2;
            processEntry22.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemVersion.ProcessEntry = processEntry22;
            processItem22.FunCode = 0;
            processItem22.Index = 0;
            processItem22.TestContent = null;
            processItem22.TestTitle = null;
            this.testProcessItemVersion.ProcessItem = processItem22;
            this.testProcessItemVersion.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemVersion.TabIndex = 2;
            // 
            // testProcessLine2
            // 
            this.testProcessLine2.BackColor = System.Drawing.Color.White;
            this.testProcessLine2.Location = new System.Drawing.Point(177, 48);
            this.testProcessLine2.Name = "testProcessLine2";
            this.testProcessLine2.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine2.TabIndex = 3;
            // 
            // testProcessItemLight
            // 
            this.testProcessItemLight.BackColor = System.Drawing.Color.White;
            this.testProcessItemLight.InfoText = "指示灯测试";
            this.testProcessItemLight.ItemText = "3";
            this.testProcessItemLight.Location = new System.Drawing.Point(218, 0);
            this.testProcessItemLight.Name = "testProcessItemLight";
            processEntry23.InfoText = "指示灯测试";
            processEntry23.ItemIndex = 3;
            processEntry23.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemLight.ProcessEntry = processEntry23;
            processItem23.FunCode = 0;
            processItem23.Index = 0;
            processItem23.TestContent = null;
            processItem23.TestTitle = null;
            this.testProcessItemLight.ProcessItem = processItem23;
            this.testProcessItemLight.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemLight.TabIndex = 4;
            // 
            // testProcessLine3
            // 
            this.testProcessLine3.BackColor = System.Drawing.Color.White;
            this.testProcessLine3.Location = new System.Drawing.Point(286, 48);
            this.testProcessLine3.Name = "testProcessLine3";
            this.testProcessLine3.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine3.TabIndex = 5;
            // 
            // testProcessItemMeasure
            // 
            this.testProcessItemMeasure.BackColor = System.Drawing.Color.White;
            this.testProcessItemMeasure.InfoText = "计量测试";
            this.testProcessItemMeasure.ItemText = "4";
            this.testProcessItemMeasure.Location = new System.Drawing.Point(327, 0);
            this.testProcessItemMeasure.Name = "testProcessItemMeasure";
            processEntry24.InfoText = "计量测试";
            processEntry24.ItemIndex = 4;
            processEntry24.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemMeasure.ProcessEntry = processEntry24;
            processItem24.FunCode = 0;
            processItem24.Index = 0;
            processItem24.TestContent = null;
            processItem24.TestTitle = null;
            this.testProcessItemMeasure.ProcessItem = processItem24;
            this.testProcessItemMeasure.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemMeasure.TabIndex = 6;
            // 
            // testProcessLine4
            // 
            this.testProcessLine4.BackColor = System.Drawing.Color.White;
            this.testProcessLine4.Location = new System.Drawing.Point(395, 48);
            this.testProcessLine4.Name = "testProcessLine4";
            this.testProcessLine4.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine4.TabIndex = 7;
            // 
            // testProcessItemICCID
            // 
            this.testProcessItemICCID.BackColor = System.Drawing.Color.White;
            this.testProcessItemICCID.InfoText = "ICCID获取";
            this.testProcessItemICCID.ItemText = "5";
            this.testProcessItemICCID.Location = new System.Drawing.Point(436, 0);
            this.testProcessItemICCID.Name = "testProcessItemICCID";
            processEntry25.InfoText = "ICCID获取";
            processEntry25.ItemIndex = 5;
            processEntry25.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemICCID.ProcessEntry = processEntry25;
            processItem25.FunCode = 0;
            processItem25.Index = 0;
            processItem25.TestContent = null;
            processItem25.TestTitle = null;
            this.testProcessItemICCID.ProcessItem = processItem25;
            this.testProcessItemICCID.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemICCID.TabIndex = 8;
            // 
            // testProcessLine5
            // 
            this.testProcessLine5.BackColor = System.Drawing.Color.White;
            this.testProcessLine5.Location = new System.Drawing.Point(504, 48);
            this.testProcessLine5.Name = "testProcessLine5";
            this.testProcessLine5.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine5.TabIndex = 9;
            // 
            // testProcessItemNB
            // 
            this.testProcessItemNB.BackColor = System.Drawing.Color.White;
            this.testProcessItemNB.InfoText = "NB通讯测试";
            this.testProcessItemNB.ItemText = "6";
            this.testProcessItemNB.Location = new System.Drawing.Point(545, 0);
            this.testProcessItemNB.Name = "testProcessItemNB";
            processEntry26.InfoText = "NB通讯测试";
            processEntry26.ItemIndex = 6;
            processEntry26.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemNB.ProcessEntry = processEntry26;
            processItem26.FunCode = 0;
            processItem26.Index = 0;
            processItem26.TestContent = null;
            processItem26.TestTitle = null;
            this.testProcessItemNB.ProcessItem = processItem26;
            this.testProcessItemNB.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemNB.TabIndex = 10;
            // 
            // testProcessLine6
            // 
            this.testProcessLine6.BackColor = System.Drawing.Color.White;
            this.testProcessLine6.Location = new System.Drawing.Point(613, 48);
            this.testProcessLine6.Name = "testProcessLine6";
            this.testProcessLine6.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine6.TabIndex = 11;
            // 
            // testProcessItemWIFI
            // 
            this.testProcessItemWIFI.BackColor = System.Drawing.Color.White;
            this.testProcessItemWIFI.InfoText = "WIFI测试";
            this.testProcessItemWIFI.ItemText = "7";
            this.testProcessItemWIFI.Location = new System.Drawing.Point(654, 0);
            this.testProcessItemWIFI.Name = "testProcessItemWIFI";
            processEntry27.InfoText = "WIFI测试";
            processEntry27.ItemIndex = 7;
            processEntry27.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemWIFI.ProcessEntry = processEntry27;
            processItem27.FunCode = 0;
            processItem27.Index = 0;
            processItem27.TestContent = null;
            processItem27.TestTitle = null;
            this.testProcessItemWIFI.ProcessItem = processItem27;
            this.testProcessItemWIFI.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemWIFI.TabIndex = 12;
            // 
            // testProcessLine7
            // 
            this.testProcessLine7.BackColor = System.Drawing.Color.White;
            this.testProcessLine7.Location = new System.Drawing.Point(722, 48);
            this.testProcessLine7.Name = "testProcessLine7";
            this.testProcessLine7.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine7.TabIndex = 13;
            // 
            // testProcessItemBlueTooth
            // 
            this.testProcessItemBlueTooth.BackColor = System.Drawing.Color.White;
            this.testProcessItemBlueTooth.InfoText = "蓝牙测试";
            this.testProcessItemBlueTooth.ItemText = "8";
            this.testProcessItemBlueTooth.Location = new System.Drawing.Point(763, 0);
            this.testProcessItemBlueTooth.Name = "testProcessItemBlueTooth";
            processEntry28.InfoText = "蓝牙测试";
            processEntry28.ItemIndex = 8;
            processEntry28.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemBlueTooth.ProcessEntry = processEntry28;
            processItem28.FunCode = 0;
            processItem28.Index = 0;
            processItem28.TestContent = null;
            processItem28.TestTitle = null;
            this.testProcessItemBlueTooth.ProcessItem = processItem28;
            this.testProcessItemBlueTooth.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemBlueTooth.TabIndex = 14;
            // 
            // testProcessLine8
            // 
            this.testProcessLine8.BackColor = System.Drawing.Color.White;
            this.testProcessLine8.Location = new System.Drawing.Point(831, 48);
            this.testProcessLine8.Name = "testProcessLine8";
            this.testProcessLine8.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine8.TabIndex = 15;
            // 
            // testProcessItemBattery
            // 
            this.testProcessItemBattery.BackColor = System.Drawing.Color.White;
            this.testProcessItemBattery.InfoText = "电池供电测试";
            this.testProcessItemBattery.ItemText = "9";
            this.testProcessItemBattery.Location = new System.Drawing.Point(872, 0);
            this.testProcessItemBattery.Name = "testProcessItemBattery";
            processEntry29.InfoText = "电池供电测试";
            processEntry29.ItemIndex = 9;
            processEntry29.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemBattery.ProcessEntry = processEntry29;
            processItem29.FunCode = 0;
            processItem29.Index = 0;
            processItem29.TestContent = null;
            processItem29.TestTitle = null;
            this.testProcessItemBattery.ProcessItem = processItem29;
            this.testProcessItemBattery.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemBattery.TabIndex = 16;
            // 
            // testProcessLine9
            // 
            this.testProcessLine9.BackColor = System.Drawing.Color.White;
            this.testProcessLine9.Location = new System.Drawing.Point(940, 48);
            this.testProcessLine9.Name = "testProcessLine9";
            this.testProcessLine9.Size = new System.Drawing.Size(74, 8);
            this.testProcessLine9.TabIndex = 17;
            // 
            // testProcessItemSleep
            // 
            this.testProcessItemSleep.BackColor = System.Drawing.Color.White;
            this.testProcessItemSleep.InfoText = "休眠测试";
            this.testProcessItemSleep.ItemText = "10";
            this.testProcessItemSleep.Location = new System.Drawing.Point(981, 0);
            this.testProcessItemSleep.Name = "testProcessItemSleep";
            processEntry30.InfoText = "休眠测试";
            processEntry30.ItemIndex = 10;
            processEntry30.TestStatus = DynamicEnergyTest.TestStatus.UnTest;
            this.testProcessItemSleep.ProcessEntry = processEntry30;
            processItem30.FunCode = 0;
            processItem30.Index = 0;
            processItem30.TestContent = null;
            processItem30.TestTitle = null;
            this.testProcessItemSleep.ProcessItem = processItem30;
            this.testProcessItemSleep.Size = new System.Drawing.Size(100, 100);
            this.testProcessItemSleep.TabIndex = 18;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(870, 118);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 12);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // checkTimer
            // 
            this.checkTimer.Interval = 1000;
            this.checkTimer.Tick += new System.EventHandler(this.CheckTimer_Tick);
            // 
            // lblStartTest
            // 
            this.lblStartTest.AutoSize = true;
            this.lblStartTest.Location = new System.Drawing.Point(20, 118);
            this.lblStartTest.Name = "lblStartTest";
            this.lblStartTest.Size = new System.Drawing.Size(53, 12);
            this.lblStartTest.TabIndex = 20;
            this.lblStartTest.TabStop = true;
            this.lblStartTest.Text = "开始测试";
            this.lblStartTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblStartTest_LinkClicked);
            // 
            // lblStopTest
            // 
            this.lblStopTest.AutoSize = true;
            this.lblStopTest.Location = new System.Drawing.Point(127, 118);
            this.lblStopTest.Name = "lblStopTest";
            this.lblStopTest.Size = new System.Drawing.Size(53, 12);
            this.lblStopTest.TabIndex = 21;
            this.lblStopTest.TabStop = true;
            this.lblStopTest.Text = "停止测试";
            this.lblStopTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblStopTest_LinkClicked);
            // 
            // TestProcessCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStopTest);
            this.Controls.Add(this.lblStartTest);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.testProcessLine9);
            this.Controls.Add(this.testProcessLine8);
            this.Controls.Add(this.testProcessLine7);
            this.Controls.Add(this.testProcessLine6);
            this.Controls.Add(this.testProcessLine5);
            this.Controls.Add(this.testProcessLine4);
            this.Controls.Add(this.testProcessLine3);
            this.Controls.Add(this.testProcessLine2);
            this.Controls.Add(this.testProcessLine1);
            this.Controls.Add(this.testProcessItemBar);
            this.Controls.Add(this.testProcessItemVersion);
            this.Controls.Add(this.testProcessItemLight);
            this.Controls.Add(this.testProcessItemMeasure);
            this.Controls.Add(this.testProcessItemICCID);
            this.Controls.Add(this.testProcessItemNB);
            this.Controls.Add(this.testProcessItemWIFI);
            this.Controls.Add(this.testProcessItemBlueTooth);
            this.Controls.Add(this.testProcessItemBattery);
            this.Controls.Add(this.testProcessItemSleep);
            this.Name = "TestProcessCtrl";
            this.Size = new System.Drawing.Size(1086, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TestProcessItem testProcessItemBar;
        private TestProcessLine testProcessLine1;
        private TestProcessItem testProcessItemVersion;
        private TestProcessLine testProcessLine2;
        private TestProcessItem testProcessItemLight;
        private TestProcessLine testProcessLine3;
        private TestProcessItem testProcessItemMeasure;
        private TestProcessLine testProcessLine4;
        private TestProcessItem testProcessItemICCID;
        private TestProcessLine testProcessLine5;
        private TestProcessItem testProcessItemNB;
        private TestProcessLine testProcessLine6;
        private TestProcessItem testProcessItemWIFI;
        private TestProcessLine testProcessLine7;
        private TestProcessItem testProcessItemBlueTooth;
        private TestProcessLine testProcessLine8;
        private TestProcessItem testProcessItemBattery;
        private TestProcessLine testProcessLine9;
        private TestProcessItem testProcessItemSleep;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Timer checkTimer;
        private System.Windows.Forms.LinkLabel lblStartTest;
        private System.Windows.Forms.LinkLabel lblStopTest;
    }
}
