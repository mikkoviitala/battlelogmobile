using Polenter.Serialization;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public class User : BaseModel, IUser
    {
        private BitmapImage _bitmap;

        public long Id { get; set; }                // userId
        public string Name { get; set; }            // username
        public string GravatarMd5 { get; set; }     // gravatarMd5
        [ExcludeFromSerialization]
        public BitmapImage Image
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged("RankImage"); }
        }

        public override string ToString()
        {
            return string.Format("Id={0}, Name={1}, GravatarMd5={2}, GravatarImage={3}", Id, Name, GravatarMd5, Image);
        }
    }
}