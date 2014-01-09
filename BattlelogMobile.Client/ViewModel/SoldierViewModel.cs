﻿using System.Collections.ObjectModel;
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
    public class SoldierViewModel : BaseViewModel
    {
        private BattlefieldData _battlefieldData;
        private bool _backgroundEnabled;

        public SoldierViewModel()
            : this(new FileSettingsRepository(), new BattlelogRepository(new DownloadService(ViewModelLocator.CookieJar)))
        {}

        public SoldierViewModel(FileSettingsRepository settingsRepository, BattlelogRepository battlelogRepository)
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
                        var battlefieldData = BattlelogRepository.LoadBattlefieldData();
                        if (battlefieldData != null)
                            Data = battlefieldData;
                    }));
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

                Messenger.Default.Send(new SoldierLoadedMessage(Common.StatusInformationPreparingStatistics));
                //Soldier = new Soldier();
            }
        }

        //public ISoldier Soldier
        //{
        //    get { return null; }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            // TODO: 
        //            // Message was moved here from Register<BattlelogUpdateCompleteMessage> block
        //            // but this makes no sense, and even less when we have new version of stats update...
        //            Messenger.Default.Send(new SoldierLoadedMessage(Common.StatusInformationPreparingStatistics));
        //            //Messenger.Default.Send(new SoldierLoadedMessage(string.Format("Updated {0}", value.UpdateTime.ToString(CultureInfo.InvariantCulture))));
                    
        //            RaisePropertyChanged("Soldier");
        //            RaisePropertyChanged("FirstTwoKitProgressions");
        //            RaisePropertyChanged("LastTwoKitProgressions");
        //            RaisePropertyChanged("FirstTwoKits");
        //            RaisePropertyChanged("LastTwoKits");
        //        }
        //    }
        //}

        // Stooopid workaround for showing two listboxes side by side on UI.... and same below
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