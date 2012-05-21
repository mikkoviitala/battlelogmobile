using System;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    // overviewStats - serviceStarsProgress   
    // overviewStats - serviceStars
    public class KitProgression : BaseModel, IKitProgression
    {
        private BitmapImage _bitmap;
        public KitProgression(KitType type, int serviceStars, double progress)
        {
            Type = type;
            ServiceStars = serviceStars;
            Progress = progress;
        }

        public KitType Type { get; set; }       
        public int ServiceStars { get; set; }
        public BitmapImage Image
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged("Image"); }
        }
        public double Progress { get; set; }

        public int CompareTo(object progression)
        {
            if (progression == null)
                return 1;

            var otherProgression = progression as KitProgression;
            if (otherProgression != null)
                return Type.CompareTo(otherProgression.Type);
            throw new ArgumentException("object is not a KitProgression!");
        }

        public bool Equals(IKitProgression otherKitProgression)
        {
            return otherKitProgression != null && Type.Equals(otherKitProgression.Type);
        }

        public override string ToString()
        {
            return string.Format("Type={0}, ServiceStars={1}, Progress={2}", Type, ServiceStars, Progress);
        }
    }
}
