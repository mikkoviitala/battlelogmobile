using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Threading;
using BattlelogMobile.Client.Service;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ICredentials = BattlelogMobile.Core.Model.ICredentials;

namespace BattlelogMobile.Client.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private const int TimeOutInSeconds = 90;
        private const string LogInFailedReasonTimedOut = "Login request timed out!";
        private const string LogInFailedReasonInvalidCredentials = "User credentials not accepted!";
        private const string StatusInformationVerifyingCredential = "Verifying credentials";

        private readonly INavigationService _navigationService = new NavigationService();
        private string _email;
        private string _password;
        private bool _rememberMe;
        private string _logInFailedReason = string.Empty;
        private bool _userInterfaceEnabled = true;
        private bool _timedOut = false;

        public MainViewModel() : this(new FileCredentialsRepository())
        {}

        public MainViewModel(ICredentialsRepository credentialsRepository)
        {
            //Messenger.Default.Register<PageOrientationChangedMessage>(this, message =>
            //    {
            //        if (!message.IsPortrait)
            //            _navigationService.NavigateTo(ViewModelLocator.CopyrightPageUri);
            //    });
            Messenger.Default.Register<BattlelogResponseMessage>(this, BattlelogResponseMessageReceived);
            Messenger.Default.Register<SoldierLoadedMessage>(this, SoldierLoadedMessageReceived);
            Messenger.Default.Register<SoldierVisibleMessage>(this, SoldierVisibleMessageReceived);

            LogInCommand = new RelayCommand(LogInCommandReceived, CanExecuteLogInCommand);
            CredentialsRepository = credentialsRepository;
            LoadCredentials();

            Email = "nakquada@hotmail.com";
            Password = "acceptpw2";
        }

        public ICredentialsRepository CredentialsRepository { get; private set; }
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
                if (_userInterfaceEnabled != value)
                    GlobalLoading.Instance.IsLoading = !value;

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
            set { GlobalLoading.Instance.Text = value; }
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
            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                _navigationService.NavigateTo(ViewModelLocator.SoldierPageUri));
        }

        /// <summary>
        /// When soldier information is shown, reset login UI.
        /// This is in separate message since UI is slacking a little...
        /// </summary>
        private void SoldierVisibleMessageReceived(SoldierVisibleMessage message)
        {
            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                StatusInformation = string.Empty);
            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                UserInterfaceEnabled = true);
        }

        /// <summary>
        /// Connect to battlelog and verify user credentials
        /// </summary>
        private void LogInCommandReceived()
        {
            UserInterfaceEnabled = false;
            StatusInformation = StatusInformationVerifyingCredential;
            SaveCredentials();

            var request = WebRequest.Create(ViewModelLocator.WebRequestLogInUri) as HttpWebRequest;
            if (request == null)
                throw new ArgumentNullException();

            request.Credentials = new NetworkCredential(Email, Password);
            request.Method = "POST";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:6.0.2) Gecko/20100101 Firefox/6.0.2";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = ViewModelLocator.CookieJar;

            _timedOut = false;
            var dispatchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(TimeOutInSeconds) };
            dispatchTimer.Tick += TimerTicked;
            dispatchTimer.Start();

            request.BeginGetRequestStream(requestAsyncResult =>
            {
                var requestStream = request.EndGetRequestStream(requestAsyncResult);
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(ConstructPostData(Email, Password));
                    writer.Close();
                }

                // Got response
                request.BeginGetResponse(responseAsyncResult =>
                {
                    if (_timedOut)
                    {
                        ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                            UserInterfaceEnabled = true);
                        ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                            StatusInformation = string.Empty);
                        ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                            LogInFailedReason = LogInFailedReasonTimedOut);
                        return;
                    }
                    
                    try
                    {
                        var response = request.EndGetResponse(responseAsyncResult);
                        if (response.ResponseUri.Equals(ViewModelLocator.WebRequestLogInResponseUri))
                        {
                            // Send message signaling that JSON download can begin
                            Messenger.Default.Send(new BattlelogCredentialsAcceptedMessage());
                        }
                        else
                        {
                            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                                UserInterfaceEnabled = true);
                            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                                StatusInformation = string.Empty);
                            ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                                LogInFailedReason = LogInFailedReasonInvalidCredentials);
                        }
                    }
                    catch (WebException we)
                    {
                        ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                                StatusInformation = string.Empty);
                        ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                            LogInFailedReason = we.Message);
                        ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
                            UserInterfaceEnabled = true);
                    }
                }, null);
            }, null);
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
            const string postDataRedirect = "|bf3|";
            const string postDataRemember = "0";
            const string postDataSubmit = "Sign in";
            
            var postParams = new Dictionary<string, string>
            {
                {"redirect", postDataRedirect },
                {"email", email },
                {"password", password },
                {"remember", postDataRemember },
                {"submit", postDataSubmit }
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
            (sender as DispatcherTimer).Stop();
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