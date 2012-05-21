using System;
using System.Globalization;

namespace BattlelogMobile.Core.Model
{
    public class Credentials : ICredentials
    {
        public Credentials()
        {
            Email = string.Empty;
            Password = string.Empty;
            RememberMe = false;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public bool Equals(ICredentials other)
        {
            return other != null && 
                Email.Equals(other.Email) && Password.Equals(other.Password) && RememberMe.Equals(other.RememberMe);
        }

        public override string ToString()
        {
            return string.Format("{0}" + Environment.NewLine + "{1}" + Environment.NewLine + "{2}", 
                Email, Password, RememberMe.ToString(CultureInfo.InvariantCulture));
        }
    }
}
