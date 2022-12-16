using _08_MultiWindows.Model;
using System.Data.SqlClient;

namespace _08_MultiWindows.DAO
{
    public class ProduitDAO : IProduitDAO
    {
        public string ConnexionString { get; set; }

        public ProduitDAO(string connexionString)
        {
            ConnexionString = connexionString;
        }

        public void DeleteById(int id)
        {
            string sql = "DELETE FROM produit WHERE id=@id";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);

                cmd.Parameters.AddWithValue("id", id);
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public List<Produit> GetAll()
        {
            List<Produit> produits = new List<Produit>();

            string sql = "SELECT * FROM produit";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cnx.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        /*Produit p = new Produit();
                        p.Id = reader.GetInt32(0);
                        p.Description = reader.GetString(1);
                        p.Prix = reader.GetDouble(2);
                        p.Quantite = reader.GetInt32(3);*/

                        Produit p = new()
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            Prix = reader.GetDouble(2),
                            Quantite = reader.GetInt32(3)
                        };

                        produits.Add(p);
                    }
                }
            }

            return produits;
        }

        public Produit GetById(int id)
        {
            Produit produit = new Produit();

            string sql = "SELECT * FROM produit WHERE id =@filtre";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);

                cmd.Parameters.AddWithValue("@filtre", id);
                cnx.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // si la requête a trouvé un résultat
                    {
                        produit.Id = reader.GetInt32(0);
                        produit.Description = reader.GetString(1);
                        produit.Prix = reader.GetDouble(2);
                        produit.Quantite = reader.GetInt32(3);
                    }
                }
            }

            return produit;
        }

        public void Insert(Produit p)
        {
            string sql = "INSERT INTO produit(description, prix, quantite) VALUES (@description, @prix, @quantite)";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@prix", p.Prix);
                cmd.Parameters.AddWithValue("@quantite", p.Quantite);

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Produit p)
        {
            string sql = "UPDATE produit SET description=@description, prix=@prix, quantite=@quantite WHERE id=@id";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@prix", p.Prix);
                cmd.Parameters.AddWithValue("@quantite", p.Quantite);
                cmd.Parameters.AddWithValue("@id", p.Id);

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Produit> FindByKey(string key)
        {
            List<Produit> produits = new List<Produit>();

            string sql = "SELECT * FROM produit WHERE description LIKE @description";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@description", "%" + key + "%");
                cnx.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produit p = new()
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            Prix = reader.GetDouble(2),
                            Quantite = reader.GetInt32(3)
                        };

                        produits.Add(p);
                    }
                }
            }

            return produits;
        }
    }
}
