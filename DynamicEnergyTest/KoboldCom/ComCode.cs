using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoboldCom
{
    [LocalizedResource(typeof(Properties.Resource))]
    public enum ComCode
    {
        [LocalizedDescription("StrComNotExist")]
        ComNotExist,
        [LocalizedDescription("StrComNotOpen")]
        ComNotOpen,
        [LocalizedDescription("StrTimeOut")]
        TimeOut,
        [LocalizedDescription("StrSendOK")]
        SendOK,
        [LocalizedDescription("StrReceivedOK")]
        ReceivedOK,

        ReceivedMessageError
    }
}
