using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnergyTest.UI
{
    public static class GraphicFactory
    {
        public static Color DynamicBlue = Color.FromArgb(24,144,255);
        public static Color DynamicGray = Color.FromArgb(74, 74, 74);
        public static Color DynamicOrange = Color.FromArgb(255, 131, 26);
        public static Color DynamicGreen = Color.FromArgb(126, 211, 26);
        public static Color DynamicRed = Color.FromArgb(208, 2, 26);
        public static Color Pass = Color.DarkGreen;
        public static Color Failure = Color.Red;
        public static Color UnTested = Color.Orange;

        public static Font CreateFont()
        {
            return new Font("Microsoft Sans Serif", 10F);
        }

        public static Font CreateFont(float fontSize, FontStyle fontStyle = FontStyle.Regular)
        {
            return new Font("Microsoft Sans Serif", fontSize, fontStyle);
        }
    }
}
