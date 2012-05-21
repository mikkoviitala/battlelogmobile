using BattlelogMobile.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Core.Service
{
    [TestClass()]
    public class CryptoServiceTest
    {
        private readonly CryptoService _crypto = new CryptoService();

        [TestMethod()]
        public void EncryptDecryptTest()
        {
            string expected = "test";
            string actual = _crypto.Decrypt(_crypto.Encrypt(expected));
            Assert.AreEqual(expected, actual);

            Assert.AreEqual(string.Empty, _crypto.Decrypt("not base64"));
        }
    }
}