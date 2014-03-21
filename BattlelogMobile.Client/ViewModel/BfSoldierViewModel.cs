using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Model.Battlefield4;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using StoreLauncher;

namespace BattlelogMobile.Client.ViewModel
{
    public class Bf3UserControlViewModel : BfUserControlViewModel<Battlefield3Data>
    {
        
    }

    public class ProductInfo : BaseModel
    {
        public ProductInfo(string name, string description, string formattedPrice, Uri imageUri, bool hasLicense)
        {
            Name = name;
            Description = description;
            FormattedPrice = formattedPrice;
            ImageUri = imageUri;
            HasLicense = hasLicense;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string FormattedPrice { get; set; }

        private Uri _imageUri;

        public Uri ImageUri
        {
            get { return _imageUri; }
            set
            {
                _imageUri = value;
                RaisePropertyChanged("ImageUri");

                Image.Source = new BitmapImage(_imageUri);
                RaisePropertyChanged("Image");
            }
        }

        public Image Image { get; set; }
        public bool HasLicense { get; set; }
    }

    public class Bf4UserControlViewModel : BfUserControlViewModel<Battlefield4Data>
    {
        private readonly ProductLicenseBase _license;

        public Bf4UserControlViewModel()
            : base()
        {
            //PurchaseCommand = new RelayCommand(() => Task.Factory.StartNew(() =>
            //    {
            //        ViewModelLocator.Store.RequestProductPurchaseAsync(_license.ProductId, false);
            //        RaisePropertyChanged("HasLicense");
            //    }));

            //Load();
            //_license = ViewModelLocator.Store.LicenseInformation.ProductLicenses["betabf4stats"];
        }

        //public void Load()
        //{
        //    //return new Task(() =>
        //    //    {
        //            try
        //            {
        //                var li = ViewModelLocator.Store.LoadListingInformationAsync().GetResults();
        //                var products = new List<ProductInfo>();

        //                var a = ViewModelLocator.Store.LicenseInformation.ProductLicenses["betabf4stats"];
                        
        //                products.Add(
        //                    new ProductInfo(
        //                        "Product One",
        //                        "Description One",
        //                        "0.00€",
        //                        new Uri("/Assets/Images/Common/InAppBf4Unlock.png", UriKind.Relative),
        //                        a.IsActive));

        //                a = ViewModelLocator.Store.LicenseInformation.ProductLicenses["betabf4stats2"];

        //                products.Add(
        //                    new ProductInfo(
        //                        "Product Two",
        //                        "Description Two",
        //                        "0.00€",
        //                        new Uri("/Assets/Images/Common/InAppBf4Unlock.png", UriKind.Relative),
        //                        a.IsActive));

        //                //foreach (string key in li.ProductListings.Keys)
        //                //{
        //                //    var pListing = li.ProductListings[key];
        //                //    System.Diagnostics.Debug.WriteLine(key);

        //                //    var product = new ProductInfo(
        //                //        pListing.Name,
        //                //        pListing.Description,
        //                //        pListing.FormattedPrice,
        //                //        pListing.ImageUri,
        //                //        ViewModelLocator.Store.LicenseInformation.ProductLicenses[key].IsActive);

        //                //    products.Add(product);
        //                //}
        //                Products = new ObservableCollection<ProductInfo>(products);
        //            }
        //            catch
        //            {
        //            }
        //        //});
        //}

        private ObservableCollection<ProductInfo> _products = new ObservableCollection<ProductInfo>();
        public ObservableCollection<ProductInfo> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                RaisePropertyChanged("Products");
            }
        }

        public ICommand PurchaseCommand { get; set; }
    }

    public class BfUserControlViewModel<T> : BaseViewModel where T : IUpdateInfo
    {
        private static DispatcherTimer _dispatchTimer = null;
        private T _data;

        public BfUserControlViewModel()
        {
            if (_dispatchTimer != null)
                return;

            _dispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1d) };
            _dispatchTimer.Tick += (sender, args) =>
                {
                    if (Data == null)
                        return;

                    Updated = DateTime.Now  - Data.Updated;
                    RaisePropertyChanged("Updated");
                };
            _dispatchTimer.Start();
        }
        
        public TimeSpan Updated { get; private set; }

        public T Data 
        {
            get { return _data; }
            set
            {
                _data = value;
                RaisePropertyChanged("Data");
            }
        }
    }
}