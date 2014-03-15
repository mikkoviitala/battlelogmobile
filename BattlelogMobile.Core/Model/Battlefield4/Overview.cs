using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Overview
    {
        public class Challenges
        {
            public string wins { get; set; }
            public string mostplayedmission_name { get; set; }
            public string losses { get; set; }
            public string mostplayedmission_missions { get; set; }
        }

        public class GameProgress
        {
            public string name { get; set; }
            public int max { get; set; }
            public int percent { get; set; }
            public int current { get; set; }
            public object subProgress { get; set; }
            public string slug { get; set; }
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

        public class OverviewStats
        {
            public object timeDead { get; set; }
            public int skill { get; set; }
            public object elo { get; set; }
            public int sc_award { get; set; }
            public object revives { get; set; }
            public object rushWlr { get; set; }
            public int kills { get; set; }
            public double kdRatio { get; set; }
            public object sc_bonus { get; set; }
            public object flagrunner { get; set; }
            public int rsKills { get; set; }
            public object kdRatioDelta { get; set; }
            public object squadRushWlr { get; set; }
            public object quitPercentage { get; set; }
            public object spm_engineer { get; set; }
            public object flagCaptures { get; set; }
            public int sc_unlock { get; set; }
            public object reDeploys { get; set; }
            public object clubRepution { get; set; }
            public object rushLosses { get; set; }
            public object resupplies { get; set; }
            public object spm_support { get; set; }
            public object repairs { get; set; }
            public object shotsFired { get; set; }
            public object maxHeadshotsInRound { get; set; }
            public int score { get; set; }
            public object timePlayedDelta { get; set; }
            public int timePlayed { get; set; }
            public KitScores kitScores { get; set; }
            public object suppressionAssists { get; set; }
            public int rsDeaths { get; set; }
            public int timePlayedSinceLastReset { get; set; }
            public object winPercentage { get; set; }
            public object tdmWlr { get; set; }
            public object wlRatio { get; set; }
            public object meleeKills { get; set; }
            public int numRounds { get; set; }
            public object maxKillsInRound { get; set; }
            public object killStreakBonus { get; set; }
            public object lastReset { get; set; }
            public object spm_recon { get; set; }
            public int rsShotsFired { get; set; }
            public object shotsHit { get; set; }
            public List<ServiceStarsGameMode> serviceStarsGameModes { get; set; }
            public int numLosses { get; set; }
            public object spm_assault { get; set; }
            public object squadDMLosses { get; set; }
            public object maxScoreInRound { get; set; }
            public ServiceStarsProgress serviceStarsProgress { get; set; }
            public object rsScorePerMinute { get; set; }
            public int rsScore { get; set; }
            public int rsNumLosses { get; set; }
            public int rank { get; set; }
            public object rushWins { get; set; }
            public int sc_vehicle { get; set; }
            public object sc_team { get; set; }
            public int totalScore { get; set; }
            public object heals { get; set; }
            public object longestHeadshot { get; set; }
            public object conquestWlr { get; set; }
            public object tdmLosses { get; set; }
            public object longestWinStreak { get; set; }
            public object mcomDefendKills { get; set; }
            public object vehiclesDestroyedAssists { get; set; }
            public object squadDMWins { get; set; }
            public object squadRushLosses { get; set; }
            public object flagDefend { get; set; }
            public object nemesisStreak { get; set; }
            public int numWins { get; set; }
            public object conquestWins { get; set; }
            public object scorePerMinuteDelta { get; set; }
            public object sc_objective { get; set; }
            public int rsTimePlayed { get; set; }
            public int rsShotsHit { get; set; }
            public object nemesisKills { get; set; }
            public int sc_squad { get; set; }
            public object vehicleDamage { get; set; }
            public ServiceStars serviceStars { get; set; }
            public object dogtagsTaken { get; set; }
            public int deaths { get; set; }
            public object killAssists { get; set; }
            public object tdmWins { get; set; }
            public object headshots { get; set; }
            public object avengerKills { get; set; }
            public object conquestLosses { get; set; }
            public int rsNumWins { get; set; }
            public object squadDmWlr { get; set; }
            public object maxMeleeKillsInRound { get; set; }
            public int rankScore { get; set; }
            public double accuracy { get; set; }
            public object scoreDelta { get; set; }
            public object vehiclesDestroyed { get; set; }
            public int scorePerMinute { get; set; }
            public int combatScore { get; set; }
            public object scoreMultiplier { get; set; }
            public object mcomDestroy { get; set; }
            public object squadRushWins { get; set; }
            public object sc_general { get; set; }
            public object saviorKills { get; set; }
        }

        public class Area
        {
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class LeaderboardItem
        {
            public string category { get; set; }
            public string statId { get; set; }
            public string statKey { get; set; }
            public string nameSID { get; set; }
            public string image { get; set; }
            public string slug { get; set; }
            public string statType { get; set; }
            public string scoreType { get; set; }
        }

        public class GeolbTopPerformance
        {
            public int division { get; set; }
            public double score { get; set; }
            public Area area { get; set; }
            public object rank { get; set; }
            public string statId { get; set; }
            public LeaderboardItem leaderboardItem { get; set; }
            public string leaderboardKey { get; set; }
        }

        public class ImageInfo
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions
        {
            public ImageInfo mobile { get; set; }
            public ImageInfo tiny { get; set; }
            public ImageInfo tinyinv { get; set; }
            public ImageInfo small { get; set; }
            public ImageInfo smallinv { get; set; }
            public ImageInfo smallns { get; set; }
            public ImageInfo medium { get; set; }
            public ImageInfo mediumns { get; set; }
            public ImageInfo large { get; set; }
            public ImageInfo xlarge { get; set; }
        }

        public class ImageConfig
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions versions { get; set; }
        }

        public class CurrentRankNeeded
        {
            public string name { get; set; }
            public int level { get; set; }
            public int pointsNeeded { get; set; }
            public string texture { get; set; }
            public ImageConfig iconImageConfig { get; set; }
            public string guid { get; set; }
            public ImageConfig imageConfig { get; set; }
        }

        public class UnlockedBy
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public bool completed { get; set; }
            public object award { get; set; }
            public int bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public double actualValue { get; set; }
            public double valueNeeded { get; set; }
        }

        public class Unlock
        {
            public object valueNeeded { get; set; }
            public object actualValue { get; set; }
            public object unlocked { get; set; }
            public object nameSID { get; set; }
            public object image { get; set; }
            public object descriptionSID { get; set; }
            public object kit { get; set; }
            public string unlockId { get; set; }
            public UnlockedBy unlockedBy { get; set; }
            public object codeNeeded { get; set; }
            public object vehicleCategory { get; set; }
            public object unlockImageConfig { get; set; }
            public string guid { get; set; }
            public object type { get; set; }
            public object slug { get; set; }
            public object imageConfig { get; set; }
            public object valueNeededUnit { get; set; }
        }

        public class TopVehicle
        {
            public double serviceStars { get; set; }
            public double serviceStarsProgress { get; set; }
            public string code { get; set; }
            public int kills { get; set; }
            public List<Unlock> unlocks { get; set; }
            public int timeIn { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
            public string category { get; set; }
            public int destroyXinY { get; set; }
            public string name { get; set; }
            public object killsDelta { get; set; }
            public object vehicle { get; set; }
            public object type { get; set; }
            public object timeInDelta { get; set; }
        }

        public class NextRankNeeded
        {
            public string name { get; set; }
            public int level { get; set; }
            public int pointsNeeded { get; set; }
            public string texture { get; set; }
            public ImageConfig iconImageConfig { get; set; }
            public string guid { get; set; }
            public ImageConfig imageConfig { get; set; }
        }

        public class LatestGameReport
        {
            public object persona { get; set; }
            public int gameMode { get; set; }
            public object userId { get; set; }
            public string reportId { get; set; }
            public bool isUnread { get; set; }
            public int createdAt { get; set; }
            public string personaId { get; set; }
            public int mapVariant { get; set; }
            public string serverName { get; set; }
            public string mapName { get; set; }
            public int platform { get; set; }
            public int winStatus { get; set; }
        }

        public class DogTagBasic
        {
            public object statValue { get; set; }
            public int index { get; set; }
            public bool isAdvanced { get; set; }
            public bool backgroundInverted { get; set; }
            public string nameSID { get; set; }
            public string image { get; set; }
            public object statSID { get; set; }
            public ImageConfig imageConfig { get; set; }
        }

        public class TopWeapon
        {
            public double serviceStars { get; set; }
            public double serviceStarsProgress { get; set; }
            public string code { get; set; }
            public object deaths { get; set; }
            public string categorySID { get; set; }
            public object unlockImageConfig { get; set; }
            public string guid { get; set; }
            public string category { get; set; }
            public int shotsFired { get; set; }
            public object unlocked { get; set; }
            public object timeEquippedDelta { get; set; }
            public object score { get; set; }
            public object type { get; set; }
            public object imageConfig { get; set; }
            public double accuracy { get; set; }
            public object startedWith { get; set; }
            public double headshots { get; set; }
            public int kills { get; set; }
            public List<object> unlocks { get; set; }
            public List<int> kit { get; set; }
            public object duplicateOf { get; set; }
            public string slug { get; set; }
            public int timeEquipped { get; set; }
            public object killsPerMinuteDelta { get; set; }
            public string name { get; set; }
            public object weapon { get; set; }
            public int shotsHit { get; set; }
            public object killsDelta { get; set; }
        }
        
        public class DogTagAdvanced
        {
            public object statValue { get; set; }
            public int index { get; set; }
            public bool isAdvanced { get; set; }
            public bool backgroundInverted { get; set; }
            public string nameSID { get; set; }
            public string image { get; set; }
            public object statSID { get; set; }
            public ImageConfig imageConfig { get; set; }
        }

        public class Data : BaseModel
        {
            public Challenges challenges { get; set; }
            public int personaId { get; set; }
            public List<GameProgress> gameProgress { get; set; }
            public OverviewStats overviewStats { get; set; }
            public object geolbHighlight { get; set; }
            public int platform { get; set; }
            public List<GeolbTopPerformance> geolbTopPerformance { get; set; }
            public CurrentRankNeeded currentRankNeeded { get; set; }
            public object activeEmblem { get; set; }
            public List<TopVehicle> topVehicles { get; set; }
            public NextRankNeeded nextRankNeeded { get; set; }
            public List<LatestGameReport> latestGameReports { get; set; }
            public string currentUserId { get; set; }
            public int game { get; set; }
            public DogTagBasic dogTagBasic { get; set; }
            public List<TopWeapon> topWeapons { get; set; }
            public string statsTemplate { get; set; }
            public DogTagAdvanced dogTagAdvanced { get; set; }
            public int platformInt { get; set; }
            public bool isActiveUser { get; set; }
            public List<object> favBattleReports { get; set; }
            public List<int> rankScoreNeeded { get; set; }
        }
    }
}
