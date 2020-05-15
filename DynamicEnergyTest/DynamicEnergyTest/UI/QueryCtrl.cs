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
using System.Data.SqlClient;

namespace DynamicEnergyTest.UI
{
    public partial class QueryCtrl : UserControl
    {
        private SysConfig sysConfig;
        private const int MARGIN = 10;
        private DataTable dataTable;
        public QueryCtrl()
        {
            InitializeComponent();

            sysConfig = SysConfig.GetConfig();
            //dataAdapter = new SqlDataAdapter();
            BindDataToGridView();

            //sysConfig.UpdateDataGridViewHandler += UpdateDataGridViewHandler;

            //var v = sysConfig.QueryProcessTests();
        }


        private void BindDataToGridView()
        {
            dataTable = sysConfig.QueryProcessTests();
            //dataTable = sysConfig.UIDs.ToDataTable();

            this.dataGridView.DataSource = dataTable;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    this.dataGridView.Columns[i].Width = 250;
                    //this.dataGridView.Columns[i].DataPropertyName = "UIDCode";
                }
                if (i == 1)
                {
                    this.dataGridView.Columns[i].Width = 400;
                    //this.dataGridView.Columns[i].DataPropertyName = "TestStatus";
                }
                if (i == 2)
                {
                    this.dataGridView.Columns[i].Width = 300;
                    //this.dataGridView.Columns[i].DataPropertyName = "Operate";
                }

            }
        }
        private void UpdateDataGridViewHandler(object sender, EventArgs e)
        {
            BindDataToGridView();

            this.dataGridView.Refresh();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, MARGIN, MARGIN, this.Width - 2 * MARGIN, this.Height - 2 * MARGIN);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.dataGridView.Bounds = new Rectangle(10, this.querySettingCtrl1.Location.Y + this.querySettingCtrl1.Height, this.Width - 20, this.Height - this.querySettingCtrl1.Location.Y - this.querySettingCtrl1.Height -10);
        }

        private void DataGridView_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var row = e.RowIndex;
                if (sysConfig.UIDs != null && row < sysConfig.UIDs.Count - 1)
                {
                    var uid = sysConfig.UIDs[row];
                    Console.WriteLine("UID: " + uid.UIDCode + " TestStatus: " + uid.TestStatus.ToString());

                    DetailForm detailForm = new DetailForm(uid);
                    detailForm.ShowDialog();
                }
            }
        }
    }
}
