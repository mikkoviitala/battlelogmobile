using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BattlelogMobile.Client
{
    public class GlobalLoading //: INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        private ProgressIndicator _progressIndicator;
        private static GlobalLoading _instance;
        private int _loadingCount;

        private GlobalLoading() { }

        public void Initialize(PhoneApplicationFrame frame)
        {
            _progressIndicator = new ProgressIndicator();
            frame.Navigated += OnRootFrameNavigated;
        }

        private void OnRootFrameNavigated(object sender, NavigationEventArgs e)
        {
            var ee = e.Content;
            var pp = ee as PhoneApplicationPage;
            if (pp != null)
                pp.SetValue(SystemTray.ProgressIndicatorProperty, _progressIndicator);
        }

        public static GlobalLoading Instance
        {
            get { return _instance ?? (_instance = new GlobalLoading()); }
        }

        public bool ActualIsLoading
        {
            get { return IsLoading; }
        }

        public bool IsLoading
        {
            get { return _loadingCount > 0; }
            set 
            {
                if (value)
                    ++_loadingCount;
                else
                    --_loadingCount;

                NotifyValueChanged();
            }
        }

        public string Text
        {
            get { return _progressIndicator.Text; }
            set { _progressIndicator.Text = value; }
        }

        public void Force(bool f)
        {
            _loadingCount = 0;
            if (f)
                _loadingCount = 1;
            NotifyValueChanged();
        }

        private void NotifyValueChanged()
        {
            if (_progressIndicator != null)
            {
                _progressIndicator.IsIndeterminate = _loadingCount > 0;

                if (_progressIndicator.IsVisible == false)
                    _progressIndicator.IsVisible = true;
                else
                    _progressIndicator.IsVisible = false;
            }
        }
    }
}