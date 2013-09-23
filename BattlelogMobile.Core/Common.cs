namespace BattlelogMobile.Core
{
    public static class Common
    {
        public const int TimeOutInSeconds = 90;
        public const string LogInFailedReasonTimedOut = "Login request timed out!";
        public const string LogInFailedReasonInvalidCredentials = "User credentials not accepted!";
        public const string StatusInformationVerifyingCredential = "Verifying credentials";
        public const string StatusInformationDownloading = "Downloading";
        public const string StatusInformationSeekingContent = "Seeking content";
        public const string StatusInformationPreparingStatistics = "Preparing statistics";
        public const string ServerMessageUrl = "http://www.losninosdelsol.net/battlelogmobile/message.txt?nocache={0}";

        public const string HttpPostMethod = "POST";
        public const string HttpGetMethod = "GET";
        public const string HttpAccept = "*/*";
        public const string HttpUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:6.0.2) Gecko/20100101 Firefox/6.0.2";
        public const string HttpContentType = "application/x-www-form-urlencoded";

        //public const string SoldierFile = "soldier.bin";
        public const string CredentialsFile = "credentials.txt";
        public const string OverviewFile = "overview.txt";
        public const string VehiclesFile = "vehicles.txt";
        public const string WeaponsAndGadgetsFile = "weapons.txt";
        public const string UnlocksFile = "unlocks.txt";

        public const string EntryPageUrl = "http://battlelog.battlefield.com/bf3/";
        public const string OverviewPageUrl = "http://battlelog.battlefield.com/bf3/overviewPopulateStats/{0}/bf3-us-assault/{1}/"; // {0} for user id and {1} for platform
        public const string VehiclesPageUrl = "http://battlelog.battlefield.com/bf3/vehiclesPopulateStats/{0}/{1}/";
        public const string GadgetsPageUrl = "http://battlelog.battlefield.com/bf3/weaponsPopulateStats/{0}/{1}/";
        public const string UnlocksPageUrl = "http://battlelog.battlefield.com/bf3/upcomingUnlocksPopulateStats/{0}/{1}/";
        //public const string BattleFeedPageUrl = "http://battlelog.battlefield.com/bf3/";

        public const string GravatarImageUrl = "http://www.gravatar.com/avatar/{0}?s=52&d=http://battlelog-cdn.battlefield.com/public/base/shared/default-avatar-52.png?v=7909";
        //public const string GravatarImageUrl = "http://www.gravatar.com/avatar/{0}";
        //public const string DefaultGravatarImage = "default-avatar-52.png";
        //public const string DefaultGravatarImageUrl = "http://battlelog-cdn.battlefield.com/public/base/shared/{0}?v=7909";

        public const int MaxRank = 45;
        public const string RankImagePrefix = "r";
        public const string RankServiceStarImagePrefix = "ss";
        public const string RankImageUrl = "http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/ranks/medium/{0}";
        public const string KitImageUrl = "http://battlelog-cdn.battlefield.com/public/profile/bf3/kit-icon-{0}?v=3173239";
        public const string WeaponAndAccessoryImageUrl = "http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/items_90x54/{0}?v=3173239";
        public const string RibbonAwardImageUrl = "http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/ribbons/s/{0}?v=3173239";
        public const string MedalAwardImageUrl = "http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/medals/s/{0}?v=3173239";
        public const string VehicleAndGadgetImageUrl = "http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/items_147x88/{0}?v=3173239";

        public const string ServiceStarImage = "servicestar-31x31.png";
        public const string ServiceStarImageUrl = "http://battlelog.battlefield.com/public/profile/bf3/stats/servicestars/{0}";

        public const string KillsToken = "kills";
        public const string AwardGroup = "AwardGroup_Ribbons";
        public const string RibbonAwardSavePrefix = "ribbon_";
        public const string MedalAwardSavePrefix = "medal_";
        public const string ImageSuffix = ".png";
        public const string JsonParseFailedMessage = "Couldn't read soldier information";

        public const string SerializationFailed = "Something funky occured while saving your soldier... :(";
        public const string DeserializationFailed = "Something funky occured while loading your soldier... :(";
    }
}
