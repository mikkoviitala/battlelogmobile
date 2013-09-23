using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class UpdateRequestedMessage : MessageBase
    {
        public UpdateRequestedMessage()
        {}

        public UpdateRequestedMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
