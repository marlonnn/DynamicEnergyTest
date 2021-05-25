using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    //WIFI测试
    public class C7072 : DataModel
    {
        public class WifiInfo
        {
            public string SSID { get; set; }
            public string MAC { get; set; }
            public string RSSI { get; set; }
        }

        public WifiInfo WifiInfomation { get; set; }
        public C7072()
        {
            this.TestIndex = 7;
            this.TestItem = "WIFI测试";
            this.FunCode = 0x00717072;
        }

        public override bool Decode(byte[] buf)
        {
            if (buf != null && buf.Count() > 0)
            {
                string wifiInfoStr = System.Text.Encoding.UTF8.GetString(buf);
                this.WifiInfomation = ParseHelpers.ParseJSON<WifiInfo>(wifiInfoStr);
                return true;
            }
            return false;
        }

        public override bool CheckLegal()
        {
            bool legal = false;
            if (this.WifiInfomation != null)
            {
                legal = !string.IsNullOrEmpty(this.WifiInfomation.SSID) && this.WifiInfomation.SSID == "medatc_socket" &&
                    !string.IsNullOrEmpty(this.WifiInfomation.MAC) && !string.IsNullOrEmpty(this.WifiInfomation.RSSI);
            }
            return legal;
        }
    }
}
