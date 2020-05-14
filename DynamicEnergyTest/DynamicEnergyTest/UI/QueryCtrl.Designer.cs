namespace DynamicEnergyTest.UI
{
    partial class QueryCtrl
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.querySettingCtrl1 = new DynamicEnergyTest.UI.QuerySettingCtrl();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(10, 66);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(920, 570);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.ReadOnly = true;
            this.dataGridView.CellClick += DataGridView_CellClick;
            // 
            // querySettingCtrl1
            // 
            this.querySettingCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.querySettingCtrl1.Location = new System.Drawing.Point(0, 0);
            this.querySettingCtrl1.Margin = new System.Windows.Forms.Padding(4);
            this.querySettingCtrl1.Name = "querySettingCtrl1";
            this.querySettingCtrl1.Size = new System.Drawing.Size(949, 61);
            this.querySettingCtrl1.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UIDCode";
            this.Column1.HeaderText = "UID编号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TestStatus";
            this.Column2.HeaderText = "测试状态";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 400;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Operate";
            this.Column3.HeaderText = "操作";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 300;
            // 
            // QueryCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.querySettingCtrl1);
            this.Controls.Add(this.dataGridView);
            this.Name = "QueryCtrl";
            this.Size = new System.Drawing.Size(949, 639);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private QuerySettingCtrl querySettingCtrl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
