using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicEnergyTest
{
    public static class ExtensionMethods
    {
        public static void InvokeInvalidate(this Control control, string textString, string value)
        {
            if (!control.IsHandleCreated)
                return;
            try
            {
                control.Invoke((MethodInvoker)delegate { textString = value; });
            }
            catch { }
        }

        public static void InvokeInvalidate(this Control control, TestStatus originalStatus, TestStatus value)
        {
            if (!control.IsHandleCreated)
                return;
            try
            {
                control.Invoke((MethodInvoker)delegate { originalStatus = value; });
            }
            catch { }
        }
    }
}
