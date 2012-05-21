using System;
using System.Globalization;
using System.Windows.Media.Imaging;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    public class OverviewPanorama : BaseModel, IOverviewPanorama
    {
        private int _wins;
        private int _losses;
        private BitmapImage _rankImage;

        public IUser User { get; set; }
        public int Rank { get; set; }
        [ExcludeFromSerializationAttribute]
        public BitmapImage RankImage
        {
            get { return _rankImage; }
            set { _rankImage = value; RaisePropertyChanged("RankImage");  }
        }
        public TimeSpan TimePlayed { get; set; }
        public double Skill { get; set; }
        public double KillDeathRatio { get; set; }
        public double WinLoseRatio { get; set; }
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
        public int ScorePerMinute { get; set; }

        private void CalculateWinLoseRatio()
        {
            if (_wins > 0 && _losses > 0)
                WinLoseRatio = Convert.ToDouble(_wins, CultureInfo.InvariantCulture) / Convert.ToDouble(_losses, CultureInfo.InvariantCulture);
            else
                WinLoseRatio = 0d;
        }
    }
}