using System.Net;
using System.Threading.Tasks;
using System.Windows;
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
        private readonly IsolatedStorageFile _storage = IsolatedStorageFile.GetUserStoreForApplication();
        private BattlelogUser _battlelogUser;

        public BattlelogRepository() 
            : this(new DownloadService(new CookieContainer()))
        {}

        public BattlelogRepository(DownloadService downloadService)
        {
            DownloadService = downloadService;
        }

        public DownloadService DownloadService { get; set; }

        public bool IsSerialized
        {
            get
            {
                return _battlelogUser != null && _battlelogUser.IsValid && _storage.FileExists(_battlelogUser.StorageFile);
            }
        }

        /// <summary>
        /// Update local storage
        /// </summary>
        public async Task<bool> UpdateStorage(SupportedGame game, bool forceUpdate = false)
        {
            Messenger.Default.Send(new NotificationMessage(this, Common.ProggressIndicator, Common.StatusInformationSeekingContent));

            if (_battlelogUser != null)
                _battlelogUser.Game = game;

            if (forceUpdate)
                ClearCache();

            if (!IsSerialized)
            {
                string url = game == SupportedGame.Battlefield3 ? Common.Bf3EntryPageUrl : Common.Bf4EntryPageUrl;
                _battlelogUser = await DownloadService.ResolveUserIdAndPlatform(url, new UserIdAndPlatformResolver(game));
                
                if (_battlelogUser == null || !_battlelogUser.IsValid)
                    return false;
                
                await GetFilesFromServer(game);
            }
            return true;
        }

        private void ClearCache()
        {
            if (_battlelogUser != null && _battlelogUser.IsValid)
                if (_storage.FileExists(_battlelogUser.StorageFile))
                    _storage.DeleteFile(_battlelogUser.StorageFile);
        }

        public T Daa<T>()
        {
            return default(T);
        }

        public Task<T> LoadBattlefieldData<T>(JSONParser<T> parser) where T : class
        {
            if (!IsSerialized)
            {
                return Task.Factory.StartNew(() =>
                    {
                        T data = parser.Parse();
                        Serialize(data);
                        return data;
                    });
            }

            return Task.Factory.StartNew(() =>  Deserialize<T>());
        }

        /// <summary>
        ///  When user id and platform are resolved, tell download service to get JSON streams 
        /// </summary>
        private async Task GetFilesFromServer(SupportedGame game)
        {
            string status;
            var network = NetworkInformation.Current();
            if (string.IsNullOrWhiteSpace(network))
                status = string.Format(Common.StatusInformationDownloading, string.Empty);
            else
                status = string.Format(Common.StatusInformationDownloading, string.Format(" ({0})", network));
            
            Messenger.Default.Send(new NotificationMessage(this, Common.ProggressIndicator, status));

            if (game == SupportedGame.Battlefield3)
            {
                await DownloadService.GetFile(string.Format(Common.Bf3OverviewPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.Bf3OverviewFile);
                await DownloadService.GetFile(string.Format(Common.Bf3VehiclesPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.Bf3VehiclesFile);
                await DownloadService.GetFile(string.Format(Common.Bf3GadgetsPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.Bf3WeaponsAndGadgetsFile);
            }
            else
            {
                await DownloadService.GetFile(string.Format(Common.Bf4IndexPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.Bf4IndexFile);
                await DownloadService.GetFile(string.Format(Common.Bf4OverviewPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.Bf4OverviewFile);
                await DownloadService.GetFile(string.Format(Common.Bf4VehiclesPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.Bf4VehiclesFile);
                await DownloadService.GetFile(string.Format(Common.Bf4GadgetsPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.Bf4WeaponsAndGadgetsFile);
            }
        }

        private void Serialize<T>(T data) where T : class
        {
            bool errorOccured = false;

            using (var file = _storage.OpenFile(_battlelogUser.StorageFile, FileMode.Create))
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
                Messenger.Default.Send(
                    new DialogMessage(this, Common.SerializationFailed, result => {}) 
                        { Caption = Common.FailedMessageHeader, Button = MessageBoxButton.OK});
            }
        }

        private T Deserialize<T>() where T : class
        {
            T data = default(T);
            bool errorOccured = false;

            using (var file = _storage.OpenFile(_battlelogUser.StorageFile, FileMode.Open))
            {
                var serializer = new SharpSerializer(true);
                try
                {
                    data = serializer.Deserialize(file) as T;
                }
                catch (Exception)
                {
                    errorOccured = true;
                }
            }

            if (errorOccured)
            {
                ClearCache();
                Messenger.Default.Send(
                    new DialogMessage(this, Common.DeserializationFailed, result => { }) 
                        { Caption = Common.FailedMessageHeader, Button = MessageBoxButton.OK });
            }

            return data;
        }
    }
}
