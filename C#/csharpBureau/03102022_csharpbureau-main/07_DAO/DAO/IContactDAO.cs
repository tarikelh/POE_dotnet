using _07_DAO.Model;

namespace _07_DAO.DAO
{
    public interface IContactDAO
    {
        void AddContact(Contact c);

        List<Contact> GetAll();
    }
}
