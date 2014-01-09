namespace BattlelogMobile.Core.Model
{
    public class Credentials
    {
        public Credentials()
        {
            Email = string.Empty;
            Password = string.Empty;
            Game = SupportedGame.Battlefield3;
            RememberMe = false;
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public SupportedGame Game { get; set; }

        public bool RememberMe { get; set; }

        public bool Equals(Credentials other)
        {
            return other != null &&
                Email.Equals(other.Email) && Password.Equals(other.Password) && Game.Equals(other.Game) && RememberMe.Equals(other.RememberMe);
        }
    }
}
