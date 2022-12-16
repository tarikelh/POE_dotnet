using _08_MultiWindows.DAO;
using _08_MultiWindows.Model;

namespace _08_MultiWindows.Services
{
    public class ProduitService : IProduitService
    {
        public IProduitDAO dao { get; set; }

        public ProduitService(IProduitDAO dao)
        {
            this.dao = dao;
        }

        public void DeleteById(int id)
        {
            dao.DeleteById(id);
        }
       
        public List<Produit> GetAll()
        {
            return dao.GetAll();
        }

        public Produit GetById(int id)
        {
            return dao.GetById(id);
        }

        public void Insert(Produit p)
        {
            dao.Insert(p);
        }

        public void Update(Produit p)
        {
            dao.Update(p);
        }

        public List<Produit> FindByKey(string key)
        {
            return dao.FindByKey(key);
        }
    }
}
