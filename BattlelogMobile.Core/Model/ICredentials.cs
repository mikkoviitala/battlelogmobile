using System;

namespace BattlelogMobile.Core.Model
{
    public interface ICredentials : IEquatable<ICredentials>
    {
        string Email { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
    }
}