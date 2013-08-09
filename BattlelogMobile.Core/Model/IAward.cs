using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface IAward
    {
        string Code { get; set; }
        string Group { get; set; }
        BitmapImage Image { get; set; }
        string ImageName { get; set; }
        string ImageSaveName { get; set; }
        string ImageUrl { get; set; }
        int Width { get; }
        int Height { get; }
        string Name { get; }
        string Description { get; }
    }
}
