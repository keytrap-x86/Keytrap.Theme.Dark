using System;
using System.Globalization;
using System.Windows.Data;

namespace Keytrap.Theme.Dark.Tools.Converter
{
    public class DivideByTwoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double numeric)
            {
                return numeric / 2 - 5;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}