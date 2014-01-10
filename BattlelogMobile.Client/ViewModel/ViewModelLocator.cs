using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public static readonly string ApplicationName = "Battlelog Mobile";
        public static readonly Uri LogInPageUri = new Uri("/View/MainPage.xaml", UriKind.Relative);
        public static readonly Uri SoldierPageUri = new Uri("/View/SoldierPage.xaml", UriKind.Relative);

        public static readonly Uri WebRequestLogInUri = new Uri("https://battlelog.battlefield.com/bf3/gate/login/");
        public static readonly Uri WebRequestLogInResponseUri = new Uri("http://battlelog.battlefield.com/bf3/");
        public static CookieContainer CookieJar = new CookieContainer();

        public static readonly string ApplicationVersion = (new AssemblyName(Assembly.GetExecutingAssembly().FullName)).Version.ToString();

        public ViewModelLocator()
        {
            if (Main == null)
                Main = new MainViewModel();
            if (Soldier == null)
                Soldier = new SoldierViewModel();
        }

        public static void Cleanup()
        {
            Messenger.Default.Unregister(Main);
            Messenger.Default.Unregister(Soldier);
            Main = null;
            Soldier = null;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static MainViewModel Main { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static SoldierViewModel Soldier { get; private set; }
    }
}