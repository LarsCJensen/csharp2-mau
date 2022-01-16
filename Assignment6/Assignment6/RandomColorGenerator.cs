using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Assignment6
{
    /// <summary>
    /// Class to generate random colors to mark duplicates with
    /// </summary>
    public class RandomColorGenerator
    {
        public Color randomBrush { get; set; }
        private Random randomColor = new Random();
        private static uint[] uintColors = {
            0xFF34AADC,0xFFFF2D55,0xFF007AFF,0xFFFF9500,0xFF4CD964,
            0xFFFFCC00,0xFF5856D6,0xFFFF3B30,0xFFFF4981,0xFFFF3A2D
        };

        public RandomColorGenerator()
        {
            randomBrush = GenerateRandomColor();
        }

        private Color ConvertColor(uint uintCol)
        {
            byte A = (byte)((uintCol & 0xFF000000) >> 24);
            byte R = (byte)((uintCol & 0x00FF0000) >> 16);
            byte G = (byte)((uintCol & 0x0000FF00) >> 8);
            byte B = (byte)((uintCol & 0x000000FF) >> 0);
            return Color.FromArgb(A, R, G, B); ;
        }

        private Color GenerateRandomColor()
        {
            return ConvertColor(uintColors[randomColor.Next(0, 9)]);
        }
    }
}
