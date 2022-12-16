using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _08_Calculatrice
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Key_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return; // En vrai lever une exception...

            string? key = btn.Content.ToString();

            if (String.IsNullOrEmpty(key)) return; // En vrai lever une exception...

            int currentPos = txt_Operation.SelectionStart;

            switch (key)
            {
                case "DEL":

                    if (currentPos > 0)
                    {
                        StringBuilder str = new StringBuilder(txt_Operation.Text);

                        str.Remove(currentPos -1 , 1);

                        txt_Operation.Text = str.ToString();
                        txt_Operation.SelectionStart = currentPos - 1;
                    }

                    break;

                case "C":
                    txt_Operation.Clear();
                    txt_Resultat.Text = "";
                    break;

                case "=":

                    try
                    {
                        txt_Resultat.Foreground = Brushes.Black;
                        txt_Resultat.Text = Calcul.Get(txt_Operation.Text);
                    }
                    catch (Exception)
                    {
                        txt_Resultat.Foreground = Brushes.Red;
                        txt_Resultat.Text = "Expression non valide";
                    }

                    break;
                default:
                    txt_Operation.Text = txt_Operation.Text.Insert(currentPos, key);
                    txt_Operation.SelectionStart = currentPos + 1;
                    break;
            }
        }
    }
}
