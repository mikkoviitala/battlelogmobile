using System;
using System.IO.IsolatedStorage;
using System.Windows;
using BattlelogMobile.Core.Message;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Tomers.Phone.Controls;
using BattlelogMobile.Client.ViewModel;
using System.Threading.Tasks;
using Microsoft.Phone.Shell;
using System.Threading;

namespace BattlelogMobile.Client.View
{
    /// <summary>
    /// SoldierPage
    /// </summary>
    public partial class SoldierPage : PhoneApplicationPage
    {
        private const int DefaultNextRatingPrompt = 5;
        private static bool _ratingPrompted;
        private static bool _isUpdating = false;

        /// <summary>
        /// Initializes a new instance of the SoldierPage class.
        /// </summary>
        public SoldierPage()
        {
            InitializeComponent();
            Messenger.Default.Register<SoldierLoadedMessage>(this, SoldierLoadedMessageReceived);
        }

        private void SoldierLoadedMessageReceived(SoldierLoadedMessage message)
        {
            ToggleUIState(true);
            //GlobalLoading.Instance.Text = string.Format("Updated {0}", message);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Visibility = Visibility.Visible;
            Messenger.Default.Send(new SoldierVisibleMessage());
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            ToggleUIState(true);

            if (_ratingPrompted)
                return;

            _ratingPrompted = true;

            int launches;
            IsolatedStorageSettings.ApplicationSettings.TryGetValue("AppLaunches", out launches);

            int nextRatingPrompt;
            if (!IsolatedStorageSettings.ApplicationSettings.TryGetValue("NextRatingPrompt", out nextRatingPrompt))
                nextRatingPrompt = DefaultNextRatingPrompt;

            if (launches >= nextRatingPrompt)
            {
                IsolatedStorageSettings.ApplicationSettings["NextRatingPrompt"] = nextRatingPrompt * 2;

                NotificationBox.ShowAgain(
                    "Enjoying?",
                    "Would you like to review this application?",
                    "Ask me later",
                    false,
                    surpressed => { },
                    "RatingMsgPrompt",
                    new NotificationBoxCommand("Yes", () => new MarketplaceReviewTask().Show()),
                    new NotificationBoxCommand("No", () => {} ));
            }
            IsolatedStorageSettings.ApplicationSettings["AppLaunches"] = ++launches;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (_isUpdating)
                e.Cancel = true;
        }

        private void AboutMenuItemClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/YourLastAboutDialog;component/AboutPage.xaml", UriKind.Relative));
        }

        private void UpdateMenuItemClick(object sender, EventArgs e)
        {
            ToggleUIState(false);
            Messenger.Default.Send(new BattlelogCredentialsAcceptedMessage(ViewModelLocator.MainStatic.Email, true));
        }

        private void ToggleUIState(bool isEnabled)
        {
            _isUpdating = !isEnabled;

            if (isEnabled)
                Opacity = 1d;
            else
                Opacity = 0.5d;

            Panorama.IsEnabled = isEnabled;
            foreach (ApplicationBarIconButton button in ApplicationBar.Buttons)
                button.IsEnabled = isEnabled;
        }
    }
}