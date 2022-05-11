using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Assignment6
{
    public class BackgroundColorConverter : IValueConverter
    {
        /// <summary>
        /// Class to convert background color values for listView
        /// Used to show which items that are duplicates.
        /// </summary>
        private Dictionary<int, Color> _colors = new Dictionary<int, Color>();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FileClass file = (FileClass)value;
            Color newColor;
            if (_colors.Count == 0 || _colors.ContainsKey(file.DuplicateId) == false) {
                // Try to get a unique color 15 times and then just chose one that is not the same as last
                for (int i = 0; i < 15; i++)
                {
                    RandomColorGenerator randomColor = new RandomColorGenerator();
                    newColor = randomColor.randomBrush;
                    if(!_colors.ContainsValue(newColor))
                    {
                        break;
                    }
                }
                // If last random color was the same as last color, choose first color to prevent
                // color grouping to be misleading
                if(_colors.Count > 0 && _colors.Values.Last() == newColor)
                {
                    newColor = _colors.Values.First();
                }
                _colors[file.DuplicateId] = newColor;
            }
            return new SolidColorBrush(_colors[file.DuplicateId]);            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Is not used
            throw new NotImplementedException();
        }
    }
}
