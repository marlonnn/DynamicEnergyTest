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

        private void TestResultToJsonFile()
        {
            var processTests = sysConfig.ProcessTests;
            foreach (var process in processTests)
            {
                string fileName = string.Format("TestResult\\{0}.json", process.UID.UIDCode);
                var jsonStr = fastJSON.JSON.ToNiceJSON(process);
                File.WriteAllText(fileName, jsonStr);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            processItems = ProcessFactory.Instance().ProcessItems;
            InitializeProcessItemCtrl();
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

        private void MouseEventClick(object sender, MouseEventArgs e)
        {
            TestProcessItem testProcessItem = sender as TestProcessItem;
            if (testProcessItem != null)
            {
                testProcessItem.TestStatus = TestStatus.Testing;
                TestPanelCtrl parentCtrl = this.Parent as TestPanelCtrl;
                if (parentCtrl != null)
                {
                    parentCtrl.StatusSwitchCtrl.UpdateProcessItem(testProcessItem.ProcessItem);
                }
                int testIndex = Int32.Parse(testProcessItem.ItemText);
                UpdateListView(testIndex, parentCtrl);
            }
        }

        private void UpdateListView(int testIndex, TestPanelCtrl parentCtrl)
        {
            var dataModels = protocolFactory.DataModels;

            foreach (var dm in dataModels.Values)
            {
                if (dm.TestIndex == testIndex)
                {
                    string testItem = dm.TestItem;
                    parentCtrl.UpdateListView(testItem);
                    var bytes = dm.Encode();

                    string realablebytes = ByteHelper.Byte2ReadalbeXstring(bytes);
                    parentCtrl.UpdateListView(realablebytes);
                    ComCode comCode = protocolFactory.Write(bytes, 0, bytes.Count());

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
                }

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
    }
}
