using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class SerializationFailedMessage : MessageBase
    {
        public SerializationFailedMessage()
        {}

        public SerializationFailedMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
