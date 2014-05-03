using System.Windows.Input;
using BattlelogMobile.Client.Message;
using BattlelogMobile.Core;
using BattlelogMobile.Core.Model.Battlefield4;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class Bf4UserControlViewModel : BfUserControlViewModel<Battlefield4Data>
    {
        private ProductInfo _product = null;

        public Bf4UserControlViewModel()
        {
            Messenger.Default.Register<ProductLicenseMessage>(this, message =>
                {
                    if (Product == null)
                        GetProducts();


                    // TODO: STORE == NULL
                    // Save licence locally

                    HasLicense = true; // message.HasLicense;
                    RaisePropertyChanged("HasLicense");
                });

            PurchaseCommand = new RelayCommand(() =>
                {
                    try
                    {
                        ViewModelLocator.Store.RequestProductPurchaseAsync(Common.ProductKey, true);
                    }
                    catch { }
                });

            GetProducts();
        }

        public ICommand PurchaseCommand { get; set; }
        
        public bool HasLicense { get; set; }

        public ProductInfo Product
        {
            get { return _product; }
            set
            {
                _product = value;
                RaisePropertyChanged("Product");
            }
        }

        private void GetProducts()
        {
            try
            {
                var li = ViewModelLocator.Store.LoadListingInformationAsync().GetResults();
                if (li.ProductListings.ContainsKey(Common.ProductKey))
                {
                    var productListing = li.ProductListings[Common.ProductKey];

                    var product = new ProductInfo(
                        productListing.Name,
                        productListing.Description,
                        productListing.FormattedPrice,
                        productListing.ImageUri);

                    Product = product;
                }
            }
            catch {}
        }
    }
}