using System.Collections.Generic;
namespace BattlelogMobile.Core.Model
{
    public class Score : IScore
    {
        //public IKits Kits { get; set; }
        public IEnumerable<IKit> Kits { get; set; }
        //public IOthers Others { get; set; }
        public IEnumerable<IOther> Others { get; set; }
        public int TotalScore { get; set; }

        public override string ToString()
        {
            return string.Format("KitsScores=[{0}], OtherScores=[{1}], TotalScore={2}", Kits, Others, TotalScore);
        }
    }
}