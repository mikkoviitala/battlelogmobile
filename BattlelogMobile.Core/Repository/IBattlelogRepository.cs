using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Core.Repository
{
    public interface IBattlelogRepository
    {
        string CurrentUser { get; set; }
        void UpdateStorage(bool forceUpdate);
        ISoldier Load();
    }
}