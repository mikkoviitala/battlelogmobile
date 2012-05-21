using System;
using System.Windows.Navigation;

namespace BattlelogMobile.Client.Service
{
    public interface INavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Uri pageUri);
        void GoBack();
    }
}
