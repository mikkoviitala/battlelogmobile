using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class SoldierLoadedMessage : MessageBase
    {
        public SoldierLoadedMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
