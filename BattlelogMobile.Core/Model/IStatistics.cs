namespace BattlelogMobile.Core.Model
{
    public interface IStatistics
    {
        int Kills { get; set; }
        int KillAssists { get; set; }
        int Deaths { get; set; }
        double Accuracy { get; set; }
        double LongestHeadshot { get; set; }
        int KillStreakBonus { get; set; }
        int VehiclesDestroyed { get; set; }
        int VehiclesDestroyedAssists { get; set; }
        int SquadScoreBonus { get; set; }
        int Repairs { get; set; }
        int Revives { get; set; }
        int Heals { get; set; }
        int Resupplies { get; set; }
    }
}