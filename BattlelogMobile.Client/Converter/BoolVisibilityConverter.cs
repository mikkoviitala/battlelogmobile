using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BattlelogMobile.Client.Converter
{
    /// <summary>
    /// Convert boolean value to Visibility enumeration.
    /// </summary>
    public class BoolVisibilityConverter : IValueConverter
    {
        private const string ReverseResult = "reverse";

        /// <summary>
        /// If you need the opposite value of direct conversion, provide "reverse" as converter parameter.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = Visibility.Collapsed;
            if (System.Convert.ToBoolean(value))
                visibility = Visibility.Visible;
            
            if (parameter != null && parameter.ToString().ToLowerInvariant().Equals(ReverseResult))
                visibility = visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            else if (parameter != null)
                throw new ArgumentException("Unkown converter parameter");
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
