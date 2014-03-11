using System;
using System.Net;
using System.Windows;

namespace StoreLauncher
{
    public static class StoreLauncher
    {
        public static StoreBase GetStoreInterface(string implementingType)
        {
            StoreBase storeInterface = null;

            Type t = Type.GetType(implementingType);

            if (t != null)
            {
                storeInterface = Activator.CreateInstance(t) as StoreBase;
            }

            return storeInterface;
        }
    }
}
