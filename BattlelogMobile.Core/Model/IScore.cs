using System.Collections.Generic;
namespace BattlelogMobile.Core.Model
{
    public interface IScore
    {
        IEnumerable<IKit> Kits { get; set; }
        IEnumerable<IOther> Others { get; set; }
        int TotalScore { get; set; }
    }
}