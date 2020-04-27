using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class Bin
    {
        public int FlushOrder { get; set; }
        public string Address { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public Bin() { }

        public Bin(int flushOrder, string address, string name, string fullName)
        {
            this.FlushOrder = flushOrder;
            this.Address = address;
            this.Name = name;
            this.FullName = fullName;
        }
    }
}
