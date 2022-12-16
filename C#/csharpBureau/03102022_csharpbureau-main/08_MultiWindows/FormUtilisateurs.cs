using _08_MultiWindows.DAO;
using _08_MultiWindows.Model;
using _08_MultiWindows.Services;

namespace _08_MultiWindows
{
    public partial class FormUtilisateurs : Form
    {
        UtilisateurService _service;

        public FormUtilisateurs(string cstring)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            _service = new UtilisateurService(new UtilisateurDAO(cstring));

            foreach (var item in Utilisateur.Profiles)
            {
                cmbProfile.Items.Add(item);
            }
        }

        private void FormUtilisateurs_Load(object sender, EventArgs e)
        {
            // _service.Insert(new Utilisateur("riri@gmail.com", "password", Profile.ADMIN, ""));
            BindDatagrid();
        }

        private void BindDatagrid()
        {
            dataGridUtilisateur.DataSource = _service.GetAll();
            dataGridUtilisateur.Columns["password"].Visible = false;

            dataGridUtilisateur.Columns["Login"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridUtilisateur.Columns["Photo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridUtilisateur.Columns["Profile"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridUtilisateur.Columns["Login"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridUtilisateur.Columns["Photo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridUtilisateur.Columns["Profile"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridUtilisateur.Columns["Login"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridUtilisateur.Columns["Photo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridUtilisateur.Columns["Profile"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridUtilisateur.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridUtilisateur.ReadOnly = true;

            dataGridUtilisateur.ClearSelection();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string imageLocation = "";

            if (pictureAvatar.ImageLocation != null)
            {
                imageLocation = pictureAvatar.ImageLocation;
            }

            Utilisateur u = new()
            {
                Login = txtLogin.Text,
                Password = txtPassword.Text,
                Photo = imageLocation,
                Profile = (Profile)cmbProfile.SelectedIndex
            };

            if (btnAjouter.Text == "Ajouter")
            {
                if(_service.GetByLogin(u.Login) != null)
                {
                    MessageBox.Show("Login non disponible");
                    return;
                }

                try
                {
                    string? login = _service.Insert(u);

                    if (login != null)
                    {
                        MessageBox.Show($"Utilisateur {login} créé avec succès");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                _service.Update(u);
            }

            BindDatagrid();
        }

        private void pictureAvatar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureAvatar.Image = Image.FromFile(openFileDialog1.FileName);
                pictureAvatar.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void dataGridUtilisateur_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridUtilisateur.SelectedRows.Count != 1)
            {
                Clear();
            }
            else
            {
                string? login = dataGridUtilisateur.SelectedRows[0].Cells[0].Value.ToString();

                if (login != null)
                {
                    Utilisateur u = _service.GetByLogin(login);

                    txtLogin.Text = u.Login;
                    txtPassword.Text = u.Password;

                    try
                    {
                        pictureAvatar.ImageLocation = u.Photo;
                        if (u.Photo != "")
                        {
                            pictureAvatar.Image = Image.FromFile(u.Photo);

                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    cmbProfile.SelectedIndex = (int)u.Profile;

                }

                btnAjouter.Text = "Modifier";
                btnSupprimer.Enabled = true;
                txtLogin.Enabled = false;
            }
        }

        private void Clear()
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
            pictureAvatar.Image = null;
            pictureAvatar.ImageLocation = "";
            cmbProfile.SelectedIndex = -1;

            btnAjouter.Text = "Ajouter";
            btnSupprimer.Enabled = false;
            txtLogin.Enabled = true;
        }

        private void FormUtilisateurs_Click(object sender, EventArgs e)
        {
            dataGridUtilisateur.ClearSelection();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridUtilisateur.SelectedRows.Count != 1) return;

            string? login = dataGridUtilisateur.SelectedRows[0].Cells[0].Value.ToString();

            if (!String.IsNullOrEmpty(login))
            {
                _service.RemoveByLogin(login);
            }
            BindDatagrid();
            Clear();
        }
    }
}
