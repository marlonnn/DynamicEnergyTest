using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class SysConfig
    {
        public enum SysStatus
        {
            NotReady,
            GetReady,
            ProductionMode,
            Exit
        }

        private SysStatus _sysStatus;
        public SysStatus SystemStatus
        {
            get { return _sysStatus; }
            set
            {
                if (value != _sysStatus)
                {
                    _sysStatus = value;
                    Program.UIFactory.TestPanelCtrl.SystemStatus = value;
                }
            }
        }

        private static SysConfig sysConfig;

        private List<UID> _uIDs;
        public List<UID> UIDs
        {
            get { return _uIDs; }
            set { _uIDs = value; }
        }

        public UID _uID;
        public UID TestUID
        {
            get { return _uID; }
            set { _uID = value; }
        }

        private Dictionary<string, string>_binAddressTables;
        public Dictionary<string, string> BinAddressTable
        {
            get { return _binAddressTables; }
            set { _binAddressTables = value; }
        }

        private List<Bin> _flashBins;
        public List<Bin> FlashBins
        {
            get { return _flashBins; }
            set { _flashBins = value; }
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
            SystemStatus = SysStatus.NotReady;
            UIDs = new List<UID>();
            BinAddressTable = new Dictionary<string, string>();
            FlashBins = new List<Bin>();

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
        public EventHandler UpdateTestInfoHandler;

        public void ResultToJsonFile(ProcessTest processTest)
        {
            string fileName = GetJsonFileName(processTest.UID);
            var jsonStr = fastJSON.JSON.ToNiceJSON(processTest);
            File.WriteAllText(fileName, jsonStr);
        }

        public string GetJsonFileName(UID uID)
        {
            return string.Format("TestResult\\{0}.json", uID.UIDCode);
        }
    }
}
