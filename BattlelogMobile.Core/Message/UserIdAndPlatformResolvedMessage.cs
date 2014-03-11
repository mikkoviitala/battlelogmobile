using BattlelogMobile.Core.Model;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class UserIdAndPlatformResolvedMessage : MessageBase
    {
        public UserIdAndPlatformResolvedMessage(BattlelogUser user)
        {
            User = user;
        }

        public BattlelogUser User { get; set; }
    }
}