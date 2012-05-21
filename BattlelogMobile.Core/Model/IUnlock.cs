using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface IUnlock
    {
        string Parent { get; set; }
        string Slug { get; set; }
        int Completion { get; set; }
        BitmapImage Image { get; set; }
    }
}
