using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class ParameterSetting
    {
        private string _version;
        public string Version
        {
            get { return _version; }
            set { this._version = value; }
        }

        private double _lowVoltage;
        public double LowVoltage
        {
            get { return _lowVoltage; }
            set { this._lowVoltage = value; }
        }

        private double _highVoltage;
        public double HighVoltage
        {
            get { return _highVoltage; }
            set { this._highVoltage = value; }
        }

        private double _lowCurrent;
        public double LowCurrent
        {
            get { return _lowCurrent; }
            set { this._lowCurrent = value; }
        }

        private double _highCurrent;
        public double HighCurrent
        {
            get { return _highCurrent; }
            set { this._highCurrent = value; }
        }
        private double _lowPower;
        public double LowPower
        {
            get { return _lowPower; }
            set { this._lowPower = value; }
        }

        private double _highPower;
        public double HighPower
        {
            get { return _highPower; }
            set { this._highPower = value; }
        }

        private double _lowSleepCurrent;
        public double LowSleepCurrent
        {
            get { return _lowSleepCurrent; }
            set { this._lowSleepCurrent = value; }
        }

        private double _highSleepCurrent;
        public double HighSleepCurrent
        {
            get { return _highSleepCurrent; }
            set { this._highSleepCurrent = value; }
        }
    }
}
