using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Device.Location;
using BattlelogMobile.Log;

namespace BattlelogMobile.Client.View
{
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
                            DevCenterAds.Longitude = coordinates.Longitude;
                            DevCenterAds.Latitude = coordinates.Latitude;
                        }
                        finally
                        {
                            _watcher.Stop();
                        }
                    } 
                };
            _watcher.Start();

            LayoutUpdated += OnLayoutUpdated;
        }

        private void OnLayoutUpdated(object sender, EventArgs eventArgs)
        {
            LayoutUpdated -= OnLayoutUpdated;
            EmailLogProvider.ReportException();
        }

        private void InputChangedUpdateTrigger(object sender, EventArgs e)
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

