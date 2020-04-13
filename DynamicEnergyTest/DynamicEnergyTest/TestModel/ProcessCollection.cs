using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicEnergyTest.TestModel
{
    [XmlRoot("ProcessCollection")]
    public class ProcessCollection
    {
        private List<ProcessItem> _processItems;
        [XmlElement("ProcessItem")]
        public List<ProcessItem> ProcessItems
        {
            get { return _processItems; }
            set { _processItems = value; }
        }
        public ProcessCollection()
        {
            ProcessItems = new List<ProcessItem>();
        }
    }
}
