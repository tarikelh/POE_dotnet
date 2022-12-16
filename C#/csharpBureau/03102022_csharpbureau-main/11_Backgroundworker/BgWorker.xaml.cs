using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace _11_Backgroundworker
{

    /*
     * 
     * Quand on veut réaliser une opération qui prend du temps 
     * 
     * - boucle infinie
     * - attend une connexion
     * - cherche dans le systeme de fichier
     * -...
     * 
     * l4UI va rester non responsive pendant toute la durée de l'oparation
     * 
     * Pour résoudre ce pb, il faut lancer l'opération qui prend du temps dans un thraed séparé.
     * Plusieurs solutions s'offrent à nous en .NET parmis lesquelles la classe "Backgroundworker"
     * 
     * Cette classe est disponible dans le namespace "System.ComponentModel"
     * 
     * Elle peut gérer les évènements suivants : 
     * - Dowork : invoqué dans un thread sapéré pour exécuter l tâche qui prend du temps
     * - ProgressChanged : invoqué lorsque la méthode "ReportProgress" est appelée
     * - RunWorkerCompleted : déclenché lorsque Dowork se termine
     *     
     */
    public partial class BgWorker : Window
    {
        BackgroundWorker bgWorker = new BackgroundWorker();

        readonly int counterMax = 50;

        public BgWorker()
        {
            InitializeComponent();

            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;

            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.WorkerReportsProgress = true;
        }

        private void BgWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblStatus.Content = "Cancelled!";
            }
            else
            {
                lblStatus.Content = "Completed!";
            }

            btnStart.Content = "Start";
        }

        private void BgWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            lblCount.Content = e.ProgressPercentage;
            progressBar.Value = 100 / counterMax * e.ProgressPercentage;
        }

        private void BgWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= counterMax; i++)
            {
                bgWorker.ReportProgress(i);

                Thread.Sleep(100);

                if (bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void btnStartClick(object? sender, RoutedEventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
                btnStart.Content = "Cancel";
                lblStatus.Content = "Running...";
            }
            else
            {
                bgWorker.CancelAsync();
                btnStart.Content = "Start";
                lblStatus.Content = "Cancelled...";
            }
        }
    }
}
