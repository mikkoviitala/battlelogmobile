using System;
using System.Globalization;
using System.Windows.Data;
using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Client.Converter
{
    /// <summary>
    /// Concatenate user kills and assist, or vehicles destroyed and assists
    /// </summary>
    public class KillsAndAssistsStringConverter : IValueConverter
    {
        private const string Kills = "Kills";
        private const string Format = "### ### ###";

        /// <summary>
        /// Return value format is "### ### ### + ### ### ###",
        /// converter parameter determines whether kills or destroyes are returned 
        /// ("Kills" for kills, otherwise vehicle destroys)
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stats = (IStatistics) value;
            if (parameter != null && parameter.ToString().Equals(Kills))
                return stats.Kills.ToString(Format, CultureInfo.InvariantCulture).Trim() + "+" + 
                    stats.KillAssists.ToString(Format, CultureInfo.InvariantCulture).Trim();
            
            return stats.VehiclesDestroyed.ToString(Format).Trim() + "+" + 
                   stats.VehiclesDestroyedAssists.ToString(Format).Trim();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
