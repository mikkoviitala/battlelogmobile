using System;
using System.Collections.Generic;
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
using ICredentials = BattlelogMobile.Core.Model.ICredentials;
using Microsoft.Phone.Controls;

namespace BattlelogMobile.Client.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService = new NavigationService();
        private string _email;
        private string _password;
        private string _logInFailedReason = string.Empty;
        private string _serverMessage = string.Empty;
        private bool _userInterfaceEnabled = true;
        private bool _rememberMe;
        private bool _timedOut;

        public MainViewModel() : this(new FileCredentialsRepository())
        {}

        public MainViewModel(ICredentialsRepository credentialsRepository)
        {
            Messenger.Default.Register<BattlelogResponseMessage>(this, BattlelogResponseMessageReceived);
            Messenger.Default.Register<SoldierLoadedMessage>(this, SoldierLoadedMessageReceived);
            Messenger.Default.Register<SoldierVisibleMessage>(this, SoldierVisibleMessageReceived);
            Messenger.Default.Register<DialogMessage>(this, message => ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() => ServerMessage = message.Content));
            Messenger.Default.Register<SerializationFailedMessage>(this, SerializationFailedMessageReceived);

            LogInCommand = new RelayCommand(() => LogInCommandReceived(), CanExecuteLogInCommand);
            CredentialsRepository = credentialsRepository;
            LoadCredentials();

            var task = new Task(() => 
                (new DownloadService(ViewModelLocator.CookieJar)).RetrieveServerMessage(string.Format(Common.ServerMessageUrl, DateTime.Now.Ticks.ToString())));
            task.Start();

            //(new DownloadService(ViewModelLocator.CookieJar)).RetrieveServerMessage(Common.ServerMessageUrl);
        }

        public ICredentialsRepository CredentialsRepository { get; set; }

        public RelayCommand LogInCommand { get; private set; }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value; 
                LogInCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                LogInCommand.RaiseCanExecuteChanged();
            }
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
                //if (_userInterfaceEnabled != value)
                //    GlobalLoading.Instance.IsLoading = !value;

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

        /// <summary>
        /// Update UI when web requests complete
        /// </summary>
        /// <param name="message"></param>
        private void BattlelogResponseMessageReceived(BattlelogResponseMessage message)
        {
            if (message.IsOk)
            {
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                    StatusInformation = message.Message);
            }
            else
            {
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                    StatusInformation = string.Empty);
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                    LogInFailedReason = message.Message);
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                    UserInterfaceEnabled = true);
            }
        }

        /// <summary>
        /// Soldier information is downloaded and parsed
        /// </summary>
        private void SoldierLoadedMessageReceived(SoldierLoadedMessage message)
        {
            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                StatusInformation = message.Message);

            var currentPage = ((App)Application.Current).RootFrame.Content as PhoneApplicationPage;
            if (currentPage.GetType() == typeof(BattlelogMobile.Client.View.MainPage))
            {
                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                    _navigationService.NavigateTo(ViewModelLocator.SoldierPageUri));
            }
            else
            {
                ResetControls();
            }
        }

        private void SerializationFailedMessageReceived(SerializationFailedMessage message)
        {
            Task.Factory.StartNew(() => ResetControls());
            MessageBox.Show(message.Message, "Oh noes!", MessageBoxButton.OK);
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
            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                StatusInformation = string.Empty);
            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                UserInterfaceEnabled = true);
        }

        /// <summary>
        /// Connect to battlelog and verify user credentials
        /// </summary>
        private async Task LogInCommandReceived()
        {
            UserInterfaceEnabled = false;
            StatusInformation = Common.StatusInformationVerifyingCredential;
            SaveCredentials();

            var request = WebRequest.Create(ViewModelLocator.WebRequestLogInUri) as HttpWebRequest;
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
            {
                var requestStream = await streamTask.ConfigureAwait(false);
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(ConstructPostData(Email, Password));
                    writer.Close();
                }

                // Got response
                var responseTask = request.GetResponseAsync();

                if (_timedOut)
                {
                    ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                        UserInterfaceEnabled = true);
                    ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                        StatusInformation = string.Empty);
                    ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                        LogInFailedReason = Common.LogInFailedReasonTimedOut);
                    return;
                }

                try
                {
                    var response = await responseTask.ConfigureAwait(false);
                    if (response.ResponseUri.Equals(ViewModelLocator.WebRequestLogInResponseUri))
                    {
                        Messenger.Default.Send(new BattlelogCredentialsAcceptedMessage(Email));
                    }
                    else
                    {
                        ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                            UserInterfaceEnabled = true);
                        ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                            StatusInformation = string.Empty);
                        ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                            LogInFailedReason = Common.LogInFailedReasonInvalidCredentials);
                    }
                }
                catch (WebException we)
                {
                    ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                        StatusInformation = string.Empty);
                    ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                        LogInFailedReason = we.Message);
                    ((App) Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                        UserInterfaceEnabled = true);
                }
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
        private static string ConstructPostData(string email, string password)
        {
            var postParams = new Dictionary<string, string>
            {
                { "redirect", "|bf3|" },
                { "email", email },
                { "password", password },
                { "remember", "0" },
                { "submit", "Sign in" }
            };

            string postData = null;
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
            ICredentials credentials = CredentialsRepository.Load();
            if (credentials.RememberMe)
            {
                Email = credentials.Email;
                Password = credentials.Password;
                RememberMe = credentials.RememberMe;
            }
        }

        /// <summary>
        /// Save credentials to phone
        /// </summary>
        private void SaveCredentials()
        {
            ICredentials credentials = new Credentials();
            if (RememberMe)
            {
                credentials.Email = Email;
                credentials.Password = Password;
                credentials.RememberMe = RememberMe;
            }
            CredentialsRepository.Save(credentials);
        }
    }
}