using System;
using System.Globalization;
using System.Windows.Data;

namespace BattlelogMobile.Client.Converter
{
    /// <summary>
    /// Convert TimeSpan to string presentation
    /// </summary>
    public class TimeSpanStringConverter : IValueConverter
    {
        private const string Format = "00";
        private const string Hours = "h ";
        private const string Minutes = "m";

        /// <summary>
        /// Return hours and minutes, format is "00h 00m";
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var span = (TimeSpan)value;
            return ((span.Days * 24) + span.Hours).ToString(Format) + Hours + span.Minutes.ToString(Format) + Minutes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
