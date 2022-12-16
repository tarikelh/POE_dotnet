using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstExo.Model;

namespace CodeFirstExo.DAO
{
    public interface IContactDao
    {
        List<Contact> FindContacts();
        Contact FindContactById(int id);

        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
    }
}
