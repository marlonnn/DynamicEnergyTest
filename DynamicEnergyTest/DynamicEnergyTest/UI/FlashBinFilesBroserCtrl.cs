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
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        public void AddBinFile(Bin bin)
        {
            if (sysConfig.FlashBins.Find(b => b.Name == bin.Name) == null)
            {
                sysConfig.FlashBins.Add(bin);
            }
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
                    textBox.Text = openFileDialog.FileName;
                    string fileName = openFileDialog.SafeFileName;
                    if (sysConfig.BinAddressTable.Keys.Contains(fileName))
                    {
                        string address = sysConfig.BinAddressTable[fileName];
                        Bin bin = new Bin(address, fileName, openFileDialog.FileName);
                        AddBinFile(bin);
                    }
                }
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            GetBinFileName(textBox1);
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            GetBinFileName(textBox2);
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            GetBinFileName(textBox3);
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            GetBinFileName(textBox4);
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            GetBinFileName(textBox5);
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
