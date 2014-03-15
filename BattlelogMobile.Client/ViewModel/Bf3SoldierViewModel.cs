using System;
using System.Windows.Threading;
using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Client.ViewModel
{
    public class Bf3SoldierViewModel : BaseViewModel
    {
        private Battlefield3Data _battlefield3Data;
        private readonly DispatcherTimer _dispatchTimer;

        public Bf3SoldierViewModel()
        {
            _dispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1d) };
            _dispatchTimer.Tick += (sender, args) =>
                {
                    if (Data == null)
                        return;

                    Updated = DateTime.Now - Data.Updated;
                    RaisePropertyChanged("Updated");
                };
            _dispatchTimer.Start();
        }

        public TimeSpan Updated { get; private set; }

        public Battlefield3Data Data
        {
            get { return _battlefield3Data; }
            set
            {
                _battlefield3Data = value;
                RaisePropertyChanged("Data");
            }
        }
    }
}