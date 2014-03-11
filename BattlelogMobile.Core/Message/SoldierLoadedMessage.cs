using System;
using BattlelogMobile.Core.Model;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Message
{
    public class SoldierLoadedMessage : MessageBase
    {
        public SoldierLoadedMessage(string message, SupportedGame game)
        {
            Message = message;
            Game = game;
        }

        public string Message { get; set; }

        public SupportedGame Game { get; set; }
    }
}
