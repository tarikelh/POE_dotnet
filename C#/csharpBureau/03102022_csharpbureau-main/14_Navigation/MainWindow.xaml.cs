using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _14_Navigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            framePage.Content = new Page1();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New Menu cliqué");
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open Menu cliqué");
        }

        private void NotModal_Click(object sender, RoutedEventArgs e)
        {
            var notModal = new Child();
            notModal.Owner = this;

            notModal.Show();
        }

        private void Modal_Click(object sender, RoutedEventArgs e)
        {
            var modal = new Child();
            modal.Owner = this;

            modal.ShowDialog();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            framePage.Content = new Page2();
        }

        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            framePage.Content = new Page1();
        }
    }
}
