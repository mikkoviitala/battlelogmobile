using System;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface ISoldier
    {
        DateTime UpdateTime { get; }
        IUser User { get; set; }                        // Panorama 1
        int Rank { get; set; }                          // Panorama 1
        BitmapImage RankImage { get; set; }             // Panorama 1
        TimeSpan TimePlayed { get; set; }               // Panorama 1
        double Skill { get; set; }                      // Panorama 1
        double KillDeathRatio { get; set; }             // Panorama 1
        int Wins { get; set; }
        int Losses { get; set; }
        double WinLoseRatio { get; set; }               // Panorama 1
        IScore Score { get; set; }                      // Panorama 2, 4
        int ScorePerMinute { get; set; }                // Panorama 1
        IKitProgressions KitProgressions { get; set; }  // Panorama 3
        IItems Weapons { get; set; }                    // Panorama 5
        IItems Vehicles { get; set; }                   // Panorama 6
        IItems Gadgets { get; set; }                    // Panorama 7
        IAwards Awards { get; set; }                    // Panorama 8
        IUnlocks Unlocks { get; set; }                  // Panorama 9
        IStatistics Statistics { get; set; }            // Panorama 10
    }
}