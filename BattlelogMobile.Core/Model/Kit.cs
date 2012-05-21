using System;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    // parsed from overviewStats - kitScores block  
    public class Kit : BaseModel, IKit
    {
        private BitmapImage _bitmap;

        public  Kit()
        {}

        public Kit(KitType type, int score) : this(type, score, new TimeSpan(), 0d)
        {}

        public Kit(KitType type, int score, TimeSpan time, double percentage)
        {
            Type = type;
            Score = score;
            Time = time;
            Percentage = percentage;
        }

        public KitType Type { get; set; }   
        public int Score { get; set; }
        public TimeSpan Time { get; set; }
        public double Percentage { get; set; }
        public BitmapImage Image
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged("Image"); }
        }

        public int CompareTo(object kit)
        {
            if (kit == null)
                return 1;

            var otherKit = kit as Kit;
            if (otherKit != null)
                return Type.CompareTo(otherKit.Type);
            throw new ArgumentException("object is not a Kit!");
        }

        public bool Equals(IKit otherKit)
        {
            return otherKit != null && Type.Equals(otherKit.Type);
        }

        public override string ToString()
        {
            return string.Format("Type={0}, Score={1}, Time={2}s, Percentage={3}", Type, Score, Time, Percentage);
        }
    }
}