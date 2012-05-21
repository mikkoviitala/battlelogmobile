using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BattlelogMobile.Client.Converter
{
    /// <summary>
    /// Convert string length to Visibility enumeration
    /// </summary>
    public class StringLengthVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Returns Collapsed if string length is zero, otherwise Visible 
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                if (value.ToString().Length > 0)
                    return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
