using BattlelogMobile.Client.ViewModel;


namespace BattlelogMobile.Client.UserControl
{
    public partial class Bf4UserControl : System.Windows.Controls.UserControl
    {
        public Bf4UserControl()
        {
            InitializeComponent();


            Do();
        }


        private void Do()
        {
            //if (ViewModelLocator.Store == null)
            //    return;

            //var license = ViewModelLocator.Store.LicenseInformation.ProductLicenses["bf4"];

            //Daa.Text = license.ProductId + " - " + license.IsConsumable + " " + license.IsActive;

            //if (!license.IsActive)
            //    ViewModelLocator.Store.RequestProductPurchaseAsync(license.ProductId, false);

            //if (license.IsActive)
            //    ViewModelLocator.Store.ReportProductFulfillment(license.ProductId);

            //System.Windows.ApplicationModel.
            //var li = ViewModelLocator.Store.LoadListingInformationAsync().Completed(() => {});
            //li.GetResults()
            //foreach (string key in li.ProductListings.Keys)
            //{
            //    var p = li.ProductListings[key];
            //    Daa.Text += key + " - " +
            //               p.Name + " - " +
            //               p.ProductId + " - " +
            //               p.ProductType + " - " +
            //               p.Tag + " - " +
            //               p.Keywords + " - " +
            //               p.ImageUri + " - " +
            //               p.Description;
            //}
        }
    }
}
 