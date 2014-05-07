using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using BattlelogMobile.Client.Message;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Tomers.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BattlelogMobile.Client.View
{

    public partial class SoldierPage : PhoneApplicationPage
    {
        private const string AppLaunchesKey = "AppLaunches";
        private const string NextRatingPromptKey = "NextRatingPrompt";
        private const string RatingUniqueIdentifier = "RatingMsgPrompt";
        private const string InfoPromptedKey = "InfoPrompted";
        private const string TipPromptedKey = "TipPrompted";

        private const int DefaultNextRatingPrompt = 5;
        private static bool _ratingPrompted;
        private static bool _isUpdating;

        public SoldierPage()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            ShowInfoPrompt();
            ShowTipPrompt();
            ShowRatingPrompt();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Messenger.Default.Send(new ProductLicenseMessage());
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (_isUpdating)
                e.Cancel = true;
        }

        private void ToggleUIState(bool isEnabled)
        {
            foreach (ApplicationBarIconButton button in ApplicationBar.Buttons)
                button.IsEnabled = isEnabled;

            _isUpdating = !isEnabled;
        }

        private void ToggleAppBarSate(object sender, DependencyPropertyChangedEventArgs e)
        {
            ToggleUIState((sender as CheckBox).IsEnabled);
        }

        private static void ShowRatingPrompt()
        {
            if (_ratingPrompted)
                return;

            _ratingPrompted = true;

            int launches;
            IsolatedStorageSettings.ApplicationSettings.TryGetValue(AppLaunchesKey, out launches);

            int nextRatingPrompt;
            if (!IsolatedStorageSettings.ApplicationSettings.TryGetValue(NextRatingPromptKey, out nextRatingPrompt))
                nextRatingPrompt = DefaultNextRatingPrompt;

            if (launches >= nextRatingPrompt)
            {
                IsolatedStorageSettings.ApplicationSettings[NextRatingPromptKey] = nextRatingPrompt * 2;

                NotificationBox.ShowAgain(
                    "Enjoying?",
                    "Would you like to review this application?",
                    "Ask me later",
                    false,
                    surpressed => { },
                    RatingUniqueIdentifier,
                    new NotificationBoxCommand("Yes", () => new MarketplaceReviewTask().Show()),
                    new NotificationBoxCommand("No", () => { }));
            }
            IsolatedStorageSettings.ApplicationSettings[AppLaunchesKey] = ++launches;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        private void ShowInfoPrompt()
        {
            Dispatcher.BeginInvoke(() => 
                {
                    bool infoPrompted;
                    IsolatedStorageSettings.ApplicationSettings.TryGetValue(InfoPromptedKey, out infoPrompted);

                    if (infoPrompted)
                        return;

                    MessageBox.Show(
                        "See those three dots on bottom right of the screen? Good, tap it to popup menu and update your soldier's statistics when ever you want.",
                        "Hey there!", MessageBoxButton.OK);

                    IsolatedStorageSettings.ApplicationSettings[InfoPromptedKey] = true;
                    IsolatedStorageSettings.ApplicationSettings.Save();
                });
        }

        private void ShowTipPrompt()
        {
            Dispatcher.BeginInvoke(() =>
            {
                bool tipPrompted;
                IsolatedStorageSettings.ApplicationSettings.TryGetValue(TipPromptedKey, out tipPrompted);

                if (tipPrompted)
                    return;

                MessageBox.Show(
                    "Go to Battlelog website and change your Active Soldier to control which statistics are shown on your mobile.",
                    "Pro tip!", MessageBoxButton.OK);

                IsolatedStorageSettings.ApplicationSettings[TipPromptedKey] = true;
                IsolatedStorageSettings.ApplicationSettings.Save();
            });
        }
    }
}