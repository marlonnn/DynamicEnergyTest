using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class BinAddressTable
    {
        //烧录的顺序
        public int FlushOrder { get; set; }
        public string Address { get; set; }

        public string Name { get; set; }

        public BinAddressTable() { }
        public BinAddressTable(int flushOrder, string name, string address)
        {
            this.FlushOrder = flushOrder;
            this.Address = address;
            this.Name = name;
        }
    }
}
