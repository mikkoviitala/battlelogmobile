using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Core.Repository
{
    public interface ISettingsRepository
    {
        void Save(ISettings settings);
        ISettings Load();
    }
}
