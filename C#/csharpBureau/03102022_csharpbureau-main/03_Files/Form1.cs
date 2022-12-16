namespace _03_Files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnEcrire_Click(object sender, EventArgs e)
        {
            //if ((saveFileDialog1.ShowDialog() == DialogResult.OK) == false)
            if (!(saveFileDialog1.ShowDialog() == DialogResult.OK))
            {
                MessageBox.Show("Fichier introuvable");
                return;
            }

            try
            {
                Files.Write(saveFileDialog1.FileName, txtEcriture.Text, false);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLire_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLecture.Text = Files.Read(openFileDialog1.FileName);
            }
        }
    }
}