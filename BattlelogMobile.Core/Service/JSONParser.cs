using System.IO.IsolatedStorage;
using BattlelogMobile.Core.Model.Battlefield4.Vehiclez;

namespace BattlelogMobile.Core.Service
{
    public abstract class JSONParser<T>
    {
        protected readonly IsolatedStorageFile IsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
        public abstract T Parse();
    }
}
