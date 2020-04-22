﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicEnergyTest.UI
{
    public partial class FlashBinFilesCtrl : UserControl
    {
        private const int MARGIN = 10;

        private Rectangle _dragRectangle;

        private string dragFile;
        private string supportFile;
        //private Image dragFileImage;
        private Button loadButton;

        public FlashBinFilesCtrl()
        {
            InitializeComponent();
            dragFile = "点击或将固件拖拽到这里上传";
            supportFile = "支持扩展名: .bin";
            InitializeLoadButton();
        }

        private void InitializeLoadButton()
        {
            loadButton = new Button();
            this.loadButton.BackColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.loadButton.FlatStyle = FlatStyle.Flat;
            this.loadButton.ForeColor = Color.White;
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new Size(88, 30);
            this.loadButton.TabIndex = 11;
            this.loadButton.Text = "加载文件";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += LoadButton_Click;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _dragRectangle = new Rectangle(2 * MARGIN, MARGIN, this.Width / 2 - 2 * MARGIN, this.Height - 2 * MARGIN);
            loadButton.Location = new Point(_dragRectangle.X + (_dragRectangle.Width - loadButton.Width) / 2, _dragRectangle.Y + (_dragRectangle.Height - loadButton.Height) / 2);
            this.Controls.Add(loadButton);
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

            g.FillRectangle(Brushes.White, MARGIN,  0, this.Width - 2 * MARGIN, this.Height);
            Pen pen = new Pen(Color.LightGray, 1.5f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.DrawRectangle(pen, _dragRectangle);
            g.FillRectangle(Brushes.LightGray, _dragRectangle);

            var dragFileSize = g.MeasureString(dragFile, this.Font);
            var supportFileSize = g.MeasureString(supportFile, this.Font);
            g.DrawString(dragFile, this.Font, Brushes.Black, _dragRectangle.X + (_dragRectangle.Width - dragFileSize.Width) / 2, _dragRectangle.Height / 2 + 40);
            g.DrawString(supportFile, this.Font, Brushes.Black, _dragRectangle.X + (_dragRectangle.Width - dragFileSize.Width) / 2, _dragRectangle.Height / 2 + 60);

            pen.Dispose();
            //g.DrawPath
        }
    }
}