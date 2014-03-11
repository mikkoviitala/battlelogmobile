using System.IO;
using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Core.Service
{
    public interface IUserIdAndPlatformResolver
    {
        BattlelogUser Resolve(Stream stream);
    }
}