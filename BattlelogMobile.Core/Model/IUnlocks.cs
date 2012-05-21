using System.Collections.Generic;

namespace BattlelogMobile.Core.Model
{
    public interface IUnlocks : IEnumerable<IUnlock>
    {
        IUnlock Get(string slug);
    }
}
