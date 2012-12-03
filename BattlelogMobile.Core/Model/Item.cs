using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Service;

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
        public BitmapImage ServiceStarImage
        {
            get { return _starBitmap; }
            set { _starBitmap = value; RaisePropertyChanged("ServiceStarImage"); }
        }
        public TimeSpan? TimeIn { get; set; }
        public BitmapImage Image
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged("Image"); }
        }

        public int Performance { get; set; }
        public string PerformanceDescription { get; set; }

        public override string ToString()
        {
            return string.Format("Name={0}, Slug={1}, Kills={2}, Headshots={3}, ServiceStars={4}, TimeIn={5}, Image={6}",
                Name, Slug, Kills, Headshots, ServiceStars, TimeIn, Image);
        }
    }

    public class ItemComparer : IEqualityComparer<IItem>
    {
        public bool Equals(IItem item1, IItem item2)
        {
            if (ReferenceEquals(item1, item2)) 
                return true;
            return item1.Name == item2.Name && item1.Kills == item2.Kills;
        }

        public int GetHashCode(IItem item)
        {
            int name = item.Name == null ? 0 : item.Name.GetHashCode();
            int kills = item.Kills == 0 ? 0 : item.Kills.GetHashCode();
            return name ^ kills;
        }

    }

}