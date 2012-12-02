using System.Windows.Controls;
using System.Windows.Data;
//using System.Device;

namespace BattlelogMobile.Client.View
{
    /// <summary>
    /// Mainapage
    /// </summary>
    public partial class MainPage
    {
        //private GeoCoordinateWatcher watcher;

        public MainPage()
        {
            InitializeComponent();

            //if (watcher == null)
            //{
            //    watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High); // Use high accuracy. 
            //    watcher.MovementThreshold = 20; // Use MovementThreshold to ignore noise in the signal. 
            //    watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
            //}
            //watcher.Start(); 

            //void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e) 
            //{ 
            //    if (e.Status == GeoPositionStatus.Ready) 
            //    { 
            //        // Use the Position property of the GeoCoordinateWatcher object to get the current location. 
            //        GeoCoordinate co = watcher.Position.Location; 
            //        latitudeTextBlock.Text = co.Latitude.ToString("0.000"); 
            //        longitudeTextBlock.Text = co.Longitude.ToString("0.000"); 
            //        //Stop the Location Service to conserve battery power. 
            //        watcher.Stop(); 
            //    } 
            //}

            //BattlelogMobileAds.CountryOrRegion
            //BattlelogMobileAds.PostalCode
            //BattlelogMobileAds.Longitude
            //BattlelogMobileAds.Latitude

            //BattlelogMobileAds.ErrorOccurred += (sender, args) => System.Diagnostics.Debug.WriteLine(args.Error.ToString());
        }

        private void TextChangedUpdateTrigger(object sender, TextChangedEventArgs e)
        {
            UpdateSource(sender);
        }

        private void PasswordChangedUpdateTrigger(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateSource(sender);
        }

        /// <summary>
        /// Workaround to update properties while typing
        /// </summary>
        private static void UpdateSource(object sender)
        {
            BindingExpression bindingExpression = null;
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
            }
            else
            {
                var passwordBox = sender as PasswordBox;
                if (passwordBox != null)
                    bindingExpression = passwordBox.GetBindingExpression(PasswordBox.PasswordProperty);
            }

            if (bindingExpression != null)
                bindingExpression.UpdateSource();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            while (NavigationService.RemoveBackEntry() != null)
                NavigationService.RemoveBackEntry();
            base.OnBackKeyPress(e);
        }
    }
}

