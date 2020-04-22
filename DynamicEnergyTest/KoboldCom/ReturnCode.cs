using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    public enum ReturnCode : byte
    {
        CommandOK = 0x00,
        CommandError = 0x01
    }
}
