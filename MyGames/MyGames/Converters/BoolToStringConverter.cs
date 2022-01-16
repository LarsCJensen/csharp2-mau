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
            
            if(targetType == typeof(string) && value != null)
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
            // Also return "No" if null
            if(value == null)
            {
                return "No";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
