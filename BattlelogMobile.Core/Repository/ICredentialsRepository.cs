using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Core.Repository
{
    public interface ICredentialsRepository
    {
        void Save(ICredentials credentials);
        ICredentials Load();
    }
}