using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //通信测试
    public class C14 : DataModel
    {
        //信号强度RSSI：0-99
        public byte RSSI { get; set; }
        public C14()
        {
            this.TestIndex = 6;
            this.TestItem = "通信测试";
            this.FunCode = 0x00710014;
        }

        public override bool Decode(byte[] buf)
        {
            base.Decode(buf);
            if (buf.Count() == 2)
            {
                this.RSSI = buf[1];
                return true;
            }
            return false;
        }
    }
}
