using System;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Service;
using Newtonsoft.Json;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    public class Item : BaseModel
    {
        private BitmapImage _bitmap;
        private BitmapImage _starBitmap;

        [JsonProperty(PropertyName = "guid")]
        public string Guid { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonIgnore]
        public string DisplayName
        {
            get { return ItemNameMapper.Get(Slug); }
        }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "kills")]
        public int Kills { get; set; }

        public int? Headshots { get; set; }

        public int? ServiceStars { get; set; }

        [ExcludeFromSerialization]
        public BitmapImage ServiceStarImage
        {
            get { return _starBitmap; }
            set { _starBitmap = value; RaisePropertyChanged("ServiceStarImage"); }
        }

        [JsonIgnore]
        public TimeSpan? TimeIn { get; set; }

        private string _timeInSeconds;
        [JsonProperty(PropertyName = "timeIn")]
        [ExcludeFromSerialization]
        public string TimeInSeconds
        {
            get { return _timeInSeconds; }
            set
            {
                _timeInSeconds = value;
                TimeIn = TimeSpan.FromSeconds(Convert.ToInt32(_timeInSeconds));
            }
        }

        [ExcludeFromSerialization]
        public BitmapImage Image
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged("Image"); }
        }

        [JsonIgnore]
        public string ImageName { get; set; }

        public int ShotsFired { get; set; }

        public double Accuracy { get; set; }

        public int Performance { get; set; }
        
        public string PerformanceDescription { get; set; }

        public override string ToString()
        {
            return string.Format("Name={0}, Slug={1}, Kills={2}, Headshots={3}, ServiceStars={4}, TimeIn={5}, Image={6}",
                Name, Slug, Kills, Headshots, ServiceStars, TimeIn, Image);
        }
    }
}