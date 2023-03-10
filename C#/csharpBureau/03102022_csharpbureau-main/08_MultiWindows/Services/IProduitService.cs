using _08_MultiWindows.Model;

namespace _08_MultiWindows.Services
{
    public interface IProduitService
    {
        void Insert(Produit p);

        List<Produit> GetAll();

        Produit GetById(int id);

        void Update(Produit p);

        void DeleteById(int id);

        List<Produit> FindByKey(string key);
    }
}
