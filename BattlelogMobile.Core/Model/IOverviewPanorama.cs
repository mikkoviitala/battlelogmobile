using System;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface IOverviewPanorama
    {
        IUser User { get; set; }                        // Panorama 1
        int Rank { get; set; }                          // Panorama 1
        BitmapImage RankImage { get; set; }             // Panorama 1
        TimeSpan TimePlayed { get; set; }               // Panorama 1
        double Skill { get; set; }                      // Panorama 1
        double KillDeathRatio { get; set; }             // Panorama 1
        int Wins { get; set; }
        int Losses { get; set; }
        double WinLoseRatio { get; set; }               // Panorama 1
        int ScorePerMinute { get; set; }                // Panorama 1
    }
}