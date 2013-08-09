using System;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Service;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    public class Item : BaseModel, IItem
    {
        private BitmapImage _bitmap;
        private BitmapImage _starBitmap;

        public string Name { get; set; }
        public string DisplayName
        {
            get { return ItemNameMapper.Get(Slug); }
        }
        public string Slug { get; set; }
        public int Kills { get; set; }
        public int? Headshots { get; set; }
        public int? ServiceStars { get; set; }
        [ExcludeFromSerialization]
        public BitmapImage ServiceStarImage
        {
            get { return _starBitmap; }
            set { _starBitmap = value; RaisePropertyChanged("ServiceStarImage"); }
        }
        public TimeSpan? TimeIn { get; set; }
        [ExcludeFromSerialization]
        public BitmapImage Image
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged("Image"); }
        }
        public string ImageName { get; set; }

        public int Performance { get; set; }
        public string PerformanceDescription { get; set; }

        public override string ToString()
        {
            return string.Format("Name={0}, Slug={1}, Kills={2}, Headshots={3}, ServiceStars={4}, TimeIn={5}, Image={6}",
                Name, Slug, Kills, Headshots, ServiceStars, TimeIn, Image);
        }
    }
}