using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    public class GadgetContainer : BaseModel
    {
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
        [JsonProperty(PropertyName = "slug")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
                Slug = value.ToUpperInvariant();
            }
        }

        private string _slug;
        [JsonIgnore]
        public string Slug
        {
            get { return _slug; }
            set
            {
                _slug = value;
                RaisePropertyChanged("Slug");
            }
        }

        [JsonIgnore]
        public string DisplayName
        {
            get { return ItemNameMapper.Get(Slug); }
        }

        private List<Performance> _performances; 
        [JsonProperty(PropertyName = "performances", NullValueHandling = NullValueHandling.Ignore)]
        public List<Performance> Performances
        {
            get { return _performances; }
            set
            {
                if (value == null)
                    return;

                _performances = value;
                RaisePropertyChanged("Performances");
            }
        }

        private BitmapImage _bitmap;
        [JsonIgnore]
        [ExcludeFromSerialization]
        public BitmapImage Image
        {
            get { return _bitmap; }
            set
            {
                _bitmap = value; 
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

                Task.Factory.StartNew(() =>
                    {
                        var r = new ImageRepository();
                        DispatcherHelper.CheckBeginInvokeOnUI(() => r.Load(Common.VehicleAndGadgetImageUrl, _imageName, bitmap => Image = bitmap));
                    });
            }
        }
    }
}