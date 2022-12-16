using System.Windows;

namespace _09_UserControls
{
    public partial class WithUserControl : Window
    {
        public WithUserControl()
        {
            InitializeComponent();
        }

        private void OnjoinBasicClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Membre basic", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnjoinProClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Membre pro", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
