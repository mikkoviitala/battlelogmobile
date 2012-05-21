using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface IAward
    {
        string Code { get; set; }
        string Group { get; set; }
        BitmapImage Image { get; }
        int Width { get; }
        int Height { get; }
        string Name { get; }
        string Description { get; }
    }
}
