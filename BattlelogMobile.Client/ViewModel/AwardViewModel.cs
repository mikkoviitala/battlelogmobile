using System.Windows;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class AwardViewModel : BaseViewModel
    {
        private IAwardPanorama _awardPanorama = new AwardPanorama();

        public AwardViewModel() : this(new BattlelogRepository())
        {}

        public AwardViewModel(IBattlelogRepository battlelogRepository)
        {

            BattlelogRepository = battlelogRepository;
            Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message =>
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                {
                    _awardPanorama = BattlelogRepository.LoadAward();
                    RaisePropertyChanged("Awards");
                }));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public IAwards Awards { get { return _awardPanorama.Awards; } }
    }
}
