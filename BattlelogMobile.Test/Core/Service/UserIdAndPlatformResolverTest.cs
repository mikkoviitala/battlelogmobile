using System.IO;
using System.Text;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Core.Service
{
    [TestClass()]
    public class UserIdAndPlatformResolverTest
    {
        private const long ExpectedUserId = 1234567890;
        private const Platform ExpectedPlatform = Platform.PS3;
        private const bool ExpectedStatus = false;
        private readonly string _dogtagsBlock = "/dogtags/" + ExpectedUserId + "/" + ExpectedPlatform + "/";
        private readonly string _unlocksBlock = "/unlocks/" + ExpectedUserId + "/" + ExpectedPlatform + "/";
        private readonly string _unknownBlock = "/unknowblock/" + ExpectedUserId + "/" + ExpectedPlatform + "/";

        public UserIdAndPlatformResolverTest()
        {
            Messenger.Default.Register<UserIdAndPlatformResolvedMessage>(this, message =>
                {
                    Assert.AreEqual(ExpectedUserId, message.UserId);
                    Assert.AreEqual(ExpectedPlatform, message.Platform);
                });
            Messenger.Default.Register<BattlelogResponseMessage>(this, message => Assert.AreEqual(ExpectedStatus, message.IsOk));
        }

        [TestMethod()]
        public void ResolveTest()
        {
            var resolver = new UserIdAndPlatformResolver();
            resolver.Resolve(new MemoryStream(Encoding.UTF8.GetBytes(_dogtagsBlock)));
            resolver.Resolve(new MemoryStream(Encoding.UTF8.GetBytes(_unlocksBlock)));
            resolver.Resolve(new MemoryStream(Encoding.UTF8.GetBytes(_unknownBlock)));
        }
    }
}