using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicEnergyTest.TestModel
{
    public class ProcessItem
    {
        private int _index;
        [XmlElement("Index")]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private string _testTitle;
        [XmlElement("TestTitle")]
        public string TestTitle
        {
            get { return _testTitle; }
            set { _testTitle = value; }
        }

        private string _testContent;
        [XmlElement("TestContent")]
        public string TestContent
        {
            get { return _testContent; }
            set { _testContent = value; }
        }

        private int _funCode;
        [XmlElement("FunCode")]
        public int FunCode
        {
            get { return _funCode; }
            set { _funCode = value; }
        }
    }
}
