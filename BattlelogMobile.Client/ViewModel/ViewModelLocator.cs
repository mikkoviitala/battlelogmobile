using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;
using BattlelogMobile.Client.Service;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Model.Battlefield4;
using GalaSoft.MvvmLight.Messaging;
using StoreLauncher;

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
        public static readonly Uri AboutPageUri = new Uri("/YourLastAboutDialog;component/AboutPage.xaml", UriKind.Relative);

        public static readonly Uri Bf3LogInUri = new Uri("https://battlelog.battlefield.com/bf3/gate/login/");
        public static readonly Uri Bf3LogInResponseUri = new Uri("http://battlelog.battlefield.com/bf3/");

        public static readonly Uri Bf4LogInUri = new Uri("https://battlelog.battlefield.com:443/bf4/gate/login/");
        public static readonly Uri Bf4LogInResponseUri = new Uri("http://battlelog.battlefield.com/bf4/");

        public static CookieContainer CookieJar = new CookieContainer();

        //public static readonly string ApplicationVersion = (new AssemblyName(Assembly.GetExecutingAssembly().FullName)).Version.ToString();

        public static readonly string ApplicationVersion =
            Assembly.GetExecutingAssembly().GetCustomAttributes(false).OfType<AssemblyFileVersionAttribute>().First().Version;

        public ViewModelLocator()
        {
            if (Main == null)
                Main = new MainViewModel();
            if (Soldier == null)
                Soldier = new SoldierViewModel();
            if (Bf3UserControl == null)
                Bf3UserControl = new BfUserControlViewModel<Battlefield3Data>();
            if (Bf4UserControl == null)
                Bf4UserControl = new BfUserControlViewModel<Battlefield4Data>();
            if (Navigation == null)
                Navigation = new NavigationService();

            if (Environment.OSVersion.Version.Major >= 8)
                Store = StoreLauncher.StoreLauncher.GetStoreInterface("StoreWrapper.Store, StoreWrapper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        }

        public static void Cleanup()
        {
            Messenger.Default.Unregister(Main);
            Messenger.Default.Unregister(Soldier);
            Messenger.Default.Unregister(Bf3UserControl);
            Messenger.Default.Unregister(Bf4UserControl);
            Main = null;
            Soldier = null;
            Bf3UserControl = null;
            Bf4UserControl = null;
            Navigation = null;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static MainViewModel Main { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static SoldierViewModel Soldier { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static BfUserControlViewModel<Battlefield3Data> Bf3UserControl { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static BfUserControlViewModel<Battlefield4Data> Bf4UserControl { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static StoreBase Store { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static INavigationService Navigation { get; private set; }
    }
}