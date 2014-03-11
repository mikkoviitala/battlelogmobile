using System.Collections.ObjectModel;
using System.Windows;
using BattlelogMobile.Core;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using System.Linq;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class Bf3SoldierViewModel : BaseViewModel
    {
        private BattlefieldData _battlefieldData;
        private bool _backgroundEnabled;

        public Bf3SoldierViewModel()
            : this(new FileSettingsRepository(), new BattlelogRepository(new DownloadService(ViewModelLocator.CookieJar)))
        {}

        public Bf3SoldierViewModel(FileSettingsRepository settingsRepository, BattlelogRepository battlelogRepository)
        {
            SettingsRepository = settingsRepository;
            BattlelogRepository = battlelogRepository;

            LoadSettings();

            // Credentials are ok, download information
            Messenger.Default.Register<BattlelogCredentialsAcceptedMessage>(this, async message =>
                {
                    if (message.Game != SupportedGame.Battlefield3)
                        return;

                    BattlelogRepository.CurrentUser = message.CurrentUser;
                    await BattlelogRepository.UpdateStorage(message.ForceUpdate);
                });

            // Download complete, parse data
            Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, async message =>
                {
                    var battlefieldData = await BattlelogRepository.LoadBattlefieldData();
                    if (battlefieldData == null)
                        return;
                    
                    ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() => Data = battlefieldData);
                });
        }

        public BattlelogRepository BattlelogRepository { get; set; }

        public FileSettingsRepository SettingsRepository { get; set; }

        public BattlefieldData Data
        {
            get { return _battlefieldData; }
            set
            {
                _battlefieldData = value;
                RaisePropertyChanged("Data");

                Messenger.Default.Send(new SoldierLoadedMessage(Common.StatusInformationPreparingStatistics, SupportedGame.Battlefield3));
            }
        }

        public ObservableCollection<KitServiceStar> FirstTwoKitProgressions
        {
            get
            {
                return new ObservableCollection<KitServiceStar>(
                    from kitProgression in Data.Overview.KitServiceStars
                    where kitProgression.Type == KitType.Assault || kitProgression.Type == KitType.Support
                    select kitProgression);
            }
        }

        public ObservableCollection<KitServiceStar> LastTwoKitProgressions
        {
            get
            {
                return new ObservableCollection<KitServiceStar>(
                    from kitProgression in Data.Overview.KitServiceStars 
                    where kitProgression.Type == KitType.Engineer || kitProgression.Type == KitType.Recon
                    select kitProgression);
            }
        }

        public ObservableCollection<KitServiceStar> FirstTwoKits
        {
            get
            {
                return new ObservableCollection<KitServiceStar>(
                    from kit in Data.Overview.KitServiceStars
                    where kit.Type == KitType.Assault || kit.Type == KitType.Support
                    select kit);
            }
        }

        public ObservableCollection<KitServiceStar> LastTwoKits
        {
            get
            {
                return new ObservableCollection<KitServiceStar>(
                    from kit in Data.Overview.KitServiceStars
                    where kit.Type == KitType.Engineer || kit.Type == KitType.Recon
                    select kit);
            }
        }

        public bool BackgroundEnabled
        {
            get { return _backgroundEnabled; }
            set 
            {
                if (_backgroundEnabled != value)
                    SettingsRepository.Save(new Settings { BackgroundEnabled = value } );
                _backgroundEnabled = value;
                RaisePropertyChanged("BackgroundEnabled"); }
        }

        private void LoadSettings()
        {
            var settings = SettingsRepository.Load();
            _backgroundEnabled = settings.BackgroundEnabled;
        }
    }
}