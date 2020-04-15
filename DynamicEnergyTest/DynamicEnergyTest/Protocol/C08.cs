using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //休眠测试
    public class C08 : DataModel
    {
        public C08()
        {
            this.FunCode = 0x00710008;
        }

        public override bool Decode(byte[] buf)
        {
            return true;
        }
    }
}
