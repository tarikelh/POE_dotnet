using _08_MultiWindows.Model;

namespace _08_MultiWindows.Services
{
    public interface IUtilisateurService
    {
        List<Utilisateur> GetAll();

        string? Insert(Utilisateur u);

        void Update(Utilisateur u);

        Utilisateur GetByLogin(string login);
        void RemoveByLogin(string login);

    }
}
