using System.Collections.Generic;
namespace BattlelogMobile.Core.Model
{
    public interface IScore
    {
        List<IKit> Kits { get; set; }
        List<IOther> Others { get; set; }
        int TotalScore { get; set; }
    }
}