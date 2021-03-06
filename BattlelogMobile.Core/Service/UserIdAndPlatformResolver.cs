﻿using System;
using System.Globalization;
using System.IO;
using BattlelogMobile.Core.Model;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Service
{
    public class UserIdAndPlatformResolver
    {
        private const string UnableToParse = "Unable to retrieve user id, please contact support using email link below to resolve this issue.";
        private const string DogtagsBlockStart = "/dogtags/";
        private const string UnlocksBlockStart = "/unlocks/";
        private const string StatsBlockStart = "/stats/";
        private const string EaId = "cem_ea_id";
        private SupportedGame _game = SupportedGame.Unknown;

        public UserIdAndPlatformResolver(SupportedGame game)
        {
            _game = game;
        }

        public BattlelogUser Resolve(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                string buffer = reader.ReadToEnd();
                BattlelogUser user = null;

                if (_game == SupportedGame.Battlefield3)
                {
                    user = Resolve(buffer, DogtagsBlockStart);
                    if (user == null || !user.IsValid)
                        user = Resolve(buffer, UnlocksBlockStart);
                }
                else
                {
                    user = Resolve(buffer, StatsBlockStart);
                }

                if (user != null && user.IsValid)
                    user.Game = _game;
                else
                    Messenger.Default.Send(new NotificationMessage(this, UnableToParse));

                return user;
            }
        }

        private BattlelogUser Resolve(string buffer, string htmlBlock)
        {
            try
            {
                int startPosition = buffer.IndexOf(htmlBlock, StringComparison.Ordinal);
                buffer = buffer.Substring(startPosition + htmlBlock.Length);
                long userId = Convert.ToInt64(buffer.Substring(0, buffer.IndexOf("/", StringComparison.Ordinal)));

                buffer = buffer.Substring(userId.ToString(CultureInfo.InvariantCulture).Length + 1);
                string platformString = buffer.Substring(0, buffer.IndexOf("/", StringComparison.Ordinal));

                var platform = Platform.Unknown;
                if (platformString == EaId)
                    platform = Platform.PC;
                else
                    platform = (Platform) Enum.Parse(typeof (Platform), platformString, true);
                
                return new BattlelogUser(userId, platform);
            }
            catch (Exception e)
            {
                //if (e is ArgumentException || e is FormatException)
                //    throw;
            }
            return null;
        }
    }
}
