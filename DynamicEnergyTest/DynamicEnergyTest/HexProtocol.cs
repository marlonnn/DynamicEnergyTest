using KoboldCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest
{
    public class HexProtocol : HexProtocolAnalyzer<DataModel>
    {
        public HexProtocol()
        {
            this.Mask = new byte[] { 0x7E };
            this.TimeOut = 5;
            this.CheckData = SumCheck;
        }
        public override void Analyze()
        {
            int offset = Mask.Length + LenLength;
            Array.Copy(Raw, offset, this.Data.Mac, 0, this.Data.Mac.Length);
            this.Data.FunCode = BitConverter.ToInt32(Raw, offset + this.Data.Mac.Length);
            Array.Copy(Raw, offset + this.Data.Mac.Length + 4, this.Data.DataRegion, 0, Raw.Length - offset - this.Data.Mac.Length - 4);
        }
    }
}
