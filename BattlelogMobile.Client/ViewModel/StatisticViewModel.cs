using System.Windows;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class StatisticViewModel : BaseViewModel
    {
        private IStatisticPanorama _statisticPanorama = new StatisticPanorama();

        public StatisticViewModel() : this(new BattlelogRepository())
        {}

        public StatisticViewModel(IBattlelogRepository battlelogRepository)
        {

            BattlelogRepository = battlelogRepository;
            //Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message =>
            //    ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
            //    {
            //        _statisticPanorama = BattlelogRepository.LoadStatistic();
            //        RaisePropertyChanged("Statistics");
            //    }));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public IStatistics Statistics { get { return _statisticPanorama.Statistics; } }
    }
}
