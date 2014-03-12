﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using BattlelogMobile.Client.Service;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using BattlelogMobile.Core;
using GalaSoft.MvvmLight.Threading;
using Credentials = BattlelogMobile.Core.Model.Credentials;
using Microsoft.Phone.Controls;

namespace BattlelogMobile.Client.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService = new NavigationService();
        private string _email;
        private string _password;
        private SupportedGame _game = SupportedGame.Battlefield3;
        private readonly ObservableCollection<SupportedGame> _games = new ObservableCollection<SupportedGame> { SupportedGame.Battlefield3, SupportedGame.Battlefield4 };
        private string _logInFailedReason = string.Empty;
        private string _serverMessage = string.Empty;
        private bool _userInterfaceEnabled = true;
        private bool _rememberMe;
        private bool _timedOut;

        public MainViewModel() : this(new FileCredentialsRepository())
        {}

        public MainViewModel(FileCredentialsRepository credentialsRepository)
        {
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<SoldierLoadedMessage>(this, SoldierLoadedMessageReceived);
            Messenger.Default.Register<SoldierVisibleMessage>(this, SoldierVisibleMessageReceived);
            Messenger.Default.Register<DialogMessage>(this, DialogMessageReceived);
            
            CredentialsRepository = credentialsRepository;
            LogInCommand = new RelayCommand(LogInCommandReceived, CanExecuteLogInCommand);
            LoadCredentials();

            Task.Factory.StartNew(() => (new DownloadService(ViewModelLocator.CookieJar)).RetrieveServerMessage(string.Format(Common.ServerMessageUrl, DateTime.Now.Ticks.ToString())));
        }

        public FileCredentialsRepository CredentialsRepository { get; set; }

        public RelayCommand LogInCommand { get; private set; }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value; 
                RaisePropertyChanged("Email");
                LogInCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                RaisePropertyChanged("Password");
                LogInCommand.RaiseCanExecuteChanged();
            }
        }

        public SupportedGame Game
        {
            get { return _game; }
            set
            {
                _game = value;
                RaisePropertyChanged("Game");
                LogInCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<SupportedGame> Games
        {
            get { return _games; }
        }

        public bool RememberMe
        {
            get { return _rememberMe; }
            set
            {
                _rememberMe = value;
                RaisePropertyChanged("RememberMe");
            }
        }

        public bool UserInterfaceEnabled
        {
            get { return _userInterfaceEnabled; }
            set
            {
                _userInterfaceEnabled = value;
                RaisePropertyChanged("UserInterfaceEnabled"); 
                LogInCommand.RaiseCanExecuteChanged();
                if (!_userInterfaceEnabled)
                    LogInFailedReason = string.Empty;
            }
        }

        public string StatusInformation
        {
            get { return GlobalLoading.Instance.Text; }
            set 
            { 
                GlobalLoading.Instance.Text = value; 
                if (string.IsNullOrEmpty(value) && GlobalLoading.Instance.IsLoading)
                    GlobalLoading.Instance.IsLoading = false;
                else if (!string.IsNullOrEmpty(value) &&  !GlobalLoading.Instance.IsLoading)
                    GlobalLoading.Instance.IsLoading = true;
            }
        }

        public string LogInFailedReason
        {
            get { return _logInFailedReason; }
            set
            {
                _logInFailedReason = value;
                RaisePropertyChanged("LogInFailedReason");
            }
        }

        public string ServerMessage
        {
            get { return _serverMessage; }
            set
            {
                _serverMessage = value;
                RaisePropertyChanged("ServerMessage");
            }
        }

        private void NotificationMessageReceived(NotificationMessage message)
        {
            string target = (string) message.Target;
            string notification = message.Notification;

            if (target == Common.ProggressIndicator)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => StatusInformation = notification);
            }
            else if (target == Common.DeveloperInformation)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => ServerMessage = notification);
            }
            else
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => StatusInformation = string.Empty);
                DispatcherHelper.CheckBeginInvokeOnUI(() => LogInFailedReason = notification);
                DispatcherHelper.CheckBeginInvokeOnUI(() => UserInterfaceEnabled = true);
            }
        }

        /// <summary>
        /// Soldier information is downloaded and parsed
        /// </summary>
        private void SoldierLoadedMessageReceived(SoldierLoadedMessage message)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => StatusInformation = message.Message);

            var currentPage = ((App)Application.Current).RootFrame.Content as PhoneApplicationPage;
            if (currentPage != null && currentPage.GetType() == typeof(View.MainPage))
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => _navigationService.NavigateTo(ViewModelLocator.SoldierPageUri));
            }
            else
            {
                ResetControls();
            }
        }

        private void DialogMessageReceived(DialogMessage message)
        {
            Task.Factory.StartNew(ResetControls);
            DispatcherHelper.CheckBeginInvokeOnUI(() => MessageBox.Show(message.Content, message.Caption, message.Button));
        }

        /// <summary>
        /// When soldier information is shown, reset login UI.
        /// This is in separate message since UI is slacking a little...
        /// </summary>
        private void SoldierVisibleMessageReceived(SoldierVisibleMessage message)
        {
            ResetControls();
        }

        private void ResetControls()
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => StatusInformation = string.Empty);
            DispatcherHelper.CheckBeginInvokeOnUI(() => UserInterfaceEnabled = true);
        }

        /// <summary>
        /// Connect to battlelog and verify user credentials
        /// </summary>
        private async void LogInCommandReceived()
        {
            //await PurchaseProduct();
            LogIn(Game);
        }

        private async void LogIn(SupportedGame game)
        {
            UserInterfaceEnabled = false;
            StatusInformation = Common.StatusInformationVerifyingCredential;
            SaveCredentials();

            Uri requestUri = game == SupportedGame.Battlefield3 ? ViewModelLocator.Bf3LogInUri : ViewModelLocator.Bf4LogInUri;
            Uri responseUri = game == SupportedGame.Battlefield3 ? ViewModelLocator.Bf3LogInResponseUri : ViewModelLocator.Bf4LogInResponseUri;

            var request = WebRequest.Create(requestUri) as HttpWebRequest;
            if (request == null)
                throw new ArgumentNullException();

            request.Credentials = new NetworkCredential(Email, Password);
            request.Method = Common.HttpPostMethod;
            request.Accept = Common.HttpAccept;
            request.UserAgent = Common.HttpUserAgent;
            request.ContentType = Common.HttpContentType;
            request.CookieContainer = ViewModelLocator.CookieJar;

            _timedOut = false;
            var dispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(Common.TimeOutInSeconds) };
            dispatchTimer.Tick += TimerTicked;
            dispatchTimer.Start();

            var streamTask = request.GetRequestStreamAsync();

            var requestStream = await streamTask.ConfigureAwait(false);
            using (var writer = new StreamWriter(requestStream))
            {
                await writer.WriteAsync(ConstructPostData(Email, Password, Game)).ConfigureAwait(false);
                writer.Close();
            }

            // Got response
            var responseTask = request.GetResponseAsync();

            if (_timedOut)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => UserInterfaceEnabled = true);
                DispatcherHelper.CheckBeginInvokeOnUI(() => StatusInformation = string.Empty);
                DispatcherHelper.CheckBeginInvokeOnUI(() => LogInFailedReason = Common.LogInFailedReasonTimedOut);
                return;
            }

            try
            {
                var response = await responseTask.ConfigureAwait(false);
                if (response.ResponseUri.Equals(responseUri))
                {
                    ViewModelLocator.Soldier.Game = Game;
                    ViewModelLocator.Soldier.Update();
                }
                else
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(() => UserInterfaceEnabled = true);
                    DispatcherHelper.CheckBeginInvokeOnUI(() => StatusInformation = string.Empty);
                    DispatcherHelper.CheckBeginInvokeOnUI(() => LogInFailedReason = Common.LogInFailedReasonInvalidCredentials);
                }
            }
            catch (WebException we)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => StatusInformation = string.Empty);
                DispatcherHelper.CheckBeginInvokeOnUI(() => LogInFailedReason = we.Message);
                DispatcherHelper.CheckBeginInvokeOnUI(() => UserInterfaceEnabled = true);
            }
        }

        private async Task PurchaseProduct()
        {
            try
            {
                var license = ViewModelLocator.Store.LicenseInformation.ProductLicenses["bf4"];

                if (!license.IsActive)
                    ViewModelLocator.Store.RequestProductPurchaseAsync(license.ProductId, false);

                //if (license.IsActive)
                //    ViewModelLocator.Store.ReportProductFulfillment(license.ProductId);
            }
            catch (Exception ex)
            {
                // When the user does not complete the purchase (e.g. cancels or navigates back from the Purchase Page), an exception with an HRESULT of E_FAIL is expected.
            }
        }

        private bool CanExecuteLogInCommand()
        {
            if (!UserInterfaceEnabled || (Email == null || Password == null))
                return false;

            return Email.Length > 0 && Password.Length > 0;
        }

        /// <summary>
        /// Create and encode login POST data
        /// </summary>
        private static string ConstructPostData(string email, string password, SupportedGame game)
        {
            string postData = null;
            Dictionary<string, string> postParams;

            if (game == SupportedGame.Battlefield3)
            {
                postParams = new Dictionary<string, string>
                    {
                        {"redirect", "|bf3|"},
                        {"email", email},
                        {"password", password},
                        {"remember", "0"},
                        {"submit", "Sign in"}
                    };
            }
            else
            {
                postParams = new Dictionary<string, string>
                    {
                        {"redirect", "|bf4|"},
                        {"email", email},
                        {"password", password},
                        {"remember", "0"},
                        {"submit", "Log in"}
                    };
            }
            foreach (var param in postParams)
            {
                if (postData != null)
                    postData += "&";
                postData += HttpUtility.UrlEncode(param.Key) + "=" + HttpUtility.UrlEncode(param.Value);
            }

            return postData;
        }

        /// <summary>
        /// Cancel login if it's taking too long
        /// </summary>
        private void TimerTicked(object sender, EventArgs e)
        {
            _timedOut = true;

            var dispatcherTimer = sender as DispatcherTimer;
            if (dispatcherTimer != null) 
                dispatcherTimer.Stop();
        }

        /// <summary>
        /// Load stored credentials from phone
        /// </summary>
        private void LoadCredentials()
        {
            Credentials credentials = CredentialsRepository.Load();
            if (credentials.RememberMe)
            {
                Email = credentials.Email;
                Password = credentials.Password;
                Game = credentials.Game;
                RememberMe = credentials.RememberMe;
            }
        }

        /// <summary>
        /// Save credentials to phone
        /// </summary>
        private void SaveCredentials()
        {
            Credentials credentials = new Credentials();
            if (RememberMe)
            {
                credentials.Email = Email;
                credentials.Password = Password;
                credentials.Game = Game;
                credentials.RememberMe = RememberMe;
            }
            CredentialsRepository.Save(credentials);
        }
    }
}