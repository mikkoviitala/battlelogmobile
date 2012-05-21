using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Core.Repository
{
    public interface IBattlelogRepository
    {
        void UpdateStorage();
        ISoldier Load();
    }
}