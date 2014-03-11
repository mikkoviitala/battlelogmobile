using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    public class KitServiceStar : BaseModel
    {
        private static readonly ImageRepository Repo = new ImageRepository();

        public KitServiceStar()
        {}

        public KitServiceStar(KitType kitType, int score, int stars, double progression, double percentage)
        {
            Type = kitType;
            Score = score;
            Stars = stars;
            Progression = progression;
            Percentage = percentage;
        }

        private KitType _kitType;
        public KitType Type
        {
            get { return _kitType; }
            set
            {
                _kitType = value;
                RaisePropertyChanged("Type");

                string imageName = string.Format("{0}{1}", Type.ToString().ToLowerInvariant(), Common.ImageSuffix);
                DispatcherHelper.CheckBeginInvokeOnUI(() => Repo.Load(Common.KitImageUrl, imageName, bitmap => Image = bitmap));
            }
        }

        private int _stars;
        public int Stars
        {
            get { return _stars; }
            set
            {
                _stars = value;
                RaisePropertyChanged("Stars");
            }
        }

        private double _progression;
        public double Progression
        {
            get { return _progression; }
            set
            {
                _progression = value;
                RaisePropertyChanged("Progression");
            }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged("Score");
            }
        }

        private double _percentage;
        public double Percentage
        {
            get { return _percentage; }
            set
            {
                _percentage = value;
                RaisePropertyChanged("Percentage");
            }
        }

        private BitmapImage _kitImage;
        [JsonIgnore]
        [ExcludeFromSerialization]
        public BitmapImage Image
        {
            get { return _kitImage; }
            set
            {
                _kitImage = value;
                RaisePropertyChanged("Image");
            }
        }
    }
}