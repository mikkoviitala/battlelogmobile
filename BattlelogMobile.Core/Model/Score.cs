using System.Collections.Generic;

namespace BattlelogMobile.Core.Model
{
    public class Score : IScore
    {
        public List<IKit> Kits { get; set; }
        public List<IOther> Others { get; set; }
        public int TotalScore { get; set; }

        public override string ToString()
        {
            return string.Format("KitsScores=[{0}], OtherScores=[{1}], TotalScore={2}", Kits, Others, TotalScore);
        }
    }
}