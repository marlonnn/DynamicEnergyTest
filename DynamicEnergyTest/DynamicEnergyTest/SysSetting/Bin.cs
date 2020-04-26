using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class Bin
    {
        public string Address { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public Bin() { }

        public Bin(string address, string name, string fullName)
        {
            this.Address = address;
            this.Name = name;
            this.FullName = fullName;
        }
    }
}
