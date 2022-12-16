namespace _01_ListBoxes
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
           /* listBox1.Items.Add("Riri");
            listBox1.Items.Add("Fifi");
            listBox1.Items.Add("Loulou");*/
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
                listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1]; // Sélectionne le dernier élément de la liste
            }
        }

        private void btnRight_click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox2.SelectedItem = listBox2.Items[listBox2.Items.Count - 1]; // Sélectionne le dernier élément de la liste
            }
        }
    }
}