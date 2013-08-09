using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class BattlelogCredentialsAcceptedMessage : MessageBase
    {
        public BattlelogCredentialsAcceptedMessage(string currentUser)
            :this(currentUser, false)
        {}

        public BattlelogCredentialsAcceptedMessage(string currentUser, bool forceUpdate)
        {
            CurrentUser = currentUser; 
            ForceUpdate = forceUpdate;
        }

        public bool ForceUpdate { get; set; }

        public string CurrentUser { get; set; }
    }
}
