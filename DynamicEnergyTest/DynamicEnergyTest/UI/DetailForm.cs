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
    public partial class DetailForm : ChildForm
    {
        private SysConfig sysConfig;
        public DetailForm() : base()
        {
            sysConfig = SysConfig.GetConfig();
            InitializeComponent();
            this.EnableMin = this.EnableMax = false;
            //this.ClientSize = new Size(483, 353);
        }

        public DetailForm(UID uID) : this()
        {
            var entrys = sysConfig.QueryProcessEntrys(uID);
            DataTable dt = new DataTable();
            dt.Columns.Add("Index");
            dt.Columns.Add("Status");
            dt.Columns.Add("Info");

            foreach (var entry in entrys)
            {
                DataRow dr = dt.NewRow();
                dr["Index"] = entry.ItemIndex;
                dr["Status"] = entry.TestStatus.ToString();
                dr["Info"] = entry.InfoText;
                dt.Rows.Add(dr);
            }
            this.dataGridView1.DataSource = dt;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    this.dataGridView1.Columns[i].Width = 50;
                }
                if (i == 1)
                {
                    this.dataGridView1.Columns[i].Width = 100;
                }
                if (i == 2)
                {
                    this.dataGridView1.Columns[i].Width = 300;
                }

            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
