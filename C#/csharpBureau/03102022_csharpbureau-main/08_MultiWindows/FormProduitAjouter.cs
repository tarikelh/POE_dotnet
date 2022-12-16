using _08_MultiWindows.Model;
using _08_MultiWindows.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08_MultiWindows
{
    public partial class FormProduitAjouter : Form
    {
        public ProduitService Service { get; set; }
        public Produit Produit { get; set; }
        public FormProduitAjouter(ProduitService service, Produit produit)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Service = service;

            if (produit == null)
            {
                Produit = new Produit();
                txtId.Text = "0";
                btnAjouter.Text = "Ajouter";
            }
            else
            {
                Produit = produit;
                txtId.Text = produit.Id.ToString();
                txtDescription.Text = produit.Description;
                txtPrix.Text = produit.Prix.ToString();
                txtQuantite.Text = produit.Quantite.ToString();

                btnAjouter.Text = "Modifier";
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int id;
            string description = txtDescription.Text;
            double prix;
            int quantite;
            try
            {
                id = Convert.ToInt32(txtId.Text);
                prix = Convert.ToDouble(txtPrix.Text);
                quantite = Convert.ToInt32(txtQuantite.Text);

                Produit = new Produit(id, description, prix, quantite);

            }
            catch (Exception)
            {

                throw;
            }


            if (btnAjouter.Text == "Ajouter")
            {
                Service.Insert(Produit);
            }
            else /*if (btnAjouter.Text == "Modifier")*/
            {
                Service.Update(Produit);
            }

            if (this.Owner is FormProduits formParent)
            {
                formParent.dataGridProduits.DataSource = Service.GetAll();
                formParent.dataGridProduits.ClearSelection();
            }
            this.Close();
        }
    }
}
