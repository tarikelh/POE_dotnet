using System;

namespace _13_QCM.Model
{
    public class QcmReponse
    {
        public int Id { get; set; } = 0;
        public string Texte { get; set; } = String.Empty;

        public bool Correcte { get; set; } = false;

        public QcmReponse()
        {

        }

        public QcmReponse(int id, string texte, bool correcte)
        {
            Id = id;
            Texte = texte;
            Correcte = correcte;
        }

        public override string ToString()
        {
            return Texte;
        }
    }
}
