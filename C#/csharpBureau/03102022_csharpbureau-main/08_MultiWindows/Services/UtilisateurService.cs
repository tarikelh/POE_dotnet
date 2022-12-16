using _08_MultiWindows.DAO;
using _08_MultiWindows.Model;

namespace _08_MultiWindows.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        public IUtilisateurDAO Dao { get; set; }

        public UtilisateurService(IUtilisateurDAO dao)
        {
            Dao = dao;
        }

        public List<Utilisateur> GetAll()
        {
            return Dao.GetAll();
        }

        public Utilisateur GetByLogin(string login)
        {
            return Dao.FindByLogin(login);
        }

        public string? Insert(Utilisateur u)
        {
            return Dao.Insert(u);
        }

        public void Update(Utilisateur u)
        {
            Dao.Update(u);
        }

        public void RemoveByLogin(string login)
        {
            Dao.DeleteByLogin(login);
        }
    }
}
