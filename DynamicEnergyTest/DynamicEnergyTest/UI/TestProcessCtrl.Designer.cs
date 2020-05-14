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
            DynamicEnergyTest.TestModel.ProcessItem processItem1 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem2 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem3 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem4 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem5 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem6 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem7 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem8 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem9 = new DynamicEnergyTest.TestModel.ProcessItem();
            DynamicEnergyTest.TestModel.ProcessItem processItem10 = new DynamicEnergyTest.TestModel.ProcessItem();
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
            processItem1.FunCode = 0;
            processItem1.Index = 0;
            processItem1.TestContent = null;
            processItem1.TestTitle = null;
            this.testProcessItemBar.ProcessItem = processItem1;
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
            processItem2.FunCode = 0;
            processItem2.Index = 0;
            processItem2.TestContent = null;
            processItem2.TestTitle = null;
            this.testProcessItemVersion.ProcessItem = processItem2;
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
            processItem3.FunCode = 0;
            processItem3.Index = 0;
            processItem3.TestContent = null;
            processItem3.TestTitle = null;
            this.testProcessItemLight.ProcessItem = processItem3;
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
            processItem4.FunCode = 0;
            processItem4.Index = 0;
            processItem4.TestContent = null;
            processItem4.TestTitle = null;
            this.testProcessItemMeasure.ProcessItem = processItem4;
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
            processItem5.FunCode = 0;
            processItem5.Index = 0;
            processItem5.TestContent = null;
            processItem5.TestTitle = null;
            this.testProcessItemICCID.ProcessItem = processItem5;
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
            processItem6.FunCode = 0;
            processItem6.Index = 0;
            processItem6.TestContent = null;
            processItem6.TestTitle = null;
            this.testProcessItemNB.ProcessItem = processItem6;
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
            processItem7.FunCode = 0;
            processItem7.Index = 0;
            processItem7.TestContent = null;
            processItem7.TestTitle = null;
            this.testProcessItemWIFI.ProcessItem = processItem7;
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
            processItem8.FunCode = 0;
            processItem8.Index = 0;
            processItem8.TestContent = null;
            processItem8.TestTitle = null;
            this.testProcessItemBlueTooth.ProcessItem = processItem8;
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
            processItem9.FunCode = 0;
            processItem9.Index = 0;
            processItem9.TestContent = null;
            processItem9.TestTitle = null;
            this.testProcessItemBattery.ProcessItem = processItem9;
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
            processItem10.FunCode = 0;
            processItem10.Index = 0;
            processItem10.TestContent = null;
            processItem10.TestTitle = null;
            this.testProcessItemSleep.ProcessItem = processItem10;
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
            // TestProcessCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
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
    }
}
