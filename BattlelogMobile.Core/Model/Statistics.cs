namespace BattlelogMobile.Core.Model
{
    // overviewStats
    public class Statistics : IStatistics
    {
        public int Kills { get; set; }                      // kills
        public int KillAssists { get; set; }                // killAssists
        public int Deaths { get; set; }                     // deaths
        public double Accuracy { get; set; }                // accuracy
        public int ShotsFired { get; set; }                 // shotsFired
        public double LongestHeadshot { get; set; }         // longestHeadshot
        public int KillStreakBonus { get; set; }            // killStreakBonus
        public int VehiclesDestroyed { get; set; }          // vehiclesDestroyed
        public int VehiclesDestroyedAssists { get; set; }   // vehiclesDestroyedAssists
        public int SquadScoreBonus { get; set; }            // sc_squad
        public int Repairs { get; set; }                    // repairs
        public int Revives { get; set; }                    // revives
        public int Heals { get; set; }                      // heals
        public int Resupplies { get; set; }                 // resupplies

        public double Quits { get; set; }	                    // quitPercentage
        public int MCOMDefendKills { get; set; }            // mcomDefendKills
        public int MCOMDestroyed { get; set; }	            // mcomDestroy
        public int FlagsCaptured { get; set; }              // flagCaptures
        public int FlagsDefended { get; set; }              // flagDefend
        public int AvengerKills { get; set; }               // avengerKills
        public int SaviorKills { get; set; }                // saviorKills
        public int DogtagsTaken	{ get; set; }               // dogtagsTaken
        public int FlagsCapturedCTF { get; set; }           // flagrunner
        public int NemesisStreak { get; set; }              // nemesisStreak
        public int NemesisKills { get; set; }               // nemesisKills
        public int SuppressionAssists { get; set; }         // suppressionAssists

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