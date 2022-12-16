using _07_DAO.DAO;
using _07_DAO.Model;
using System.Configuration;

namespace _07_DAO
{
    public partial class Form1 : Form
    {
        IContactDAO _dao;

        public Form1()
        {
            InitializeComponent();

            /*
             * ATTENTION : il faut ajouter le App.Config manuellement
             * - Ajouter => composant => fichier XML => nommé App.Config
             * - Renseigner la connexionstring
             * 
             * ATTENTION : ne pas oublier de commencer par créer la base de données avec la table Contact
             */

            StartPosition = FormStartPosition.CenterScreen;

            _dao = new ContactDAO(ConfigurationManager.ConnectionStrings["chConnexion"].ConnectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindDatagrid();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            _dao.AddContact(new Contact(txtNom.Text, txtPrenom.Text, txtEmail.Text, txtTel.Text));
            BindDatagrid();
        }

        private void BindDatagrid()
        {
            dataGridContact.DataSource = _dao.GetAll();
            dataGridContact.Columns["id"].Visible = false;
        }
    }
}