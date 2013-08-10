using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public class Soldier : BaseModel, ISoldier
    {
        private BitmapImage _bitmap;
        private int _wins;
        private int _losses;

        public Soldier()
        {}

        [ExcludeFromSerialization]
        public DateTime UpdateTime { get; set; }
        public IUser User { get; set; }
        public int Rank { get; set; }               // rank
        [ExcludeFromSerialization]
        public BitmapImage RankImage
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged("RankImage"); }
        }
        public string RankImageName { get; set; }
        public TimeSpan TimePlayed { get; set; }    // timePlayed
        public int RoundsPlayed { get; set; }
        public double Skill { get; set; }           // elo
        public double KillDeathRatio { get; set; }  // kdRatio
        public int Wins                             // numWins
        {
            get { return _wins; }
            set
            {
                _wins = value;
                CalculateWinLoseRatio();
            }
        }
        public int Losses                           // numLosses
        {
            get { return _losses; }
            set
            {
                _losses = value;
                CalculateWinLoseRatio();
            }
        }
        [ExcludeFromSerialization]     
        public double WinLoseRatio { get; set; }
        public IScore Score { get; set; }
        public double ScorePerMinute { get; set; }     // scorePerMinute
        public List<IKitProgression> KitProgressions { get; set; }
        public List<IItem> Weapons { get; set; }
        public List<IItem> Vehicles { get; set; }
        public List<IItem> Gadgets { get; set; }
        public List<IAward> Awards { get; set; }
        public List<IUnlock> Unlocks { get; set; }
        public IStatistics Statistics { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "User=[{0}], Rank={1}, TimePlayed={2}, Skill={3}, KillDeathRatio={4}, Wins={5}, " +
                    "Losses={6}, WinLoseRatio={7}, Score=[{8}], ScorePerMinute={9}, KitProgressions=[{10}],  " + 
                    "TopWeapons={11}, TopVehicles=[{12}], TopGadgets=[{13}], Awards=[{14}], Statistics=[{15}]", 
                    User, Rank, TimePlayed.ToString(), Skill, KillDeathRatio, Wins, Losses, WinLoseRatio,
                    Score, ScorePerMinute, KitProgressions, Weapons, Vehicles, Gadgets, Awards, Statistics);
        }

        private void CalculateWinLoseRatio()
        {
            if (_wins > 0 && _losses > 0)
                WinLoseRatio = Convert.ToDouble(_wins, CultureInfo.InvariantCulture) / Convert.ToDouble(_losses, CultureInfo.InvariantCulture);
            else
                WinLoseRatio = 0d;
        }
    }
}