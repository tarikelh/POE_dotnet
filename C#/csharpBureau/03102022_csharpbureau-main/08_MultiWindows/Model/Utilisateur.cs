namespace _08_MultiWindows.Model
{
    public enum Profile
    {
        ADMIN, MANAGER, STAGIAIRE, RH
    }

    public class Utilisateur
    {
        public string Login { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public Profile Profile { get; set; }
        public string? Photo { get; set; } = "";

        public static string[] Profiles = { "ADMIN", "MANAGER", "STAGIAIRE", "RH" };

        public Utilisateur()
        {

        }

        public Utilisateur(string login, string password, Profile myProperty, string? photo)
        {
            Login = login;
            Password = password;
            Profile = myProperty;
            Photo = photo;
        }

        public override string ToString()
        {
            return $"Login : {Login} - {Profile}";
        }
    }
}
