using KoboldCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicEnergyTest
{
    public static class ExtensionMethods
    {
        public static string GetComCodeDescription(this ComCode comCode)
        {
            string des = "";
            switch (comCode)
            {
                case ComCode.ComNotExist:
                    des = "串口不存在，请检查硬件设备";
                    break;
                case ComCode.ComNotOpen:
                    des = "请检查串口是否已经打开";
                    break;
                case ComCode.TimeOut:
                    des = "串口通信超时，3s内未收到任何消息";
                    break;
                case ComCode.SendOK:
                    des = "发送正常";
                    break;
                case ComCode.ReceivedOK:
                    des = "接收到数据";
                    break;
            }
            return des;
        }
        public static string ToDescription(this Enum en)
        {
            string result = RetrieveDescription(en);
            if (null == result)
            {
                // try to retrieve localized description if any
                result = RetrieveLocalizedDescription(en);
                if (null == result)
                {
                    // set enum's string representation
                    result = en.ToString();

                }
            }

            // return result
            return result;
        }

        private static string RetrieveDescription(Enum en)
        {
            // get the type
            Type type = en.GetType();

            // get the member info
            MemberInfo[] mi = type.GetMember(en.ToString());
            if ((null != mi) && (0 < mi.Length))
            {
                // retrieve all description attributes
                Object[] attributes = mi[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                // get the description info
                if ((null != attributes) && (0 < attributes.Length))
                {
                    // return the corresponding description
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            // return no description
            return null;
        }

        /// <summary>
        /// Get the description for the input value.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The corresponding description is fuccessful, an empty string otherwise.</returns>
        public static String RetrieveLocalizedDescription(Enum en)
        {
            // get the input type
            Type type = en.GetType();

            // retrieve all resource attributes; should be only one
            Object[] attributesLocalizedResource = type.GetCustomAttributes(typeof(LocalizedResourceAttribute), false);
            // get the description info
            if ((null != attributesLocalizedResource) && (0 < attributesLocalizedResource.Length))
            {
                // retrieve resource type
                Type resourceType = ((LocalizedResourceAttribute)attributesLocalizedResource[0]).Type;

                // initialize property name with enum's value
                String propertyName = en.ToString();
                // check for a localized description attribute
                MemberInfo[] mi = type.GetMember(en.ToString());
                if ((null != mi) && (0 < mi.Length))
                {
                    // retrieve all localized description attributes
                    Object[] attributesLocalizedDescription = mi[0].GetCustomAttributes(typeof(LocalizedDescriptionAttribute), false);
                    // get the localized description info
                    if ((null != attributesLocalizedDescription) && (0 < attributesLocalizedDescription.Length))
                    {
                        // set property name to the corresponding description
                        propertyName = ((LocalizedDescriptionAttribute)attributesLocalizedDescription[0]).Description;
                    }
                }

                // retrieve the corresponding property
                PropertyInfo propertyInfo = resourceType.GetProperty(propertyName, BindingFlags.Static | BindingFlags.NonPublic);
                if (null != propertyInfo)
                {
                    // return the corresponding value
                    return (string)propertyInfo.GetValue(null, null);
                }
            }

            // return no description
            return null;
        }

        // remove "this" if not on C# 3.0 / .NET 3.5
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.DisplayName, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static void InvokeInvalidate(this Control control, int textInt, int value)
        {
            if (!control.IsHandleCreated)
                return;
            try
            {
                control.Invoke((MethodInvoker)delegate { textInt = value; });
            }
            catch { }
        }

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
