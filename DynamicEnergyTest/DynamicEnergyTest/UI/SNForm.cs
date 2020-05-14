using DynamicEnergyTest.SysSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicEnergyTest.UI
{
    public partial class SNForm : ChildForm
    {
        private string _sn;
        public string SN
        {
            get { return _sn; }
            set { _sn = value; }
        }

        private SysConfig sysConfig;
        public SNForm()
        {
            InitializeComponent();
            this.EnableMin = this.EnableMax = false;
            sysConfig = SysConfig.GetConfig();
            waringInfo = "请输入合法的SN条码！";
            legalInfo = "设备SN检查通过，请点击确定进行测试。";

        }
        private string waringInfo;
        private string legalInfo;
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (sysConfig.TestUID != null)
            {
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            sysConfig.TestUID = null;
            this.Close();
        }

        private void TxtSN_TextChanged(object sender, EventArgs e)
        {
            //Check SN is legal
            this.SN = this.txtSN.Text;
            if (sysConfig.UIDs.Count > 0)
            {
                UID findUid = sysConfig.UIDs.Find(uid => uid.UIDCode == SN);
                if (findUid != null)
                {
                    sysConfig.TestUID = findUid;
                    this.label2.Text = legalInfo;
                }
                else
                {
                    this.label2.Text = waringInfo;
                }
            }
            else
            {
                MessageBox.Show("请先导入测试的 UID 设备列表。", SysConfig.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
