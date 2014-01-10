using System;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    public class ItemContainer : BaseModel
    {
        private static readonly ImageRepository Repo = new ImageRepository();

        public ItemContainer()
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => Repo.Load(Common.ServiceStarImageUrl, Common.ServiceStarImage, bitmap => ServiceStarImage = bitmap));
        }

        private string _guid;
        [JsonProperty(PropertyName = "guid")]
        public string Guid
        {
            get { return _guid; }
            set
            {
                _guid = value;
                RaisePropertyChanged("Guid");
            }
        }

        private string _name;
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        [JsonIgnore]
        public string DisplayName
        {
            get { return ItemNameMapper.Get(Slug); }
        }

        private string _slug;
        [JsonProperty(PropertyName = "slug")]
        public string Slug
        {
            get { return _slug; }
            set
            {
                _slug = value.ToUpperInvariant();
                RaisePropertyChanged("Slug");
            }
        }

        private double _kills;
        [JsonProperty(PropertyName = "kills")]
        public double Kills
        {
            get { return _kills; }
            set
            {
                _kills = value;
                RaisePropertyChanged("Kills");
            }
        }

        private double _headshots;
        [JsonProperty(PropertyName = "headshots")]
        public double Headshots
        {
            get { return _headshots; }
            set
            {
                _headshots = value;
                RaisePropertyChanged("Headshots");
            }
        }

        private double _serviceStars;
        [JsonProperty(PropertyName = "serviceStars")]
        public double ServiceStars
        {
            get { return _serviceStars; }
            set
            {
                _serviceStars = value;
                RaisePropertyChanged("ServiceStars");
            }
        }

        private BitmapImage _serviceStarImage;
        [JsonIgnore]
        [ExcludeFromSerialization]
        public BitmapImage ServiceStarImage
        {
            get { return _serviceStarImage; }
            set
            {
                _serviceStarImage = value; 
                RaisePropertyChanged("ServiceStarImage");
            }
        }

        private TimeSpan? _timeIn;
        [JsonIgnore]
        public TimeSpan? TimeIn
        {
            get { return _timeIn; }
            set
            {
                _timeIn = value;
                RaisePropertyChanged("TimeIn");
            }
        }

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

        private BitmapImage _image;
        [JsonIgnore]
        [ExcludeFromSerialization]
        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value; 
                RaisePropertyChanged("Image");
            }
        }

        private string _imageName;
        [JsonIgnore]
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                RaisePropertyChanged("ImageName");

                if (TimeIn != null)
                    DispatcherHelper.CheckBeginInvokeOnUI(() => Repo.Load(Common.VehicleAndGadgetImageUrl, _imageName, bitmap => Image = bitmap));
                else
                    DispatcherHelper.CheckBeginInvokeOnUI(() => Repo.Load(Common.WeaponAndAccessoryImageUrl, _imageName, bitmap => Image = bitmap));
            }
        }

        private double _shotsFired;
        [JsonProperty(PropertyName = "shotsFired")]
        public double ShotsFired
        {
            get { return _shotsFired; }
            set
            {
                _shotsFired = value;
                RaisePropertyChanged("ShotsFired");
            }
        }

        private double _accuracy;
        [JsonProperty(PropertyName = "accuracy")]
        public double Accuracy
        {
            get { return _accuracy; }
            set
            {
                _accuracy = value;
                RaisePropertyChanged("Accuracy");
            }
        }
    }
}