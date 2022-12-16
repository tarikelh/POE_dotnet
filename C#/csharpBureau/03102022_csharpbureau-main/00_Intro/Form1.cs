namespace _00_Intro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*this.*/StartPosition = FormStartPosition.CenterScreen; // Pour que la fen^tre s'ouvre au mileu de l'écran
            FormBorderStyle = FormBorderStyle.FixedSingle; // Pour empéher le redimensionnement de la fenêtre
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            // string message = "Hello " + txtName.Text;
            string message = $"Hello {txtFirstName.Text} {txtName.Text}";

            MessageBox.Show(message);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // txtName.Text = " World...";
        }
    }
}