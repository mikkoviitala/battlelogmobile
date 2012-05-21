using System;
using System.IO;
using System.IO.IsolatedStorage;
using BattlelogMobile.Core.Model;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Service
{
    public static class BinarySerializeHelper
    {
        public static void Serialize<T>(T obj)
        {
            var sharpSerializer = new SharpSerializer(true);
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var file = storage.OpenFile(obj.GetType().Name + ".bin", FileMode.Create))
                {
                    sharpSerializer.Serialize(obj, file);
                }
            }
        }

        public static object Deserialize(Type type)
        {
            var sharpSerializer = new SharpSerializer(true);
            var storage = IsolatedStorageFile.GetUserStoreForApplication();

            if (storage.FileExists(type.Name + ".bin"))
            {
                using (var file = storage.OpenFile(type.Name + ".bin", FileMode.Open, FileAccess.ReadWrite))
                {
                    return sharpSerializer.Deserialize(file);
                }
            }
            return null;
        }
    }
}
