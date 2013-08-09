namespace BattlelogMobile.Core.Model
{
    public interface IStatistics
    {
        int Kills { get; set; }
        int KillAssists { get; set; }
        int Deaths { get; set; }
        double Accuracy { get; set; }
        int ShotsFired { get; set; }
        double LongestHeadshot { get; set; }
        int KillStreakBonus { get; set; }
        int VehiclesDestroyed { get; set; }
        int VehiclesDestroyedAssists { get; set; }
        int SquadScoreBonus { get; set; }
        int Repairs { get; set; }
        int Revives { get; set; }
        int Heals { get; set; }
        int Resupplies { get; set; }

        double Quits { get; set; }
        int MCOMDefendKills { get; set; }
        int MCOMDestroyed { get; set; }
        int FlagsCaptured { get; set; }
        int FlagsDefended { get; set; }
        int AvengerKills { get; set; }
        int SaviorKills { get; set; }
        int DogtagsTaken { get; set; }
        int FlagsCapturedCTF { get; set; }
        int NemesisStreak { get; set; }
        int NemesisKills { get; set; }
        int SuppressionAssists { get; set; }
    }
}