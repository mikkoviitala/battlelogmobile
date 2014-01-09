using GalaSoft.MvvmLight;

namespace BattlelogMobile.Client.ViewModel
{
    public abstract class BaseViewModel : ViewModelBase
    {
        public virtual string ApplicationName { get { return ViewModelLocator.ApplicationName; } }
        public virtual string ApplicationNameAndVersion { get { return ViewModelLocator.ApplicationName + " v" + ViewModelLocator.ApplicationVersion; } }
        public virtual string ApplicationVersion { get { return "v" + ViewModelLocator.ApplicationVersion; } }
    }
}
