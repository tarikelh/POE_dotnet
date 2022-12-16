using System.Threading;
using System.Windows;

namespace _11_Backgroundworker
{
    public partial class SingleThread : Window
    {
        public SingleThread()
        {
            InitializeComponent();
        }

        // Pas responsive...
        private void btnStartClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 50; i++)
            {
                Thread.Sleep(100);
                lblCount.Content = i.ToString();
            }
        }
    }
}
