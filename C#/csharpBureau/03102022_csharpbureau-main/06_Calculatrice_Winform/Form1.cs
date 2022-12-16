using System.Text;

namespace _06_Calculatrice_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnSimpleKey_Click(object sender, EventArgs e)
        {
            if (sender is not Button b) return;

            int currentPos = txtOperation.SelectionStart;
            txtOperation.Text = txtOperation.Text.Insert(currentPos, b.Text.ToString());
            txtOperation.SelectionStart = currentPos + 1;
            txtOperation.Focus();
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if (btnOnOff.Text == "ON")
            {
                btnOnOff.Text = "OFF";
            }
            else
            {
                btnOnOff.Text = "ON";
            }
            EnableDisablePanel();
        }

        private void EnableDisablePanel()
        {
            foreach (Control item in groupBox.Controls)
            {
                if (item.Name != "btnOnOff")
                {
                    if (item.Enabled == true) item.Enabled = false;
                    else
                    {
                        item.Enabled = true;
                        txtOperation.Focus();
                    }
                }
            }

            btnEffacer_Click(null, EventArgs.Empty);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int currentPos = txtOperation.SelectionStart;

            if (currentPos > 0)
            {
                StringBuilder str = new StringBuilder(txtOperation.Text);

                str.Remove(currentPos - 1, 1);

                txtOperation.Text = str.ToString();
                txtOperation.SelectionStart = currentPos - 1;
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            Calcul c = new Calcul(txtOperation.Text);

            txtResultat.Text = c.GetResult();
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            txtOperation.Clear();
            txtResultat.Clear();
        }
    }
}