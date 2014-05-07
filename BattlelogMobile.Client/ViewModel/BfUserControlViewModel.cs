using System;
using System.Windows.Threading;
using BattlelogMobile.Core.Model;

namespace BattlelogMobile.Client.ViewModel
{
    public class BfUserControlViewModel<T> : BaseViewModel where T : IUpdateInfo
    {
        private static DispatcherTimer _dispatchTimer;
        private T _data;
        private TimeSpan _updated;

        public BfUserControlViewModel()
        {
            if (_dispatchTimer != null)
                return;

            _dispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1d) };
            _dispatchTimer.Tick += (sender, args) =>
                {
                    try
                    {
                        if (Data == null)
                            return;

                        Updated = DateTime.Now - Data.Updated;
                    }
                    catch
                    {}
                };
            _dispatchTimer.Start();
        }
        
        public TimeSpan Updated
        {
            get { return _updated; }
            set
            {
                _updated = value;
                RaisePropertyChanged("Updated");
            }
        }

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