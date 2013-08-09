using System.Net;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;
using System.IO.IsolatedStorage;
using Polenter.Serialization;
using System.IO;
using System;
using System.Linq;
using Polenter.Serialization.Core;
using System.Globalization;
using System.Windows;
using System.Windows.Navigation;

namespace BattlelogMobile.Core.Repository
{
    /// <summary>
    /// Battlelog repository
    /// </summary>
    public class BattlelogRepository : IBattlelogRepository
    {
        private const int ExpectedResponseMessages = 3;
        private readonly IsolatedStorageFile _storage = IsolatedStorageFile.GetUserStoreForApplication();
        private int _responseMessages = 0;
        private long? _userId;
        private Platform? _platform;

        public BattlelogRepository() 
            : this(new DownloadService(new CookieContainer()))
        {}

        public BattlelogRepository(IDownloadService downloadService)
        {
            Messenger.Default.Register<UserIdAndPlatformResolvedMessage>(this, UserIdAndPlatformResolvedMessageReceived);
            Messenger.Default.Register<BattlelogResponseMessage>(this, BattlelogResponseMessageReceived);
            DownloadService = downloadService;
        }

        public IDownloadService DownloadService { get; set; }

        public string CurrentUser { get; set; }

        public bool IsSerialized
        {
            get 
            {
                if (CurrentUser == null)
                    return false;
                return _storage.FileExists(CurrentUser);
            }
        }

        /// <summary>
        /// Update local storage
        /// </summary>
        public void UpdateStorage(bool forceUpdate = false)
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
                DownloadService.ResolveUserIdAndPlatform(Common.EntryPageUrl, new UserIdAndPlatformResolver());
            }
        }

        private void ClearCache()
        {
            if (IsSerialized)
            {
                if (CurrentUser != null)
                    if (_storage.FileExists(CurrentUser))
                        _storage.DeleteFile(CurrentUser);
            }
        }

        private void Reset()
        {
            _responseMessages = 0;
            _userId = null;
            _platform = null;
        }

        /// <summary>
        /// Load current soldier information
        /// </summary>
        public ISoldier Load()
        {
            if (!IsSerialized)
            {
                var parser = new JSONParser();
                ISoldier soldier = parser.Parse() as Soldier;
                Serialize(soldier);
                return soldier;
            }

            return Deserialize();

            //var parser = new JSONParser();
            //return parser.Parse();
        }

        /// <summary>
        ///  When user id and platform are resolved, tell download service to get JSON streams 
        /// </summary>
        private void GetFilesFromServer()
        {
            if (_userId == null || _platform == null)
                return;

            DownloadService.GetFile(string.Format(Common.OverviewPageUrl, _userId, (int)_platform), Common.OverviewFile);
            DownloadService.GetFile(string.Format(Common.VehiclesPageUrl, _userId, (int)_platform), Common.VehiclesFile);
            DownloadService.GetFile(string.Format(Common.GadgetsPageUrl, _userId, (int)_platform), Common.WeaponsAndGadgetsFile);
            //DownloadService.GetFile(string.Format(Common.UnlocksPageUrl, _userId, (int)_platform), Common.UnlocksFile);
        }

        private void UserIdAndPlatformResolvedMessageReceived(UserIdAndPlatformResolvedMessage message)
        {
            _userId = message.UserId;
            _platform = message.Platform;
            Messenger.Default.Send(new BattlelogResponseMessage(Common.StatusInformationSeekingContent, true));
            GetFilesFromServer();
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

        private void Serialize(ISoldier soldier)
        {
            using (var file = _storage.OpenFile(CurrentUser, FileMode.OpenOrCreate))
            {
                try
                {
                    var serializer = new SharpSerializer(true);
                    serializer.Serialize(soldier as Soldier, file);
                    file.Close();
                }
                catch (Exception)
                {
                    file.Close();
                    ClearCache();
                    Messenger.Default.Send(new SerializationFailedMessage(Common.SerializationFailed));
                }
            }
        }

        private ISoldier Deserialize()
        {
            ISoldier soldier;
            using (var file = _storage.OpenFile(CurrentUser, FileMode.Open))
            {
                var serializer = new SharpSerializer(true);
                try
                {
                    soldier = serializer.Deserialize(file) as Soldier;
                    ApplyImages(soldier);
                }
                catch (Exception)
                {
                    file.Close();
                    ClearCache();
                    soldier = null;
                    Messenger.Default.Send(new SerializationFailedMessage(Common.DeserializationFailed));
                }
            }
            return soldier;
        }

        private void ApplyImages(ISoldier soldier)
        {
            var _imageRepository = new ImageRepository();

            foreach (var kit in soldier.Score.Kits)
                kit.Image = _imageRepository.Load(kit.ImageName);

            foreach (var kitProgression in soldier.KitProgressions)
                kitProgression.Image = _imageRepository.Load(Common.ServiceStarImage);

            soldier.RankImage = _imageRepository.Load(soldier.RankImageName);

            soldier.User.Image = _imageRepository.Load(soldier.User.GravatarMd5);

            foreach (var award in soldier.Awards)
                award.Image = _imageRepository.Load(award.ImageSaveName);

            foreach (var vehicle in soldier.Vehicles)
                vehicle.Image = _imageRepository.Load(vehicle.ImageName);

            foreach (var gadget in soldier.Gadgets)
                gadget.Image = _imageRepository.Load(gadget.ImageName);

            var serviceStarImage = _imageRepository.Load(Common.ServiceStarImage);
            foreach (var weapon in soldier.Weapons)
            {
                weapon.ServiceStarImage = serviceStarImage;
                weapon.Image = _imageRepository.Load(weapon.ImageName);
            }
        }
    }
}
