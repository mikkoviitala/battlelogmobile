using System.Collections.Generic;

namespace BattlelogMobile.Core.Model
{
    public interface IItems : IEnumerable<IItem>
    {
        IItem Get(string itemName);
    }
}

