using System.Windows;
using BattlelogMobile.Core;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class Bf3SoldierViewModel : BaseViewModel
    {
        private Battlefield3Data _battlefield3Data;
        //private bool _backgroundEnabled;

        public Bf3SoldierViewModel()
            : this(new BattlelogRepository(new DownloadService(ViewModelLocator.CookieJar)))
        {}

        public Bf3SoldierViewModel(BattlelogRepository battlelogRepository)
        {
            //SettingsRepository = settingsRepository;
            BattlelogRepository = battlelogRepository;

            //LoadSettings();

            // Credentials are ok, download information
            Messenger.Default.Register<BattlelogCredentialsAcceptedMessage>(this, async message =>
                {
                    if (message.Game != SupportedGame.Battlefield3)
                        return;

                    await BattlelogRepository.UpdateStorage(message.ForceUpdate);
                });

            // Download complete, parse data
            Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, async message =>
                {
                    var battlefieldData = await BattlelogRepository.LoadBattlefield3Data();
                    if (battlefieldData == null)
                        return;
                    
                    ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() => Data = battlefieldData);
                });
        }

        public BattlelogRepository BattlelogRepository { get; set; }

        //public FileSettingsRepository SettingsRepository { get; set; }

        public Battlefield3Data Data
        {
            get { return _battlefield3Data; }
            set
            {
                _battlefield3Data = value;
                RaisePropertyChanged("Data");

                Messenger.Default.Send(new SoldierLoadedMessage(Common.StatusInformationPreparingStatistics, SupportedGame.Battlefield3));
            }
        }

        //public bool BackgroundEnabled
        //{
        //    get { return _backgroundEnabled; }
        //    set 
        //    {
        //        if (_backgroundEnabled != value)
        //            SettingsRepository.Save(new Settings { BackgroundEnabled = value } );
        //        _backgroundEnabled = value;
        //        RaisePropertyChanged("BackgroundEnabled"); }
        //}

        //private void LoadSettings()
        //{
        //    var settings = SettingsRepository.Load();
        //    _backgroundEnabled = settings.BackgroundEnabled;
        //}
    }
}