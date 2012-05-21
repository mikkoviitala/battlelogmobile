using System;
using System.IO.IsolatedStorage;
using System.Windows;
using BattlelogMobile.Core.Message;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Tomers.Phone.Controls;

namespace BattlelogMobile.Client.View
{
    /// <summary>
    /// Description for SoldierPage.
    /// </summary>
    public partial class SoldierPage : PhoneApplicationPage
    {
        private const int DefaultNextRatingPrompt = 5;
        private static bool _ratingPrompted;

        /// <summary>
        /// Initializes a new instance of the SoldierPage class.
        /// </summary>
        public SoldierPage()
        {
            InitializeComponent();
            ShowLoginHelp();
        }

        private static void ShowLoginHelp()
        {
            NotificationBox.ShowAgain(
                "Problems?",
                "If your credentials are not being saved, please uninstall and install application again. " +
                "For further assistance, please contact Support.",
                false,
                surpressed => { },
                "LoginMsgPrompt",
                new NotificationBoxCommand("Ok", () => { }));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Messenger.Default.Send(new SoldierVisibleMessage());
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
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

        private void AboutMenuItemClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/YourLastAboutDialog;component/AboutPage.xaml", UriKind.Relative));
        }
    }
}