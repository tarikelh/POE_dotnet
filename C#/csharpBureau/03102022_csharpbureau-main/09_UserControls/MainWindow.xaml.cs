using System.Windows;

namespace _09_UserControls
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnJoinBasicClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Membre basic", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnJoinProClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Membre pro", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
