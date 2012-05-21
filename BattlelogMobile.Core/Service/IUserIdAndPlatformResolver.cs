using System.IO;

namespace BattlelogMobile.Core.Service
{
    public interface IUserIdAndPlatformResolver
    {
        void Resolve(Stream stream);
    }
}