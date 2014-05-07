namespace BattlelogMobile.Core
{
    public static class Common
    {
        public const int TimeOutInSeconds = 90;
        public const string LogInFailedReasonTimedOut = "Login request timed out!";
        public const string LogInFailedReasonInvalidCredentials = "User credentials not accepted!";
        public const string StatusInformationVerifyingCredential = "Verifying credentials";
        public const string StatusInformationDownloading = "Downloading{0}";
        public const string StatusInformationSeekingContent = "Seeking content";
        public const string ServerMessageUrl = "http://www.losninosdelsol.net/battlelogmobile/message.txt?nocache={0}";

        public const string HttpPostMethod = "POST";
        public const string HttpGetMethod = "GET";
        public const string HttpAccept = "*/*";
        public const string HttpUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:6.0.2) Gecko/20100101 Firefox/6.0.2";
        public const string HttpContentType = "application/x-www-form-urlencoded";

        public const string CredentialsFile = "credentials.txt";
        public const string Bf3OverviewFile = "bf3overview.txt";
        public const string Bf3VehiclesFile = "bf3vehicles.txt";
        public const string Bf3WeaponsAndGadgetsFile = "bf3weapons.txt";

        public const string Bf4IndexFile = "bf4index.txt";
        public const string Bf4OverviewFile = "bf4overview.txt";
        public const string Bf4VehiclesFile = "bf4vehicles.txt";
        public const string Bf4WeaponsAndGadgetsFile = "bf4weapons.txt";

        public const string Bf3EntryPageUrl = "http://battlelog.battlefield.com/bf3/";
        public const string Bf3OverviewPageUrl = "http://battlelog.battlefield.com/bf3/overviewPopulateStats/{0}/bf3-us-assault/{1}/"; // {0} for user id and {1} for platform
        public const string Bf3VehiclesPageUrl = "http://battlelog.battlefield.com/bf3/vehiclesPopulateStats/{0}/{1}/";
        public const string Bf3GadgetsPageUrl = "http://battlelog.battlefield.com/bf3/weaponsPopulateStats/{0}/{1}/";

        public const string Bf4EntryPageUrl = "http://battlelog.battlefield.com/bf4/";
        public const string Bf4IndexPageUrl = "http://battlelog.battlefield.com/bf4/indexstats/{0}/{1}/?stats=1";
        public const string Bf4OverviewPageUrl = "http://battlelog.battlefield.com/bf4/warsawoverviewpopulate/{0}/{1}/";
        public const string Bf4VehiclesPageUrl = "http://battlelog.battlefield.com/bf4/warsawvehiclesPopulateStats/{0}/{1}/";
        public const string Bf4GadgetsPageUrl = "http://battlelog.battlefield.com/bf4/warsawWeaponsPopulateStats/{0}/{1}/";

        public const string GravatarImageUrl = "http://www.gravatar.com/avatar/{0}?s=52&d=http://battlelog-cdn.battlefield.com/public/base/shared/default-avatar-52.png?v=7909";

        public const int MaxRank = 45;
        public const string RankImagePrefix = "r";
        public const string RankServiceStarImagePrefix = "ss";
        //public const string RankImageUrl = "http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/ranks/medium/{0}";
        public const string KitImageUrl = "http://battlelog-cdn.battlefield.com/public/profile/bf3/kit-icon-{0}?v=3173239";
        public const string WeaponAndAccessoryImageUrl = "http://eaassets-a.akamaihd.net/bl-cdn/cdnprefix/a162802f7633bb6127b7d9bda2b88f65c/public/profile/bf3/stats/items_147x88/{0}"; //"http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/items_90x54/{0}?v=3173239";
        public const string RibbonAwardImageUrl = "http://eaassets-a.akamaihd.net/bl-cdn/cdnprefix/a162802f7633bb6127b7d9bda2b88f65c/public/profile/bf3/stats/ribbons/s/{0}"; //"http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/ribbons/s/{0}?v=3173239";
        public const string MedalAwardImageUrl = "http://eaassets-a.akamaihd.net/bl-cdn/cdnprefix/a162802f7633bb6127b7d9bda2b88f65c/public/profile/bf3/stats/medals/s/{0}"; //"http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/medals/s/{0}?v=3173239";
        public const string VehicleAndGadgetImageUrl = "http://eaassets-a.akamaihd.net/bl-cdn/cdnprefix/a162802f7633bb6127b7d9bda2b88f65c/public/profile/bf3/stats/items_147x88/{0}"; //"http://battlelog-cdn.battlefield.com/public/profile/bf3/stats/items_147x88/{0}?v=3173239";

        public const string KillsToken = "kills";
        public const string AwardGroup = "AwardGroup_Ribbons";
        public const string RibbonAwardSavePrefix = "ribbon_";
        public const string MedalAwardSavePrefix = "medal_";
        public const string ImageSuffix = ".png";
        public const string JsonParseFailedMessage = "Couldn't read soldier information";

        public const string UnexpectedException = "Something went wrong, please try again.";
        public const string SerializationFailed = "Something funky occured while saving your soldier... :(";
        public const string DeserializationFailed = "Something funky occured while loading your soldier... :(";

        public const string ProggressIndicator = "ProgressIndicator";
        public const string DeveloperInformation = "DeveloperInformation";
        public const string FailedMessageHeader = "Oh noes!";

        public const string Bf3BackgroundUri = "/Assets/Images/Battlefield3/Background.png";
        public const string Bf4BackgroundUri = "/Assets/Images/Battlefield4/Background.png";
        public const string ToggleBackgroundCheckedUri = "/Toolkit.Content/ApplicationBar.Check.png";
        public const string ToggleBackgroundUncheckedUri = "/Toolkit.Content/ApplicationBar.Uncheck.png";

        public const string ProductKey = "bf4stats";
    }
}
