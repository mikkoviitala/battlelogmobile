namespace BattlelogMobile.Core.Model
{
    public class BattlelogUser
    {
        public BattlelogUser()
        {
            UserId = null;
            Platform = null;
        }

        public BattlelogUser(long userId, Platform platform)
        {
            UserId = userId;
            Platform = platform;
        }

        public long? UserId { get; set; }

        public Platform? Platform { get; set; }

        public SupportedGame Game { get { return SupportedGame.Battlefield3; } }

        public bool IsValid
        {
            get
            {
                return UserId.HasValue && (Platform.HasValue && Platform.Value != Model.Platform.Unknown);
            }
        }

        public string StorageFile { get { return string.Format("{0}_{1}_{2}", UserId, Platform, Game); } }
    }
}
