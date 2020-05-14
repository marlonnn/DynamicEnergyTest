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

namespace DynamicEnergyTest.UI
{
    public partial class FlashBinFilesBroserCtrl : UserControl
    {
        private OpenFileDialog openFileDialog;
        private SysConfig sysConfig;
        public FlashBinFilesBroserCtrl()
        {
            sysConfig = SysConfig.GetConfig();
            //LoadFlushBinsSetting();
            sysConfig.UpdateFlushBinsHandler += UpdateFlushBinsHandler;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (sysConfig.JsonConfig != null && sysConfig.JsonConfig != null && sysConfig.JsonConfig.FlashBins != null && sysConfig.JsonConfig.FlashBins.Count > 0)
            {
                UpdateFlushBinsHandler(null, null);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        public void AddBinFile(Bin bin)
        {
            if (sysConfig.JsonConfig.FlashBins.Find(b => b.Name == bin.Name) == null)
            {
                sysConfig.JsonConfig.FlashBins.Add(bin);
            }
            else
            {
                //update
                sysConfig.JsonConfig.FlashBins.Find(b => b.Name == bin.Name).FullName = bin.FullName;
            }
        }

        private void UpdateFlushBinsHandler(object sender, EventArgs e)
        {
            if (sysConfig.JsonConfig.FlashBins != null && sysConfig.JsonConfig.FlashBins.Count() > 0)
            {
                var sortedFlushbins = sysConfig.JsonConfig.FlashBins.OrderBy(b => b.FlushOrder).ToList();
                for (int i=0; i<sortedFlushbins.Count(); i++)
                {
                    var binFileName = sortedFlushbins[i];
                    TextBox textBox = GetTextBoxCtrl(i + 1);
                    if (textBox != null)
                    {
                        textBox.Text = binFileName.Name;
                    }
                }
            }
        }

        private TextBox GetTextBoxCtrl(int index)
        {
            TextBox tb = null;
            foreach (var ctrl in this.Controls)
            {
                var textBox = ctrl as TextBox;
                if (textBox != null && textBox.Name == string.Format("textBox{0}", index))
                {
                    tb = textBox;
                    break;
                }
            }
            return tb;
        }

        private void GetBinFileName(TextBox textBox)
        {
            using (openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Flush Bin Files (*.bin) | *.bin";
                openFileDialog.InitialDirectory = System.Environment.CurrentDirectory + "\\Firmware";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.SafeFileName;

                    foreach (var ctrl in this.Controls)
                    {
                        var tb = ctrl as TextBox;
                        if (tb != null && tb.Name != textBox.Name)
                        {
                            if (fileName == tb.Text)
                            {
                                MessageBox.Show(string.Format("{0} 文件已存在，请重新选择。", fileName), SysConfig.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    textBox.Text = openFileDialog.SafeFileName;
                    BinAddressTable binAddressTable = sysConfig.BinAddressTable.Find(bin => bin.Name == fileName);
                    if (binAddressTable != null)
                    {
                        Bin bin = new Bin(binAddressTable.FlushOrder, binAddressTable.Address, fileName, openFileDialog.FileName);
                        AddBinFile(bin);
                    }
                }
            }
        }

        public void UpdateBinFiles(List<string> binfileList)
        {
            if (binfileList != null && binfileList.Count > 0)
            {

            }
        }

        private void AutoFillBinFiles()
        {

        }
    }
}
