using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using BattlelogMobile.Core;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using System.Linq;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Shell;
using System;
using System.IO.IsolatedStorage;
using System.Windows;
using BattlelogMobile.Core.Message;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Tomers.Phone.Controls;
using BattlelogMobile.Client.ViewModel;

namespace BattlelogMobile.Client.ViewModel
{
    public class SoldierViewModel : BaseViewModel
    {
        private ISoldier _soldier;
        private bool _backgroundEnabled;

        public SoldierViewModel() 
            : this(new FileSettingsRepository(), new BattlelogRepository(new DownloadService(ViewModelLocator.CookieJar)))
        {}

        public SoldierViewModel(ISettingsRepository settingsRepository, IBattlelogRepository battlelogRepository)
        {
            SettingsRepository = settingsRepository;
            BattlelogRepository = battlelogRepository;

            LoadSettings();

            // Credentials are ok, download information
            Messenger.Default.Register<BattlelogCredentialsAcceptedMessage>(this, message => 
                {
                    BattlelogRepository.CurrentUser = message.CurrentUser;
                    BattlelogRepository.UpdateStorage(message.ForceUpdate);
                });

            // Download complete, parse data
            Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message => 
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>  
                { 
                    var soldier = BattlelogRepository.Load(); 
                    if (soldier != null) 
                        Soldier = soldier; 
                }));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public ISettingsRepository SettingsRepository { get; set; }

        public ISoldier Soldier
        {
            get { return _soldier; }
            set
            {
                if (value != null)
                {
                    // TODO: 
                    // Message was moved here from Register<BattlelogUpdateCompleteMessage> block
                    // but this makes no sense, and even less when we have new version of stats update...
                    Messenger.Default.Send(new SoldierLoadedMessage(Common.StatusInformationPreparingStatistics));
                    //Messenger.Default.Send(new SoldierLoadedMessage(string.Format("Updated {0}", value.UpdateTime.ToString(CultureInfo.InvariantCulture))));
                    _soldier = value;
                    RaisePropertyChanged("Soldier");
                }
            }
        }

        // Stooopid workaround for showing two listboxes side by side on UI.... and same below
        public ObservableCollection<IKitProgression> FirstTwoKitProgressions
        {
            get
            {
                return new ObservableCollection<IKitProgression>(
                    from kitProgression in Soldier.KitProgressions
                    where kitProgression.Type == KitType.Assault || kitProgression.Type == KitType.Engineer
                    select kitProgression);
            }
        }

        public ObservableCollection<IKitProgression> LastTwoKitProgressions
        {
            get
            {
                return new ObservableCollection<IKitProgression>(
                    from kitProgression in Soldier.KitProgressions
                    where kitProgression.Type == KitType.Support || kitProgression.Type == KitType.Recon
                    select kitProgression);
            }
        }

        public ObservableCollection<IKit> FirstTwoKits
        {
            get
            {
                return new ObservableCollection<IKit>(
                    from kit in Soldier.Score.Kits
                    where kit.Type == KitType.Assault || kit.Type == KitType.Engineer
                    select kit);
            }
        }

        public ObservableCollection<IKit> LastTwoKits
        {
            get
            {
                return new ObservableCollection<IKit>(
                    from kit in Soldier.Score.Kits
                    where kit.Type == KitType.Support || kit.Type == KitType.Recon
                    select kit);
            }
        }

        public bool BackgroundEnabled
        {
            get { return _backgroundEnabled; }
            set 
            {
                if (_backgroundEnabled != value)
                    SettingsRepository.Save(new Settings() { BackgroundEnabled = value } );
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