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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace BattlelogMobile.Client.View
{
    /// <summary>
    /// SoldierPage
    /// </summary>
    public partial class SoldierPage : PhoneApplicationPage
    {
        private const string BackgroundUri = @"/PanoramaBackground.jpg";
        private const string CheckedUri = "/Toolkit.Content/ApplicationBar.Check.png";
        private const string UncheckedUri = "/Toolkit.Content/ApplicationBar.Uncheck.png";
        private const string AboutUri = "/YourLastAboutDialog;component/AboutPage.xaml";

        private const string AppLaunchesKey = "AppLaunches";
        private const string NextRatingPromptKey = "NextRatingPrompt";
        private const string RatingUniqueIdentifier = "RatingMsgPrompt";
        private const string InfoPromptedKey = "InfoPrompted";
        private const string TipPromptedKey = "TipPrompted";

        private const int DefaultNextRatingPrompt = 5;
        private static bool _ratingPrompted;
        private static bool _isUpdating = false;
        private ImageBrush _brush = new ImageBrush() { ImageSource = new BitmapImage(new Uri(BackgroundUri, UriKind.Relative)), Opacity = 0.25d };
        private Brush _blackBrush = new SolidColorBrush(Colors.Black);

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
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Visibility = Visibility.Visible;

            SetBackground();
            Messenger.Default.Send(new SoldierVisibleMessage());
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            ToggleUIState(true);
            ShowInfoPrompt();
            ShowTipPrompt();
            ShowRatingPrompt();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (_isUpdating)
                e.Cancel = true;
        }

        private void AboutMenuItemClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri(AboutUri, UriKind.Relative));
        }

        private void UpdateMenuItemClick(object sender, EventArgs e)
        {
            ToggleUIState(false);
            //Messenger.Default.Send(new UpdateRequestedMessage("Please wait..."));
            Messenger.Default.Send(new BattlelogCredentialsAcceptedMessage(ViewModelLocator.MainStatic.Email, true));
        }

        private void BackgroundMenuItemClick(object sender, EventArgs e)
        {
            BackgroundEnabled = !BackgroundEnabled;
            SetBackground();
        }

        private bool BackgroundEnabled
        {
            get { return (DataContext as SoldierViewModel).BackgroundEnabled; }
            set { (DataContext as SoldierViewModel).BackgroundEnabled = value; }
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

        private void SetBackground()
        {
            if (BackgroundEnabled)
            {
                Panorama.Background = _brush;
                (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IconUri = (new Uri(UncheckedUri, UriKind.Relative));
            }
            else
            {
                Panorama.Background = _blackBrush; 
                (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IconUri = (new Uri(CheckedUri, UriKind.Relative));
            }
        }

        private void ShowRatingPrompt()
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
                    "Go to Battlelog website and change your Active Soldier to choose which statistics you'll receive.",
                    "Pro tip!", MessageBoxButton.OK);

                IsolatedStorageSettings.ApplicationSettings[InfoPromptedKey] = true;
            });
        }
    }
}