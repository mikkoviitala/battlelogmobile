using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BattlelogMobile.Client.Converter
{
    public class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visible = System.Convert.ToBoolean(value);
            return visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visible = value is Visibility ? (Visibility) value : Visibility.Collapsed;
            return visible == Visibility.Visible;

        }
    }
}
