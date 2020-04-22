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
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //this.Column1,
            //this.Column2,
            //this.Column3});
            this.dataGridView.Location = new System.Drawing.Point(21, 82);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(1227, 651);
            this.dataGridView.TabIndex = 6;
            // 
            // querySettingCtrl1
            // 
            this.querySettingCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.querySettingCtrl1.Location = new System.Drawing.Point(0, 0);
            this.querySettingCtrl1.Margin = new System.Windows.Forms.Padding(5);
            this.querySettingCtrl1.Name = "querySettingCtrl1";
            this.querySettingCtrl1.Size = new System.Drawing.Size(1265, 76);
            this.querySettingCtrl1.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "UID编号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 250;
            this.Column1.DataPropertyName = "UIDCode";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "测试状态";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 400;
            this.Column2.DataPropertyName = "TestStatus";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "操作";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 300;
            this.Column3.DataPropertyName = "Operate";
            // 
            // QueryCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.querySettingCtrl1);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QueryCtrl";
            this.Size = new System.Drawing.Size(1265, 799);
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
