using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDemo.Model;

namespace CodeFirstDemo.DAO
{
    public class VilleDaoImpl : IVilleDao
    {
        private MyContext _context;

        public VilleDaoImpl()
        {
            _context = new MyContext();
        }

        public Ville FindVilleById(int id)
        {
            Ville ville = _context.Villes.Find(id);
            if(ville == null)
            {
                Console.WriteLine("Cette ville n'existe pas");
            }
            return ville;
        }

        public List<Ville> FindVilles()
        {
            return _context.Villes.ToList();
        }
    }
}
