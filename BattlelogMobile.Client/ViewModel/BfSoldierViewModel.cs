using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using BattlelogMobile.Core.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using StoreLauncher;

namespace BattlelogMobile.Client.ViewModel
{
    public class BfUserControlViewModel<T> : BaseViewModel where T : IUpdateInfo
    {
        private static DispatcherTimer DispatchTimer = null;
        private readonly ProductLicenseBase _license;
        private T _data;

        public BfUserControlViewModel()
        {
            if (DispatchTimer != null)
                return;

            DispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1d) };
            DispatchTimer.Tick += (sender, args) =>
                {
                    if (Data == null)
                        return;

                    Updated = DateTime.Now  - Data.Updated;
                    RaisePropertyChanged("Updated");
                };
            DispatchTimer.Start();

            PurchaseCommand = new RelayCommand(() =>
                {
                    Task.Factory.StartNew(() =>
                        {
                            PurchaseCommand.CanExecute(false);
                            ViewModelLocator.Store.RequestProductPurchaseAsync(_license.ProductId, false);
                            PurchaseCommand.CanExecute(true);
                            RaisePropertyChanged("HasLicense");
                        });
                });

            _license = ViewModelLocator.Store.LicenseInformation.ProductLicenses["betabf4stats"];

        }

        public string A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public async void Load()
        {

            if (!string.IsNullOrWhiteSpace(A))
                return;

            var li = ViewModelLocator.Store.LoadListingInformationAsync().GetResults();
            var pListing = li.ProductListings["betabf4stats"];
            A = pListing.Name;
            B = pListing.FormattedPrice;
            C = pListing.Description;

            RaisePropertyChanged("A");
            RaisePropertyChanged("B");
            RaisePropertyChanged("C");
        }

        public ICommand PurchaseCommand { get; set; }

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

        public bool HasLicense
        {
            get { return _license.IsActive; }
        }
    }
}