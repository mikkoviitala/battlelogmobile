using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BattlelogMobile.Client.Converter
{
    /// <summary>
    /// Converts integer to Visibility enum
    /// </summary>
    public class IntegerVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// All values greater than zero (0) are treated as Visible, any other Collapsed 
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                int intValue = int.Parse(value.ToString());
                return intValue > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            throw new ArgumentException("Value must be type of int", "value");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
