using DynamicEnergyTest.SysSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //计量测试
    public class C13 : DataModel
    {
        //插孔号
        public byte JackNum { get; set; }

        public ushort Voltage { get; set; }

        public ushort Current { get; set; }

        public ushort Power { get; set; }
        public C13()
        {
            this.TestIndex = 4;
            this.TestItem = "计量测试";
            this.FunCode = 0x00710013;
        }

        //public override byte[] Encode()
        //{
        //    int datalength = 11;
        //    byte[] data = new byte[datalength + 3];
        //    data[0] = 0x7E;
        //    data[1] = (byte)datalength;

        //    //小端
        //    var tempData = ByteHelper.IntToBytes(this.FunCode);
        //    Array.Copy(tempData, 0, data, 8, 4);

        //    data[12] = JackNum;

        //    //check sum
        //    int sum = 0;
        //    for (int i = 0; i < data.Length - 1; i++)
        //    {
        //        sum += data[i];
        //    }
        //    data[13] = (byte)sum;

        //    return data;
        //}

        public override bool Decode(byte[] buf)
        {
            base.Decode(buf);
            if (buf.Count() == 8)
            {
                this.JackNum = buf[1];
                this.Voltage = BitConverter.ToUInt16(buf, 2);
                this.Current = BitConverter.ToUInt16(buf, 4);
                this.Power = BitConverter.ToUInt16(buf, 6);
                return true;
            }
            return false;
        }

        public override bool CheckLegal()
        {
            bool legal = false;
            var parameter = SysConfig.GetConfig().JsonConfig.ParameterSetting;
            if (parameter != null)
            {
                legal = (this.Voltage >= parameter.LowVoltage && this.Voltage <= parameter.HighVoltage) &&
                    (this.Current >= parameter.LowCurrent && this.Current <= parameter.HighCurrent) &&
                    (this.Power >= parameter.LowPower && this.Power <= parameter.HighPower);
            }
            return legal;
        }
    }
}
