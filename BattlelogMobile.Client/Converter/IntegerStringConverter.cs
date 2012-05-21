using System;
using System.Globalization;
using System.Windows.Data;

namespace BattlelogMobile.Client.Converter
{
    /// <summary>
    /// Convert integer value to formatted string presentation
    /// </summary>
    public class IntegerStringConverter : IValueConverter
    {
        private const string ScoreFormat = "### ### ###";

        /// <summary>
        /// Return value format is "### ### ###", provide "AddEquals" as
        /// converter parameter if "=" sign in desired in from of the value
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string formatted = (System.Convert.ToDouble(value, CultureInfo.InvariantCulture).ToString(ScoreFormat, CultureInfo.InvariantCulture)).Trim();

            if (parameter != null && parameter.ToString().Equals("AddEquals"))
                formatted = "= " + formatted;
            else if (parameter != null)
                formatted += parameter.ToString();
            return formatted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
