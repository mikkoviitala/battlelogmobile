using System.Net;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Repository
{
    /// <summary>
    /// Battlelog repository
    /// </summary>
    public class BattlelogRepository : IBattlelogRepository
    {
        private const string UserIdAndPlatformResolved = "Seeking content";
        private const int ExpectedResponseMessages = 3;
        private int _responseMessages = 0;
        private long? _userId;
        private Platform? _platform;

        public BattlelogRepository() : this(new DownloadService(new CookieContainer()))
        {}

        public BattlelogRepository(IDownloadService downloadService)
        {
            Messenger.Default.Register<UserIdAndPlatformResolvedMessage>(this, UserIdAndPlatformResolvedMessageReceived);
            Messenger.Default.Register<BattlelogResponseMessage>(this, BattlelogResponseMessageReceived);
            DownloadService = downloadService;
        }

        public IDownloadService DownloadService { get; set; }

        /// <summary>
        /// Update local storage
        /// </summary>
        public void UpdateStorage()
        {
            Reset();
            DownloadService.ResolveUserIdAndPlatform(Common.EntryPageUrl, new UserIdAndPlatformResolver());
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
            var parser = new JSONParser();
            return parser.Parse();
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
            Messenger.Default.Send(new BattlelogResponseMessage(UserIdAndPlatformResolved, true));
            GetFilesFromServer();
        }

        // Listen for download completions, send message to UI when all done
        private void BattlelogResponseMessageReceived(BattlelogResponseMessage message)
        {
            if (message.Sender == null || (message.Sender.GetType() != (typeof(DownloadService))))
                return;

            _responseMessages++;
            if (_responseMessages == ExpectedResponseMessages)
                Messenger.Default.Send(new BattlelogUpdateCompleteMessage());
        }
    }
}
