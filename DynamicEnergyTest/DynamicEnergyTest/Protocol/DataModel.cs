using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    public class DataModel 
    {
        //Raw data
        public byte[] Raw { get; set; }
        //测试序号
        public int TestIndex { get; set; }
        //测试项目名称
        public string TestItem { get; set; }
        public byte[] Mac { get; set; }

        public int FunCode { get; set; }

        public byte[] DataRegion { get; set; }

        public ReturnCode ReturnCode { get; set; }

        public DataModel()
        {
        }

        public virtual bool Decode(byte[] buf)
        {
            if (buf != null && buf.Count() > 0)
            {
                ReturnCode = (ReturnCode)buf[0];
                if (ReturnCode == ReturnCode.CommandError)
                {
                    return false;
                }
            }
            return false;
        }
        public virtual byte[] Encode()
        {
            int datalength = 10;
            byte[] data = new byte[datalength + 3];
            data[0] = 0x7E;
            data[1] = (byte)datalength;

            var tempData = ByteHelper.IntToBytes(this.FunCode);
            Array.Copy(tempData, 0, data, 8, 4);
            //check sum
            int sum = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                sum += data[i];
            }
            data[12] = (byte)sum;
            return data;
        }

        public virtual bool CheckLegal()
        {
            return true;
        }
    }
}
