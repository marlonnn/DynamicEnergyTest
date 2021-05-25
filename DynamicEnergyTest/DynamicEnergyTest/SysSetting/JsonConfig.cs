using KoboldCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class JsonConfig
    {
        private string _importedUIDFile;
        public string ImportedUIDFile
        {
            get { return _importedUIDFile; }
            set { _importedUIDFile = value; }
        }

        private List<Bin> _flashBins;
        public List<Bin> FlashBins
        {
            get { return _flashBins; }
            set { _flashBins = value; }
        }

        private ParameterSetting _parameterSetting;
        public ParameterSetting ParameterSetting
        {
            get { return _parameterSetting; }
            set { _parameterSetting = value; }
        }

        private SerialPortSetting _serialPortSetting;
        public SerialPortSetting SerialPortSetting
        {
            get { return _serialPortSetting; }
            set { _serialPortSetting = value; }
        }

        public JsonConfig()
        {
            FlashBins = new List<Bin>();
            ParameterSetting = new ParameterSetting();
        }

    }
}
