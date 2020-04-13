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

namespace DynamicEnergyTest.UI
{
    public partial class TestProcessCtrl : UserControl
    {
        private List<ProcessItem> processItems;
        public TestProcessCtrl()
        {
            InitializeComponent();
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
                TestPanelCtrl parentCtrl = this.Parent as TestPanelCtrl;
                if (parentCtrl != null)
                {
                    parentCtrl.StatusSwitchCtrl.UpdateProcessItem(testProcessItem.ProcessItem);
                }
                //var v = testProcessItem.ProcessItem;
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
