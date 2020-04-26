using DynamicEnergyTest.Protocol;
using DynamicEnergyTest.SysSetting;
using DynamicEnergyTest.UI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DynamicEnergyTest
{
    static class Program
    {
        private static ProtocolFactory _protocolsFactory;
        public static ProtocolFactory ProtocolsFactory
        {
            get { return _protocolsFactory; }
            set { _protocolsFactory = value; }
        }

        private static MainUIFactory _mainUI;
        public static MainUIFactory UIFactory
        {
            get { return _mainUI; }
            set { _mainUI = value; }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary
        [STAThread]
        static void Main()
        {
            ProtocolsFactory = ProtocolFactory.GetFactory();

            C00 c00 = new C00();
            var v = c00.Encode();
            var v2 = ByteHelper.Byte2ReadalbeXstring(v);
            //var dataModels = ProtocolsFactory.DataModels;
            //foreach (var key in dataModels.Keys)
            //{
            //    var model = dataModels[key];
            //    var bytes = model.Encode();
            //    var readableString = ByteHelper.Byte2ReadalbeXstring(bytes);
            //    Console.WriteLine(readableString);

            //    byte[] funCode = new byte[4];
            //    Array.Copy(bytes, 8, funCode, 0, 4);
            //    var v1 = BitConverter.ToInt32(funCode, 0);
            //    //var v2 = GetLittleEndianIntegerFromByteArray(funCode, 0);
            //    //var v3 = GetBigEndianIntegerFromByteArray(funCode, 0);

            //    HexProtocol hexProtocol = new HexProtocol();
            //    hexProtocol.SearchBuffer(bytes.ToList());
            //    hexProtocol.Analyze();
            //    model.Decode(hexProtocol.Data.DataRegion);
            //}

            //try
            //{
            //    SQLiteConnection.CreateFile("Database.sqlite");
            //    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
            //    m_dbConnection.Open();
            //    m_dbConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //}

            InitializeParameters();
            InitializeBinAddressTable();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UIFactory = MainUIFactory.Get();
            Application.Run(new MainForm());
            //Application.Run(new Form1());
        }

        public static void InitializeBinAddressTable()
        {
            var binAddressTablesJson = File.ReadAllText(System.Environment.CurrentDirectory +  "\\Config\\BinAddressTable.json");
            Type type = typeof(Dictionary<string, string>);
            SysConfig.GetConfig().BinAddressTable = (Dictionary<string, string>)fastJSON.JSON.ToObject(binAddressTablesJson, type);
        }

        public static void InitializeParameters()
        {
            using (var reader = new StreamReader("Paramaters.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(ParameterSetting));
                var parameterSetting = (ParameterSetting)deserializer.Deserialize(reader);
                SysConfig.GetConfig().ParameterSetting = parameterSetting;
            }
        }

    }
}
