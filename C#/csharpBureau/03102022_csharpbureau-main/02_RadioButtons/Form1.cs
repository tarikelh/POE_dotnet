namespace _02_RadioButtons
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioDepot.Checked = true;
            txtSolde.Enabled = false;

            if (txtSolde.Text.Length == 0) txtSolde.Text = "0";
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            // if (Double.TryParse(txtSolde.Text, out double solde) == false)
            if (!Double.TryParse(txtSolde.Text, out double solde))
            {
                MessageBox.Show($"Solde {txtSolde.Text} invalide", " Solde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Double.TryParse(txtMontant.Text.Replace('.', ','), out double montant))
            {
                MessageBox.Show($"Montant {txtMontant.Text} invalide", " Montant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioDepot.Checked)
            {
                solde += montant;
                txtSolde.Text = solde.ToString();
            }
            else if (radioRetrait.Checked)
            {
                if (solde < montant)
                {
                    MessageBox.Show($"Solde insuffisant : {solde} < {montant} ", "Insuffisant", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                solde -= montant;
                txtSolde.Text = solde.ToString();
            }
        }
    }
}