using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //BT测试
    public class C7071 : DataModel
    {
        public class BTInfo
        {
            public string MAC { get; set; }
            public string RSSI { get; set; }
        }

        public BTInfo BTInfomation { get; set; }
        public C7071()
        {
            this.TestIndex = 8;
            this.TestItem = "蓝牙测试";
            this.FunCode = 0x00717071;
        }

        public override bool Decode(byte[] buf)
        {
            if (buf != null && buf.Count() > 0)
            {
                string btInfoStr = System.Text.Encoding.UTF8.GetString(buf);
                this.BTInfomation = ParseHelpers.ParseJSON<BTInfo>(btInfoStr);
                return true;
            }
            return false;
        }
    }
}
