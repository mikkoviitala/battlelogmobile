using BattlelogMobile.Core.Model;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class BattlelogCredentialsAcceptedMessage : MessageBase
    {
        public BattlelogCredentialsAcceptedMessage(string currentUser, SupportedGame game)
            :this(currentUser, game, false)
        {}

        public BattlelogCredentialsAcceptedMessage(string currentUser, SupportedGame game, bool forceUpdate)
        {
            CurrentUser = currentUser;
            Game = game;
            ForceUpdate = forceUpdate;
        }

        public SupportedGame Game { get; set; }

        public bool ForceUpdate { get; set; }

        public string CurrentUser { get; set; }
    }
}
