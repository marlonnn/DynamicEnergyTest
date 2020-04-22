using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //ICCID测试
    public class C15 : DataModel
    {
        public string ICCID { get; set; }
        public C15()
        {
            this.TestIndex = 5;
            this.TestItem = "ICCID测试";
            this.FunCode = 0x00710015;
        }

        public override bool Decode(byte[] buf)
        {
            base.Decode(buf);
            if (buf.Count() == 21)
            {
                ICCID = System.Text.Encoding.UTF8.GetString(buf, 1, 20);
                return true;
            }
            return false;
        }
    }
}
