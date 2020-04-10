using System;

namespace DynamicEnergyTest.UI
{
    partial class ToolBarCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolBarItemTest = new DynamicEnergyTest.UI.ToolBarItem();
            this.toolBarItemReport = new DynamicEnergyTest.UI.ToolBarItem();
            this.toolBarItemSetting = new DynamicEnergyTest.UI.ToolBarItem();
            this.SuspendLayout();
            // 
            // toolBarItemTest
            // 
            this.toolBarItemTest.BackColor = System.Drawing.Color.White;
            this.toolBarItemTest.ItemText = "测试";
            this.toolBarItemTest.Location = new System.Drawing.Point(0, 0);
            this.toolBarItemTest.Name = "toolBarItemTest";
            this.toolBarItemTest.Size = new System.Drawing.Size(120, 60);
            this.toolBarItemTest.TabIndex = 1;
            this.toolBarItemTest.ItemIndex = 1;
            this.toolBarItemTest.ClickEvent += ClickEvent;
            // 
            // toolBarItemReport
            // 
            this.toolBarItemReport.BackColor = System.Drawing.Color.White;
            this.toolBarItemReport.ItemText = "报告";
            this.toolBarItemReport.Location = new System.Drawing.Point(120, 0);
            this.toolBarItemReport.Name = "toolBarItemReport";
            this.toolBarItemReport.Size = new System.Drawing.Size(120, 60);
            this.toolBarItemReport.TabIndex = 2;
            this.toolBarItemReport.ItemIndex = 2;
            this.toolBarItemReport.ClickEvent += ClickEvent;
            // 
            // toolBarItemSetting
            // 
            this.toolBarItemSetting.BackColor = System.Drawing.Color.White;
            this.toolBarItemSetting.ItemText = "设置";
            this.toolBarItemSetting.Location = new System.Drawing.Point(240, 0);
            this.toolBarItemSetting.Name = "toolBarItemReport";
            this.toolBarItemSetting.Size = new System.Drawing.Size(120, 60);
            this.toolBarItemSetting.TabIndex = 3;
            this.toolBarItemSetting.ItemIndex = 3;
            this.toolBarItemSetting.ClickEvent += ClickEvent;
            // 
            // ToolBarCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.toolBarItemReport);
            this.Controls.Add(this.toolBarItemTest);
            this.Controls.Add(this.toolBarItemSetting);
            this.Name = "ToolBarCtrl";
            this.Size = new System.Drawing.Size(952, 70);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolBarItem toolBarItemTest;
        private ToolBarItem toolBarItemReport;
        private ToolBarItem toolBarItemSetting;
    }
}
