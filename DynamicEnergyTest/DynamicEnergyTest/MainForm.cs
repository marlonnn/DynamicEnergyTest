using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using KoboldCom;

namespace DynamicEnergyTest
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly Communicator communicator = new Communicator(new SerialPort(), new Protocols());

        public MainForm()
        {
            InitializeComponent();

            byte[] bytes = new byte[] {
                0x4d, 0x61, 0x6e, 0x75, 0x66, 0x61, 0x63, 0x74, 0x75, 0x72, 0x65, 0x54, 0x65, 0x73, 0x74
            };
            string result = System.Text.Encoding.UTF8.GetString(bytes);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;
            string skinName = comboBox.Text;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinName;
        }
    }
}