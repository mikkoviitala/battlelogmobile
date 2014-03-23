using System;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Client.ViewModel
{
    public class ProductInfo : BaseModel
    {
        private Uri _imageUri;

        public ProductInfo()
        {}

        public ProductInfo(string name, string description, string formattedPrice, Uri imageUri)
        {
            Name = name;
            Description = description;
            FormattedPrice = formattedPrice;
            ImageUri = imageUri;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FormattedPrice { get; set; }

        public Uri ImageUri
        {
            get { return _imageUri; }
            set
            {
                _imageUri = value;
                RaisePropertyChanged("ImageUri");
                RaisePropertyChanged("Image");
            }
        }

        private BitmapImage _image = new BitmapImage();
        public BitmapImage Image
        {
            get
            {
                _image = new BitmapImage(_imageUri);
                return _image;
            }
        }
    }
}