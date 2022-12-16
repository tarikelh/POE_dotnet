using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstExo.DAO;
using CodeFirstExo.Model;

namespace CodeFirstExo
{
    public class Program
    {
        static void Main(string[] args)
        {

            IContactDao dao = new ContactDaoImpl();
            Contact c2 = new Contact("MESSI", "Lionel");
            //dao.AddContact(c2);
            Contact newcontact = dao.FindContactById(7);
            newcontact.Nom = "FERNAND";
            dao.UpdateContact(newcontact);
            List<Contact> contacts = dao.FindContacts();

            

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Nom);
            }

            Console.ReadLine();

        }

    }
}
