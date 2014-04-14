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
        /// Provide desired suffix as converter parameter, if any, return value format is "0.00"
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "0.00";

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
