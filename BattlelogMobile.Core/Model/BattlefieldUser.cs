using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    public class BattlefieldUser : BaseModel
    {
        private static readonly ImageRepository Repo = new ImageRepository();

        private long _userId;
        [JsonProperty(PropertyName = "userId")]
        public long UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                RaisePropertyChanged("UserId");
            }
        }

        private string _userName;
        [JsonProperty(PropertyName = "username")]
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        private string _gravatarMd5;
        [JsonProperty(PropertyName = "gravatarMd5")]
        public string GravatarMd5
        {
            get { return _gravatarMd5; }
            set
            {
                _gravatarMd5 = value;
                RaisePropertyChanged("GravatarMd5");
                DispatcherHelper.CheckBeginInvokeOnUI(() => Repo.Load(Common.GravatarImageUrl, GravatarMd5, bitmap => GravatarImage = bitmap)); 
            }
        }

        private BitmapImage _gravatarImage;
        [JsonIgnore]
        [ExcludeFromSerialization]
        public BitmapImage GravatarImage
        {
            get { return _gravatarImage; }
            set
            {
                _gravatarImage = value;
                RaisePropertyChanged("GravatarImage");
            }
        }
    }
}