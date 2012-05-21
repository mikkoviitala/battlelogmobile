using System;
using System.Text;
using System.Security.Cryptography;

namespace BattlelogMobile.Core.Service
{
    public class CryptoService
    {
        public string Encrypt(string data)
        {
            var byteArray = Encoding.UTF8.GetBytes(data);
            var protectedByteArray = ProtectedData.Protect(byteArray, null);
            return Convert.ToBase64String(protectedByteArray);
        }

        public string Decrypt(string data)
        {
            try
            {
                var protectedByteArray = Convert.FromBase64String(data);
                var byteArray = ProtectedData.Unprotect(protectedByteArray, null);
                return Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            }
            catch (Exception) //Trying to decrypt old data fails. Returns empty string instead
            {
                return string.Empty;
            }
        }
    }
}
