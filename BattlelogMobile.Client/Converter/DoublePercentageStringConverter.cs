using System;
using System.Globalization;
using System.Windows.Data;

namespace BattlelogMobile.Client.Converter
{
    /// <summary>
    /// Convert double value to percentage
    /// </summary>
    public class DoublePercentageStringConverter : IValueConverter
    {
        private const string PercentageFormat = "0.0";
        private const string Suffix = "%";

        /// <summary>
        /// Return format is "0.0%"
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (System.Convert.ToDouble(value).ToString(PercentageFormat, CultureInfo.InvariantCulture)) + Suffix;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}