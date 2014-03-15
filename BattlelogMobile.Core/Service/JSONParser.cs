using System.IO.IsolatedStorage;

namespace BattlelogMobile.Core.Service
{
    public abstract class JSONParser<T>
    {
        protected readonly IsolatedStorageFile IsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
        public abstract T Parse();
    }
}
