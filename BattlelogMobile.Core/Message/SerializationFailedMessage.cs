using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
