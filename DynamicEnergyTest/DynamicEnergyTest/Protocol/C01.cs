using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //版本测试
    public class C01 : DataModel
    {
        public class Version
        {
            public string MCUVersion { get; set; }
        }
        public Version McuVersion { get; set; }
        public C01()
        {
            this.TestIndex = 2;
            this.TestItem = "版本测试";
            this.FunCode = 0x00710001;
        }

        public override bool Decode(byte[] buf)
        {
            if (buf != null && buf.Count() > 0)
            {
                string mcuVersion = System.Text.Encoding.UTF8.GetString(buf);
                this.McuVersion = ParseHelpers.ParseJSON<Version>(mcuVersion);
                return true;
            }
            return false;
        }
    }
}
