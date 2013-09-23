using System;
using System.Globalization;
using System.IO;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Service
{
    // The Resolve method will first try to resolve userId and platform from the /dogtags/ block. 
    // If it fails, a retry will be performed from the /unlocks/ block.
    public class UserIdAndPlatformResolver : IUserIdAndPlatformResolver 
    {
        private const string UnableToParse = "Unable to retrieve user id, please contact support to resolve this issue.";
        private const string DogtagsBlockStart = "/dogtags/";
        private const string UnlocksBlockStart = "/unlocks/";
        private const string EaId = "cem_ea_id";
        private long _userId;
        private Platform _platform;

        public void Resolve(Stream stream)
        {
            _platform = Platform.Unknown;
            using (var reader = new StreamReader(stream))
            {
                string buffer = reader.ReadToEnd();
                bool resolvedIdAndPlatform = 
                    Resolve(buffer, DogtagsBlockStart);
                if (!resolvedIdAndPlatform)
                    Resolve(buffer, UnlocksBlockStart);

                if (_userId <= 0 || _platform == Platform.Unknown)
                {
                    Messenger.Default.Send(new BattlelogResponseMessage(UnableToParse, false));
                    return;
                }

                Messenger.Default.Send(new UserIdAndPlatformResolvedMessage(_userId, _platform));
            }
        }

        private bool Resolve(string buffer, string dogtagsBlockStart)
        {
            try
            {
                int startPosition = buffer.IndexOf(dogtagsBlockStart, StringComparison.Ordinal);
                buffer = buffer.Substring(startPosition + dogtagsBlockStart.Length);
                _userId = Convert.ToInt64(buffer.Substring(0, buffer.IndexOf("/", StringComparison.Ordinal)));

                buffer = buffer.Substring(_userId.ToString(CultureInfo.InvariantCulture).Length + 1);
                string platformBlock = buffer.Substring(0, buffer.IndexOf("/", StringComparison.Ordinal));
                
                if (platformBlock == EaId)
                    _platform = Platform.PC;
                else
                    _platform = (Platform) Enum.Parse(typeof (Platform), platformBlock, true);
                
                return true;
            }
            catch (Exception e)
            {
                if (e is ArgumentException || e is FormatException)
                    return false;
                throw;
            }
        }
    }
}
