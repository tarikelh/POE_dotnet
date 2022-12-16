using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Concepts_Objet
{
    public interface IPersonnel
    {
        void AjouterEmploye(Employe e);
        void CalculerSalaire();
        double SalaireMoyen();
    }
}
