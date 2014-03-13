using System;
using System.IO;
using System.IO.IsolatedStorage;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Service;

namespace BattlelogMobile.Core.Repository
{
    public class FileCredentialsRepository
    {
        private readonly CryptoService _crypto = new CryptoService();

        public FileCredentialsRepository() : this(IsolatedStorageFile.GetUserStoreForApplication())
        {}

        public FileCredentialsRepository(IsolatedStorageFile storageFile)
        {
            StorageFile = storageFile;
        }

        public IsolatedStorageFile StorageFile { get; set; }

        public void Save(Credentials credentials)
        {
            using (var writer = new StreamWriter(StorageFile.OpenFile(Common.CredentialsFile, FileMode.Create, FileAccess.Write)))
            {
                //writer.WriteLine(_crypto.Encrypt(credentials.Email));
                //writer.WriteLine(_crypto.Encrypt(credentials.Password));
                writer.WriteLine(credentials.Email);
                writer.WriteLine(credentials.Password);
                writer.WriteLine((int)credentials.Game);
                writer.WriteLine(credentials.RememberMe);
            }
            IsolatedStorageSettings.ApplicationSettings["IsEncrypted"] = false;
        }

        public Credentials Load()
        {
            Credentials credentials = new Credentials();
            using (var reader = new StreamReader(StorageFile.OpenFile(Common.CredentialsFile, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                bool isEncrypted;
                IsolatedStorageSettings.ApplicationSettings.TryGetValue("IsEncrypted", out isEncrypted);
                if (reader.Peek() > 0)
                {
                    try
                    {
                        credentials.Email = isEncrypted ? _crypto.Decrypt(reader.ReadLine()) : reader.ReadLine();
                        credentials.Password = isEncrypted ? _crypto.Decrypt(reader.ReadLine()) : reader.ReadLine();
                        credentials.Game = (SupportedGame) Convert.ToInt32(reader.ReadLine());
                        credentials.RememberMe = !string.IsNullOrEmpty(credentials.Password) && Convert.ToBoolean(reader.ReadLine());
                    }
                    catch (Exception e)
                    {
                        // If it's format exception, then user has not saved credentials in new format before
                        if (!(e is FormatException))
                            throw;
                    }
                }
            }
            
            if (credentials.Email == null || credentials.Password == null || credentials.Password.Length > 20)
                return new Credentials();
            return credentials;
        }
    }
}
