using System;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Repository
{
    public interface IImageRepository
    {
        // Kinda stupid shit, but imageSaveName is there just because there's e.g. 
        // medal with same name as weapon... m27.png = M27 IAR and Conquest Medal.
        void Load(string imageUrl, string imageName, Action<BitmapImage> callback, string imageSaveName = null);
        BitmapImage Load(string imageName);
    }
}