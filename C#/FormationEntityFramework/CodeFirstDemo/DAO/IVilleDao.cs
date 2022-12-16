using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDemo.Model;

namespace CodeFirstDemo.DAO
{
    public interface IVilleDao
    {
        List<Ville> FindVilles();
        Ville FindVilleById(int id);


    }
}
