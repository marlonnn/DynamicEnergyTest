using DynamicEnergyTest.DBClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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

        private List<FlushBlock> _flushBlocks;
        public List<FlushBlock> FlushBlocks
        {
            get { return _flushBlocks; }
            set { _flushBlocks = value; }
        }

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

        public readonly static string ApplicationName = "动态能量标识产测软件";
        private const string configPath = "Config\\FlushConfig.json";
        private const string flushBinsPath = "Config\\FlushBins.json";
        private const string dynamicTestPath = "\\Firmware\\DynamicTest.db";
        private const string flushTable = "FlushTable";
        private string dataBase;
        public SysConfig()
        {
            FlushSetting = new FlushSetting();
            FlushBlocks = new List<FlushBlock>();

            SystemMode = Properties.Settings.Default.FlushMode ? SysMode.FlushMode: SysMode.FullMode;
            SystemStatus = SysStatus.NotReady;
            FlushUIDs = new List<UID>();
            UIDs = new List<UID>();
            BinAddressTable = new List<BinAddressTable>();
            FlashBins = new List<Bin>();

            ProcessTests = new List<ProcessTest>();
            ParameterSetting = new ParameterSetting();

            dataBase = System.Environment.CurrentDirectory + dynamicTestPath;
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

        public void TestInserUpdateFlushStatus()
        {
            FlushBlock flushBlock = new FlushBlock();

            UID uID = new UID("ZS012001000198");
            flushBlock.FlushUID = uID;
            flushBlock.FlushTime = DateTime.Now;
            flushBlock.FlushStatus = FlashStatus.Flashing;
            flushBlock.ICCID = "";
            flushBlock.IMEI = "";
            UpdateFlushStatus(flushBlock);
        }

        //Insert or update flush block
        public void UpdateFlushStatus(FlushBlock flushBlock)
        {
            SQLiteConnection conn = null;
            try
            {
                string sql = "SELECT * FROM FlushTable WHERE DEVICE = @UID";

                conn = new SQLiteConnection("data source = " + dataBase);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                conn.Open();

                SQLiteHelper sh = new SQLiteHelper(cmd);

                var dicData = new Dictionary<string, object>();
                dicData["IMEI"] = flushBlock.IMEI;
                dicData["ICCID"] = flushBlock.IMEI;
                dicData["DEVICE"] = flushBlock.FlushUID.UIDCode;
                dicData["STATUS"] = flushBlock.FlushStatus.ToString();
                dicData["DATETIME"] = flushBlock.FlushTime.ToString("MM/dd/yyyy HH:mm"); 

                //sh.Insert("FlushTable", dicData);
                DataTable dt = sh.Select(sql, new SQLiteParameter[] {
                        new SQLiteParameter("@UID", flushBlock.FlushUID.UIDCode)});
                if (dt.Rows.Count == 1)
                {
                    // do something...
                    var dicCon = new Dictionary<string, object>();
                    dicCon["DEVICE"] = flushBlock.FlushUID.UIDCode;

                    sh.Update(flushTable, dicData, dicCon);
                }
                else
                {
                    var insertDicData = new Dictionary<string, object>();
                    insertDicData["IMEI"] = flushBlock.IMEI;
                    insertDicData["ICCID"] = flushBlock.ICCID;
                    insertDicData["DEVICE"] = flushBlock.FlushUID.UIDCode;
                    insertDicData["STATUS"] = flushBlock.FlushStatus.ToString();
                    insertDicData["DATETIME"] = flushBlock.FlushTime.ToString("MM/dd/yyyy HH:mm");
                    sh.Insert(flushTable, dicData);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();
            }
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
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
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
