using System;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface IKitProgression : IEquatable<IKitProgression>, IComparable
    {
        KitType Type { get; set; }
        int ServiceStars { get; set; }
        BitmapImage Image { get; set; }
        double Progress { get; set; }
    }
}