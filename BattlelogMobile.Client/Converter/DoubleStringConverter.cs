using System;
using System.Globalization;
using System.Windows.Data;

namespace BattlelogMobile.Client.Converter
{
    /// <summary>
    /// Convert double value to string
    /// </summary>
    public class DoubleStringConverter : IValueConverter
    {
        private const string RatioFormat = "0.00";

        /// <summary>
        /// Return value format is "0.00", provide desired suffix as converter parameter
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string formatted = System.Convert.ToDouble(value, CultureInfo.InvariantCulture).ToString(RatioFormat, CultureInfo.InvariantCulture);
            if (parameter != null)
                formatted += parameter.ToString();
            return formatted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
