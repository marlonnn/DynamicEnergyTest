using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class ProcessEntry
    {
        private int _itemIndex;
        public int ItemIndex
        {
            get { return _itemIndex; }
            set
            {
                if (value != _itemIndex)
                {
                    _itemIndex = value;
                }
            }
        }

        private TestStatus _testStatus;
        public TestStatus TestStatus
        {
            get { return _testStatus; }
            set
            {
                if (value != _testStatus)
                {
                    _testStatus = value;
                }
            }
        }

        private string _infoText;
        public string InfoText
        {
            get { return _infoText; }
            set
            {
                if (value != _infoText)
                {
                    this._infoText = value;
                }
            }
        }

        public ProcessEntry() { }
        public ProcessEntry(int itemIndex, string infoText, TestStatus testStatus)
        {
            this.ItemIndex = itemIndex;
            this.InfoText = infoText;
            this.TestStatus = testStatus;
        }
    }
}
