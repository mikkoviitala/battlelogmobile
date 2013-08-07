using BattlelogMobile.Core.Model;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class UserIdAndPlatformResolvedMessage : MessageBase
    {
        public UserIdAndPlatformResolvedMessage(long userId, Platform platform)
        {
            UserId = userId;
            Platform = platform;
        }

        public long UserId { get; set; }

        public Platform Platform { get; set; }
    }
}