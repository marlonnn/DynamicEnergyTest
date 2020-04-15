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

        public C00()
        {
            this.FunCode = 0x00000000;
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
    }
}
