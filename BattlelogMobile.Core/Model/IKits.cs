using System.Collections.Generic;

namespace BattlelogMobile.Core.Model
{
    public interface IKits : IEnumerable<IKit>
    {
        void Add(IKit kit);
        IKit Get(KitType type);
    }
}