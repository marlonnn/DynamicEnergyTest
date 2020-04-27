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

        public string Com { get; set; }
        public string Baund { get; set; }

        private SysMode _sysMode;
        public SysMode SystemMode
        {
            get { return _sysMode; }
            set { _sysMode = value; }
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

        private List<UID> _flushUIDs;
        public List<UID> FlushUIDs
        {
            get { return _flushUIDs; }
            set { _flushUIDs = value; }
        }

        public UID _uID;
        public UID TestUID
        {
            get { return _uID; }
            set { _uID = value; }
        }

        //private Dictionary<string, string>_binAddressTables;
        //public Dictionary<string, string> BinAddressTable
        //{
        //    get { return _binAddressTables; }
        //    set { _binAddressTables = value; }
        //}
        private List<BinAddressTable> _binAddressTables;
        public List<BinAddressTable> BinAddressTable
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
            SystemMode = SysMode.FullMode;
            SystemStatus = SysStatus.NotReady;
            FlushUIDs = new List<UID>();
            UIDs = new List<UID>();
            BinAddressTable = new List<BinAddressTable>();
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
        public EventHandler UpdateFlushBinsHandler;

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
