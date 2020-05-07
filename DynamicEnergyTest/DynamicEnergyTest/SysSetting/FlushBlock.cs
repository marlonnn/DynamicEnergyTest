using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    /// <summary>
    /// 烧录的信息，包括UID，时间，状态
    /// </summary>
    public class FlushBlock
    {
        private string _imei;
        public string IMEI
        {
            get { return _imei; }
            set { _imei = value; }
        }

        private string _iccid;
        public string ICCID
        {
            get { return _iccid; }
            set { _iccid = value; }
        }

        private UID _uID;
        public UID FlushUID
        {
            get { return _uID; }
            set { _uID = value; }
        }

        private DateTime _flushTime;
        public DateTime FlushTime
        {
            get { return _flushTime; }
            set { _flushTime = value; }
        }

        private FlashStatus _flushStatus;
        public FlashStatus FlushStatus
        {
            get { return _flushStatus; }
            set { _flushStatus = value; }
        }
        public FlushBlock() { }


    }
}
