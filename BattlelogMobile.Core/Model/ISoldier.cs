using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface ISoldier
    {
        DateTime UpdateTime { get; set; }
        IUser User { get; set; }                        // Panorama 1
        int Rank { get; set; }                          // Panorama 1
        BitmapImage RankImage { get; set; }             // Panorama 1
        string RankImageName { get; set; }
        TimeSpan TimePlayed { get; set; }               // Panorama 1
        int RoundsPlayed { get; set; }
        double Skill { get; set; }                      // Panorama 1
        double KillDeathRatio { get; set; }             // Panorama 1
        int Wins { get; set; }
        int Losses { get; set; }
        double WinLoseRatio { get; set; }               // Panorama 1
        IScore Score { get; set; }                      // Panorama 2, 4
        double ScorePerMinute { get; set; }             // Panorama 1
        List<IKitProgression> KitProgressions { get; set; }  // Panorama 3
        List<IItem> Weapons { get; set; }        // Panorama 5
        List<IItem> Vehicles { get; set; }       // Panorama 6
        List<IItem> Gadgets { get; set; }        // Panorama 7
        List<IAward> Awards { get; set; }        // Panorama 8
        List<IUnlock> Unlocks { get; set; }      // Panorama 9
        IStatistics Statistics { get; set; }            // Panorama 10
    }
}