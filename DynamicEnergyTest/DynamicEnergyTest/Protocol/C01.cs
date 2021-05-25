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
        public class Version
        {
            public string MCUVersion { get; set; }
        }
        public string MCUVersionString { get; set; }
        public Version mcuVersion { get; set; }
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
                MCUVersionString = System.Text.Encoding.UTF8.GetString(buf);
                this.mcuVersion = ParseHelpers.ParseJSON<Version>(MCUVersionString);
                SysConfig.GetConfig().McuVersion = this.mcuVersion.MCUVersion;
                return true;
            }
            return false;
        }

        public override bool CheckLegal()
        {
            bool legal = false;
            var parameter = SysConfig.GetConfig().JsonConfig.ParameterSetting;
            if (!string.IsNullOrEmpty(MCUVersionString) && parameter != null && !string.IsNullOrEmpty(parameter.Version))
            {
                //legal = MCUVersion == parameter.Version;
                legal = true;
            }
            return legal;
        }
    }
}
