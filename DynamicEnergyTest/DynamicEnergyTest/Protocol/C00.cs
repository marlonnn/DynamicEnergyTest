using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //进入产测命令 ManufactureTest
    public class C00 : DataModel
    {
        public string Manufacture { get; set; }
        public string key = "ManufactureTest";
        public C00()
        {
            this.TestIndex = 0;
            this.TestItem = "进入产测";
            this.FunCode = 0x00000000;
        }

        public override byte[] Encode()
        {
            var tempBytes = Encoding.ASCII.GetBytes(key);

            int datalength = 10 + tempBytes.Length;
            byte[] data = new byte[datalength + 3];
            data[0] = 0x7E;
            data[1] = (byte)datalength;

            data[2] = 0x01;
            data[3] = 0x02;
            data[4] = 0x03;
            data[5] = 0x04;
            data[6] = 0x05;
            data[7] = 0x06;
            var tempData = ByteHelper.IntToBytes(this.FunCode);
            Array.Copy(tempData, 0, data, 8, 4);
            Array.Copy(tempBytes, 0, data, 12, tempBytes.Length);

            //check sum
            int sum = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                sum += data[i];
            }
            data[datalength + 2] = (byte)sum;

            return data;
        }

        public override bool Decode(byte[] buf)
        {
            base.Decode(buf);
            if (buf != null && buf.Count() == 15)
            {
                Manufacture = System.Text.Encoding.UTF8.GetString(buf);
                return true;
            }
            return false;
        }

        public override bool CheckLegal()
        {
            bool legal = false;
            if (!string.IsNullOrEmpty(Manufacture))
            {
                legal = Manufacture == key;
            }
            return legal;
        }
    }
}
