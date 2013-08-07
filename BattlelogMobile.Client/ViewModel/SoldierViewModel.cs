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
    public class SoldierViewModel : BaseViewModel
    {
        private ISoldier _soldier;

        public SoldierViewModel() : this(new BattlelogRepository(new DownloadService(ViewModelLocator.CookieJar)))
        {}

        public SoldierViewModel(IBattlelogRepository battlelogRepository)
        {
            BattlelogRepository = battlelogRepository;

            // Credentials are ok, download information
            Messenger.Default.Register<BattlelogCredentialsAcceptedMessage>(this, message => 
                BattlelogRepository.UpdateStorage());

            // Download complete, parse data
            Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message => 
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() => 
                    Soldier = BattlelogRepository.Load()));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

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
                    if (_soldier == null || _soldier.UpdateTime < value.UpdateTime)
                        Messenger.Default.Send(new SoldierLoadedMessage(Common.StatusInformationPreparingStatistics));
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
    }
}