using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Index
    {
        public class Games
        {
            [JsonProperty(PropertyName = "4")]
            public string Prop4 { get; set; }
        }

        public class Games2
        {
            [JsonProperty(PropertyName = "32")]
            public string Prop32 { get; set; }

            [JsonProperty(PropertyName = "4")]
            public string Prop4 { get; set; }
        }

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
            public string @namespace { get; set; }
            public string gamesJson { get; set; }
            public Games2 games { get; set; }
            public string clanTag { get; set; }
        }

        public class MyPersona
        {
            public string picture { get; set; }
            public string personaId { get; set; }
            public Games games { get; set; }
            public string personaName { get; set; }
            public int updatedAt { get; set; }
            public string userId { get; set; }
            public string clanTag { get; set; }
            public OriginalPersona originalPersona { get; set; }
            public string @namespace { get; set; }
        }

        public class Small
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions
        {
            public Small small { get; set; }
            public Smallns smallns { get; set; }
        }

        public class IconImageConfig
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions versions { get; set; }
        }

        public class Large
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallinv
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Medium
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Tiny
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Tinyinv
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions2
        {
            public Large large { get; set; }
            public Smallinv smallinv { get; set; }
            public Medium medium { get; set; }
            public Tiny tiny { get; set; }
            public Tinyinv tinyinv { get; set; }
            public Small2 small { get; set; }
            public Mediumns mediumns { get; set; }
            public Smallns2 smallns { get; set; }
        }

        public class ImageConfig
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions2 versions { get; set; }
        }

        public class CurrentRankNeeded
        {
            public string name { get; set; }
            public int level { get; set; }
            public int pointsNeeded { get; set; }
            public string texture { get; set; }
            public IconImageConfig iconImageConfig { get; set; }
            public string guid { get; set; }
            public ImageConfig imageConfig { get; set; }
        }

        public class KitMaxMeleeKillsInRound
        {
        }

        public class KitLosses
        {
        }

        public class KitMaxHeadshotsInRound
        {
        }

        public class KitWins
        {
        }

        public class KitDeployments
        {
        }

        public class KitLongestHeadshot
        {
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

        public class KitScores
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

        public class ServiceStarsGameMode
        {
            public int serviceStars { get; set; }
            public double serviceStarsProgress { get; set; }
            public int valueNeeded { get; set; }
            public int actualValue { get; set; }
            public string codeNeeded { get; set; }
        }

        public class ServiceStarsProgress
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

        public class KitMeleeKills
        {
        }

        public class KitKills
        {
        }

        public class KitMaxScoreInRound
        {
        }

        public class KitDeaths
        {
        }

        public class KitHeadshots
        {
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

        public class KitKillStreak
        {
        }

        public class ServiceStars
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

        public class KitMaxKillsInRound
        {
        }

        public class GeneralPersonaStats
        {
            public object timeDead { get; set; }
            public KitMaxMeleeKillsInRound kitMaxMeleeKillsInRound { get; set; }
            public int skill { get; set; }
            public int elo { get; set; }
            public int sc_award { get; set; }
            public int revives { get; set; }
            public KitLosses kitLosses { get; set; }
            public object rushWlr { get; set; }
            public int kills { get; set; }
            public double kdRatio { get; set; }
            public int sc_bonus { get; set; }
            public KitMaxHeadshotsInRound kitMaxHeadshotsInRound { get; set; }
            public KitWins kitWins { get; set; }
            public object flagrunner { get; set; }
            public int rsKills { get; set; }
            public KitDeployments kitDeployments { get; set; }
            public object kdRatioDelta { get; set; }
            public object squadRushWlr { get; set; }
            public double quitPercentage { get; set; }
            public object spm_engineer { get; set; }
            public int flagCaptures { get; set; }
            public int sc_unlock { get; set; }
            public KitLongestHeadshot kitLongestHeadshot { get; set; }
            public object reDeploys { get; set; }
            public object clubRepution { get; set; }
            public object rushLosses { get; set; }
            public int resupplies { get; set; }
            public object spm_support { get; set; }
            public int repairs { get; set; }
            public int shotsFired { get; set; }
            public object maxHeadshotsInRound { get; set; }
            public int score { get; set; }
            public KitTimes kitTimes { get; set; }
            public int timePlayedDelta { get; set; }
            public KitTimesInPercentage kitTimesInPercentage { get; set; }
            public int timePlayed { get; set; }
            public KitScores kitScores { get; set; }
            public int suppressionAssists { get; set; }
            public int rsDeaths { get; set; }
            public int timePlayedSinceLastReset { get; set; }
            public object winPercentage { get; set; }
            public object tdmWlr { get; set; }
            public double wlRatio { get; set; }
            public object meleeKills { get; set; }
            public int numRounds { get; set; }
            public object maxKillsInRound { get; set; }
            public int killStreakBonus { get; set; }
            public int lastReset { get; set; }
            public object spm_recon { get; set; }
            public int rsShotsFired { get; set; }
            public int shotsHit { get; set; }
            public List<ServiceStarsGameMode> serviceStarsGameModes { get; set; }
            public int numLosses { get; set; }
            public object spm_assault { get; set; }
            public object squadDMLosses { get; set; }
            public object maxScoreInRound { get; set; }
            public ServiceStarsProgress serviceStarsProgress { get; set; }
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
            public KitMeleeKills kitMeleeKills { get; set; }
            public double longestHeadshot { get; set; }
            public object conquestWlr { get; set; }
            public object tdmLosses { get; set; }
            public object longestWinStreak { get; set; }
            public double mcomDefendKills { get; set; }
            public object vehiclesDestroyedAssists { get; set; }
            public object squadDMWins { get; set; }
            public KitKills kitKills { get; set; }
            public KitMaxScoreInRound kitMaxScoreInRound { get; set; }
            public KitDeaths kitDeaths { get; set; }
            public object squadRushLosses { get; set; }
            public int flagDefend { get; set; }
            public int nemesisStreak { get; set; }
            public int numWins { get; set; }
            public object conquestWins { get; set; }
            public int scorePerMinuteDelta { get; set; }
            public KitHeadshots kitHeadshots { get; set; }
            public int sc_objective { get; set; }
            public int rsTimePlayed { get; set; }
            public VehicleScores vehicleScores { get; set; }
            public int rsShotsHit { get; set; }
            public int nemesisKills { get; set; }
            public int sc_squad { get; set; }
            public int vehicleDamage { get; set; }
            public KitKillStreak kitKillStreak { get; set; }
            public ServiceStars serviceStars { get; set; }
            public int dogtagsTaken { get; set; }
            public int deaths { get; set; }
            public int killAssists { get; set; }
            public object tdmWins { get; set; }
            public int headshots { get; set; }
            public int avengerKills { get; set; }
            public object conquestLosses { get; set; }
            public int rsNumWins { get; set; }
            public object squadDmWlr { get; set; }
            public object maxMeleeKillsInRound { get; set; }
            public int rankScore { get; set; }
            public KitMaxKillsInRound kitMaxKillsInRound { get; set; }
            public double accuracy { get; set; }
            public int scoreDelta { get; set; }
            public int vehiclesDestroyed { get; set; }
            public int scorePerMinute { get; set; }
            public int combatScore { get; set; }
            public int scoreMultiplier { get; set; }
            public double mcomDestroy { get; set; }
            public object squadRushWins { get; set; }
            public int sc_general { get; set; }
            public int saviorKills { get; set; }
        }

        public class Small3
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns3
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions3
        {
            public Small3 small { get; set; }
            public Smallns3 smallns { get; set; }
        }

        public class IconImageConfig2
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions3 versions { get; set; }
        }

        public class Large2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallinv2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Medium2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Tiny2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Tinyinv2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small4
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns4
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions4
        {
            public Large2 large { get; set; }
            public Smallinv2 smallinv { get; set; }
            public Medium2 medium { get; set; }
            public Tiny2 tiny { get; set; }
            public Tinyinv2 tinyinv { get; set; }
            public Small4 small { get; set; }
            public Mediumns2 mediumns { get; set; }
            public Smallns4 smallns { get; set; }
        }

        public class ImageConfig2
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions4 versions { get; set; }
        }

        public class RankNeeded
        {
            public string name { get; set; }
            public int level { get; set; }
            public int pointsNeeded { get; set; }
            public string texture { get; set; }
            public IconImageConfig2 iconImageConfig { get; set; }
            public string guid { get; set; }
            public ImageConfig2 imageConfig { get; set; }
        }

        public class Data
        {
            public List<MyPersona> myPersonas { get; set; }
            public CurrentRankNeeded currentRankNeeded { get; set; }
            public GeneralPersonaStats generalPersonaStats { get; set; }
            public RankNeeded rankNeeded { get; set; }
        }

        public class RootObject
        {
            public string type { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }
    }
}
