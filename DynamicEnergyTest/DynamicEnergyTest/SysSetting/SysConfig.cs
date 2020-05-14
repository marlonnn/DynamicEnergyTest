using DynamicEnergyTest.DBClass;
using KoboldCom;
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

        private JsonConfig _jsonConfig;
        public JsonConfig JsonConfig
        {
            get { return _jsonConfig; }
            set { _jsonConfig = value; }
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
        private const string jsonConfig = "Config\\JsonConfig.json";
        private const string dynamicTestPath = "\\Firmware\\DynamicTest.db";
        private const string flushTable = "FlushTable";
        private const string testTable = "TestTable";
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

            ProcessTests = new List<ProcessTest>();
            ParameterSetting = new ParameterSetting();

            dataBase = System.Environment.CurrentDirectory + dynamicTestPath;

            JsonConfig = LoadJsonConfig();
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


        public void QueryUIDS()
        {
            SQLiteConnection conn = null;
            try
            {
                string sql = "SELECT * FROM TestTable";
                conn = new SQLiteConnection("data source = " + dataBase);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                conn.Open();
                SQLiteHelper sh = new SQLiteHelper(cmd);
                DataTable dt = sh.Select(sql);
                if (dt.Rows.Count > 0)
                {
                    for (int i=0; i< dt.Rows.Count; i++)
                    {
                        var row = dt.Rows[i];
                        UID uID = null;
                        List<ProcessEntry> processEntries = null;
                        for (int j=0; j<dt.Columns.Count; j++)
                        {
                            if (j == 0)
                            {
                                var colum = dt.Rows[i][j];
                                uID = new UID(colum as string);
                                if (uID != null)
                                {
                                    this.UIDs.Add(uID);
                                }
                            }
                            else if (j == 2)
                            {
                                var jsonStr = dt.Rows[i][j] as string;
                                processEntries = fastJSON.JSON.ToObject<List<ProcessEntry>>(jsonStr);
                                if (uID != null && processEntries != null)
                                {
                                    this.ProcessTests.Add(new ProcessTest(uID, processEntries));
                                }
                            }
                        }
                    }
                }

                if (conn != null) conn.Close();
            }
            catch (Exception ex)
            {
                if (conn != null) conn.Close();
            }
        }
        public void UpdateTestTable()
        {
            SQLiteConnection conn = null;
            try
            {
                string sql = "SELECT * FROM TestTable WHERE DEVICE = @UID";
                conn = new SQLiteConnection("data source = " + dataBase);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                conn.Open();

                SQLiteHelper sh = new SQLiteHelper(cmd);

                for (int i=0; i<sysConfig.ProcessTests.Count; i++)
                {
                    var processTest = sysConfig.ProcessTests[i];
                    var dicData = new Dictionary<string, object>();
                    dicData["DEVICE"] = processTest.UID.UIDCode;
                    dicData["STATUS"] = processTest.TestStatus.ToString();

                    if (processTest.ProcessEntrys != null && processTest.ProcessEntrys.Count > 0)
                    {
                        var stringProcessEntrys = fastJSON.JSON.ToNiceJSON(processTest.ProcessEntrys, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });
                        dicData["PROCESSENTRYS"] = stringProcessEntrys;

                    }
                    DataTable dt = sh.Select(sql, new SQLiteParameter[] {
                        new SQLiteParameter("@UID", processTest.UID.UIDCode)});
                    if (dt.Rows.Count == 1)
                    {
                        // do update...
                        var dicCon = new Dictionary<string, object>();
                        dicCon["DEVICE"] = processTest.UID.UIDCode;

                        sh.Update(testTable, dicData, dicCon);
                    }
                    else
                    {
                        var insertDicData = new Dictionary<string, object>();
                        insertDicData["DEVICE"] = processTest.UID.UIDCode;
                        insertDicData["STATUS"] = processTest.TestStatus.ToString();

                        if (processTest.ProcessEntrys != null && processTest.ProcessEntrys.Count > 0)
                        {
                            var stringProcessEntrys = fastJSON.JSON.ToNiceJSON(processTest.ProcessEntrys, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });
                            insertDicData["PROCESSENTRYS"] = stringProcessEntrys;

                        }
                        sh.Insert(testTable, insertDicData);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public void UpdateTestTable(ProcessTest processTest, bool needUpdate = true)
        {
            SQLiteConnection conn = null;

            try
            {
                string sql = "SELECT * FROM TestTable WHERE DEVICE = @UID";
                conn = new SQLiteConnection("data source = " + dataBase);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                conn.Open();

                SQLiteHelper sh = new SQLiteHelper(cmd);
                var dicData = new Dictionary<string, object>();
                dicData["DEVICE"] = processTest.UID.UIDCode;
                dicData["STATUS"] = processTest.TestStatus.ToString();

                if (processTest.ProcessEntrys != null && processTest.ProcessEntrys.Count > 0)
                {
                    var stringProcessEntrys = fastJSON.JSON.ToNiceJSON(processTest.ProcessEntrys, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });
                    dicData["PROCESSENTRYS"] = stringProcessEntrys;

                }
                DataTable dt = sh.Select(sql, new SQLiteParameter[] {
                        new SQLiteParameter("@UID", processTest.UID.UIDCode)});
                if (dt.Rows.Count == 1)
                {
                    // do update...
                    if (needUpdate)
                    {
                        var dicCon = new Dictionary<string, object>();
                        dicCon["DEVICE"] = processTest.UID.UIDCode;

                        sh.Update(testTable, dicData, dicCon);
                    }
                }
                else
                {
                    var insertDicData = new Dictionary<string, object>();
                    insertDicData["DEVICE"] = processTest.UID.UIDCode;
                    insertDicData["STATUS"] = processTest.TestStatus.ToString();

                    if (processTest.ProcessEntrys != null && processTest.ProcessEntrys.Count > 0)
                    {
                        var stringProcessEntrys = fastJSON.JSON.ToNiceJSON(processTest.ProcessEntrys, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });
                        insertDicData["PROCESSENTRYS"] = stringProcessEntrys;

                    }
                    sh.Insert(testTable, insertDicData);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();
            }
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
                    sh.Insert(flushTable, insertDicData);
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

        public void WriteJsonConfig()
        {
            string jsonFile = fastJSON.JSON.ToNiceJSON(JsonConfig, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });
            File.WriteAllText(jsonConfig, jsonFile);
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

        public JsonConfig LoadJsonConfig()
        {
            if (File.Exists(jsonConfig))
            {
                var jsonStr = File.ReadAllText(jsonConfig);
                return fastJSON.JSON.ToObject<JsonConfig>(jsonStr);
            }
            else
            {
                return new JsonConfig();
            }
        }

    }
}
