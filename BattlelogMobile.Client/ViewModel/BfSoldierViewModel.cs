using System;
using System.Windows.Threading;
using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Client.ViewModel
{
    public class BfUserControlViewModel<T> : BaseViewModel where T : IUpdateInfo
    {
        private static DispatcherTimer DispatchTimer = null;
        private T _data;

        public BfUserControlViewModel()
        {
            if (DispatchTimer != null)
                return;

            DispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1d) };
            DispatchTimer.Tick += (sender, args) =>
                {
                    if (Data == null)
                        return;

                    Updated = DateTime.Now  - Data.Updated;
                    RaisePropertyChanged("Updated");
                };
            DispatchTimer.Start();
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