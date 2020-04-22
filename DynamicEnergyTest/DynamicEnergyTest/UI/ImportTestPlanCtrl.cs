﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;
using DynamicEnergyTest.SysSetting;

namespace DynamicEnergyTest.UI
{
    public partial class ImportTestPlanCtrl : UserControl
    {
        private SysConfig SysConfig;
        private const int MARGIN = 10;
        private string importedFile;
        public string ImportedFile
        {
            get { return importedFile; }
            set
            {
                importedFile = value;
                this.Invalidate();
            }
        }
        public ImportTestPlanCtrl()
        {
            InitializeComponent();
            SysConfig = SysConfig.GetConfig();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            //Import UID test plan
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog.Filter = @".xls Files(*.xls) | *.xls";
                if (openFileDialog.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    SysConfig.UIDs.Clear();
                    //SysConfig.UIDs
                    string fileName = openFileDialog.FileName;
                    using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                    {
                        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                        //...
                        //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        //...
                        //3. DataSet - The result of each spreadsheet will be created in the result.Tables
                        DataSet result = excelReader.AsDataSet();
                        //...
                        //4. DataSet - Create column names from first row
                        //excelReader.IsFirstRowAsColumnNames = true;
                        //DataSet result = excelReader.AsDataSet();

                        //5. Data Reader methods
                        while (excelReader.Read())
                        {
                            var sn = excelReader.GetString(0);
                            var str = excelReader.GetString(0);
                            if (!string.IsNullOrEmpty(sn) && sn.ToLower().StartsWith("zs"))
                            {
                                UID uID = new UID(sn);
                                SysConfig.UIDs.Add(uID);
                            }
                        }

                        //6. Free resources (IExcelDataReader is IDisposable)
                        excelReader.Close();
                        ImportedFile = "文件： " + openFileDialog.SafeFileName + " 已成功导入 " + SysConfig.UIDs.Count + " 个UID";

                    }
                    SysConfig.UpdateDataGridViewHandler?.Invoke(null, null);
                    SysConfig.CreateProcessTestsHandler?.Invoke(null, null);
                }
            }
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
            g.DrawString("新建测试计划", this.Font, Brushes.Black, MARGIN, MARGIN);

            g.FillRectangle(Brushes.White, MARGIN, 3 * MARGIN, this.Width - 2 * MARGIN, this.Height - 4 * MARGIN);

            var x = this.btnImport.Bounds.X + this.btnImport.Bounds.Width + 20;
            using (Font font = GraphicFactory.CreateFont())
            {
                var size = g.MeasureString(importedFile, font);
                var y = (this.Height - 4 * MARGIN - size.Height) / 2 + 3 * MARGIN;
                g.DrawString(importedFile, font, Brushes.Black, new PointF(x, y));
            }
        }
    }
}
