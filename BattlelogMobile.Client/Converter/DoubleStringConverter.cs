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
            bool wasNumeric = false;
            string ratioFormat = RatioFormat;
            if (parameter != null)
            {
                double doubleValue;
                wasNumeric = double.TryParse(parameter.ToString(), out doubleValue);
                if (wasNumeric)
                    ratioFormat = parameter.ToString();
            }

            string formatted = System.Convert.ToDouble(value, CultureInfo.InvariantCulture).ToString(ratioFormat, CultureInfo.InvariantCulture);
            if (parameter != null && !wasNumeric)
                formatted += parameter.ToString();
            
            return formatted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
