using System.Collections.ObjectModel;
using System.Linq;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight;

namespace BattlelogMobile.Client.ViewModel
{
    public class Bf4SoldierViewModel : ViewModelBase
    {
        private Battlefield3Data _battlefield3Data;
        private bool _backgroundEnabled;

        //public Bf4SoldierViewModel()
        //    : this(new FileSettingsRepository(), new BattlelogRepository(new DownloadService(ViewModelLocator.CookieJar)))
        //{}

        public Bf4SoldierViewModel()
            : this(null, null)
        { }

        public Bf4SoldierViewModel(FileSettingsRepository settingsRepository, BattlelogRepository battlelogRepository)
        {
 
        }

        public BattlelogRepository BattlelogRepository { get; set; }

        public FileSettingsRepository SettingsRepository { get; set; }

        public Battlefield3Data Data
        {
            get { return _battlefield3Data; }
            set
            {
                _battlefield3Data = value;
                RaisePropertyChanged("Data");

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
