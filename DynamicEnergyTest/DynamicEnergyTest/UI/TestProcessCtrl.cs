using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicEnergyTest.TestModel;
using System.IO;
using System.Xml.Serialization;
using DynamicEnergyTest.Protocol;
using KoboldCom;
using DynamicEnergyTest.SysSetting;
using System.Data.SQLite;

namespace DynamicEnergyTest.UI
{
    public partial class TestProcessCtrl : UserControl
    {
        private List<ProcessItem> processItems;
        private ProtocolFactory protocolFactory;
        private SysConfig sysConfig;
        public TestProcessCtrl()
        {
            InitializeComponent();
            protocolFactory = Program.ProtocolsFactory;
            sysConfig = SysConfig.GetConfig();
        }

        public List<ProcessEntry> GetProcessEntrys()
        {
            List<ProcessEntry> processEntries = new List<ProcessEntry>();
            foreach (var ctrl in this.Controls)
            {
                TestProcessItem testProcessItem = ctrl as TestProcessItem;
                if (testProcessItem != null)
                {
                    processEntries.Add(testProcessItem.ProcessEntry);
                }
            }
            return processEntries;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            processItems = ProcessFactory.Instance().ProcessItems;
            InitializeProcessItemCtrl();
            this.checkTimer.Start();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        private void InitializeProcessItemCtrl()
        {
            int index = 0;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                TestProcessItem testProcessItem = this.Controls[i] as TestProcessItem;
                if (testProcessItem != null)
                {
                    testProcessItem.ProcessItem = processItems[index++];
                    testProcessItem.MouseEventClick += MouseEventClick;
                }
            }
        }

        public void AutoProcess()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                TestProcessItem testProcessItem = this.Controls[i] as TestProcessItem;
                if (testProcessItem != null)
                {
                    TestPanelCtrl parentCtrl = this.Parent as TestPanelCtrl;
                    if (parentCtrl != null)
                    {
                        parentCtrl.StatusSwitchCtrl.UpdateProcessItem(testProcessItem.ProcessItem);
                    }

                    int testIndex = Int32.Parse(testProcessItem.ItemText);
                    UpdateListView(testIndex, parentCtrl);

                }
            }
        }

        private void MouseEventClick(object sender, MouseEventArgs e)
        {
            TestProcessItem testProcessItem = sender as TestProcessItem;
            if (testProcessItem != null)
            {
                //if (testProcessItem.ItemText == "1")
                //{
                //    //Test00(testProcessItem);
                //    if (sysConfig.TestUID == null)
                //    {
                //        if (ScanOrInputSN(testProcessItem))
                //        {
                //            ProcessTest(testProcessItem);
                //        }
                //    }
                //    else
                //    {
                //        ProcessTest(testProcessItem);
                //    }
                //}
                //else
                {
                    if (sysConfig.TestUID == null)
                    {
                        if (ScanOrInputSN(testProcessItem))
                        {
                            ProcessTest(testProcessItem);
                        }
                    }
                    else
                    {
                        ProcessTest(testProcessItem);
                    }
                }
            }
        }

        private void ProcessTest(TestProcessItem testProcessItem)
        {
            testProcessItem.TestStatus = TestStatus.Testing;
            UpdateSysProcessStatus(testProcessItem);
            TestPanelCtrl parentCtrl = this.Parent as TestPanelCtrl;
            if (parentCtrl != null)
            {
                parentCtrl.StatusSwitchCtrl.UpdateProcessItem(testProcessItem.ProcessItem);
            }
            int testIndex = Int32.Parse(testProcessItem.ItemText);
            UpdateListView(testIndex, parentCtrl);
        }

        private bool ScanOrInputSN(TestProcessItem testProcessItem)
        {
            bool scanOK = false;
            SNForm sNForm = new SNForm();
            if (sNForm.ShowDialog() == DialogResult.OK)
            {
                scanOK = sysConfig.TestUID != null;
            }
            sNForm.Dispose();
            return scanOK;
        }

        private void Test00(TestProcessItem testProcessItem)
        {
            TestPanelCtrl parentCtrl = this.Parent as TestPanelCtrl;
            if (parentCtrl != null)
            {
                parentCtrl.StatusSwitchCtrl.UpdateProcessItem(testProcessItem.ProcessItem);
            }

            var dm = protocolFactory.DataModels[0];

            int testIndex = Int32.Parse(testProcessItem.ItemText);
            parentCtrl.UpdateListView(dm.TestItem);

            ComCode comCode = protocolFactory.Write(dm);
            UpdateProcessItem(testIndex, comCode);
            parentCtrl.UpdateListView(comCode.GetComCodeDescription());

            parentCtrl.UpdateStatusSwitch(comCode);
        }
        private void UpdateListView(int testIndex, TestPanelCtrl parentCtrl)
        {
            var dataModels = protocolFactory.DataModels;

            foreach (var dm in dataModels.Values)
            {
                if (dm.TestIndex == testIndex)
                {
                    parentCtrl.UpdateStatusSwitch(TestStatus.Testing);

                    string testItem = dm.TestItem;
                    parentCtrl.UpdateListView(testItem);

                    ComCode comCode = protocolFactory.Write(dm);

                    UpdateProcessItem(testIndex, comCode);
                    parentCtrl.UpdateListView(comCode.GetComCodeDescription());
                    
                    parentCtrl.UpdateStatusSwitch(comCode);
                }

            }
        }

        private void UpdateProcessItem(int testIndex, ComCode comCode)
        {
            foreach (var ctrl in this.Controls)
            {
                TestProcessItem testProcessItem = ctrl as TestProcessItem;
                if (testProcessItem != null && testProcessItem.ItemText == testIndex.ToString())
                {
                    switch (comCode)
                    {
                        case ComCode.ComNotExist:
                            testProcessItem.TestStatus = TestStatus.Fail;
                            break;
                        case ComCode.ComNotOpen:
                            testProcessItem.TestStatus = TestStatus.Fail;
                            break;
                        case ComCode.TimeOut:
                            testProcessItem.TestStatus = TestStatus.Fail;
                            break;
                        case ComCode.SendOK:
                            break;
                        case ComCode.ReceivedOK:
                            testProcessItem.TestStatus = TestStatus.Pass;
                            break;
                    }
                    UpdateSysProcessStatus(testProcessItem);
                    UpdateTestProcessLineStatus(testIndex, testProcessItem.TestStatus);
                }

            }
        }

        private void UpdateSysProcessStatus(TestProcessItem testProcessItem)
        {
            var processTest = sysConfig.ProcessTests.FirstOrDefault(p => p.UID == sysConfig.TestUID);
            var item = processTest.ProcessEntrys.FirstOrDefault(p => p.ItemIndex.ToString() == testProcessItem.ItemText);
            item.TestStatus = testProcessItem.TestStatus;
        }

        private TestProcessLine GetProcessLineName(int processItemIndex)
        {
            string lineName = string.Format("testProcessLine{0}", processItemIndex);
            foreach (var ctrl in this.Controls)
            {
                TestProcessLine testProcessLine = ctrl as TestProcessLine;
                if (testProcessLine != null && testProcessLine.Name == lineName)
                {
                    return testProcessLine;
                }
            }
            return null;
        }

        private void UpdateTestProcessLineStatus(int testIndex, TestStatus testStatus)
        {
            TestProcessLine line = GetProcessLineName(testIndex);
            if (line != null)
            {
                line.TestStatus = testStatus;
            }
        }

        private void InitializeProcessItem()
        {
            string fileName = Environment.CurrentDirectory + "ProcessItems.xml";
            using (var reader = new StreamReader(fileName))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<ProcessItem>),
                    new XmlRootAttribute("ProcessCollection"));
                processItems = (List<ProcessItem>)deserializer.Deserialize(reader);
            }
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            int untestCount = 0;
            var uid = sysConfig.TestUID;
            if (uid != null && sysConfig.ProcessTests != null)
            {
                var processTest = sysConfig.ProcessTests.FirstOrDefault(p => p.UID == uid);
                if (processTest != null)
                {
                    for (int i = 0; i < processTest.ProcessEntrys.Count; i++)
                    {
                        if (processTest.ProcessEntrys[i].TestStatus == TestStatus.UnTest)
                        {
                            untestCount++;
                            if (untestCount > 0)
                                break;
                        }
                    }
                    if (untestCount == 0)
                    {
                        if (!this.linkLabel1.Visible)
                        {
                            this.linkLabel1.Text = "全部测试完毕，点击提交测试结果。";
                            this.linkLabel1.Visible = true;
                        }
                    }
                    else
                    {
                        if (this.linkLabel1.Visible)
                        {
                            this.linkLabel1.Visible = false;
                        }
                    }
                }
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("全部测试项目已测试完毕，是否结束并提交本轮测试结果? \r\n确认请点击 OK 按钮，并开始新一轮的测试。", SysConfig.ApplicationName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                FlushProcessTestToDB();
                ReSetAllProcessItems();
            }
        }

        public void ReSetAllProcessItems()
        {
            this.linkLabel1.Visible = false;
            foreach (var ctrl in this.Controls)
            {
                var processItem = ctrl as TestProcessItem;
                if (processItem != null)
                {
                    processItem.TestStatus = TestStatus.UnTest;
                }
                var line = ctrl as TestProcessLine;
                if (line != null)
                {
                    line.TestStatus = TestStatus.UnTest;
                }
            }
            TestPanelCtrl parentCtrl = this.Parent as TestPanelCtrl;
            if (parentCtrl != null)
            {
                parentCtrl.StatusSwitchCtrl.ResetProcessItem();
                parentCtrl.ResetListView();
            }
            sysConfig.TestUID = null;
        }

        private void FlushProcessTestToDB()
        {
            var processTest = sysConfig.ProcessTests.FirstOrDefault(p => p.UID == sysConfig.TestUID);
            if (processTest != null) sysConfig.UpdateTestTable(processTest, true);
        }
    }
}
