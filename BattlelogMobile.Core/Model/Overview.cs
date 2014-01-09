using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    public class Overview : BaseModel
    {
        private int _rank;
        [JsonProperty(PropertyName = "rank")]
        public int Rank
        {
            get { return _rank; } 
            set
            {
                _rank = value;
                RaisePropertyChanged("Rank");

                string imageName = _rank <= Common.MaxRank ?
                                       Common.RankImagePrefix + _rank.ToString(CultureInfo.InvariantCulture) + Common.ImageSuffix :
                                       Common.RankServiceStarImagePrefix + (_rank - Common.MaxRank).ToString(CultureInfo.InvariantCulture) + Common.ImageSuffix;
                RankImageName = imageName;
            }
        }

        private string _rankImageName;
        [JsonIgnore]
        public string RankImageName
        {
            get { return _rankImageName; }
            set
            {
                if (value == null || value == _rankImageName)
                    return;

                _rankImageName = value;

                Task.Factory.StartNew(() =>
                    {
                        var r = new ImageRepository();
                        DispatcherHelper.CheckBeginInvokeOnUI(() =>
                                                              r.Load(Common.RankImageUrl, _rankImageName, bitmap => RankImage = bitmap));
                    });
            }
        }

        private BitmapImage _rankImage;
        [JsonIgnore]
        [ExcludeFromSerialization]
        public BitmapImage RankImage
        {
            get { return _rankImage; }
            set
            {
                _rankImage = value;
                RaisePropertyChanged("RankImage");
            }
        }

        private double _skill;
        [JsonProperty(PropertyName = "elo")]
        public double Skill
        {
            get { return _skill; }
            set
            {
                _skill = value;
                RaisePropertyChanged("Skill");
            }
        }

        private double _timePlayedSeconds;
        [JsonProperty(PropertyName = "timePlayed")]
        public double TimePlayedSeconds
        {
            get { return _timePlayedSeconds; }
            set
            {
                _timePlayedSeconds = value;
                TimePlayed = TimeSpan.FromSeconds(_timePlayedSeconds);
            }
        }

        private TimeSpan _timePlayed;
        [JsonIgnore]
        public TimeSpan TimePlayed
        {
            get { return _timePlayed; }
            set
            {
                _timePlayed = value;
                RaisePropertyChanged("TimePlayed");
            }
        }

        private int _roundsPlayed;
        [JsonProperty(PropertyName = "numRounds")]
        public int RoundsPlayed
        {
            get { return _roundsPlayed; }
            set
            {
                _roundsPlayed = value;
                RaisePropertyChanged("RoundsPlayed");
            }
        }

        private double _scorePerMinute;
        [JsonProperty(PropertyName = "scorePerMinute")]
        public double ScorePerMinute
        {
            get { return _scorePerMinute; }
            set
            {
                _scorePerMinute = value;
                RaisePropertyChanged("ScorePerMinute");
            }
        }

        private int? _kills;
        [JsonProperty(PropertyName = "kills")]
        public int? Kills
        {
            get { return _kills; }
            set
            {
                _kills = value;
                RaisePropertyChanged("Kills");
                SetKillDeathRatio();
            }
        }

        private int? _deaths;
        [JsonProperty(PropertyName = "deaths")]
        public int? Deaths
        {
            get { return _deaths; }
            set
            {
                _deaths = value;
                RaisePropertyChanged("Deaths");
                SetKillDeathRatio();
            }
        }

        private double _killDeathRatio;
        [JsonIgnore]
        public double KillDeathRatio
        {
            get { return _killDeathRatio; }
            set
            {
                _killDeathRatio = value;
                RaisePropertyChanged("KillDeathRatio");
            }
        }

        private int _wins;
        [JsonProperty(PropertyName = "numWins")]
        public int Wins
        {
            get { return _wins; }
            set
            {
                _wins = value;
                RaisePropertyChanged("Wins");
            }
        }

        private int _losses;
        [JsonProperty(PropertyName = "numLosses")]
        public int Losses
        {
            get { return _losses; }
            set
            {
                _losses = value;
                RaisePropertyChanged("Losses");
            }
        }

        private List<KitServiceStar> _kitServiceStars;
        [JsonIgnore]
        public List<KitServiceStar> KitServiceStars
        {
            get { return _kitServiceStars; }
            set
            {
                _kitServiceStars = value;
                RaisePropertyChanged("KitServiceStars");
            }
        }

        private JObject _rawStars;
        [JsonProperty(PropertyName = "serviceStars")]
        [ExcludeFromSerialization]
        public JObject RawStars
        {
            get { return _rawStars; }
            set
            {
                _rawStars = value;
                SetServiceStars();
            }
        }

        private JObject _rawProgression;
        [JsonProperty(PropertyName = "serviceStarsProgress")]
        [ExcludeFromSerialization]
        public JObject RawProgression
        {
            get { return _rawProgression; }
            set
            {
                _rawProgression = value;
                SetServiceStars();
            }
        }

        private JObject _rawScore;
        [JsonProperty(PropertyName = "kitScores")]
        [ExcludeFromSerialization]
        public JObject RawScore
        {
            get { return _rawScore; }
            set
            {
                _rawScore = value;
                SetServiceStars();
            }
        }

        private JObject _rawPercentage;
        [JsonProperty(PropertyName = "kitTimesInPercentage")]
        [ExcludeFromSerialization]
        public JObject RawPercentage
        {
            get { return _rawPercentage; }
            set
            {
                _rawPercentage = value;
                SetServiceStars();
            }
        }

        private int _totalScore;
        [JsonProperty(PropertyName = "totalScore")]
        public int TotalScore
        {
            get { return _totalScore; }
            set
            {
                _totalScore = value;
                RaisePropertyChanged("TotalScore");
            }
        }

        private int _vehicles;
        [JsonProperty(PropertyName = "sc_vehicle")]
        public int Vehicles
        {
            get { return _vehicles; }
            set
            {
                _vehicles = value;
                RaisePropertyChanged("Vehicles");
            }
        }

        private int _combat;
        [JsonProperty(PropertyName = "combatScore")]
        public int Combat
        {
            get { return _combat; }
            set
            {
                _combat = value;
                RaisePropertyChanged("Combat");
            }
        }

        private int _awards;
        [JsonProperty(PropertyName = "sc_award")]
        public int Awards
        {
            get { return _awards; }
            set
            {
                _awards = value;
                RaisePropertyChanged("Awards");
            }
        }

        private int _unlocks;
        [JsonProperty(PropertyName = "sc_unlock")]
        public int Unlocks
        {
            get { return _unlocks; }
            set
            {
                _unlocks = value;
                RaisePropertyChanged("Unlocks");
            }
        }

        private int _killAssists;
        [JsonProperty(PropertyName = "killAssists")]
        public int KillAssists
        {
            get { return _killAssists; }
            set
            {
                _killAssists = value;
                RaisePropertyChanged("KillAssists");
            }
        }

        private int _vehiclesDestroyed;
        [JsonProperty(PropertyName = "vehiclesDestroyed")]
        public int VehiclesDestroyed
        {
            get { return _vehiclesDestroyed; }
            set
            {
                _vehiclesDestroyed = value;
                RaisePropertyChanged("VehiclesDestroyed");
            }
        }

        private int _vehiclesDestroyedAssists;
        [JsonProperty(PropertyName = "vehiclesDestroyedAssists")]
        public int VehiclesDestroyedAssists
        {
            get { return _vehiclesDestroyedAssists; }
            set
            {
                _vehiclesDestroyedAssists = value;
                RaisePropertyChanged("VehiclesDestroyedAssists");
            }
        }

        private double _accuracy;
        [JsonProperty(PropertyName = "accuracy")]
        public double Accuracy
        {
            get { return _accuracy; }
            set
            {
                _accuracy = value;
                RaisePropertyChanged("Accuracy");
            }
        }

        private double _longestHeadshot;
        [JsonProperty(PropertyName = "longestHeadshot")]
        public double LongestHeadshot
        {
            get { return _longestHeadshot; }
            set
            {
                _longestHeadshot = value;
                RaisePropertyChanged("LongestHeadshot");
            }
        }

        private int _killStreakBonus;
        [JsonProperty(PropertyName = "killStreakBonus")]
        public int KillStreakBonus
        {
            get { return _killStreakBonus; }
            set
            {
                _killStreakBonus = value;
                RaisePropertyChanged("KillStreakBonus");
            }
        }

        private int _squadScoreBonus;
        [JsonProperty(PropertyName = "sc_squad")]
        public int SquadScoreBonus
        {
            get { return _squadScoreBonus; }
            set
            {
                _squadScoreBonus = value;
                RaisePropertyChanged("SquadScoreBonus");
            }
        }

        private int _repairs;
        [JsonProperty(PropertyName = "repairs")]
        public int Repairs
        {
            get { return _repairs; }
            set
            {
                _repairs = value;
                RaisePropertyChanged("Repairs");
            }
        }

        private int _revices;
        [JsonProperty(PropertyName = "revives")]
        public int Revives
        {
            get { return _revices; }
            set
            {
                _revices = value;
                RaisePropertyChanged("Revives");
            }
        }

        private int _heals;
        [JsonProperty(PropertyName = "heals")]
        public int Heals
        {
            get { return _heals; }
            set
            {
                _heals = value;
                RaisePropertyChanged("Heals");
            }
        }

        private int _resupplies;
        [JsonProperty(PropertyName = "resupplies")]
        public int Resupplies
        {
            get { return _resupplies; }
            set
            {
                _resupplies = value;
                RaisePropertyChanged("Resupplies");
            }
        }

        private long _shotsFired;
        [JsonProperty(PropertyName = "shotsFired")]
        public long ShotsFired
        {
            get { return _shotsFired; }
            set
            {
                _shotsFired = value;
                RaisePropertyChanged("ShotsFired");
            }
        }

        private double _quits;
        [JsonProperty(PropertyName = "quitPercentage")]
        public double Quits
        {
            get { return _quits; }
            set
            {
                _quits = value;
                RaisePropertyChanged("Quits");
            }
        }

        private int _mcomDefendKills;
        [JsonProperty(PropertyName = "mcomDefendKills")]
        public int MCOMDefendKills
        {
            get { return _mcomDefendKills; }
            set
            {
                _mcomDefendKills = value;
                RaisePropertyChanged("MCOMDefendKills");
            }
        }

        private int _mcomDestroyed;
        [JsonProperty(PropertyName = "mcomDestroy")]
        public int MCOMDestroyed
        {
            get { return _mcomDestroyed; }
            set
            {
                _mcomDestroyed = value;
                RaisePropertyChanged("MCOMDestroyed");
            }
        }

        private int _flagsCaptured;
        [JsonProperty(PropertyName = "flagCaptures")]
        public int FlagsCaptured
        {
            get { return _flagsCaptured; }
            set
            {
                _flagsCaptured = value;
                RaisePropertyChanged("FlagsCaptured");
            }
        }

        private int _flagsDefended;
        [JsonProperty(PropertyName = "flagDefend")]
        public int FlagsDefended
        {
            get { return _flagsDefended; }
            set
            {
                _flagsDefended = value;
                RaisePropertyChanged("FlagsDefended");
            }
        }

        private int _avengerKills;
        [JsonProperty(PropertyName = "avengerKills")]
        public int AvengerKills
        {
            get { return _avengerKills; }
            set
            {
                _avengerKills = value;
                RaisePropertyChanged("AvengerKills");
            }
        }

        private int _saviorKills;
        [JsonProperty(PropertyName = "saviorKills")]
        public int SaviorKills
        {
            get { return _saviorKills; }
            set
            {
                _saviorKills = value;
                RaisePropertyChanged("SaviorKills");
            }
        }

        private int _dogtagsTaken;
        [JsonProperty(PropertyName = "dogtagsTaken")]
        public int DogtagsTaken
        {
            get { return _dogtagsTaken; }
            set
            {
                _dogtagsTaken = value;
                RaisePropertyChanged("DogtagsTaken");
            }
        }

        private int _flagsCapturedCtf;
        [JsonProperty(PropertyName = "flagrunner")]
        public  int FlagsCapturedCTF
        {
            get { return _flagsCapturedCtf; }
            set
            {
                _flagsCapturedCtf = value;
                RaisePropertyChanged("FlagsCapturedCTF");
            }
        }

        private int _nemesisStreak;
        [JsonProperty(PropertyName = "nemesisStreak")]
        public int NemesisStreak
        {
            get { return _nemesisStreak; }
            set
            {
                _nemesisStreak = value;
                RaisePropertyChanged("NemesisStreak");
            }
        }

        private int _nemesisKills;
        [JsonProperty(PropertyName = "nemesisKills")]
        public int NemesisKills
        {
            get { return _nemesisKills; }
            set
            {
                _nemesisKills = value;
                RaisePropertyChanged("NemesisKills");
            }
        }

        private int _suppressionAssists;
        [JsonProperty(PropertyName = "suppressionAssists")]
        public int SuppressionAssists
        {
            get { return _suppressionAssists; }
            set
            {
                _suppressionAssists = value;
                RaisePropertyChanged("SuppressionAssists");
            }
        }

        private double _winLoseRatio;
        [JsonProperty(PropertyName = "wlRatio")]
        public double WinLoseRatio
        {
            get { return _winLoseRatio; }
            set
            {
                _winLoseRatio = value;
                RaisePropertyChanged("WinLoseRatio");
            }
        }

        private int _shotsHit;
        [JsonProperty(PropertyName = "shotsHit")]
        public int ShotsHit
        {
            get { return _shotsHit; }
            set
            {
                _shotsHit = value;
                RaisePropertyChanged("ShotsHit");
            }
        }

        //public int sc_general { get; set; }
        //public long rankScore { get; set; }
        //public int sc_objective { get; set; }
        //public int sc_team { get; set; }
        //public long sc_bonus { get; set; }
        //public long score { get; set; }

        private void SetKillDeathRatio()
        {
            if (!Kills.HasValue || !Deaths.HasValue)
                return;

            KillDeathRatio = Math.Round(((double)Kills.Value / (double)Deaths.Value), 2);
        }

        private void SetServiceStars()
        {
            if (RawStars == null || RawProgression == null || RawScore == null || RawPercentage == null)
                return;

            _kitServiceStars = new List<KitServiceStar>();
            foreach (var token in RawStars)
            {
                var star = new KitServiceStar();
                star.Type = (KitType)int.Parse(token.Key);
                star.Stars = int.Parse(token.Value.ToString());
                _kitServiceStars.Add(star);
            }

            foreach (var token in RawProgression)
            {
                var current = (KitType)int.Parse(token.Key);
                var type = _kitServiceStars.FirstOrDefault(s => s.Type == current);
                if (type != null)
                    type.Progression = double.Parse(token.Value.ToString());
            }
           
            foreach (var token in RawScore)
            {
                var current = (KitType)int.Parse(token.Key);
                var type = _kitServiceStars.FirstOrDefault(s => s.Type == current);
                if (type != null)
                    type.Score = int.Parse(token.Value.ToString());
            }

            foreach (var token in RawPercentage)
            {
                var current = (KitType)int.Parse(token.Key);
                var type = _kitServiceStars.FirstOrDefault(s => s.Type == current);
                if (type != null)
                    type.Percentage = double.Parse(token.Value.ToString());
            }

            KitServiceStars = _kitServiceStars;
        }
    }
}