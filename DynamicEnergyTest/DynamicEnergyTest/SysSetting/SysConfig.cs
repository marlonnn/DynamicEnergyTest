using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class SysConfig
    {
        private static SysConfig sysConfig;

        private List<UID> _uIDs;
        public List<UID> UIDs
        {
            get { return _uIDs; }
            set { _uIDs = value; }
        }

        private List<ProcessTest> _processTests;
        public List<ProcessTest> ProcessTests
        {
            get { return _processTests; }
            set { _processTests = value; }
        }

        private ParameterSetting _parameterSetting;
        public ParameterSetting ParameterSetting
        {
            get { return _parameterSetting; }
            set { _parameterSetting = value; }
        }

        public SysConfig()
        {
            UIDs = new List<UID>();
            ProcessTests = new List<ProcessTest>();
            ParameterSetting = new ParameterSetting();
        }

        public static SysConfig GetConfig()
        {
            if (sysConfig == null)
            {
                sysConfig = new SysConfig();
            }
            return sysConfig;
        }

        public EventHandler UpdateDataGridViewHandler;
        public EventHandler CreateProcessTestsHandler;
    }
}
