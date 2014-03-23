using System;
using System.Windows.Threading;
using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Client.ViewModel
{
    public class BfUserControlViewModel<T> : BaseViewModel where T : IUpdateInfo
    {
        private static DispatcherTimer _dispatchTimer;
        private T _data;

        public BfUserControlViewModel()
        {
            if (_dispatchTimer != null)
                return;

            _dispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1d) };
            _dispatchTimer.Tick += (sender, args) =>
                {
                    if (Data == null)
                        return;

                    Updated = DateTime.Now  - Data.Updated;
                    RaisePropertyChanged("Updated");
                };
            _dispatchTimer.Start();
        }
        
        public TimeSpan Updated { get; private set; }

        public T Data 
        {
            get { return _data; }
            set
            {
                _data = value;
                RaisePropertyChanged("Data");
            }
        }
    }
}