using System.Net;
using System.Threading.Tasks;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;
using System.IO.IsolatedStorage;
using Polenter.Serialization;
using System.IO;
using System;

namespace BattlelogMobile.Core.Repository
{
    /// <summary>
    /// Battlelog repository
    /// </summary>
    public class BattlelogRepository
    {
        private const int ExpectedResponseMessages = 3;
        private readonly IsolatedStorageFile _storage = IsolatedStorageFile.GetUserStoreForApplication();
        private int _responseMessages = 0;
        private long? _userId;
        private Platform? _platform;

        public BattlelogRepository() 
            : this(new DownloadService(new CookieContainer()))
        {}

        public BattlelogRepository(DownloadService downloadService)
        {
            Messenger.Default.Register<UserIdAndPlatformResolvedMessage>(this, UserIdAndPlatformResolvedMessageReceived);
            Messenger.Default.Register<BattlelogResponseMessage>(this, BattlelogResponseMessageReceived);
            DownloadService = downloadService;
        }

        public DownloadService DownloadService { get; set; }

        public string CurrentUser { get; set; }

        public bool IsSerialized
        {
            get
            {
                return CurrentUser != null && _storage.FileExists(CurrentUser);
            }
        }

        /// <summary>
        /// Update local storage
        /// </summary>
        public async Task UpdateStorage(bool forceUpdate = false)
        {
            //forceUpdate = true;
            if (forceUpdate)
                ClearCache();

            if (IsSerialized)
            {
                Messenger.Default.Send(new BattlelogUpdateCompleteMessage());
            }
            else
            {
                Reset();
                await DownloadService.ResolveUserIdAndPlatform(Common.EntryPageUrl, new UserIdAndPlatformResolver());
            }
        }

        private void ClearCache()
        {
            if (CurrentUser != null)
                if (_storage.FileExists(CurrentUser))
                    _storage.DeleteFile(CurrentUser);
        }

        private void Reset()
        {
            _responseMessages = 0;
            _userId = null;
            _platform = null;
        }

        public Task<BattlefieldData> LoadBattlefieldData()
        {
            if (!IsSerialized)
            {
                return Task.Factory.StartNew(() =>
                    {
                        var parser = new JSONParser();
                        var data = parser.Parse();
                        Serialize(data);
                        return data;
                    });
            }

            return Task.Factory.StartNew(() =>  Deserialize());
        }

        /// <summary>
        ///  When user id and platform are resolved, tell download service to get JSON streams 
        /// </summary>
        private async Task GetFilesFromServer()
        {
            if (_userId == null || _platform == null)
                return;

            await DownloadService.GetFile(string.Format(Common.OverviewPageUrl, _userId, (int)_platform), Common.OverviewFile);
            await DownloadService.GetFile(string.Format(Common.VehiclesPageUrl, _userId, (int)_platform), Common.VehiclesFile);
            await DownloadService.GetFile(string.Format(Common.GadgetsPageUrl, _userId, (int)_platform), Common.WeaponsAndGadgetsFile);
        }

        private async void UserIdAndPlatformResolvedMessageReceived(UserIdAndPlatformResolvedMessage message)
        {
            _userId = message.UserId;
            _platform = message.Platform;
            Messenger.Default.Send(new BattlelogResponseMessage(Common.StatusInformationSeekingContent, true));
            await GetFilesFromServer();
        }

        // Listen for download completions, send message to UI when all done
        private void BattlelogResponseMessageReceived(BattlelogResponseMessage message)
        {
            if (message.Sender == null || (message.Sender.GetType() != (typeof(DownloadService))))
                return;

            _responseMessages++;
            if (_responseMessages == ExpectedResponseMessages)
            {
                _responseMessages = 0;
                Messenger.Default.Send(new BattlelogUpdateCompleteMessage());
            }
        }

        private void Serialize(BattlefieldData data)
        {
            bool errorOccured = false;

            using (var file = _storage.OpenFile(CurrentUser, FileMode.Create))
            {
                try
                {
                    var serializer = new SharpSerializer(true);
                    serializer.Serialize(data, file);
                }
                catch (Exception)
                {
                    errorOccured = true;
                }
            }

            if (errorOccured)
            {
                ClearCache();
                Messenger.Default.Send(new SerializationFailedMessage(Common.SerializationFailed));
            }
        }

        private BattlefieldData Deserialize()
        {
            BattlefieldData data = null;
            bool errorOccured = false;

            using (var file = _storage.OpenFile(CurrentUser, FileMode.Open))
            {
                var serializer = new SharpSerializer(true);
                try
                {
                    data = serializer.Deserialize(file) as BattlefieldData;
                }
                catch (Exception)
                {
                    errorOccured = true;
                }
            }

            if (errorOccured)
            {
                ClearCache();
                Messenger.Default.Send(new SerializationFailedMessage(Common.DeserializationFailed));
            }

            return data;
        }
    }
}
