namespace BattlelogMobile.Core.Model
{
    public class Other : IOther
    {
        public Other()
        {}

        public Other(string type, int score)
        {
            Type = type;
            Score = score;
        }

        public string Type { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return string.Format("Type={0}, Score={1}", Type, Score);
        }

        // At least the following.....
        // Vehicles     -> sc_vehicle
        // Combat       -> combatScore
        // Award        -> sc_award
        // Unlocks      -> sc_unlock
        // TotalScore   -> totalScore
    }
}
