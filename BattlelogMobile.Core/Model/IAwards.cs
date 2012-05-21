using System.Collections.Generic;

namespace BattlelogMobile.Core.Model
{
    public interface IAwards : IEnumerable<IAward>
    {
        IAward Get(string code);
    }
}
