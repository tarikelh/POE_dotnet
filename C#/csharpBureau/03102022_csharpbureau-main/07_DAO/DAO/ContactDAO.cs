using _07_DAO.Model;
using System.Data.SqlClient;

namespace _07_DAO.DAO
{
    public class ContactDAO : IContactDAO
    {
        public string ConnexionString { get; set; }

        public ContactDAO(string connexionString)
        {
            ConnexionString = connexionString;
        }

        public List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();

            string sql = "SELECT * FROM Contact";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cnx.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact c = new Contact();
                        c.Id = reader.GetInt32(0);
                        c.Nom = reader.GetString(1);
                        c.Prenom = reader.GetString(2);
                        c.Email = reader.GetString(3);
                        c.Telephone = reader.GetString(4);

                        contacts.Add(c);
                    }
                }
            }
            return contacts;
        }


        public void AddContact(Contact c)
        {
            SqlConnection cnx = new SqlConnection(ConnexionString);

            try
            {
                string sql = "INSERT INTO Contact(nom, prenom, email, telephone) VALUES(@nom, @prenom, @email, @telephone)";

                SqlCommand cmd = new SqlCommand(sql, cnx);

                cnx.Open();
                cmd.Parameters.AddWithValue("@nom", c.Nom);
                cmd.Parameters.AddWithValue("@prenom", c.Prenom);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@telephone", c.Telephone);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cnx.Close();
            }
        }
    }
}
