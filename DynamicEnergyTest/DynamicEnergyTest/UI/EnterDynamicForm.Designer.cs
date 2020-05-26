namespace DynamicEnergyTest.UI
{
    partial class EnterDynamicForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.exListView = new DynamicEnergyTest.UI.ExListView();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(3, 45);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(128, 30);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "发送产测命令";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // exListView
            // 
            this.exListView.FullRowSelect = true;
            this.exListView.GridLines = true;
            this.exListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.exListView.HideSelection = false;
            this.exListView.Location = new System.Drawing.Point(4, 81);
            this.exListView.MaxLogRecords = 300;
            this.exListView.MultiSelect = false;
            this.exListView.Name = "exListView";
            this.exListView.ShowGroups = false;
            this.exListView.Size = new System.Drawing.Size(547, 421);
            this.exListView.TabIndex = 2;
            this.exListView.Timer = null;
            this.exListView.UseCompatibleStateImageBehavior = false;
            this.exListView.View = System.Windows.Forms.View.Details;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(161, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(128, 30);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "清除日志";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // EnterDynamicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 500);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.exListView);
            this.Controls.Add(this.btnSend);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "EnterDynamicForm";
            this.NewClientSize = new System.Drawing.Size(542, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "进入产测模式";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnterDynamicForm_FormClosing);
            this.Controls.SetChildIndex(this.btnSend, 0);
            this.Controls.SetChildIndex(this.exListView, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private ExListView exListView;
        private System.Windows.Forms.Button btnClear;
    }
}