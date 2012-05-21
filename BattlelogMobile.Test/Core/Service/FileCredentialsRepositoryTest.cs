using System.IO.IsolatedStorage;
using System.Reflection;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Core.Service
{
    [TestClass()]
    public class FileCredentialsRepositoryTest
    {
        [TestMethod()]
        public void LoadAndSaveTest()
        {
            var repository = new FileCredentialsRepository(IsolatedStorageFile.GetUserStoreForApplication());
            var expected = new Credentials()
                {
                    Email = "some@email.com",
                    Password = "very_secret",
                    RememberMe = true
                };
            repository.Save(expected);
            var actual = repository.Load();
            Assert.IsTrue(expected.Equals(actual));
        }
    }
}
