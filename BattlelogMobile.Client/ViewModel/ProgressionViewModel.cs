using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class ProgressionViewModel : BaseViewModel
    {
        private IProgressionPanorama _progressionPanorama = new ProgressionPanorama() {KitProgressions = new KitProgressions()};

        public ProgressionViewModel() : this(new BattlelogRepository())
        {}

        public ProgressionViewModel(IBattlelogRepository battlelogRepository)
        {

            BattlelogRepository = battlelogRepository;
            //Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message =>
            //    ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
            //    {
            //        _progressionPanorama = BattlelogRepository.LoadProgression();
            //        RaisePropertyChanged("KitProgressions");
            //        RaisePropertyChanged("FirstTwoKitProgressions");
            //        RaisePropertyChanged("LastTwoKitProgressions");
            //    }));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public IKitProgressions KitProgressions { get { return _progressionPanorama.KitProgressions; } }
        public ObservableCollection<IKitProgression> FirstTwoKitProgressions
        {
            get
            {
                return new ObservableCollection<IKitProgression>(
                    from kitProgression in KitProgressions
                    where kitProgression.Type == KitType.Assault || kitProgression.Type == KitType.Engineer
                    select kitProgression);
            }
        }

        public ObservableCollection<IKitProgression> LastTwoKitProgressions
        {
            get
            {
                return new ObservableCollection<IKitProgression>(
                    from kitProgression in KitProgressions
                    where kitProgression.Type == KitType.Support || kitProgression.Type == KitType.Recon
                    select kitProgression);
            }
        }
    }
}
