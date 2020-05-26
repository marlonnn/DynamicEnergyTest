using KoboldCom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    public class ProtocolFactory
    {
        private Dictionary<int, DataModel> _dataModels;
        public Dictionary<int, DataModel> DataModels
        {
            get { return _dataModels; }
            set { _dataModels = value; }
        }

        private static ProtocolFactory _protocolFactory;

        private readonly Communicator _communicator;
        public Communicator Communicator
        {
            get { return _communicator; }
        }


        private DataModel receiveDataModel;
        public DataModel ReceiveDataModel
        {
            get { return receiveDataModel; }
            set { receiveDataModel = value; }
        }

        public ProtocolFactory()
        {
            InitializeDataModels();
            _communicator = new Communicator(new SerialPort(), new Protocols());
            _communicator.OnRawDataReceived += Communicator_OnRawDataReceived;

            Protocols results = _communicator.Analyzers as Protocols;
            if (results != null)
            {
                results.ProtocolBinary.OnDataAnalyzed += ProtocolBinary_OnDataAnalyzed;
            }
        }

        private void InitializeDataModels()
        {
            DataModels = new Dictionary<int, DataModel>();
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00000000), new C00());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710012), new C12());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710001), new C01());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x0071000E), new C0E());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710013), new C13());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710015), new C15());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710014), new C14());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00717072), new C7072());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00717071), new C7071());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710008), new C08());

        }

        private DataModel CreateByFuncCode(int funcCode)
        {
            DataModel dm = null;
            switch (/*BigEndianIntToLittleEndianInt(*/funcCode/*)*/)
            {
                case 0x00000000:
                    dm =  new C00();
                    break;
                case 0x00710001:
                    dm = new C01();
                    break;
                case 0x00710012:
                    dm = new C12();
                    break;
                case 0x0071000E:
                    dm = new C0E();
                    break;
                case 0x00710013:
                    dm = new C13();
                    break;
                case 0x00710015:
                    dm = new C15();
                    break;
                case 0x00710014:
                    dm = new C14();
                    break;
                case 0x00717072:
                    dm = new C7072();
                    break;
                case 0x00717071:
                    dm = new C7071();
                    break;
                case 0x00710008:
                    dm = new C08();
                    break;
            }
            return dm;
        }

        private int BigEndianIntToLittleEndianInt(int bigEndianInt)
        {
            byte[] tmepData = new byte[4];
            tmepData[0] = (byte)(bigEndianInt >> 24); //(length / 256 / 256);
            tmepData[1] = (byte)(bigEndianInt >> 16);  //(length / 256);
            tmepData[2] = (byte)(bigEndianInt >> 8);
            tmepData[3] = (byte)(bigEndianInt);
            return BitConverter.ToInt32(tmepData, 0);
        }

        private void ProtocolBinary_OnDataAnalyzed(ProtocolAnalyzer<DataModel> m)
        {
            if (m.Valid)
            {
                var funCode = m.Data.FunCode;
                var v = ByteHelper.IntToBytes(funCode);
                var vv1 =ByteHelper.Byte2ReadalbeXstring(v);
                var v2 = ByteHelper.IntToBytes2(funCode);
                var vv2 = ByteHelper.Byte2ReadalbeXstring(v2);
                receiveDataModel = CreateByFuncCode(funCode);
                if (receiveDataModel != null)
                {
                    receiveDataModel.Raw = m.Raw;
                    //decode data region
                    receiveDataModel.Decode(m.Data.DataRegion);

                    C00 c00 = receiveDataModel as C00;
                    if (c00 != null)
                    {
                        //收到数据则，进入产测模式
                    }
                }

            }
            else
            {
                //Data timeout
            }
        }

        private void Communicator_OnRawDataReceived(byte[] bytes)
        {
            var v = ByteHelper.Byte2ReadalbeXstring(bytes);
            Console.WriteLine(v);

            var v2 = System.Text.Encoding.UTF8.GetString(bytes);
            Console.WriteLine(v2);
            RawDataHandler?.Invoke(bytes);
        }

        public RawDataDelegate RawDataHandler;
        public delegate void RawDataDelegate(byte[] bytes);

        public static ProtocolFactory GetFactory()
        {
            if (_protocolFactory == null) _protocolFactory = new ProtocolFactory();
            return _protocolFactory;
        }

        public void Close()
        {
            if (Communicator.Com != null && Communicator.Com.IsOpen)
            {
                Communicator.Com.Close();
            }
        }

        private bool Open()
        {
            bool isOpen = false;
            try
            {
                Close();
                SerialPortSetting sps = new SerialPortSetting();
                var config = SysSetting.SysConfig.GetConfig();
                if (config != null && config.JsonConfig != null && config.JsonConfig.SerialPortSetting != null)
                {
                    sps.Baudrate = config.JsonConfig.SerialPortSetting.Baudrate;
                    sps.Port = config.JsonConfig.SerialPortSetting.Port;
                    sps.Parity = System.IO.Ports.Parity.None;
                    sps.StopBits = System.IO.Ports.StopBits.One;
                    sps.DataBits = config.JsonConfig.SerialPortSetting.DataBits;

                    isOpen = Communicator.Com.Open(sps);
                }
            }
            catch (Exception ex)
            {
                isOpen = false;
            }
            return isOpen;
        }

        public ComCode Write(byte[] sendBytes, int funCode)
        {
            //close and reopen com port
            if (Open())
            {
                ComCode comCode = _communicator.Write(sendBytes, 0, sendBytes.Count());
                if (comCode == ComCode.SendOK)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    while (true)
                    {
                        //Do 
                        if (receiveDataModel != null && receiveDataModel.FunCode == funCode)
                        {
                            var raw = receiveDataModel.Raw;
                            var dataRegion = receiveDataModel.DataRegion;
                            if (receiveDataModel.CheckLegal())
                                return ComCode.ReceivedOK;
                            else
                                return ComCode.ReceivedMessageError;
                        }
                        if (sw.ElapsedMilliseconds > 3000)
                        {
                            return ComCode.TimeOut;
                        }
                        Thread.Sleep(1);
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                else
                {
                    return comCode;
                }
            }
            else
            {
                return ComCode.ComNotOpen;
            }
        }

        public ComCode Write(DataModel dataModel, bool needInvoke = true)
        {
            receiveDataModel = null;

            var sendBytes = dataModel.Encode();
            string readableBytes = ByteHelper.Byte2ReadalbeXstring(sendBytes);
            if (needInvoke)
                UpdateListViewHandler?.Invoke(readableBytes);

            //close and reopen com port
            if (Open())
            {
                ComCode comCode = _communicator.Write(sendBytes, 0, sendBytes.Count());
                if (comCode == ComCode.SendOK)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    while (true)
                    {
                        //Do 
                        if (receiveDataModel != null && receiveDataModel.FunCode == dataModel.FunCode)
                        {
                            var raw = receiveDataModel.Raw;
                            var dataRegion = receiveDataModel.DataRegion;
                            if (receiveDataModel.CheckLegal())
                                return ComCode.ReceivedOK;
                            else
                                return ComCode.ReceivedMessageError;
                        }
                        if (sw.ElapsedMilliseconds > 3000)
                        {
                            return ComCode.TimeOut;
                        }
                        Thread.Sleep(1);
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                else
                {
                    return comCode;
                }
            }
            else
            {
                return ComCode.ComNotOpen;
            }
        }

        public delegate void RefreshListViewDelegate(string info);
        public RefreshListViewDelegate UpdateListViewHandler;
    }
}
