using System.Threading;
using System.Windows;

namespace _10_Dispatcher
{
    public partial class MainWindow : Window
    {
        Thread? BgThread = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            //ExecuteCounter(); // Pas responsive

            BgThread = new Thread( () => { ExecuteCounter(); });
            BgThread.Start();
        }

        private void ExecuteCounter()
        {
            try
            {
                Dispatcher.Invoke(() => { myButton.Content = "Counting...";  myButton.IsEnabled = false; });

                for (int i = 0; i <= 50; i++)
                {
                    // txtMessage.Text = i.ToString(); // Exception : 'Le thread appelant ne peut pas accéder à cet objet parce qu'un autre thread en est propriétaire.'

                    Dispatcher.Invoke(() => { txtMessage.Text = i.ToString(); }); // Dispatcher permet d'accéder aux propriétés du thread principal

                    Thread.Sleep(100);
                }

                Dispatcher.Invoke(() => { myButton.Content = "START"; myButton.IsEnabled = true; });

            }
            catch (System.Exception)
            {

                // throw;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(BgThread is not null) BgThread.Interrupt();
        }
    }
}
