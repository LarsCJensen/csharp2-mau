using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyGames.Converters
{
    /// <summary>
    /// Convert boolean to string
    /// </summary>
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if(targetType == typeof(bool) && value != null)
            {            
                // If true return 'Yes', else 'No'
                if ((bool)value == true)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }            
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
