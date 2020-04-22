using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.SysSetting
{
    public class UID : INotifyPropertyChanged
    {
        private string _uidCode;
        [DisplayName("UID编号")]
        public string UIDCode
        {
            get { return _uidCode; }
            set
            {
                _uidCode = value;
                NotifyPropertyChanged();
            }
        }
        private TestStatus _testStatus;
        [DisplayName("测试状态")]
        public TestStatus TestStatus
        {
            get { return _testStatus; }
            set
            {
                if (value != _testStatus)
                {
                    _testStatus = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _operate;

        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [DisplayName("操作")]
        public string Operate
        {
            get { return _operate; }
            set
            {
                if (value != _operate)
                {
                    _operate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public UID (string sn)
        {
            this._uidCode = sn;
            this._testStatus = TestStatus.UnTest;
            this._operate = "查看测试日志";
        }
    }

    //public class UIDS : IEnumerable<UID>
    //{
    //    private List<UID> uidList;

    //    public UIDS()
    //    {
    //        uidList = new List<UID>();
    //    }

    //    public void Clear()
    //    {
    //        this.uidList.Clear();
    //    }

    //    public void Add(UID uID)
    //    {
    //        uidList.Add(uID);
    //    }

    //    public UID this[int index]
    //    {
    //        get
    //        {
    //            return uidList[index];
    //        }
    //    }

    //    public IEnumerator<UID> GetEnumerator()
    //    {
    //        return (IEnumerator<UID>)uidList.GetEnumerator();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return uidList.GetEnumerator();
    //    }

    //    public int Count
    //    {
    //        get { return uidList.Count; }
    //    }
    //}
}
