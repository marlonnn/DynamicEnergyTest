using DynamicEnergyTest.DBClass;
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

            try
            {
                MiniDumper.Init();

                InitializeParameters();
                InitializeBinAddressTable();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                UIFactory = MainUIFactory.Get();
                Application.Run(new MainBaseForm());
                //Application.Run(new Form1());
            }
            catch (Exception ex)
            {

            }
        }

        public static void InitializeBinAddressTable()
        {
            var binAddressTablesJson = File.ReadAllText(System.Environment.CurrentDirectory +  "\\Config\\BinAddressTable.json");
            Type type = typeof(List<BinAddressTable>);
            SysConfig.GetConfig().BinAddressTable = (List<BinAddressTable>)fastJSON.JSON.ToObject(binAddressTablesJson, type);
        }

        public static void InitializeParameters()
        {
            //using (var reader = new StreamReader("Paramaters.xml"))
            //{
            //    XmlSerializer deserializer = new XmlSerializer(typeof(ParameterSetting));
            //    var parameterSetting = (ParameterSetting)deserializer.Deserialize(reader);
            //    SysConfig.GetConfig().ParameterSetting = parameterSetting;
            //}

            var ParamatersJson = File.ReadAllText(System.Environment.CurrentDirectory + "\\Config\\Paramaters.json");
            Type type = typeof(ParameterSetting);
            SysConfig.GetConfig().ParameterSetting = fastJSON.JSON.ToObject<ParameterSetting>(ParamatersJson);
        }

    }
}
