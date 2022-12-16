using System.Runtime.Serialization;

namespace _05_Serialization
{
    [Serializable]

    [DataContract]
    public class CompteBancaire
    {
        [DataMember]
        public string Numero { get; set; } = "";

        [DataMember]
        public double Solde { get; set; }

        public CompteBancaire()
        {

        }
        public CompteBancaire(string numero, double solde)
        {
            Numero = numero;
            Solde = solde;
        }

        public override string ToString()
        {
            // return "Numéro : " + Numero + " - Solde : " + Solde;
            return $"Numéro : {Numero} - Solde : {Solde}";
        }
    }
}
