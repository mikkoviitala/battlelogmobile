using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model.Battlefield4
{
public class ImageInfo
{
    public string path { get; set; }
    public bool isSprite { get; set; }
    public int height { get; set; }
    public string name { get; set; }
    public int width { get; set; }
}

public class Image
{
    public string category { get; set; }
    public string slug { get; set; }
    public string texture { get; set; }
}

public class PlayerProgress
{
    public object descriptionID { get; set; }
    public int actualValue { get; set; }
    public object parentNameSID { get; set; }
    public object license { get; set; }
    public string codeNeeded { get; set; }
    public string unlockType { get; set; }
    public int valueNeeded { get; set; }
    public object valueNeededPlain { get; set; }
    public object award { get; set; }
    public int complete { get; set; }
}

public class Suggestion
{
    public string loadoutIdentifier { get; set; }
    public int? itemCategoryID { get; set; }
    public object description { get; set; }
    public Image image { get; set; }
    public string guid { get; set; }
    public bool isTrackedManually { get; set; }
    public string slug { get; set; }
    public string category { get; set; }
    public int index { get; set; }
    public string name { get; set; }
    public List<PlayerProgress> playerProgress { get; set; }
    public int? aliasing { get; set; }
    public int gameType { get; set; }
    public int type { get; set; }
    public object isDefault { get; set; }
}

public class Dummy
{
}

public class Bucket
{
}

public class Award
{
}

public class License
{
}

public class UnlockProgression
{
    public Dummy dummy { get; set; }
    public Bucket bucket { get; set; }
    public Award award { get; set; }
    public License license { get; set; }
}

public class DeltaHigh
{
    public double headshots { get; set; }
    public double timeEquipped { get; set; }
    public double shotsFired { get; set; }
    public double kills { get; set; }
    public double deaths { get; set; }
    public double shotsHit { get; set; }
    public double score { get; set; }
    public double timeIn { get; set; }
    public double destroyXinY { get; set; }
    public double kpm { get; set; }
}

public class DeltaLow
{
    public double headshots { get; set; }
    public double timeEquipped { get; set; }
    public double shotsFired { get; set; }
    public object kills { get; set; }
    public double deaths { get; set; }
    public double shotsHit { get; set; }
    public double score { get; set; }
    public object timeIn { get; set; }
    public double destroyXinY { get; set; }
    public double kpm { get; set; }
}

public class MainVehicleStatsMetadata
{
    public UnlockProgression unlockProgression { get; set; }
    public DeltaHigh deltaHigh { get; set; }
    public DeltaLow deltaLow { get; set; }
}

public class MainVehicleStat
{
    public double serviceStars { get; set; }
    public double serviceStarsProgress { get; set; }
    public string code { get; set; }
    public double kills { get; set; }
    public List<object> unlocks { get; set; }
    public double timeIn { get; set; }
    public string guid { get; set; }
    public string slug { get; set; }
    public string category { get; set; }
    public double destroyXinY { get; set; }
    public string name { get; set; }
    public object killsDelta { get; set; }
    public object vehicle { get; set; }
    public object type { get; set; }
    public object timeInDelta { get; set; }
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

public class VehicleAirHelicopterScout
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

public class UnlockedBy2
{
    public string codeNeeded { get; set; }
    public object valueNeededPlain { get; set; }
    public bool? completed { get; set; }
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

public class VehicleFastAttackCraft
{
    public object valueNeeded { get; set; }
    public object actualValue { get; set; }
    public object unlocked { get; set; }
    public object nameSID { get; set; }
    public object image { get; set; }
    public object descriptionSID { get; set; }
    public object kit { get; set; }
    public string unlockId { get; set; }
    public UnlockedBy2 unlockedBy { get; set; }
    public object codeNeeded { get; set; }
    public object vehicleCategory { get; set; }
    public object unlockImageConfig { get; set; }
    public string guid { get; set; }
    public object type { get; set; }
    public object slug { get; set; }
    public object imageConfig { get; set; }
    public object valueNeededUnit { get; set; }
}

public class UnlockedBy3
{
    public string codeNeeded { get; set; }
    public object valueNeededPlain { get; set; }
    public bool? completed { get; set; }
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

public class VehicleInfantryFightingVehicle
{
    public object valueNeeded { get; set; }
    public object actualValue { get; set; }
    public object unlocked { get; set; }
    public object nameSID { get; set; }
    public object image { get; set; }
    public object descriptionSID { get; set; }
    public object kit { get; set; }
    public string unlockId { get; set; }
    public UnlockedBy3 unlockedBy { get; set; }
    public object codeNeeded { get; set; }
    public object vehicleCategory { get; set; }
    public object unlockImageConfig { get; set; }
    public string guid { get; set; }
    public object type { get; set; }
    public object slug { get; set; }
    public object imageConfig { get; set; }
    public object valueNeededUnit { get; set; }
}

public class UnlockedBy4
{
    public string codeNeeded { get; set; }
    public object valueNeededPlain { get; set; }
    public object completed { get; set; }
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

public class VehicleAirJetAttack
{
    public object valueNeeded { get; set; }
    public object actualValue { get; set; }
    public object unlocked { get; set; }
    public object nameSID { get; set; }
    public object image { get; set; }
    public object descriptionSID { get; set; }
    public object kit { get; set; }
    public string unlockId { get; set; }
    public UnlockedBy4 unlockedBy { get; set; }
    public object codeNeeded { get; set; }
    public object vehicleCategory { get; set; }
    public object unlockImageConfig { get; set; }
    public string guid { get; set; }
    public object type { get; set; }
    public object slug { get; set; }
    public object imageConfig { get; set; }
    public object valueNeededUnit { get; set; }
}

public class UnlockedBy5
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

public class VehicleAirHelicopterAttack
{
    public object valueNeeded { get; set; }
    public object actualValue { get; set; }
    public object unlocked { get; set; }
    public object nameSID { get; set; }
    public object image { get; set; }
    public object descriptionSID { get; set; }
    public object kit { get; set; }
    public string unlockId { get; set; }
    public UnlockedBy5 unlockedBy { get; set; }
    public object codeNeeded { get; set; }
    public object vehicleCategory { get; set; }
    public object unlockImageConfig { get; set; }
    public string guid { get; set; }
    public object type { get; set; }
    public object slug { get; set; }
    public object imageConfig { get; set; }
    public object valueNeededUnit { get; set; }
}

public class UnlockedBy6
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

public class VehicleMainBattleTank
{
    public object valueNeeded { get; set; }
    public object actualValue { get; set; }
    public object unlocked { get; set; }
    public object nameSID { get; set; }
    public object image { get; set; }
    public object descriptionSID { get; set; }
    public object kit { get; set; }
    public string unlockId { get; set; }
    public UnlockedBy6 unlockedBy { get; set; }
    public object codeNeeded { get; set; }
    public object vehicleCategory { get; set; }
    public object unlockImageConfig { get; set; }
    public string guid { get; set; }
    public object type { get; set; }
    public object slug { get; set; }
    public object imageConfig { get; set; }
    public object valueNeededUnit { get; set; }
}

public class UnlockedBy7
{
    public string codeNeeded { get; set; }
    public object valueNeededPlain { get; set; }
    public object completed { get; set; }
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

public class VehicleAirJetStealth
{
    public object valueNeeded { get; set; }
    public object actualValue { get; set; }
    public object unlocked { get; set; }
    public object nameSID { get; set; }
    public object image { get; set; }
    public object descriptionSID { get; set; }
    public object kit { get; set; }
    public string unlockId { get; set; }
    public UnlockedBy7 unlockedBy { get; set; }
    public object codeNeeded { get; set; }
    public object vehicleCategory { get; set; }
    public object unlockImageConfig { get; set; }
    public string guid { get; set; }
    public object type { get; set; }
    public object slug { get; set; }
    public object imageConfig { get; set; }
    public object valueNeededUnit { get; set; }
}

public class UnlockedBy8
{
    public string codeNeeded { get; set; }
    public object valueNeededPlain { get; set; }
    public bool? completed { get; set; }
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

public class VehicleAntiAir
{
    public object valueNeeded { get; set; }
    public object actualValue { get; set; }
    public object unlocked { get; set; }
    public object nameSID { get; set; }
    public object image { get; set; }
    public object descriptionSID { get; set; }
    public object kit { get; set; }
    public string unlockId { get; set; }
    public UnlockedBy8 unlockedBy { get; set; }
    public object codeNeeded { get; set; }
    public object vehicleCategory { get; set; }
    public object unlockImageConfig { get; set; }
    public string guid { get; set; }
    public object type { get; set; }
    public object slug { get; set; }
    public object imageConfig { get; set; }
    public object valueNeededUnit { get; set; }
}

public class UnlockProgression2
{
    //public List<VehicleAirHelicopterScout> __invalid_name__Vehicle Air Helicopter Scout { get; set; }
    //public List<VehicleFastAttackCraft> __invalid_name__Vehicle Fast Attack Craft { get; set; }
    //public List<VehicleInfantryFightingVehicle> __invalid_name__Vehicle Infantry Fighting Vehicle { get; set; }
    //public List<VehicleAirJetAttack> __invalid_name__Vehicle Air Jet Attack { get; set; }
    //public List<VehicleAirHelicopterAttack> __invalid_name__Vehicle Air Helicopter Attack { get; set; }
    //public List<VehicleMainBattleTank> __invalid_name__Vehicle Main Battle Tanks { get; set; }
    //public List<VehicleAirJetStealth> __invalid_name__Vehicle Air Jet Stealth { get; set; }
    //public List<VehicleAntiAir> __invalid_name__Vehicle Anti Air { get; set; }
}

public class VehicleTaken
{
    public int taken { get; set; }
    public int total { get; set; }
}

public class UnlockProgressionAmount
{
    [JsonProperty(PropertyName = "Vehicle Air Helicopter Scout")]
    public VehicleTaken ScoutHeli { get; set; }

    [JsonProperty(PropertyName = "Vehicle Fast Attack Craft")]
    public VehicleTaken FAC { get; set; }

    [JsonProperty(PropertyName = "Vehicle Infantry Fighting Vehicle")]
    public VehicleTaken IFV { get; set; }

    [JsonProperty(PropertyName = "Vehicle Air Jet Attack")]
    public VehicleTaken AttackJet { get; set; }

    [JsonProperty(PropertyName = "Vehicle Air Helicopter Attack")]
    public VehicleTaken AttackHeli { get; set; }

    [JsonProperty(PropertyName = "Vehicle Main Battle Tanks")]
    public VehicleTaken MBT { get; set; }

    [JsonProperty(PropertyName = "Vehicle Air Jet Stealth")]
    public VehicleTaken StealthJet { get; set; }

    [JsonProperty(PropertyName = "Vehicle Anti Air")]
    public VehicleTaken AA { get; set; }
}

public class Data
{
    public int personaId { get; set; }
    public string statsTemplate { get; set; }
    public int platformInt { get; set; }
    public List<Suggestion> suggestions { get; set; }
    public MainVehicleStatsMetadata mainVehicleStatsMetadata { get; set; }
    public List<MainVehicleStat> mainVehicleStats { get; set; }
    public UnlockProgression2 unlockProgression { get; set; }
    public bool mySoldier { get; set; }
    public bool suggestionsEnabled { get; set; }
    public bool isGridView { get; set; }
    public UnlockProgressionAmount unlockProgressionAmount { get; set; }
    public int suggestionType { get; set; }
    public int gameInt { get; set; }
}

public class RootObject
{
    public string type { get; set; }
    public string message { get; set; }
    public Data data { get; set; }
}
}
