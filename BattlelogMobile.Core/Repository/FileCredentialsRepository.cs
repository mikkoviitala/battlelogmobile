using System;
using System.IO;
using System.IO.IsolatedStorage;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Service;

namespace BattlelogMobile.Core.Repository
{
    public class FileCredentialsRepository : ICredentialsRepository 
    {
        private readonly CryptoService _crypto = new CryptoService();
        private bool _isEncrypted;

        public FileCredentialsRepository() : this(IsolatedStorageFile.GetUserStoreForApplication())
        {}

        public FileCredentialsRepository(IsolatedStorageFile storageFile)
        {
            StorageFile = storageFile;
        }


        public IsolatedStorageFile StorageFile { get; set; }

        public void Save(ICredentials credentials)
        {
            using (var writer = new StreamWriter(StorageFile.OpenFile(Common.CredentialsFile, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                writer.WriteLine(_crypto.Encrypt(credentials.Email));
                writer.WriteLine(_crypto.Encrypt(credentials.Password));
                writer.WriteLine(credentials.RememberMe);
                writer.Close();
            }
            IsolatedStorageSettings.ApplicationSettings["IsEncrypted"] = true;
        }

        public ICredentials Load()
        {
            ICredentials credentials = new Credentials();
            using (var reader = new StreamReader(StorageFile.OpenFile(Common.CredentialsFile, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                IsolatedStorageSettings.ApplicationSettings.TryGetValue("IsEncrypted", out _isEncrypted);
                if (reader.Peek() > 0)
                {
                    credentials.Email = _isEncrypted ? _crypto.Decrypt(reader.ReadLine()) : reader.ReadLine();
                    credentials.Password = _isEncrypted ? _crypto.Decrypt(reader.ReadLine()) : reader.ReadLine();
                    credentials.RememberMe = !string.IsNullOrEmpty(credentials.Password) && Convert.ToBoolean(reader.ReadLine());
                }
                reader.Close();
            }
            
            if ((credentials.Email == null || credentials.Password == null) || (credentials.Email.Length > 20 || credentials.Password.Length > 20))
                return new Credentials();
            return credentials;
        }
    }
}
