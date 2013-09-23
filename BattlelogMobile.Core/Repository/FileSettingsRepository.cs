using BattlelogMobile.Core.Model;
using System.IO.IsolatedStorage;

namespace BattlelogMobile.Core.Repository
{
    public class FileSettingsRepository : ISettingsRepository
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

        public void Save(ISettings settings)
        {
            IsolatedStorageSettings.ApplicationSettings[Key] = settings.BackgroundEnabled;
        }

        public ISettings Load()
        {
            ISettings settings = new Settings();
            bool backgroundEnabled = true;

            if (IsolatedStorageSettings.ApplicationSettings.Contains(Key))
                IsolatedStorageSettings.ApplicationSettings.TryGetValue(Key, out backgroundEnabled);

            settings.BackgroundEnabled = backgroundEnabled;

            return settings;
        }
    }
}
