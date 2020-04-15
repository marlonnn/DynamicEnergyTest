using KoboldCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710001), new C01());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710008), new C08());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x0071000E), new C0E());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710012), new C12());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710013), new C13());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710014), new C14());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00710015), new C15());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00717071), new C7071());
            DataModels.Add(BigEndianIntToLittleEndianInt(0x00717072), new C7072());
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
                //decode data region
                var c12 = m.Data as C12;
                c12.Decode(m.Data.DataRegion);
            }
        }

        private void Communicator_OnRawDataReceived(byte[] bytes)
        {

        }

        public static ProtocolFactory GetFactory()
        {
            if (_protocolFactory == null) _protocolFactory = new ProtocolFactory();
            return _protocolFactory;
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            _communicator.Write(buffer, offset, count);
        }
    }
}
