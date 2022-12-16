using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_ClientWinform
{
    public partial class Form1 : Form
    {
        private ApiContact api = new ApiContact();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            await RemplirAsync();
        }

        public async Task RemplirAsync()
        {
            gridContact.DataSource = await api.LoadContactsAsync();
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            Contact c = new Contact { Nom = txtNom.Text, Prenom = txtPrenom.Text };
            if (btnAjouter.Text.Equals("Ajouter"))
            {
                var res = await api.AddContactAsync(c);
                MessageBox.Show("Contact inséré. Uri = " + res.AbsoluteUri);
            }
            else
            {
                c.Id = Convert.ToInt32 (gridContact.CurrentRow.Cells["id"].Value.ToString());
                var res = await api.UpdateContactAsync(c);
                MessageBox.Show("Contact mis à jours? "+res.ToString());
            }
            
            await RemplirAsync();

            txtNom.Text = txtPrenom.Text = "";
            btnAjouter.Text = "Ajouter";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridContact.CurrentRow.Cells["id"].Value.ToString());

            var res = await api.DeleteContactAsync(id);
            MessageBox.Show(res.ToString());
            await RemplirAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNom.Text = gridContact.CurrentRow.Cells["nom"].Value.ToString();
            txtPrenom.Text = gridContact.CurrentRow.Cells["prenom"].Value.ToString();
            btnAjouter.Text = "Modifier";
        }
    }
}
