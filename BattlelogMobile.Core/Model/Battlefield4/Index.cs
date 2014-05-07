using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Index
    {
        public class Data : BaseModel
        {
            private List<MyPersona> _myPersonas;
            public List<MyPersona> myPersonas
            {
                get { return _myPersonas; }
                set
                {
                    _myPersonas = value;
                    RaisePropertyChanged("myPersonas");
                }
            }

            private CurrentRankNeeded _currentRankNeeded;
            public CurrentRankNeeded currentRankNeeded
            {
                get { return _currentRankNeeded; }
                set
                {
                    _currentRankNeeded = value;
                    RaisePropertyChanged("currentRankNeeded");
                }
            }

            private GeneralPersonaStats _generalPersonaStats;
            public GeneralPersonaStats generalPersonaStats
            {
                get { return _generalPersonaStats; }
                set
                {
                    _generalPersonaStats = value;
                    RaisePropertyChanged("generalPersonaStats");
                }
            }

            //public RankNeeded rankNeeded { get; set; }
        }

        public class MyPersona : BaseModel
        {
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

            //public string picture { get; set; }
            //public string personaId { get; set; }
            //public int updatedAt { get; set; }
            //public string userId { get; set; }
            //public OriginalPersona originalPersona { get; set; }
            //[JsonProperty(PropertyName = "namespace")]
            //public string ns { get; set; }
        }

        public class CurrentRankNeeded : BaseModel
        {
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

            //public string name { get; set; }
            //public int pointsNeeded { get; set; }
            //public string texture { get; set; }
            //public ImageConfig iconImageConfig { get; set; }
            //public string guid { get; set; }
            //public ImageConfig imageConfig { get; set; }
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

            public int sc_award { get; set; }
            public int revives { get; set; }


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

            private string _sc_unlock ;
            public string sc_unlock
            {
                get { return _sc_unlock; }
                set
                {
                    _sc_unlock = value;
                    RaisePropertyChanged("sc_unlock");
                }
            }

            private string _quitPercentage;
            public string quitPercentage
            {
                get { return _quitPercentage; }
                set
                {
                    _quitPercentage = value;
                    RaisePropertyChanged("quitPercentage");
                }
            }
            
            private int _resupplies;
            public int resupplies
            {
                get { return _resupplies; }
                set
                {
                    _resupplies = value;
                    RaisePropertyChanged("resupplies");
                }
            }

            private int _repairs;
            public int repairs
            {
                get { return _repairs; }
                set
                {
                    _repairs = value;
                    RaisePropertyChanged("repairs");
                }
            }

            private int _shotsFired;
            public int shotsFired
            {
                get { return _shotsFired; }
                set
                {
                    _shotsFired = value;
                    RaisePropertyChanged("shotsFired");
                }
            }

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

            private string _suppressionAssists;
            public string suppressionAssists
            {
                get { return _suppressionAssists; }
                set
                {
                    _suppressionAssists = value;
                    RaisePropertyChanged("suppressionAssists");
                }
            }
            
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
            
            private int _killStreakBonus;
            public int killStreakBonus
            {
                get { return _killStreakBonus; }
                set
                {
                    _killStreakBonus = value;
                    RaisePropertyChanged("killStreakBonus");
                }
            }

            private int _shotsHit;
            public int shotsHit
            {
                get { return _shotsHit; }
                set
                {
                    _shotsHit = value;
                    RaisePropertyChanged("shotsHit");
                }
            }

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

            private int _sc_vehicle;
            public int sc_vehicle
            {
                get { return _sc_vehicle; }
                set
                {
                    _sc_vehicle = value;
                    RaisePropertyChanged("sc_vehicle");
                }
            }

            private int _totalScore;
            public int totalScore
            {
                get { return _totalScore; }
                set
                {
                    _totalScore = value;
                    RaisePropertyChanged("totalScore");
                }
            }

            private int _heals;
            public int heals
            {
                get { return _heals; }
                set
                {
                    _heals = value;
                    RaisePropertyChanged("heals");
                }
            }

            private double _longestHeadshot;
            public double longestHeadshot
            {
                get { return _longestHeadshot; }
                set
                {
                    _longestHeadshot = value;
                    RaisePropertyChanged("longestHeadshot");
                }
            }

            private string _nemesisStreak;
            public string nemesisStreak
            {
                get { return _nemesisStreak; }
                set
                {
                    _nemesisStreak = value;
                    RaisePropertyChanged("nemesisStreak");
                }
            }

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

            private string _nemesisKills;
            public string nemesisKills
            {
                get { return _nemesisKills; }
                set
                {
                    _nemesisKills = value;
                    RaisePropertyChanged("nemesisKills");
                }
            }

            private int _sc_squad;
            public int sc_squad
            {
                get { return _sc_squad; }
                set
                {
                    _sc_squad = value;
                    RaisePropertyChanged("sc_squad");
                }
            }

            private int _vehicleDamage;
            public int vehicleDamage
            {
                get { return _vehicleDamage; }
                set
                {
                    _vehicleDamage = value;
                    RaisePropertyChanged("vehicleDamage");
                }
            }

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

            private string _dogtagsTaken;
            public string dogtagsTaken
            {
                get { return _dogtagsTaken; }
                set
                {
                    _dogtagsTaken = value;
                    RaisePropertyChanged("dogtagsTaken");
                }
            }

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

            private int _killAssists;
            public int killAssists
            {
                get { return _killAssists; }
                set
                {
                    _killAssists = value;
                    RaisePropertyChanged("killAssists");
                }
            }

            private string _headshots ;
            public string headshots
            {
                get { return _headshots; }
                set
                {
                    _headshots = value;
                    RaisePropertyChanged("headshots");
                }
            }

            private string _avengerKills;
            public string avengerKills
            {
                get { return _avengerKills; }
                set
                {
                    _avengerKills = value;
                    RaisePropertyChanged("avengerKills");
                }
            }
            
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

            private int _vehiclesDestroyed;
            public int vehiclesDestroyed
            {
                get { return _vehiclesDestroyed; }
                set
                {
                    _vehiclesDestroyed = value;
                    RaisePropertyChanged("vehiclesDestroyed");
                }
            }

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
           
            private string _saviorKills;
            public string saviorKills
            {
                get { return _saviorKills; }
                set
                {
                    _saviorKills = value;
                    RaisePropertyChanged("saviorKills");
                }
            }

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

            //public object vehiclesDestroyedAssists
            //public string sc_bonus { get; set; }
            //public object meleeKills { get; set; }
            //public object maxKillsInRound { get; set; }
            //public int lastReset { get; set; }
            //public object spm_recon { get; set; }
            //public int rsShotsFired { get; set; }
            //public object spm_assault { get; set; }
            //public object squadDMLosses { get; set; }
            //public object maxScoreInRound { get; set; }
            //public List<ServiceStarsGameMode> serviceStarsGameModes { get; set; }
            //public object squadDMWins { get; set; }
            //public object squadRushLosses { get; set; }
            //public string flagDefend { get; set; }
            //public double mcomDefendKills { get; set; }
            //public object conquestWlr { get; set; }
            //public object tdmLosses { get; set; }
            //public object longestWinStreak { get; set; }
            //public int sc_team { get; set; }
            //public double rsScorePerMinute { get; set; }
            //public int rsScore { get; set; }
            //public GameModesScore gameModesScore { get; set; }
            //public int rsNumLosses { get; set; }
            //public int rank { get; set; }
            //public object rushWins { get; set; }
            //public object conquestWins { get; set; }
            //public int scorePerMinuteDelta { get; set; }
            //public int sc_objective { get; set; }
            //public int rsTimePlayed { get; set; }
            //public VehicleScores vehicleScores { get; set; }
            //public string rsShotsHit { get; set; }
            //public object tdmWins { get; set; }
            //public object conquestLosses { get; set; }
            //public object squadDmWlr { get; set; }
            //public object maxMeleeKillsInRound { get; set; }
            //public int rankScore { get; set; }
            //public int rsNumWins { get; set; }
            //public int scoreDelta { get; set; }
            //public string combatScore { get; set; }
            //public int scoreMultiplier { get; set; }
            //public double mcomDestroy { get; set; }
            //public object squadRushWins { get; set; }
            //public int sc_general { get; set; }
            //public object rushWlr { get; set; }
            //public int elo { get; set; }
            //public string flagCaptures { get; set; }
            //public string rsKills { get; set; }
            //public int timePlayedDelta { get; set; }
            //public KitTimes kitTimes { get; set; }
            //public object flagrunner { get; set; }
            //public object kdRatioDelta { get; set; }
            //public object squadRushWlr { get; set; }
            //public object spm_engineer { get; set; }
            //public object reDeploys { get; set; }
            //public object clubRepution { get; set; }
            //public object rushLosses { get; set; }
            //public object spm_support { get; set; }
            //public object maxHeadshotsInRound { get; set; }
            //public int score { get; set; }
            //public int rsDeaths { get; set; }
            //public string timePlayedSinceLastReset { get; set; }
            //public object winPercentage { get; set; }
            //public object tdmWlr { get; set; }
        }

        public class KitTimesInPercentage : BaseModel
        {
            private double _recon;
            [JsonProperty(PropertyName = "8")]
            public double Recon
            {
                get { return _recon; }
                set
                {
                    _recon = value;
                    RaisePropertyChanged("Recon");
                }
            }

            private double _assault;
            [JsonProperty(PropertyName = "1")]
            public double Assault
            {
                get { return _assault; }
                set
                {
                    _assault = value;
                    RaisePropertyChanged("Assault");
                }
            }

            private double _engineer;
            [JsonProperty(PropertyName = "2")]
            public double Engineer
            {
                get { return _engineer; }
                set
                {
                    _engineer = value;
                    RaisePropertyChanged("Engineer");
                }
            }

            private double _commander;
            [JsonProperty(PropertyName = "2048")]
            public double Commander
            {
                get { return _commander; }
                set
                {
                    _commander = value;
                    RaisePropertyChanged("Commander");
                }
            }

            private double _support;
            [JsonProperty(PropertyName = "32")]
            public double Support
            {
                get { return _support; }
                set
                {
                    _support = value;
                    RaisePropertyChanged("Support");
                }
            }
        }

        public class KitScores : BaseModel
        {
            private int _recon;
            [JsonProperty(PropertyName = "8")]
            public int Recon
            {
                get { return _recon; }
                set
                {
                    _recon = value;
                    RaisePropertyChanged("Recon");
                }
            }

            private int _assault ;
            [JsonProperty(PropertyName = "1")]
            public int Assault
            {
                get { return _assault; }
                set
                {
                    _assault = value;
                    RaisePropertyChanged("Assault");
                }
            }

            private int _engineer;
            [JsonProperty(PropertyName = "2")]
            public int Engineer
            {
                get { return _engineer; }
                set
                {
                    _engineer = value;
                    RaisePropertyChanged("Engineer");
                }
            }

            private int _commander;
            [JsonProperty(PropertyName = "2048")]
            public int Commander
            {
                get { return _commander; }
                set
                {
                    _commander = value;
                    RaisePropertyChanged("Commander");
                }
            }

            private int _support;
            [JsonProperty(PropertyName = "32")]
            public int Support
            {
                get { return _support; }
                set
                {
                    _support = value;
                    RaisePropertyChanged("Support");
                }
            }
        }

        public class ServiceStars : BaseModel
        {
            private int _recon;
            [JsonProperty(PropertyName = "8")]
            public int Recon
            {
                get { return _recon; }
                set
                {
                    _recon = value;
                    RaisePropertyChanged("Recon");
                }
            }

            private int _assault;
            [JsonProperty(PropertyName = "1")]
            public int Assault
            {
                get { return _assault; }
                set
                {
                    _assault = value;
                    RaisePropertyChanged("Assault");
                }
            }

            private int _engineer;
            [JsonProperty(PropertyName = "2")]
            public int Engineer
            {
                get { return _engineer; }
                set
                {
                    _engineer = value;
                    RaisePropertyChanged("Engineer");
                }
            }

            private int _commander;
            [JsonProperty(PropertyName = "2048")]
            public int Commander
            {
                get { return _commander; }
                set
                {
                    _commander = value;
                    RaisePropertyChanged("Commander");
                }
            }

            private int _support;
            [JsonProperty(PropertyName = "32")]
            public int Support
            {
                get { return _support; }
                set
                {
                    _support = value;
                    RaisePropertyChanged("Support");
                }
            }
        }

        public class ServiceStarsProgress : BaseModel
        {
            private double _recon;
            [JsonProperty(PropertyName = "8")]
            public double Recon
            {
                get { return _recon; }
                set
                {
                    _recon = value;
                    RaisePropertyChanged("Recon");
                }
            }

            private double _assault;
            [JsonProperty(PropertyName = "1")]
            public double Assault
            {
                get { return _assault; }
                set
                {
                    _assault = value;
                    RaisePropertyChanged("Assault");
                }
            }

            private double _engineer;
            [JsonProperty(PropertyName = "2")]
            public double Engineer
            {
                get { return _engineer; }
                set
                {
                    _engineer = value;
                    RaisePropertyChanged("Engineer");
                }
            }

            private double _commander;
            [JsonProperty(PropertyName = "2048")]
            public double Commander
            {
                get { return _commander; }
                set
                {
                    _commander = value;
                    RaisePropertyChanged("Commander");
                }
            }

            private double _support;
            [JsonProperty(PropertyName = "32")]
            public double Support
            {
                get { return _support; }
                set
                {
                    _support = value;
                    RaisePropertyChanged("Support");
                }
            }
        }

        //public class VehicleScores
        //{
        //    [JsonProperty(PropertyName = "32")]
        //    public string Prop32 { get; set; }

        //    [JsonProperty(PropertyName = "1")]
        //    public int Prop1 { get; set; }

        //    [JsonProperty(PropertyName = "2")]
        //    public string Prop2 { get; set; }

        //    [JsonProperty(PropertyName = "4")]
        //    public string Prop4 { get; set; }

        //    [JsonProperty(PropertyName = "8")]
        //    public string Prop8 { get; set; }

        //    [JsonProperty(PropertyName = "16")]
        //    public string Prop16 { get; set; }
        //}

        //public class ServiceStarsGameMode
        //{
        //    public int serviceStars { get; set; }
        //    public double serviceStarsProgress { get; set; }
        //    public int valueNeeded { get; set; }
        //    public int actualValue { get; set; }
        //    public string codeNeeded { get; set; }
        //}

        //public class Versions
        //{
        //    public ImageInfo tiny { get; set; }
        //    public ImageInfo tinyinv { get; set; }
        //    public ImageInfo small { get; set; }
        //    public ImageInfo smallinv { get; set; }
        //    public ImageInfo smallns { get; set; }
        //    public ImageInfo medium { get; set; }
        //    public ImageInfo mediumns { get; set; }
        //    public ImageInfo large { get; set; }
        //}

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

        //public class OriginalPersona
        //{
        //    public string picture { get; set; }
        //    public string userId { get; set; }
        //    public object user { get; set; }
        //    public int updatedAt { get; set; }
        //    public string firstPartyId { get; set; }
        //    public string personaId { get; set; }
        //    public string personaName { get; set; }
        //    public string gamesLegacy { get; set; }

        //    [JsonProperty(PropertyName = "namespace")]
        //    public string ns { get; set; }

        //    public string gamesJson { get; set; }
        //    public string clanTag { get; set; }
        //}

        //public class ImageInfo
        //{
        //    public string path { get; set; }
        //    public bool isSprite { get; set; }
        //    public int height { get; set; }
        //    public string name { get; set; }
        //    public int width { get; set; }
        //}

        //public class ImageConfig
        //{
        //    public string category { get; set; }
        //    public string slug { get; set; }
        //    public string texture { get; set; }
        //    public Versions versions { get; set; }
        //}

        //public class KitTimes
        //{
        //    [JsonProperty(PropertyName = "8")]
        //    public string Recon { get; set; }

        //    [JsonProperty(PropertyName = "1")]
        //    public string Assault { get; set; }

        //    [JsonProperty(PropertyName = "2")]
        //    public string Engineer { get; set; }

        //    [JsonProperty(PropertyName = "2048")]
        //    public string Commander { get; set; }

        //    [JsonProperty(PropertyName = "32")]
        //    public string Support { get; set; }
        //}

        //public class GameModesScore
        //{
        //    [JsonProperty(PropertyName = "33554432 ")]
        //    public int Prop33554432 { get; set; }

        //    [JsonProperty(PropertyName = "1")]
        //    public string Prop1 { get; set; }

        //    [JsonProperty(PropertyName = "2")]
        //    public string Prop2 { get; set; }

        //    [JsonProperty(PropertyName = "134217728")]
        //    public int Prop134217728 { get; set; }

        //    [JsonProperty(PropertyName = "32")]
        //    public int Prop32 { get; set; }

        //    [JsonProperty(PropertyName = "8")]
        //    public int Prop8 { get; set; }

        //    [JsonProperty(PropertyName = "64")]
        //    public string Prop64 { get; set; }

        //    [JsonProperty(PropertyName = "67108864")]
        //    public int Prop67108864 { get; set; }

        //    [JsonProperty(PropertyName = "2097152")]
        //    public int Prop2097152 { get; set; }

        //    [JsonProperty(PropertyName = "8388608")]
        //    public int Prop8388608 { get; set; }

        //    [JsonProperty(PropertyName = "1024")]
        //    public int Prop1024 { get; set; }

        //    [JsonProperty(PropertyName = "16777216")]
        //    public int Prop16777216 { get; set; }

        //    [JsonProperty(PropertyName = "524288")]
        //    public int Prop524288 { get; set; }
        //}
    }
}
