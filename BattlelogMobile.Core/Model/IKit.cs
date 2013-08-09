using System;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public interface IKit : IEquatable<IKit>, IComparable
    {
        KitType Type { get; set; }
        int Score { get; set; }
        TimeSpan Time { get; set; }
        double Percentage { get; set; }
        BitmapImage Image { get; set; }
        string ImageName { get; set; }
    }
}