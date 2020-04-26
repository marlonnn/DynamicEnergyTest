using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class BinAddressTable
    {
        public string Address { get; set; }

        public string Name { get; set; }

        public BinAddressTable() { }
        public BinAddressTable(string address, string name)
        {
            this.Address = address;
            this.Name = name;
        }
    }
}
