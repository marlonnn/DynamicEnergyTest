using KoboldCom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.Protocol
{
    public class Protocols : IAnalyzerCollection
    {
        private readonly IAnalyzer[] _innerArray;

        public HexProtocol ProtocolBinary { get; } = new HexProtocol();

        public IAnalyzer this[int index]
        {
            get
            {
                return _innerArray[index];
            }
        }

        public Protocols()
        {
            _innerArray = new IAnalyzer[] { ProtocolBinary };
        }

        public IEnumerator<IAnalyzer> GetEnumerator()
        {
            return ((IEnumerable<IAnalyzer>)_innerArray).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerArray.GetEnumerator();
        }
    }
}
