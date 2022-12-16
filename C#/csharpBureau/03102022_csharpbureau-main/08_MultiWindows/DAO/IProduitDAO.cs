using _08_MultiWindows.Model;

namespace _08_MultiWindows.DAO
{
    public interface IProduitDAO
    {
        // C.R.U.D.
        // C : Create
        // R : Read
        // U : Update
        // D : Delete
        
        void Insert(Produit p);

        List<Produit> GetAll();

        Produit GetById(int id);

        void Update(Produit p);

        void DeleteById(int id);

        List<Produit> FindByKey(string key);
    }
}
