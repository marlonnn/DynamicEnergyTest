using DynamicEnergyTest.TestModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicEnergyTest
{
    public class ProcessFactory
    {
        public static ProcessFactory factory;

        public static ProcessFactory Instance()
        {
            if (factory == null)
            {
                factory = new ProcessFactory();
            }
            return factory;
        }

        public ProcessFactory()
        {
            GetProcessItems();
        }
        public List<ProcessItem> ProcessItems;

        public void GetProcessItems()
        {
            using (var reader = new StreamReader(System.Environment.CurrentDirectory + "\\Config\\ProcessItems.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<ProcessItem>),
                    new XmlRootAttribute("ProcessCollection"));
                ProcessItems = (List<ProcessItem>)deserializer.Deserialize(reader);
            }
        }
    }
}
