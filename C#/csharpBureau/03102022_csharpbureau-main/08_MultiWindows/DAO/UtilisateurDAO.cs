using _08_MultiWindows.Model;
using Microsoft.VisualBasic.Logging;
using System.Data.SqlClient;

namespace _08_MultiWindows.DAO
{
    public class UtilisateurDAO : IUtilisateurDAO
    {
        public string ConnexionString { get; set; }

        public UtilisateurDAO(string connexionString)
        {
            ConnexionString = connexionString;
        }

        public List<Utilisateur> GetAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            string sql = "SELECT * FROM utilisateur";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cnx.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        /*SQL Server Data Type Mappings

                        bigint           - GetInt64  
                        binary           - GetBytes  
                        int              - GetInt32  
                        money            - GetDecimal  
                        rowversion       - GetBytes  
                        smallint         - GetInt16  
                        tinyint          - GetByte  
                        uniqueidentifier - GetGuid */

                        Utilisateur u = new()
                        {
                            Login = reader.GetString(1),
                            Password = reader.GetString(2),
                            Photo = reader.GetString(3),
                            Profile = (Profile)reader.GetByte(4)
                        };

                        utilisateurs.Add(u);
                    }
                }
            }

            return utilisateurs;
        }

        public Utilisateur FindByLogin(string login)
        {
            Utilisateur utilisateur = new Utilisateur();

            string sql = "SELECT * FROM utilisateur WHERE login=@login";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cnx.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        utilisateur.Login = reader.GetString(1);
                        utilisateur.Password = reader.GetString(2);
                        utilisateur.Photo = reader.GetString(3);
                        utilisateur.Profile = (Profile)reader.GetByte(4);
                    }
                }
            }

            return utilisateur;
        }

        public void Update(Utilisateur u)
        {
            string sql = "UPDATE utilisateur SET password=@password, photo=@photo, profile=@profile WHERE login=@login";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@photo", u.Photo);
                cmd.Parameters.AddWithValue("@profile", u.Profile);
                cmd.Parameters.AddWithValue("@login", u.Login);
                cnx.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public string? Insert(Utilisateur u)
        {
            string sql = "spInsertUtilisateur";

            SqlParameter outputLogin;

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@photo", u.Photo);
                cmd.Parameters.AddWithValue("@profile", u.Profile);
                cmd.Parameters.AddWithValue("@login", u.Login);

                outputLogin = new SqlParameter
                {
                    ParameterName = "@nextLogin",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 50,
                    Direction = System.Data.ParameterDirection.Output
                };

                cmd.Parameters.Add(outputLogin);

                cnx.Open();
                cmd.ExecuteNonQuery();
            }

            return outputLogin.Value.ToString();
        }

        public void DeleteByLogin(string login)
        {
            string sql = "DELETE FROM Utilisateur WHERE login = @login";

            using (SqlConnection cnx = new SqlConnection(ConnexionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
