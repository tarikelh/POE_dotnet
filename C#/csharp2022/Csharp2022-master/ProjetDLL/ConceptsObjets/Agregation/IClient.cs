using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Agregation
{
    public interface IClient
    {
        //Interface: pseuso classe abstraite qui ne contient que des méthodes abstraites

        void Insert(Client c);
        void Delete(Client c);
        void Update(Client c);
        List<Client> GetAll();

    }
}
