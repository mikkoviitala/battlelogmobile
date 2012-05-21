namespace BattlelogMobile.Core.Model
{
    public interface IScore
    {
        IKits Kits { get; set; }
        IOthers Others { get; set; }
        int TotalScore { get; set; }
    }
}