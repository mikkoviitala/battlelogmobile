using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class BattlelogResponseMessage : MessageBase
    {
        public BattlelogResponseMessage(string message, bool isOk) : this(null, message, isOk)
        {}

        public BattlelogResponseMessage(object sender, string message, bool isOk)
        {
            base.Sender = sender;
            Message = message;
            IsOk = isOk;
        }

        public string Message { get; private set; }
        public bool IsOk { get; private set; }
    }
}
