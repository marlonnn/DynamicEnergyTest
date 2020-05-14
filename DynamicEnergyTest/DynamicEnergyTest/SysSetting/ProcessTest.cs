using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    //A complete test
    //包括 UID，一次完整的测试状态
    //测试子项目，对应的测试状态
    public class ProcessTest
    {
        private UID _uID;
        public UID UID
        {
            get { return _uID; }
            set { _uID = value; }
        }

        public TestStatus TestStatus
        {
            get
            {
                TestStatus testStatus = TestStatus.Fail;
                if (ProcessEntrys != null && ProcessEntrys.Count > 0)
                {
                    int passCount = 0;
                    for (int i=0; i<ProcessEntrys.Count; i++)
                    {
                        if (ProcessEntrys[i].TestStatus == TestStatus.Pass) passCount++;
                    }
                    if (passCount == ProcessEntrys.Count) testStatus = TestStatus.Pass;
                }
                return testStatus;
            }
        }

        private List<ProcessEntry> _processEntrys;
        public List<ProcessEntry> ProcessEntrys
        {
            get { return _processEntrys; }
            set { _processEntrys = value; }
        }

        public ProcessTest() { }
        public ProcessTest(UID uid)
        {
            this._uID = uid;
            this._processEntrys = new List<ProcessEntry>();
        }
        public ProcessTest(UID uid, List<ProcessEntry> processEntries)
        {
            this._uID = uid;
            this._processEntrys = processEntries;
        }
    }
}
