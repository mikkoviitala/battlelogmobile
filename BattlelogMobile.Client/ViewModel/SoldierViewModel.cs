using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;

namespace BattlelogMobile.Client.ViewModel
{
    public class SoldierViewModel : BaseViewModel
    {
        private readonly Brush _blackBrush = new SolidColorBrush(Colors.Black);
        private readonly ImageBrush _bf3Brush = new ImageBrush 
            { ImageSource = new BitmapImage(new Uri(Common.Bf3BackgroundUri, UriKind.Relative)), Opacity = 0.25d, Stretch = Stretch.None };
        private readonly ImageBrush _bf4Brush = new ImageBrush 
            { ImageSource = new BitmapImage(new Uri(Common.Bf4BackgroundUri, UriKind.Relative)), Opacity = 0.25d, Stretch = Stretch.None };

        private bool _appBarEnabled = true;
        private bool _backgroundEnabled;
        private Brush _background;
        private SupportedGame _game = SupportedGame.Unknown;

        public SoldierViewModel()
            :this(new FileSettingsRepository(), new BattlelogRepository(new DownloadService(ViewModelLocator.CookieJar)))
        {}

        public SoldierViewModel(FileSettingsRepository settingRepository, BattlelogRepository battlelogRepository)
        {
            _background = _bf3Brush;
            SettingsRepository = settingRepository;
            BattlelogRepository = battlelogRepository;

            UpdateCommand = new RelayCommand(() => UpdateData(true));

            ToggleBackgroundCommand = new RelayCommand(() =>
                {
                    _backgroundEnabled = !_backgroundEnabled;
                    SetBackground();
                });

            AboutCommand = new RelayCommand(() => ViewModelLocator.Navigation.NavigateTo(ViewModelLocator.AboutPageUri));

            _backgroundEnabled = (SettingsRepository.Load()).BackgroundEnabled;
        }

        private void SetBackground()
        {
            if (!_backgroundEnabled)
                Background = _blackBrush;
            else
                Background = _game == SupportedGame.Battlefield3 ? _bf3Brush : _bf4Brush;
        }

        public ICommand UpdateCommand { get; set; }

        public ICommand ToggleBackgroundCommand { get; set; }

        public ICommand AboutCommand { get; set; }

        public BattlelogRepository BattlelogRepository { get; set; }

        public FileSettingsRepository SettingsRepository { get; set; }

        public bool AppBarEnabled
        {
            get { return _appBarEnabled; }
            set { _appBarEnabled = value; RaisePropertyChanged("AppBarEnabled"); }
        }

        public Brush Background
        {
            get { return _background; }
            set
            {
                _background = value;
                RaisePropertyChanged("Background");
                RaisePropertyChanged("ToggleBackgroundIconUri");
            }
        }

        public string ToggleBackgroundIconUri 
        {
            get { return !_backgroundEnabled ? Common.ToggleBackgroundCheckedUri : Common.ToggleBackgroundUncheckedUri; }
        }

        public SupportedGame Game
        {
            get { return _game; }
            set
            {
                _game = value;
                RaisePropertyChanged("Game");
            }
        }

        public async void UpdateData(bool forceUpdate)
        {
            try
            {
                SetBackground();
                AppBarEnabled = false;
                await Update(forceUpdate);
                AppBarEnabled = true;
            }
            catch
            {
                Messenger.Default.Send(
                    new DialogMessage(this, Common.UnexpectedException, result => { }) 
                        { Caption = Common.FailedMessageHeader, Button = MessageBoxButton.OK });
            }
        }

        public async Task Update(bool forceUpdate)
        {
            // TODO: Untangle this "logic" right here

            bool success = await BattlelogRepository.UpdateStorage(_game, forceUpdate);
            if (!success)
                return;

            if (_game == SupportedGame.Unknown || _game == SupportedGame.Battlefield3)
            {
                var battlefieldData = await BattlelogRepository.LoadBattlefieldData(new Bf3Parser());
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    Messenger.Default.Send(new NotificationMessage(this, string.Empty));
                    ViewModelLocator.Bf4UserControl.Data = null;
                    ViewModelLocator.Bf3UserControl.Data = battlefieldData;
                    ViewModelLocator.Navigation.NavigateTo(ViewModelLocator.SoldierPageUri);
                });
            }
            else
            {
                var battlefieldData = await BattlelogRepository.LoadBattlefieldData(new Bf4Parser());
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    Messenger.Default.Send(new NotificationMessage(this, string.Empty));
                    ViewModelLocator.Bf3UserControl.Data = null;
                    ViewModelLocator.Bf4UserControl.Data = battlefieldData;
                    ViewModelLocator.Navigation.NavigateTo(ViewModelLocator.SoldierPageUri);
                });
            }
        }
    }
}
