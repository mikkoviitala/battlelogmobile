using System.Windows.Media.Imaging;

namespace BattlelogMobile.Core.Model
{
    public class Unlock : BaseModel, IUnlock
    {
        private BitmapImage _image;

        public string Parent { get; set; }
        public string Slug { get; set; }
        public int Completion { get; set; }
        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                RaisePropertyChanged("Image");
            }
        }
    }
}
