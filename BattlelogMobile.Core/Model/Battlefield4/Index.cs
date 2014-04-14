using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BattlelogMobile.Core.Service;
using Newtonsoft.Json;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Index
    {
        public class OriginalPersona
        {
            public string picture { get; set; }
            public string userId { get; set; }
            public object user { get; set; }
            public int updatedAt { get; set; }
            public string firstPartyId { get; set; }
            public string personaId { get; set; }
            public string personaName { get; set; }
            public string gamesLegacy { get; set; }

            [JsonProperty(PropertyName = "namespace")]
            public string ns { get; set; }

            public string gamesJson { get; set; }
            public string clanTag { get; set; }
        }

        public class MyPersona : BaseModel
        {
            public string picture { get; set; }
            public string personaId { get; set; }

            private string _personaName;
            public string personaName
            {
                get { return _personaName; }
                set
                {
                    _personaName = value;
                    RaisePropertyChanged("personaName");
                }
            }
            
            public int updatedAt { get; set; }
            public string userId { get; set; }

            private string _clanTag;
            public string clanTag
            {
                get { return _clanTag; } 
                set
                {
                    _clanTag = value;
                    RaisePropertyChanged("clanTag");
                }
            }
            public OriginalPersona originalPersona { get; set; }

            [JsonProperty(PropertyName = "namespace")]
            public string ns { get; set; }
        }

        public class ImageInfo
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class ImageConfig
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions versions { get; set; }
        }

        public class CurrentRankNeeded : BaseModel
        {
            public string name { get; set; }

            private int _level;
            public int level
            {
                get { return _level; } 
                set
                {
                    _level = value;
                    RaisePropertyChanged("level");
                }
            }
            
            
            public int pointsNeeded { get; set; }
            public string texture { get; set; }
            public ImageConfig iconImageConfig { get; set; }
            public string guid { get; set; }
            public ImageConfig imageConfig { get; set; }
        }

        public class KitTimes
        {
            [JsonProperty(PropertyName = "8")]
            public string Recon { get; set; }

            [JsonProperty(PropertyName = "1")]
            public string Assault { get; set; }

            [JsonProperty(PropertyName = "2")]
            public string Engineer { get; set; }

            [JsonProperty(PropertyName = "2048")]
            public string Commander { get; set; }

            [JsonProperty(PropertyName = "32")]
            public string Support { get; set; }
        }

        public class KitTimesInPercentage
        {
            [JsonProperty(PropertyName = "8")]
            public double Recon { get; set; }

            [JsonProperty(PropertyName = "1")]
            public double Assault { get; set; }

            [JsonProperty(PropertyName = "2")]
            public double Engineer { get; set; }

            [JsonProperty(PropertyName = "2048")]
            public double Commander { get; set; }

            [JsonProperty(PropertyName = "32")]
            public double Support { get; set; }
        }

        public class KitScores
        {
            [JsonProperty(PropertyName = "8")]
            public int Recon { get; set; }

            [JsonProperty(PropertyName = "1")]
            public int Assault { get; set; }

            [JsonProperty(PropertyName = "2")]
            public int Engineer { get; set; }

            [JsonProperty(PropertyName = "2048")]
            public int Commander { get; set; }

            [JsonProperty(PropertyName = "32")]
            public int Support { get; set; }
        }

        public class ServiceStarsGameMode
        {
            public int serviceStars { get; set; }
            public double serviceStarsProgress { get; set; }
            public int valueNeeded { get; set; }
            public int actualValue { get; set; }
            public string codeNeeded { get; set; }
        }

        public class ServiceStars
        {
            [JsonProperty(PropertyName = "8")]
            public int Recon { get; set; }

            [JsonProperty(PropertyName = "1")]
            public int Assault { get; set; }

            [JsonProperty(PropertyName = "2")]
            public int Engineer { get; set; }

            [JsonProperty(PropertyName = "2048")]
            public int Commander { get; set; }

            [JsonProperty(PropertyName = "32")]
            public int Support { get; set; }
        }

        public class ServiceStarsProgress
        {
            [JsonProperty(PropertyName = "8")]
            public double Recon { get; set; }

            [JsonProperty(PropertyName = "1")]
            public double Assault { get; set; }

            [JsonProperty(PropertyName = "2")]
            public double Engineer { get; set; }

            [JsonProperty(PropertyName = "2048")]
            public double Commander { get; set; }

            [JsonProperty(PropertyName = "32")]
            public double Support { get; set; }
        }

        public class GameModesScore
        {
            [JsonProperty(PropertyName = "33554432 ")]
            public int Prop33554432 { get; set; }

            [JsonProperty(PropertyName = "1")]
            public string Prop1 { get; set; }

            [JsonProperty(PropertyName = "2")]
            public string Prop2 { get; set; }

            [JsonProperty(PropertyName = "134217728")]
            public int Prop134217728 { get; set; }

            [JsonProperty(PropertyName = "32")]
            public int Prop32 { get; set; }

            [JsonProperty(PropertyName = "8")]
            public int Prop8 { get; set; }

            [JsonProperty(PropertyName = "64")]
            public string Prop64 { get; set; }

            [JsonProperty(PropertyName = "67108864")]
            public int Prop67108864 { get; set; }

            [JsonProperty(PropertyName = "2097152")]
            public int Prop2097152 { get; set; }

            [JsonProperty(PropertyName = "8388608")]
            public int Prop8388608 { get; set; }

            [JsonProperty(PropertyName = "1024")]
            public int Prop1024 { get; set; }

            [JsonProperty(PropertyName = "16777216")]
            public int Prop16777216 { get; set; }

            [JsonProperty(PropertyName = "524288")]
            public int Prop524288 { get; set; }
        }

        public class VehicleScores
        {
            [JsonProperty(PropertyName = "32")]
            public string Prop32 { get; set; }

            [JsonProperty(PropertyName = "1")]
            public int Prop1 { get; set; }

            [JsonProperty(PropertyName = "2")]
            public string Prop2 { get; set; }

            [JsonProperty(PropertyName = "4")]
            public string Prop4 { get; set; }

            [JsonProperty(PropertyName = "8")]
            public string Prop8 { get; set; }

            [JsonProperty(PropertyName = "16")]
            public string Prop16 { get; set; }
        }

        public class GeneralPersonaStats : BaseModel
        {
            public GeneralPersonaStats()
            {
                KitsServiceStars = new List<KitServiceStar>()
                    {
                        new KitServiceStar(KitType.Assault),
                        new KitServiceStar(KitType.Engineer),
                        new KitServiceStar(KitType.Support),
                        new KitServiceStar(KitType.Recon),
                        new KitServiceStar(KitType.Commander)
                    };
            }

            private List<KitServiceStar> _kitServiceStar;
            [JsonIgnore]
            public List<KitServiceStar> KitsServiceStars
            {
                get { return _kitServiceStar; }
                set
                {
                    _kitServiceStar = value;
                    RaisePropertyChanged("KitsServiceStars");
                }
            }

            public object timeDead { get; set; }

            private int _skill;
            public int skill
            {
                get { return _skill; }
                set
                {
                    _skill = value;
                    RaisePropertyChanged("skill");
                }
            }
            public int elo { get; set; }
            public int sc_award { get; set; }
            public int revives { get; set; }
            public object rushWlr { get; set; }

            private int _kills;
            public int kills
            {
                get { return _kills; }
                set
                {
                    _kills = value;
                    RaisePropertyChanged("kills");
                }
            }

            private double _kdRatio;
            public double kdRatio
            {
                get { return _kdRatio; }
                set
                {
                    _kdRatio = value;
                    RaisePropertyChanged("kdRatio");
                }
            }

            public string flagCaptures { get; set; }
            public string sc_unlock { get; set; }
            public string quitPercentage { get; set; }
            public string sc_bonus { get; set; }
            public string rsKills { get; set; }
            public int resupplies { get; set; }
            public int repairs { get; set; }
            public int timePlayedDelta { get; set; }
            public int shotsFired { get; set; }
            public KitTimes kitTimes { get; set; }
            public object flagrunner { get; set; }
            public object kdRatioDelta { get; set; }
            public object squadRushWlr { get; set; }
            public object spm_engineer { get; set; }
            public object reDeploys { get; set; }
            public object clubRepution { get; set; }
            public object rushLosses { get; set; }
            public object spm_support { get; set; }
            public object maxHeadshotsInRound { get; set; }
            public int score { get; set; }

            private KitTimesInPercentage _kitTimesInPercentage;
            public KitTimesInPercentage kitTimesInPercentage
            {
                get { return _kitTimesInPercentage; }
                set
                {
                    _kitTimesInPercentage = value;
                    RaisePropertyChanged("kitTimesInPercentage");

                    KitsServiceStars.First(k => k.Type == KitType.Assault).Percentage = _kitTimesInPercentage.Assault;
                    KitsServiceStars.First(k => k.Type == KitType.Engineer).Percentage = _kitTimesInPercentage.Engineer;
                    KitsServiceStars.First(k => k.Type == KitType.Support).Percentage = _kitTimesInPercentage.Support;
                    KitsServiceStars.First(k => k.Type == KitType.Recon).Percentage = _kitTimesInPercentage.Recon;
                    KitsServiceStars.First(k => k.Type == KitType.Commander).Percentage = _kitTimesInPercentage.Commander;
                }
            }

            private int _timePlayed;
            public int timePlayed
            {
                get { return _timePlayed; }
                set
                {
                    _timePlayed = value;
                    RaisePropertyChanged("timePlayed");
                    actualTimePlayed = TimeSpan.FromSeconds(_timePlayed);
                }
            }

            private TimeSpan _actualTimePlayed;
            [JsonIgnore]
            public TimeSpan actualTimePlayed
            {
                get { return _actualTimePlayed; }
                set
                {
                    _actualTimePlayed = value;
                    RaisePropertyChanged("actualTimePlayed");
                }
            }

            private KitScores _kitScores;
            public KitScores kitScores
            {
                get { return _kitScores; }
                set
                {
                    _kitScores = value;
                    RaisePropertyChanged("KitScores");

                    KitsServiceStars.First(k => k.Type == KitType.Assault).Score = _kitScores.Assault;
                    KitsServiceStars.First(k => k.Type == KitType.Engineer).Score = _kitScores.Engineer;
                    KitsServiceStars.First(k => k.Type == KitType.Support).Score = _kitScores.Support;
                    KitsServiceStars.First(k => k.Type == KitType.Recon).Score = _kitScores.Recon;
                    KitsServiceStars.First(k => k.Type == KitType.Commander).Score = _kitScores.Commander;
                }
            }

            public string suppressionAssists { get; set; }
            public int rsDeaths { get; set; }
            public string timePlayedSinceLastReset { get; set; }
            public object winPercentage { get; set; }
            public object tdmWlr { get; set; }

            private double _wlRatio;
            [JsonIgnore]
            public double wlRatio
            {
                get { return _wlRatio; }
                set
                {
                    _wlRatio = value;
                    RaisePropertyChanged("wlRatio");
                }
            }
            
            public object meleeKills { get; set; }

            private int _numRounds;
            public int numRounds
            {
                get { return _numRounds; }
                set
                {
                    _numRounds = value;
                    RaisePropertyChanged("numRounds");
                }
            }
            public object maxKillsInRound { get; set; }
            public int killStreakBonus { get; set; }
            public int lastReset { get; set; }
            public object spm_recon { get; set; }
            public int rsShotsFired { get; set; }
            public int shotsHit { get; set; }
            public List<ServiceStarsGameMode> serviceStarsGameModes { get; set; }

            private string _numLosses;
            public string numLosses
            {
                get { return _numLosses; }
                set
                {
                    _numLosses = value;
                    RaisePropertyChanged("numLosses");
                    CalculateWinLoseRatio();
                }
            }

            public object spm_assault { get; set; }
            public object squadDMLosses { get; set; }
            public object maxScoreInRound { get; set; }

            private ServiceStarsProgress _serviceStarsProgress;
            public ServiceStarsProgress serviceStarsProgress
            {
                get { return _serviceStarsProgress; }
                set
                {
                    _serviceStarsProgress = value;
                    RaisePropertyChanged("serviceStarsProgress");

                    KitsServiceStars.First(k => k.Type == KitType.Assault).Progression = _serviceStarsProgress.Assault;
                    KitsServiceStars.First(k => k.Type == KitType.Engineer).Progression = _serviceStarsProgress.Engineer;
                    KitsServiceStars.First(k => k.Type == KitType.Support).Progression = _serviceStarsProgress.Support;
                    KitsServiceStars.First(k => k.Type == KitType.Recon).Progression = _serviceStarsProgress.Recon;
                    KitsServiceStars.First(k => k.Type == KitType.Commander).Progression = _serviceStarsProgress.Commander;
                }
            }

            public double rsScorePerMinute { get; set; }
            public int rsScore { get; set; }
            public GameModesScore gameModesScore { get; set; }
            public int rsNumLosses { get; set; }
            public int rank { get; set; }
            public object rushWins { get; set; }
            public int sc_vehicle { get; set; }
            public int sc_team { get; set; }
            public int totalScore { get; set; }
            public int heals { get; set; }
            public double longestHeadshot { get; set; }
            public double mcomDefendKills { get; set; }
            public object conquestWlr { get; set; }
            public object tdmLosses { get; set; }
            public object longestWinStreak { get; set; }
            public object vehiclesDestroyedAssists { get; set; }
            public object squadDMWins { get; set; }
            public object squadRushLosses { get; set; }
            public string flagDefend { get; set; }
            public string nemesisStreak { get; set; }

            private string _numWins;
            public string numWins
            {
                get { return _numWins; }
                set
                {
                    _numWins = value;
                    RaisePropertyChanged("numWins");
                    CalculateWinLoseRatio();
                }
            }

            public object conquestWins { get; set; }
            public int scorePerMinuteDelta { get; set; }
            public int sc_objective { get; set; }
            public int rsTimePlayed { get; set; }
            public VehicleScores vehicleScores { get; set; }
            public string rsShotsHit { get; set; }
            public string nemesisKills { get; set; }
            public int sc_squad { get; set; }
            public int vehicleDamage { get; set; }

            private ServiceStars _serviceStars;
            public ServiceStars serviceStars
            {
                get { return _serviceStars; }
                set
                {
                    _serviceStars = value;
                    RaisePropertyChanged("ServiceStars");

                    KitsServiceStars.First(k => k.Type == KitType.Assault).Stars = _serviceStars.Assault;
                    KitsServiceStars.First(k => k.Type == KitType.Engineer).Stars = _serviceStars.Engineer;
                    KitsServiceStars.First(k => k.Type == KitType.Support).Stars = _serviceStars.Support;
                    KitsServiceStars.First(k => k.Type == KitType.Recon).Stars = _serviceStars.Recon;
                    KitsServiceStars.First(k => k.Type == KitType.Commander).Stars = _serviceStars.Commander;
                }
            }
            public string dogtagsTaken { get; set; }

            private int _deaths;
            public int deaths
            {
                get { return _deaths; }
                set
                {
                    _deaths = value;
                    RaisePropertyChanged("deaths");
                }
            }
            
            public int killAssists { get; set; }
            public object tdmWins { get; set; }
            public string headshots { get; set; }
            public string avengerKills { get; set; }
            public object conquestLosses { get; set; }
            public object squadDmWlr { get; set; }
            public object maxMeleeKillsInRound { get; set; }
            public int rankScore { get; set; }
            public int rsNumWins { get; set; }

            private double _accuracy;
            public double accuracy
            {
                get { return _accuracy; }
                set
                {
                    _accuracy = value;
                    RaisePropertyChanged("accuracy");
                }
            }
            public int scoreDelta { get; set; }
            public int vehiclesDestroyed { get; set; }

            private string _scorePerMinute;
            public string scorePerMinute
            {
                get { return _scorePerMinute; }
                set
                {
                    _scorePerMinute = value;
                    RaisePropertyChanged("scorePerMinute");
                }
            }
            public string combatScore { get; set; }

            public int scoreMultiplier { get; set; }

            public double mcomDestroy { get; set; }

            public object squadRushWins { get; set; }

            public int sc_general { get; set; }

            public string saviorKills { get; set; }

            private void CalculateWinLoseRatio()
            {
                int win = 0;
                int loss = 0;

                int.TryParse(_numWins, out win);
                int.TryParse(_numLosses, out loss);

                if (loss == 0)
                    wlRatio = 0;
                else
                    wlRatio = (double)win / loss;
            }
        }

        public class Versions
        {
            public ImageInfo tiny { get; set; }
            public ImageInfo tinyinv { get; set; }
            public ImageInfo small { get; set; }
            public ImageInfo smallinv { get; set; }
            public ImageInfo smallns { get; set; }
            public ImageInfo medium { get; set; }
            public ImageInfo mediumns { get; set; }
            public ImageInfo large { get; set; }
        }

        //public class RankNeeded
        //{
        //    public string name { get; set; }
        //    public int level { get; set; }
        //    public int pointsNeeded { get; set; }
        //    public string texture { get; set; }
        //    public ImageConfig iconImageConfig { get; set; }
        //    public string guid { get; set; }
        //    public ImageConfig imageConfig { get; set; }
        //}

        public class Data
        {
            public List<MyPersona> myPersonas { get; set; }

            public CurrentRankNeeded currentRankNeeded { get; set; }

            public GeneralPersonaStats generalPersonaStats { get; set; }
            
            //public RankNeeded rankNeeded { get; set; }
        }
    }
}
