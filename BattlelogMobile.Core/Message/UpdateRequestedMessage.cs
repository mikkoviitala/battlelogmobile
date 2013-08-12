using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
