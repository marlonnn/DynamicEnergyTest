using DynamicEnergyTest.SysSetting;
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
        public string MCUVersion { get; set; }

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
                MCUVersion = System.Text.Encoding.UTF8.GetString(buf);
                return true;
            }
            return false;
        }

        public override bool CheckLegal()
        {
            bool legal = false;
            var parameter = SysConfig.GetConfig().ParameterSetting;
            if (!string.IsNullOrEmpty(MCUVersion) && parameter != null && !string.IsNullOrEmpty(parameter.Version))
            {
                legal = MCUVersion == parameter.Version;
            }
            return legal;
        }
    }
}
