using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using CodeFirstExo.Model;

namespace CodeFirstExo.DAO
{
    public class ContactDaoImpl : IContactDao
    {
        private MyContext _context;

        public ContactDaoImpl()
        {
            _context = new MyContext();
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.Entry(contact).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            _context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public Contact FindContactById(int id)
        {
            Contact contact = _context.Contacts.Find(id);
            if(contact == null)
            {
                Console.WriteLine("Ce contact n'existe pas");
            }
            return contact;
        }

        public List<Contact> FindContacts()
        {
            return _context.Contacts.ToList();
        }
    }
}
