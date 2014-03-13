using System.ComponentModel;

namespace BattlelogMobile.Core.Model
{
    public enum SupportedGame : byte
    {
        [Description("Unknown")]
        Unknown,
        [Description("Battlefield 3")]
        Battlefield3,
        [Description("Battlefield 4")]
        Battlefield4
    }
}