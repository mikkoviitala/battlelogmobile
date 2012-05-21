using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class ScoreViewModel : BaseViewModel
    {
        private IScorePanorama _scorePanorama = new ScorePanorama() 
            { Score = new Score() { Kits = new Kits() } };

        public ScoreViewModel() : this(new BattlelogRepository())
        {}

        public ScoreViewModel(IBattlelogRepository battlelogRepository)
        {

            BattlelogRepository = battlelogRepository;
            //Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message =>
            //    ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
            //    {
            //        _scorePanorama = BattlelogRepository.LoadScore();
            //        RaisePropertyChanged("Kits");
            //        RaisePropertyChanged("Others");
            //        RaisePropertyChanged("TotalScore");
            //        RaisePropertyChanged("FirstTwoKits");
            //        RaisePropertyChanged("LastTwoKits");
            //    }));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public IKits Kits { get { return _scorePanorama.Score.Kits; } }
        public IOthers Others { get { return _scorePanorama.Score.Others; } }
        public int TotalScore { get { return _scorePanorama.Score.TotalScore; } }

        public ObservableCollection<IKit> FirstTwoKits
        {
            get
            {
                return new ObservableCollection<IKit>(
                    from kit in Kits
                    where kit.Type == KitType.Assault || kit.Type == KitType.Engineer
                    select kit);
            }
        }

        public ObservableCollection<IKit> LastTwoKits
        {
            get
            {
                return new ObservableCollection<IKit>(
                    from kit in Kits
                    where kit.Type == KitType.Support || kit.Type == KitType.Recon
                    select kit);
            }
        }
    }
}
