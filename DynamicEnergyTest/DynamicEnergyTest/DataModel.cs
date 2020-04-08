using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest
{
    public class DataModel
    {
        public byte[] Mac { get; set; }

        public int FunCode { get; set; }

        public byte[] DataRegion { get; set; }

        public DataModel()
        {
            Mac = new byte[6];
        }
    }
}
