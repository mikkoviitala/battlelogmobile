using System;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Tomers.Phone.Controls;
using BattlelogMobile.Client.ViewModel;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Client.View
{

    public partial class SoldierPage : PhoneApplicationPage
    {
        private const string BackgroundUri = @"/PivotBackground.jpg";
        private const string CheckedUri = "/Toolkit.Content/ApplicationBar.Check.png";
        private const string UncheckedUri = "/Toolkit.Content/ApplicationBar.Uncheck.png";

        private const string AppLaunchesKey = "AppLaunches";
        private const string NextRatingPromptKey = "NextRatingPrompt";
        private const string RatingUniqueIdentifier = "RatingMsgPrompt";
        private const string InfoPromptedKey = "InfoPrompted";
        private const string TipPromptedKey = "TipPrompted";

        private const int DefaultNextRatingPrompt = 5;
        private static bool _ratingPrompted;
        private static bool _isUpdating;
        private readonly ImageBrush _brush = new ImageBrush { ImageSource = new BitmapImage(new Uri(BackgroundUri, UriKind.Relative)), Opacity = 0.25d, Stretch = Stretch.None };
        private readonly Brush _blackBrush = new SolidColorBrush(Colors.Black);

        private readonly FileSettingsRepository _settingsRepository = new FileSettingsRepository();
        private bool _backgroundEnabled;

        public SoldierPage()
        {
            InitializeComponent();
            BackgroundEnabled = (_settingsRepository.Load()).BackgroundEnabled;
            SetBackground();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            var dispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            dispatchTimer.Tick += (o, args) =>
            {
                dispatchTimer.Stop();
                ShowInfoPrompt();
                ShowTipPrompt();
                ShowRatingPrompt();
            };
            dispatchTimer.Start();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (_isUpdating)
                e.Cancel = true;
        }

        public bool BackgroundEnabled
        {
            get { return _backgroundEnabled; }
            set
            {
                _backgroundEnabled = value;
                _settingsRepository.Save(new Settings { BackgroundEnabled = value });
            }
        }
        
        private void AboutMenuItemClick(object sender, EventArgs e)
        {
            ViewModelLocator.Navigation.NavigateTo(ViewModelLocator.AboutPageUri);
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

        private void BackgroundMenuItemClick(object sender, EventArgs e)
        {
            BackgroundEnabled = !BackgroundEnabled;
            SetBackground();
        }

        private void SetBackground()
        {
            var button = ApplicationBar.Buttons[1] as ApplicationBarIconButton;
            if (button == null)
                return;

            if (BackgroundEnabled)
            {
                LayoutRoot.Background = _brush;
                button.IconUri = (new Uri(UncheckedUri, UriKind.Relative));
            }
            else
            {
                LayoutRoot.Background = _blackBrush; 
                button.IconUri = (new Uri(CheckedUri, UriKind.Relative));
            }
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
                    "Go to Battlelog website and change your Active Soldier to control which statistics are shown on your mobile.",
                    "Pro tip!", MessageBoxButton.OK);

                IsolatedStorageSettings.ApplicationSettings[TipPromptedKey] = true;
            });
        }


    }
}