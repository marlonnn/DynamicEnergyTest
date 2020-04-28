using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class FlushSetting
    {
        public string Com { get; set; }
        public string Baund { get; set; }

        private string _dataFileName;
        public string DataFileName
        {
            get { return _dataFileName; }
            set { _dataFileName = value; }
        }
        public FlushSetting() { }
    }
}
