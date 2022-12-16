namespace _07_DAO.Model
{
    public class Contact
    {
        public int Id { get; set; }

        public String Nom { get; set; } = "";
        public String Prenom { get; set; } = "";
        public String Email { get; set; } = "";
        public String Telephone { get; set; } = "";

        public Contact()
        {

        }

        public Contact(string nom, string prenom, string email, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"Nom : {Nom} - Prenom {Prenom} - Email {Email} - Telephone {Telephone}";
        }
    }
}
