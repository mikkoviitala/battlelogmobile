﻿using System.Net;
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

            if (forceUpdate)
                ClearCache();

            if (!IsSerialized)
            {
                //_battlelogUser = await DownloadService.ResolveUserIdAndPlatform(Common.Bf3EntryPageUrl, new UserIdAndPlatformResolver());
                _battlelogUser = await DownloadService.ResolveUserIdAndPlatform(Common.Bf4EntryPageUrl, new UserIdAndPlatformResolver(game));
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

        public Task<Battlefield3Data> LoadBattlefield3Data()
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
        private async Task GetFilesFromServer(SupportedGame game)
        {
            Messenger.Default.Send(new NotificationMessage(this, Common.ProggressIndicator, Common.StatusInformationDownloading));

            if (game == SupportedGame.Battlefield3)
            {
                await DownloadService.GetFile(string.Format(Common.Bf3OverviewPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.OverviewFile);
                await DownloadService.GetFile(string.Format(Common.Bf3VehiclesPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.VehiclesFile);
                await DownloadService.GetFile(string.Format(Common.Bf3GadgetsPageUrl, _battlelogUser.UserId, (int)_battlelogUser.Platform.Value), Common.WeaponsAndGadgetsFile);
            }
            else
            {
                
            }
        }

        private void Serialize(Battlefield3Data data)
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

        private Battlefield3Data Deserialize()
        {
            Battlefield3Data data = null;
            bool errorOccured = false;

            using (var file = _storage.OpenFile(_battlelogUser.StorageFile, FileMode.Open))
            {
                var serializer = new SharpSerializer(true);
                try
                {
                    data = serializer.Deserialize(file) as Battlefield3Data;
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
