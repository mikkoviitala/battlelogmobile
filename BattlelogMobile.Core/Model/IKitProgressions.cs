using System.Collections.Generic;

namespace BattlelogMobile.Core.Model
{
    public interface IKitProgressions : IEnumerable<IKitProgression>
    {
        IKitProgression Get(KitType type);
    }
}