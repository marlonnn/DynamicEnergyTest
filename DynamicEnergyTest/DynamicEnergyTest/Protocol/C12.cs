using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //条码测试
    public class C12 : DataModel
    {
        public string DevID { get; set; }

        //读取设备ID
        public C12()
        {
            this.FunCode = 0x00710012;
        }

        /// <summary>
        /// 解析数据域
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public override bool Decode(byte[] buf)
        {
            base.Decode(buf);
            if (buf.Count() == 14)
            {
                DevID = System.Text.Encoding.UTF8.GetString(buf, 1, 14);
                return true;
            }
            return false;
        }

        public override byte[] Encode()
        {
            return base.Encode();
        }
    }
}
