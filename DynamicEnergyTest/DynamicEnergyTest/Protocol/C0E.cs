using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //指示灯测试
    public class C0E : DataModel
    {
        public C0E()
        {
            this.TestIndex = 3;
            this.TestItem = "指示灯测试";
            this.FunCode = 0x0071000E;
        }

        public override bool Decode(byte[] buf)
        {
            base.Decode(buf);
            if (ReturnCode == ReturnCode.CommandOK)
            {
                return true;
            }
            return false;
        }
    }
}
