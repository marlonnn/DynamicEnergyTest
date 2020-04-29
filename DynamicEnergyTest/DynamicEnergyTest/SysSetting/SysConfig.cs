using DynamicEnergyTest.DBClass;
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
        private FlushSetting _flushSetting;
        public FlushSetting FlushSetting
        {
            get { return _flushSetting; }
            set { _flushSetting = value; }
        }

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

        private string _tempNvsBinFile;
        public string TempNvsBinFile
        {
            get { return _tempNvsBinFile; }
            set { _tempNvsBinFile = value; }
        }

        private const string configPath = "Config\\FlushConfig.json";
        private const string flushBinsPath = "Config\\FlushBins.json";

        public SysConfig()
        {
            FlushSetting = new FlushSetting();
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

        public bool WriteNvsBin(string socketName)
        {
            TempNvsBinFile = "";
            if (string.IsNullOrEmpty(FlushSetting.DataFileName)) return false;
            DBOperate dbOp = null;
            try
            {
                dbOp = DBOperate.CreateDBOperator(FlushSetting.DataFileName);

                //byte[] datas = null;
                if (dbOp.Connect(false))
                {
                    string sql = string.Format("select nvs_bin from msockets where socket_name = '{0}'", socketName);
                    var obj = dbOp.TryExecuteScalar(sql, null);
                    if (obj != null && !(obj is DBNull))
                    {
                        byte[] datas = (byte[])obj;
                        TempNvsBinFile = System.Environment.CurrentDirectory + "\\Firmware\\" + socketName + ".bin";
                        File.WriteAllBytes(TempNvsBinFile, datas);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (dbOp != null)
                    dbOp.Close(true);
            }
            return true;
        }

        public void DeleteNvsBin()
        {
            if (!string.IsNullOrEmpty(TempNvsBinFile))
                File.Delete(TempNvsBinFile);
        }

        public void WriteFlushConfig()
        {
            string jsonFile = fastJSON.JSON.ToNiceJSON(this.FlushSetting, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });

            File.WriteAllText(configPath, jsonFile);
        }

        public void WriteFlushBins()
        {
            string jsonFile = fastJSON.JSON.ToNiceJSON(this.FlashBins, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });

            File.WriteAllText(flushBinsPath, jsonFile);
        }

        public FlushSetting LoadFlushConfig()
        {
            if (File.Exists(configPath))
            {
                var jsonStr = File.ReadAllText(configPath);
                return fastJSON.JSON.ToObject<FlushSetting>(jsonStr);
            }
            else
            {
                return null;
            }
        }

        public List<Bin> LoadFlushBins()
        {
            if (File.Exists(flushBinsPath))
            {
                var jsonStr = File.ReadAllText(flushBinsPath);
                return fastJSON.JSON.ToObject<List<Bin>>(jsonStr);
            }
            else
            {
                return null;
            }
        }

    }
}
