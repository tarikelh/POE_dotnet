using System;

namespace _13_QCM.Model
{
    public class Candidat
    {
        public int Id { get; set; }
        public string Nom { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        public Candidat()
        {

        }

        public Candidat(int id, string nom, string email)
        {
            Id = id;
            Nom = nom;
            Email = email;
        }
    }
}
