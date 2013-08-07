using System.Collections.Generic;
namespace BattlelogMobile.Core.Model
{
    public interface IScore
    {
        //IKits Kits { get; set; }
        IEnumerable<IKit> Kits { get; set; }
        //IOthers Others { get; set; }
        IEnumerable<IOther> Others { get; set; }
        int TotalScore { get; set; }
    }
}