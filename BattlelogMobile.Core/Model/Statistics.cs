namespace BattlelogMobile.Core.Model
{
    // overviewStats
    public class Statistics : IStatistics
    {
        public int Kills { get; set; }                      // kills
        public int KillAssists { get; set; }                // killAssists
        public int Deaths { get; set; }                     // deaths
        public double Accuracy { get; set; }                // accuracy
        public double LongestHeadshot { get; set; }         // longestHeadshot
        public int KillStreakBonus { get; set; }            // killStreakBonus
        public int VehiclesDestroyed { get; set; }          // vehiclesDestroyed
        public int VehiclesDestroyedAssists { get; set; }   // vehiclesDestroyedAssists
        public int SquadScoreBonus { get; set; }            // sc_squad
        public int Repairs { get; set; }                    // repairs
        public int Revives { get; set; }                    // revives
        public int Heals { get; set; }                      // heals
        public int Resupplies { get; set; }                 // resupplies

        public override string ToString()
        {
            return string.Format(
                "Kills={0}, KillAssists={1}, Deaths={2}, Accuracy={3}, LongestHeadshot={4}, KillStreakBonus={5}, VehiclesDestroyd={6}, " +
                "DestroyedAssists={7}, SquadScoreBonus={8}, Repairs={9}, Revives={10}, Heals={11}, Resupplies={12}",
                Kills, KillAssists, Deaths, Accuracy, LongestHeadshot, KillStreakBonus, VehiclesDestroyed,
                VehiclesDestroyedAssists, SquadScoreBonus, Repairs, Revives, Heals, Resupplies);

        }
    }
}