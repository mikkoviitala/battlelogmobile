using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection;
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
        public static readonly Uri Bf3SoldierPageUri = new Uri("/View/Bf3SoldierPage.xaml", UriKind.Relative);
        public static readonly Uri Bf4SoldierPageUri = new Uri("/View/Bf4SoldierPage.xaml", UriKind.Relative);

        public static readonly Uri Bf3LogInUri = new Uri("https://battlelog.battlefield.com/bf3/gate/login/");
        public static readonly Uri Bf3LogInResponseUri = new Uri("http://battlelog.battlefield.com/bf3/");

        public static readonly Uri Bf4LogInUri = new Uri("http://www.google.com");
        public static readonly Uri Bf4LogInResponseUri = new Uri("http://www.google.com");

        public static CookieContainer CookieJar = new CookieContainer();

        public static readonly string ApplicationVersion = (new AssemblyName(Assembly.GetExecutingAssembly().FullName)).Version.ToString();

        public ViewModelLocator()
        {
            if (Main == null)
                Main = new MainViewModel();
            if (Bf3Soldier == null)
                Bf3Soldier = new Bf3SoldierViewModel();
            if (Bf4Soldier == null)
                Bf4Soldier = new Bf4SoldierViewModel();

            if (Environment.OSVersion.Version.Major >= 8)
                Store = StoreLauncher.StoreLauncher.GetStoreInterface("StoreWrapper.Store, StoreWrapper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        }

        public static void Cleanup()
        {
            Messenger.Default.Unregister(Main);
            Messenger.Default.Unregister(Bf3Soldier);
            Messenger.Default.Unregister(Bf4Soldier);
            Main = null;
            Bf3Soldier = null;
            Bf4Soldier = null;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static MainViewModel Main { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static Bf3SoldierViewModel Bf3Soldier { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public static Bf4SoldierViewModel Bf4Soldier { get; private set; }

        public static StoreBase Store { get; private set; }
    }
}