using BattlelogMobile.Core.Model;
using System.IO.IsolatedStorage;

namespace BattlelogMobile.Core.Repository
{
    public class FileSettingsRepository
    {
        private const string Key = "BackgroundEnabled";

        public FileSettingsRepository()
            : this(IsolatedStorageFile.GetUserStoreForApplication())
        {}

        public FileSettingsRepository(IsolatedStorageFile storageFile)
        {
            StorageFile = storageFile;
        }

        public IsolatedStorageFile StorageFile { get; set; }

        public void Save(Settings settings)
        {
            IsolatedStorageSettings.ApplicationSettings[Key] = settings.BackgroundEnabled;
        }

        public Settings Load()
        {
            Settings settings = new Settings();
            bool backgroundEnabled = true;

            if (IsolatedStorageSettings.ApplicationSettings.Contains(Key))
                IsolatedStorageSettings.ApplicationSettings.TryGetValue(Key, out backgroundEnabled);

            settings.BackgroundEnabled = backgroundEnabled;

            return settings;
        }
    }
}
