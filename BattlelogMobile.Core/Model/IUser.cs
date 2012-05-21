using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface IUser
    {
        long Id { get; set; }
        string Name { get; set; }
        string GravatarMd5 { get; set; }
        BitmapImage Image { get; set; }
    }
}