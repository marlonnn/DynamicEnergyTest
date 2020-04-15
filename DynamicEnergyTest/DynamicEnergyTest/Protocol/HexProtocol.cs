using KoboldCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    public class HexProtocol : HexProtocolAnalyzer<DataModel>
    {
        private const int MacLength = 6;
        public HexProtocol()
        {
            this.Mask = new byte[] { 0x7E };
            this.TimeOut = 5;
            this.CheckData = SumCheck;
        }
        public override void Analyze()
        {
            int offset = Mask.Length + LenLength;
            this.Data.Mac = new byte[MacLength];
            Array.Copy(Raw, offset, this.Data.Mac, 0, this.Data.Mac.Length);
            this.Data.FunCode = BitConverter.ToInt32(Raw, offset + this.Data.Mac.Length);
            if (Raw.Length > 13)
            {
                int dataRegionLength = Raw.Length - offset - this.Data.Mac.Length - 4 - 1;
                this.Data.DataRegion = new byte[dataRegionLength];
                Array.Copy(Raw, offset + this.Data.Mac.Length + 4, this.Data.DataRegion, 0, dataRegionLength);
            }
        }
    }
}
