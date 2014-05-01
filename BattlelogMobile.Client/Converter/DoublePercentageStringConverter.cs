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
            try
            {
                if (value == null)
                    return "n/a";

                int multiplier = 1;
                if (parameter != null)
                    int.TryParse(parameter.ToString(), out multiplier);

                // :(((((
                double val;
                double.TryParse(value.ToString(), out val);
                if (Math.Abs(val - 0d) < 0.001)
                    double.TryParse(value.ToString().Replace(".", ","), out val);

                var percentage = ((val * multiplier).ToString(PercentageFormat, CultureInfo.InvariantCulture)) + Suffix;
                return percentage;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}