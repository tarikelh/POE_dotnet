using _08_MultiWindows.DAO;
using _08_MultiWindows.Services;

namespace _08_MultiWindows
{
    public partial class FormProduits : Form
    {
        ProduitService _service;

        public FormProduits(string cstring)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _service = new ProduitService(new ProduitDAO(cstring));
            //_service.Insert(new Model.Produit("Gomme", 2.5, 10));
        }

        private void FormProduits_Load(object sender, EventArgs e)
        {
            BindDatagrid();
        }

        private void BindDatagrid()
        {
            dataGridProduits.DataSource = _service.GetAll();
            dataGridProduits.Columns["id"].Visible = false;

            dataGridProduits.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridProduits.Columns["Prix"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridProduits.Columns["Quantite"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridProduits.Columns["Description"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridProduits.Columns["Prix"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridProduits.Columns["Quantite"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridProduits.Columns["Description"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridProduits.Columns["Prix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridProduits.Columns["Quantite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridProduits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProduits.ReadOnly = true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (btnAjouter.Text == "Ajouter")
            {
                FormProduitAjouter fpa = new FormProduitAjouter(_service, null);
               // fpa.ShowDialog();
                fpa.ShowDialog(this); // "this" permet de référencer "FormProduits" en tant que parente de "FormProduitAjouter"
            }
            else if(dataGridProduits.SelectedRows.Count == 1) // si j'ai une ligne sélectionnée dans la datagrid
            {
                int id = (int) dataGridProduits.SelectedRows[0].Cells[0].Value;

                FormProduitAjouter fpa = new FormProduitAjouter(_service, _service.GetById(id));

                fpa.ShowDialog(this);
            }
        }

        private void dataGridProduits_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridProduits.SelectedRows.Count == 1)
            {
                btnAjouter.Text = "Modifier";
                btnSupprimer.Enabled = true;
            }
            else
            {
                btnAjouter.Text = "Ajouter";
                btnSupprimer.Enabled = false;
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridProduits.SelectedRows.Count != 1) return;

            try
            {
                int id = (int)dataGridProduits.CurrentRow.Cells["id"].Value;
                _service.DeleteById(id);
                dataGridProduits.DataSource = _service.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            if (btnRechercher.Text == "Rechercher")
            {
                dataGridProduits.DataSource = _service.FindByKey(txtRechercher.Text);
                btnRechercher.Text = "Effacer";
            }
            else
            {
                dataGridProduits.DataSource = _service.GetAll();
                dataGridProduits.ClearSelection();
                btnRechercher.Text = "Rechercher";
                txtRechercher.Text = "";
            }
        }
    }
}
