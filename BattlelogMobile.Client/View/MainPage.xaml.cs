using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Device.Location;

namespace BattlelogMobile.Client.View
{
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : IDisposable
    {
        private GeoCoordinateWatcher _watcher;

        public MainPage()
        {
            InitializeComponent();

            _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            _watcher.MovementThreshold = 20;
            _watcher.StatusChanged += (sender, args) =>
                {
                    if (args.Status == GeoPositionStatus.Ready)
                    {
                        try
                        {
                            GeoCoordinate coordinates = _watcher.Position.Location;
                            BattlelogMobileAds.Longitude = coordinates.Longitude;
                            BattlelogMobileAds.Latitude = coordinates.Latitude;
                        }
                        finally
                        {
                            _watcher.Stop();
                        }
                    } 
                };
            _watcher.Start(); 
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_watcher != null)
                {
                    _watcher.Dispose();
                    _watcher = null;
                }
            }
        }
    }
}

