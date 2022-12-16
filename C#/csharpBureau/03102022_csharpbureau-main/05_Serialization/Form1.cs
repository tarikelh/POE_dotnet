namespace _05_Serialization
{
    public partial class Form1 : Form
    {
        List<CompteBancaire> comptes;
        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            comptes = new List<CompteBancaire>();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                /*CompteBancaire cb = new CompteBancaire
               {
                   Numero = txtNumero.Text,
                   Solde = Convert.ToDouble(txtSolde.Text)
               };*/

                CompteBancaire cb = new CompteBancaire(txtNumero.Text, Convert.ToDouble(txtSolde.Text));

                if (btnAjouter.Text == "Ajouter")
                {
                    lstAccounts.Items.Add(cb.ToString());
                    comptes.Add(cb);
                }
                else
                {
                    comptes[lstAccounts.SelectedIndex] = cb;
                    lstAccounts.Items[lstAccounts.SelectedIndex] = cb.ToString();
                    btnAjouter.Text = "Ajouter";
                }

                Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Paramètres invalides", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtNumero.Text = "";
            txtSolde.Text = "";

            lstAccounts.SelectedItem = null;
            btnAjouter.Text = "Ajouter";
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSupprimer.Visible = false;
        }

        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAccounts.SelectedItem != null)
            {
                btnSupprimer.Visible = true;

                btnAjouter.Text = "Modifier";

                CompteBancaire currentCompte = comptes[lstAccounts.SelectedIndex];

                txtNumero.Text = currentCompte.Numero.ToString();
                txtSolde.Text = currentCompte.Solde.ToString();
            }
            else
            {
                btnSupprimer.Visible = false;
                btnAjouter.Text = "Ajouter";

                Clear();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (lstAccounts.SelectedItem != null)
            {
                comptes.RemoveAt(lstAccounts.SelectedIndex);
                lstAccounts.Items.Remove(lstAccounts.SelectedItem);
            }
        }

        private void btnSaveBin_Click(object sender, EventArgs e)
        {
            /*if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;

                Serialization.ExportBin(path, comptes);
            }*/

            Save(".bin");
        }

        private void btnRestBin_Click(object sender, EventArgs e)
        {
            /*if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                comptes = Serialization.ImportBin(path);

                lstAccounts.Items.Clear();

                foreach (var item in comptes)
                {
                    lstAccounts.Items.Add(item);
                }
            }*/
            Restaure(".bin");
        }

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            /*if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;

                Serialization.ExportXML(path, comptes);
            }*/
            Save(".xml");
        }

        private void btnRestXML_Click(object sender, EventArgs e)
        {
            /*if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                comptes = Serialization.ImportXML(path);

                lstAccounts.Items.Clear();

                foreach (var item in comptes)
                {
                    lstAccounts.Items.Add(item);
                }
            }*/
            Restaure(".xml");
        }

        private void btnSaveJSON_Click(object sender, EventArgs e)
        {
            Save(".json");
        }

        private void btnRestJSON_Click(object sender, EventArgs e)
        {
            Restaure(".json");
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            Save(".csv");
        }

        private void btnRestCSV_Click(object sender, EventArgs e)
        {
            Restaure(".csv");
        }

        // -------------------------------------------

        private void Save(string fileType)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;

                switch (fileType)
                {
                    case ".bin":
                        Serialization.ExportBin(path, comptes);
                        break;

                    case ".xml":
                        Serialization.ExportXML(path, comptes);
                        break;

                    case ".json":
                        Serialization.ExportJSON(path, comptes);
                        break;

                    case ".csv":
                        Serialization.ExportCSV(path, comptes);
                        break;

                    default:
                        break;
                }
            }
        }
        private void Restaure(string fileType)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\Admin stagiaire.DESKTOP-8967908\Desktop\Exports";
            openFileDialog1.Filter = $"Files|*{fileType};";
            openFileDialog1.Title = "Restaure";
            openFileDialog1.FileName = "exports" + fileType;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                switch (fileType)
                {
                    case ".bin":
                        comptes = Serialization.ImportBin(path);
                        break;

                    case ".xml":
                        comptes = Serialization.ImportXML(path);
                        break;

                    case ".json":
                        comptes = Serialization.ImportJSON(path);
                        break;

                    case ".csv":
                        comptes = Serialization.ImportCSV(path);
                        break;

                    default:
                        break;
                }

                lstAccounts.Items.Clear();

                foreach (var item in comptes)
                {
                    lstAccounts.Items.Add(item);
                }
            }
        }
    }
}