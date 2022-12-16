using _08_MultiWindows.Model;

namespace _08_MultiWindows.DAO
{
    public  interface IUtilisateurDAO
    {
        List<Utilisateur> GetAll();

        string? Insert(Utilisateur u);

        void Update(Utilisateur u);

        Utilisateur FindByLogin(string login);

        void DeleteByLogin(string login);
    }
}
