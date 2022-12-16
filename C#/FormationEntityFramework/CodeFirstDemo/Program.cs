using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDemo.DAO;
using CodeFirstDemo.Model;

namespace CodeFirstDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            IVilleDao dao = new VilleDaoImpl();

            List<Ville> villes = dao.FindVilles();

            foreach (var ville in villes)
            {
                Console.WriteLine(ville.NomVille);
            }

            Console.ReadLine();
        }
    }
}
