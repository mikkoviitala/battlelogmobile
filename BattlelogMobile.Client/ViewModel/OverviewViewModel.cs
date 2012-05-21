using System;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class OverviewViewModel : BaseViewModel
    {
        private IOverviewPanorama _overviewPanorama;

        public OverviewViewModel() : this(new BattlelogRepository()) 
        {}
        
        public OverviewViewModel(IBattlelogRepository battlelogRepository)
        {
            BattlelogRepository = battlelogRepository;
            OverviewPanorama = BattlelogRepository.RestoreOverview();
            RaiseProperties();

            Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message => 
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                    {
                        OverviewPanorama = BattlelogRepository.UpdateOverview();
                        RaiseProperties();
                    }));
        }

        private void RaiseProperties()
        {
            RaisePropertyChanged("User");
            RaisePropertyChanged("Image");
            RaisePropertyChanged("Rank");
            RaisePropertyChanged("RankImage");
            RaisePropertyChanged("TimePlayed");
            RaisePropertyChanged("Skill");
            RaisePropertyChanged("KillDeathRatio");
            RaisePropertyChanged("WinLoseRatio");
            RaisePropertyChanged("ScorePerMinute");
        }

        private IOverviewPanorama OverviewPanorama
        {
            get { return _overviewPanorama; }
            set { _overviewPanorama = value; RaisePropertyChanged("OverviewViewModel");  RaisePropertyChanged("OverviewPanorama"); RaiseProperties(); }
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public IUser User { get { return OverviewPanorama.User; } }
        public int Rank { get { return _overviewPanorama.Rank; } }
        public BitmapImage RankImage { get { return OverviewPanorama.RankImage; } }
        public TimeSpan TimePlayed { get { return _overviewPanorama.TimePlayed; } }
        public double Skill { get { return _overviewPanorama.Skill; } }
        public double KillDeathRatio { get { return _overviewPanorama.KillDeathRatio; } }
        public double WinLoseRatio { get { return _overviewPanorama.WinLoseRatio; } }
        public int ScorePerMinute { get { return _overviewPanorama.ScorePerMinute; } }
    }
}
