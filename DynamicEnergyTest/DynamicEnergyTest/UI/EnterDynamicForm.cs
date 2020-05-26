using DynamicEnergyTest.Protocol;
using DynamicEnergyTest.SysSetting;
using KoboldCom;
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
    public partial class EnterDynamicForm : ChildForm
    {
        private ProtocolFactory protocolFactory;

        public EnterDynamicForm()
        {
            InitializeComponent();
        }

        public EnterDynamicForm(Timer timer)
        {
            protocolFactory = Program.ProtocolsFactory;
            protocolFactory.RawDataHandler += RawDataHandler;
            InitializeComponent();
            InitializeListView();
            this.exListView.Timer = timer;
        }

        private void RawDataHandler(byte[] bytes)
        {
            var strBytes = System.Text.Encoding.UTF8.GetString(bytes);
            Console.WriteLine(strBytes);
            AppendLog(strBytes);
        }

        private void InitializeListView()
        {

            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "日志";
            columnHeader.Width = 550;
            this.exListView.Columns.Add(columnHeader);
        }

        public void AppendLog(string info)
        {
            this.exListView.AppendLog(new string[] { info });
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            var dataModel = protocolFactory.DataModels[0];

            var sendBytes = dataModel.Encode();
            string readableBytes = ByteHelper.Byte2ReadalbeXstring(sendBytes);
            AppendLog(readableBytes);
            ComCode comCode = protocolFactory.Write(sendBytes, dataModel.FunCode);
            AppendLog(comCode.GetComCodeDescription());
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.exListView.Clear();
            InitializeListView();
        }

        private void EnterDynamicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("设备是否已经进入产测模式？\r\n 点击确定进入测试，取消则继续发送命令。", SysConfig.ApplicationName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
