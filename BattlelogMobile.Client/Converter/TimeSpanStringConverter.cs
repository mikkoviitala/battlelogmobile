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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var span = (TimeSpan)value;

            if (parameter == null || string.CompareOrdinal(parameter.ToString(), "full") != 0)
                return FormatAsHoursAndMinutes(span);
            return FormatAsCompleteUnits(span);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static string FormatAsHoursAndMinutes(TimeSpan span)
        {
            return string.Format("{0}h {1}m", ((span.Days * 24) + span.Hours).ToString("00"), span.Minutes.ToString("00"));
        }

        private static string FormatAsCompleteUnits(TimeSpan span)
        {
            long days = (long) Math.Floor(span.TotalDays);
            long hours = (long) Math.Floor(span.TotalHours);
            long minutes = (long) Math.Floor(span.TotalMinutes);

            if (days > 0)
                return string.Format(days == 1 ? "{0} day" : "{0} days", days);
            if (hours > 0)
                return string.Format(hours == 1 ? "{0} hour" : "{0} hours", hours);
            if (minutes > 0)
                return string.Format(minutes == 1 ? "{0} minute" : "{0} minutes", minutes);

            return "Less than a minute";
        }
    }
}
