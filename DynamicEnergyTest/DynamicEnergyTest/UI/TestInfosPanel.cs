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
    public partial class TestInfosPanel : UserControl
    {
        private const int MARGIN = 10;
        private const int GAP = 20;
        private const int SUBITEMWIDTH = 150;
        private Rectangle _testPlanRectangle;
        private Rectangle _unTestRectangle;
        private Rectangle _testedRectangle;

        private string _testPlanStr;
        private string _unTestStr;
        private string _testedStr;

        private int _testPlanCount;
        public int TestPlanCount
        {
            get { return _testPlanCount; }
            set { _testPlanCount = value; }
        }

        private int _unTestCount;
        public int UnTestCount
        {
            get { return _unTestCount; }
            set { _unTestCount = value; }
        }

        private int _testedCount;
        public int TestedCount
        {
            get { return _testedCount; }
            set { _testedCount = value; }
        }

        private int _passCount;
        public int PassCount
        {
            get { return _passCount; }
            set { _passCount = value; }
        }

        private int _failureCount;
        public int FailureCount
        {
            get { return _failureCount; }
            set { _failureCount = value; }
        }

        private string _subTotal;
        private string _subPass;
        private string _subFail;
        private string _subPassRate;
        private SysConfig sysConfig;

        public TestInfosPanel()
        {
            InitializeComponent();
            _testPlanStr = "计划测试数";
            _unTestStr = "待测试";
            _testedStr = "已测试";

            _subTotal = "总计";
            _subPass = "成功";
            _subFail = "失败";
            _subPassRate = "通过率";

            TestPlanCount = 0;
            UnTestCount = 0;
            TestedCount = 0;
            PassCount = 0;
            FailureCount = TestedCount - PassCount;

            sysConfig = SysConfig.GetConfig();
            sysConfig.UpdateTestInfoHandler += UpdateTestInfosHandler;
        }

        private void UpdateTestInfosHandler(object sender, EventArgs e)
        {
            var uids = sysConfig.UIDs;

            TestPlanCount = uids.Count();
            UnTestCount = uids.Where(uid => uid.TestStatus == TestStatus.UnTest).Count();
            PassCount = uids.Where(uid => uid.TestStatus == TestStatus.Pass).Count();
            TestedCount = TestPlanCount - UnTestCount;
            FailureCount = uids.Where(uid => uid.TestStatus == TestStatus.Fail).Count();
            this.Invalidate();
        }

        public void UpdateTestInfos()
        {
            var uids = sysConfig.UIDs;

            TestPlanCount = uids.Count();
            UnTestCount = uids.Where(uid => uid.TestStatus == TestStatus.UnTest).Count();
            TestedCount = TestPlanCount - UnTestCount;
            FailureCount = uids.Where(uid => uid.TestStatus == TestStatus.Fail).Count();
            this.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _testPlanRectangle = new Rectangle(MARGIN, MARGIN, SUBITEMWIDTH, this.Height - 2 * MARGIN);
            _unTestRectangle = new Rectangle(_testPlanRectangle.X + SUBITEMWIDTH + MARGIN, MARGIN, SUBITEMWIDTH, this.Height - 2 * MARGIN);
            _testedRectangle = new Rectangle(_unTestRectangle.X + SUBITEMWIDTH + MARGIN, MARGIN, this.Width - 4 * MARGIN - 2 * SUBITEMWIDTH, this.Height - 2 * MARGIN);
            UpdateTestInfos();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //draw rectangles back color
            using (SolidBrush sb = new SolidBrush(Color.White))
            {
                g.FillRectangles(sb, new Rectangle[] { _testPlanRectangle, _unTestRectangle, _testedRectangle });
            }

            int ellipseMargin = 10;
            int ellipseWH = 10;
            int strMargin = 10;
            int countMarginH = 10;

            //Test Plan
            SolidBrush testPlanSb = new SolidBrush(GraphicFactory.DynamicBlue);
            Font font = GraphicFactory.CreateFont();
            Font countFont = GraphicFactory.CreateFont(20F, FontStyle.Bold);
            g.FillEllipse(testPlanSb, _testPlanRectangle.X + ellipseMargin, _testPlanRectangle.Y + ellipseMargin, ellipseWH, ellipseWH);
            g.DrawString(_testPlanStr, font, Brushes.Black, _testPlanRectangle.X + ellipseMargin + ellipseWH + strMargin, _testPlanRectangle.Y + ellipseMargin);
            string testPlan = TestPlanCount.ToString();
            var size1 = g.MeasureString(testPlan, countFont);
            g.DrawString(testPlan, countFont, Brushes.Black, _testPlanRectangle.X + (_testPlanRectangle.Width - size1.Width) / 2, _testPlanRectangle.Height / 2 + countMarginH);

            //Untest 
            SolidBrush unTestedSb = new SolidBrush(GraphicFactory.DynamicOrange);
            g.FillEllipse(unTestedSb, _unTestRectangle.X + ellipseMargin, _unTestRectangle.Y + ellipseMargin, ellipseWH, ellipseWH);
            g.DrawString(_unTestStr, font, Brushes.Black, _unTestRectangle.X + ellipseMargin + ellipseWH + strMargin, _unTestRectangle.Y + ellipseMargin);
            string unTest = UnTestCount.ToString();
            var size2 = g.MeasureString(unTest, countFont);
            g.DrawString(unTest, countFont, Brushes.Black, _unTestRectangle.X + (_unTestRectangle.Width - size2.Width) / 2, _unTestRectangle.Height / 2 + countMarginH);

            //Tested
            SolidBrush testedSb = new SolidBrush(Color.DarkGreen);
            g.FillEllipse(testedSb, _testedRectangle.X + ellipseMargin, _testedRectangle.Y + ellipseMargin, ellipseWH, ellipseWH);
            g.DrawString(_testedStr, font, Brushes.Black, _testedRectangle.X + ellipseMargin + ellipseWH + strMargin, _testedRectangle.Y + ellipseMargin);
            string totalTested = TestedCount.ToString();
            string pass = PassCount.ToString();
            string fail = FailureCount.ToString();
            string passRate = TestedCount == 0 ? "0" : string.Format("{0:P}", PassCount / (double)TestedCount);

            int subItemWidth = _testedRectangle.Width / 4;
            int subItemGap = 30;

            var TotalSize = g.MeasureString(totalTested, countFont);
            var Pass = g.MeasureString(pass, countFont);
            var Fail = g.MeasureString(fail, countFont);
            var PassRate = g.MeasureString(passRate, countFont);

            var subTotalSize = g.MeasureString(_subTotal, font);
            var subPass = g.MeasureString(_subPass, font);
            var subFail = g.MeasureString(_subFail, font);
            var subPassRate = g.MeasureString(_subPassRate, font);

            g.DrawString(_subTotal, font, Brushes.Black, _testedRectangle.X + (subItemWidth - subTotalSize.Width) / 2, _testedRectangle.Y + subItemGap);
            g.DrawString(_subPass, font, Brushes.DarkGreen, _testedRectangle.X + subItemWidth + (subItemWidth - subPass.Width) / 2, _testedRectangle.Y + subItemGap);
            g.DrawString(_subFail, font, Brushes.Red, _testedRectangle.X + 2 * subItemWidth + (subItemWidth - subFail.Width) / 2, _testedRectangle.Y + subItemGap);
            g.DrawString(_subPassRate, font, Brushes.DarkGreen, _testedRectangle.X + 3 * subItemWidth + (subItemWidth - subPassRate.Width) / 2, _testedRectangle.Y + subItemGap);

            g.DrawString(totalTested, countFont, Brushes.Black, _testedRectangle.X + (subItemWidth - TotalSize.Width) / 2, _unTestRectangle.Height / 2 + countMarginH);
            g.DrawString(pass, countFont, Brushes.DarkGreen, _testedRectangle.X + subItemWidth + (subItemWidth - Pass.Width) / 2, _unTestRectangle.Height / 2 + countMarginH);
            g.DrawString(fail, countFont, Brushes.Red, _testedRectangle.X + 2 * subItemWidth + (subItemWidth - Fail.Width) / 2, _unTestRectangle.Height / 2 + countMarginH);
            g.DrawString(passRate, countFont, Brushes.DarkGreen, _testedRectangle.X + 3 * subItemWidth + (subItemWidth - PassRate.Width) / 2, _unTestRectangle.Height / 2 + countMarginH);

            //draw spilt line
            Pen pen = new Pen(Color.Black, 1.5f);
            int lineMargin = 35;
            g.DrawLine(pen, _testedRectangle.X + subItemWidth, _testedRectangle.Y + lineMargin, _testedRectangle.X + subItemWidth, _testedRectangle.Y + _testedRectangle .Height - lineMargin);
            g.DrawLine(pen, _testedRectangle.X + 2 * subItemWidth, _testedRectangle.Y + lineMargin, _testedRectangle.X + 2 * subItemWidth, _testedRectangle.Y + _testedRectangle.Height - lineMargin);
            g.DrawLine(pen, _testedRectangle.X + 3 * subItemWidth, _testedRectangle.Y + lineMargin, _testedRectangle.X + 3 * subItemWidth, _testedRectangle.Y + _testedRectangle.Height - lineMargin);
            testPlanSb.Dispose();
            font.Dispose();
            countFont.Dispose();
            unTestedSb.Dispose();
            testedSb.Dispose();
            pen.Dispose();
        }
    }
}
