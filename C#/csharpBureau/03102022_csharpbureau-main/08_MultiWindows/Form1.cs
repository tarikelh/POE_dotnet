using System.Configuration;

namespace _08_MultiWindows
{
    public partial class Form1 : Form
    {
        string cstring = ConfigurationManager.ConnectionStrings["chConnexion"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduits formprod = new FormProduits(cstring);

            // formprod.Show();
            formprod.ShowDialog(); // Ouverture en mode modal
        }

        private void utilisateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtilisateurs formUtilisateur = new FormUtilisateurs(cstring);

            formUtilisateur.ShowDialog(); // Ouverture en mode modal
        }
    }
}