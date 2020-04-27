using DynamicEnergyTest.SysSetting;
using DynamicEnergyTest.TestModel;
using KoboldCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DynamicEnergyTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Dictionary<string, string> binAddressTablesDic = new Dictionary<string, string>();
                List<BinAddressTable> binAddressTables = new List<BinAddressTable>();
                BinAddressTable binT1 = new BinAddressTable(1, "ota_data_initial.bin", "0xd000");
                binAddressTables.Add(binT1);
                //binAddressTablesDic["0xd000"] = "ota_data_initial.bin";
                binAddressTablesDic["ota_data_initial.bin"] = "0xd000";

                BinAddressTable binT2 = new BinAddressTable(2, "bootloader.bin", "0x1000");
                binAddressTables.Add(binT2);
                //binAddressTablesDic["0x1000"] = "bootloader.bin";
                binAddressTablesDic["bootloader.bin"] = "0x1000";

                BinAddressTable binT3 = new BinAddressTable(3, "msocket.bin", "0xa0000");
                binAddressTables.Add(binT3);
                binAddressTablesDic["msocket.bin"] = "0xa0000";

                BinAddressTable binT4 = new BinAddressTable(4, "partitions_two_ota.bin", "0x8000");
                binAddressTables.Add(binT4);
                binAddressTablesDic["partitions_two_ota.bin"] = "0x8000";

                BinAddressTable binT5 = new BinAddressTable(5, "tt01.bin", "0x10000");
                binAddressTables.Add(binT5);
                binAddressTablesDic["tt01.bin"] = "0x10000";

                string jsonFile = fastJSON.JSON.ToNiceJSON(binAddressTables, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });
                var o = fastJSON.JSON.ToObject<List<BinAddressTable>>(jsonFile);
                //var beautyJson = fastJSON.JSON.Beautify(jsonFile);
                File.WriteAllText(@"Config\\BinAddressTable.json", jsonFile);
            }
            catch (Exception ex)
            {
            }
            //try
            //{
            //    using (var writer = new FileStream(@"Config\\BinAddressTable.xml", FileMode.Create))
            //    {
            //        List<BinAddressTable> binAddressTables = new List<BinAddressTable>();
            //        BinAddressTable binT1 = new BinAddressTable("ota_data_initial.bin", "0xd000");
            //        binAddressTables.Add(binT1);

            //        BinAddressTable binT2 = new BinAddressTable("bootloader.bin", "0x1000");
            //        binAddressTables.Add(binT2);

            //        BinAddressTable binT3 = new BinAddressTable("msocket.bin", "0xa0000");
            //        binAddressTables.Add(binT3);

            //        BinAddressTable binT4 = new BinAddressTable("partitions_two_ota.bin", "0x8000");
            //        binAddressTables.Add(binT4);

            //        BinAddressTable binT5 = new BinAddressTable("tt01.bin", "0x10000");
            //        binAddressTables.Add(binT5);

            //        XmlSerializer ser = new XmlSerializer(typeof(SerialPortSetting));
            //        ser.Serialize(writer, binAddressTables);
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

            using (var writer = new FileStream("SerialPortSetting.xml", FileMode.Create))
            {
                SerialPortSetting serialPortSetting = new SerialPortSetting();

                XmlSerializer ser = new XmlSerializer(typeof(SerialPortSetting));
                ser.Serialize(writer, serialPortSetting);
            }

            SerialPortSetting serialPortSetting1 = new SerialPortSetting();
            string jsonFile1 = fastJSON.JSON.ToNiceJSON(serialPortSetting1, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });
            File.WriteAllText(@"Config\\SerialPortSetting.json", jsonFile1);

            using (var reader = new StreamReader("SerialPortSetting.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(SerialPortSetting));
                var items = (SerialPortSetting)deserializer.Deserialize(reader);
            }

            using (var writer = new FileStream("Paramaters.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(ParameterSetting));
                ParameterSetting parameterSetting = new ParameterSetting();
                parameterSetting.Version = "V1.0";
                parameterSetting.LowVoltage = 5;
                parameterSetting.HighVoltage = 5;
                parameterSetting.LowCurrent = 5;
                parameterSetting.HighCurrent = 5;
                parameterSetting.LowPower = 5;
                parameterSetting.HighPower = 5;
                parameterSetting.LowSleepCurrent = 5;
                parameterSetting.HighSleepCurrent = 5;
                ser.Serialize(writer, parameterSetting);
                string jsonFile2 = fastJSON.JSON.ToNiceJSON(parameterSetting, new fastJSON.JSONParameters() { UseExtensions = false, ShowReadOnlyProperties = true });
                File.WriteAllText(@"Config\\Paramaters.json", jsonFile2);
            }
            //// e.g. my test to create a file
            //using (var writer = new FileStream("ProcessItems.xml", FileMode.Create))
            //{
            //    XmlSerializer ser = new XmlSerializer(typeof(List<ProcessItem>),
            //        new XmlRootAttribute("ProcessCollection"));
            //    List<ProcessItem> list = new List<ProcessItem>();
            //    list.Add(new ProcessItem { Index = 1, TestTitle = "条码测试", TestContent = "扫描单板上条码,与PCBA主板上实际烧录的内容是否一致。", FunCode = 0x01});
            //    list.Add(new ProcessItem { Index = 2, TestTitle = "版本测试", TestContent = "与设置预设版本一致进入下一环节测试；\n 不一致则退出测试模式；", FunCode = 0x02 });
            //    list.Add(new ProcessItem { Index = 3, TestTitle = "指示灯测试", TestContent = "固件接收到指令后分别点亮通讯灯三色、电源灯两色；不间断闪烁", FunCode = 0x0071000E });
            //    list.Add(new ProcessItem { Index = 4, TestTitle = "计量测试", TestContent = "准备标准电压源与负载设备；\n固件接收到检测指令，读取电压值、电流值、功率值情况；\n输出得值在预设范围内则通过，否则失败；）", FunCode = 0x00710013 });
            //    list.Add(new ProcessItem { Index = 5, TestTitle = "ICCID获取", TestContent = "John5", FunCode = 0x00710012 });
            //    list.Add(new ProcessItem { Index = 6, TestTitle = "NB通讯测试", TestContent = "固件收到测试指令后，读取SIM卡卡号、通信质量", FunCode = 0x00710014 });
            //    list.Add(new ProcessItem { Index = 7, TestTitle = "WIFI测试", TestContent = "固件收到指令后进入WIFI搜索模式搜索到MAC地址与信号强度", FunCode = 0x00717072 });
            //    list.Add(new ProcessItem { Index = 8, TestTitle = "蓝牙测试", TestContent = "固件收到质量后进入蓝牙搜索模式搜索到MAC地址", FunCode = 0x00717071 });
            //    list.Add(new ProcessItem { Index = 9, TestTitle = "电池供电测试", TestContent = "固件收到测试指令后，检测220V电压断掉，设备使用5V程控电源供电，设备可以正常工作，电源指示灯闪烁显示", FunCode = 0x09 });
            //    list.Add(new ProcessItem { Index = 10, TestTitle = "休眠测试",   TestContent = "固件收到测试指令后，MCU发送进入低功耗模式，30S后采样10S电流值，10S取平均数确认待机电流", FunCode = 0x00710008 });
            //    ser.Serialize(writer, list);
            //}


            ////string xml = File.ReadAllText(@"Config\ProcessItems.xml");
            ////ProcessItem[] processItems;
            ////var items = xml.ParseXML<ProcessCollection>();
            ////var v = ParseHelpers.FromXml<ProcessItem[]>(xml);

            //List<ProcessItem> items;
            //using (var reader = new StreamReader("ProcessItems.xml"))
            //{
            //    XmlSerializer deserializer = new XmlSerializer(typeof(List<ProcessItem>),
            //        new XmlRootAttribute("ProcessCollection"));
            //    items = (List<ProcessItem>)deserializer.Deserialize(reader);
            //}


        }
    }
}
