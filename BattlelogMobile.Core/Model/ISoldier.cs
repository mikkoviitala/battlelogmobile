using System;
using System.Collections.Generic;
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
        double ScorePerMinute { get; set; }             // Panorama 1
        IEnumerable<IKitProgression> KitProgressions { get; set; }  // Panorama 3
        IEnumerable<IItem> Weapons { get; set; }        // Panorama 5
        IEnumerable<IItem> Vehicles { get; set; }       // Panorama 6
        IEnumerable<IItem> Gadgets { get; set; }        // Panorama 7
        IEnumerable<IAward> Awards { get; set; }        // Panorama 8
        IEnumerable<IUnlock> Unlocks { get; set; }      // Panorama 9
        IStatistics Statistics { get; set; }            // Panorama 10
    }
}