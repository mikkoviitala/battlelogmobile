using System.Collections.Generic;

namespace BattlelogMobile.Core.Model
{
    public interface IOthers : IEnumerable<IOther>
    {
        IOther Get(string type);
    }
}