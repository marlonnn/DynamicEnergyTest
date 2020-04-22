using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicEnergyTest.SysSetting;
using System.IO;
using System.Xml.Serialization;

namespace DynamicEnergyTest.UI
{
    public partial class ParameterSettingCtrl : UserControl
    {
        private const int MARGIN = 10;
        private ParameterSetting parameterSetting;
        public ParameterSettingCtrl()
        {
            InitializeComponent();
            parameterSetting = SysConfig.GetConfig().ParameterSetting;
            InitializeSetting();
        }

        private void InitializeSetting()
        {
            this.txtVersion.Text = parameterSetting.Version;
            this.lowInputVoltage.Value = new decimal(parameterSetting.LowVoltage);
            this.highInputVoltage.Value = new decimal(parameterSetting.HighVoltage);

            this.lowCurrent.Value = new decimal(parameterSetting.LowCurrent);
            this.highCurrent.Value = new decimal(parameterSetting.HighCurrent);

            this.lowPower.Value = new decimal(parameterSetting.LowPower);
            this.highPower.Value = new decimal(parameterSetting.LowPower);

            this.lowSleepCurrent.Value = new decimal(parameterSetting.LowSleepCurrent);
            this.highSleepCurrent.Value = new decimal(parameterSetting.HighSleepCurrent);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawString("参数设置", this.Font, Brushes.Black, MARGIN, 0);

            g.FillRectangle(Brushes.White, MARGIN, 3 * MARGIN, this.Width - 2 * MARGIN, this.Height - 4 * MARGIN);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (var writer = new FileStream("Paramaters.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(ParameterSetting));
                ParameterSetting parameterSetting = new ParameterSetting();
                parameterSetting.Version = this.txtVersion.Text;
                parameterSetting.LowVoltage = (double)this.lowInputVoltage.Value;
                parameterSetting.HighVoltage = (double)this.highInputVoltage.Value;
                parameterSetting.LowCurrent = (double)this.lowCurrent.Value;
                parameterSetting.HighCurrent = (double)this.highCurrent.Value;
                parameterSetting.LowPower = (double)this.lowPower.Value;
                parameterSetting.HighPower = (double)this.highPower.Value;
                parameterSetting.LowSleepCurrent = (double)this.lowSleepCurrent.Value;
                parameterSetting.HighSleepCurrent = (double)this.highSleepCurrent.Value;
                SysConfig.GetConfig().ParameterSetting = parameterSetting;
                ser.Serialize(writer, parameterSetting);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
