using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace _12_Async
{
    public partial class MainWindow : Window
    {
        private List<string> Sites
        {
            get
            {
                List<string> liste = new List<string>();

                liste.Add("https://www.cnn.com");
                liste.Add("https://www.google.com");
                liste.Add("https://www.codeproject.com");
                liste.Add("https://www.dawan.fr");
                liste.Add("https://www.jehann.fr/");
                liste.Add("https://fr.wikipedia.org/wiki/Microsoft_.NET");
                liste.Add("https://www.twitter.com");
                liste.Add("https://www.facebook.com");
                liste.Add("https://www.amazon.com");

                return liste;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExectuteSync_Click(object sender, RoutedEventArgs e)
        {
            var chrono = Stopwatch.StartNew(); // lancer le chrono

            //Téléchargement
            DownloadSync();

            chrono.Stop();

            Results.Content += $"Temps d'exécution total : {chrono.ElapsedMilliseconds}";
        }

        private void DownloadSync()
        {
            Results.Content = String.Empty; // On vide la liste des résultats entre chaque lancement

            foreach (var site in Sites)
            {
                WebSite downloaded = WebSite.Download(site);

                Results.Content += downloaded.ToString();
            }
        }

        private async void ExectuteASync_Click(object sender, RoutedEventArgs e)
        {
            var chrono = Stopwatch.StartNew(); // lancer le chrono

            await DownloadASync();

            chrono.Stop();

            Results.Content += $"Temps d'exécution total : {chrono.ElapsedMilliseconds}";
        }

        private async Task DownloadASync()
        {
            Results.Content = String.Empty;

            foreach (var site in Sites)
            {
                // WebSite downloaded = await Task.Run( () =>  WebSite.Download(site)); // On part du principe qu'on peut pas rendre Download asynchrone directement

                WebSite downloaded = await WebSite.DownloadAsync(site);  // Mais en vrai on peut...

                Results.Content += downloaded.ToString();
            }
        }

        private async void ExectuteParallelASync_Click(object sender, RoutedEventArgs e)
        {
            var chrono = Stopwatch.StartNew(); // lancer le chrono

            await DownloadParallelASync();

            chrono.Stop();

            Results.Content += $"Temps d'exécution total : {chrono.ElapsedMilliseconds}";
        }

        private async Task DownloadParallelASync()
        {
            Results.Content = String.Empty;

            List<Task<WebSite>> taches = new();

            foreach (var site in Sites)
            {
                taches.Add(WebSite.DownloadAsync(site));
            }

            WebSite[] results = await Task.WhenAll(taches);

            foreach (var site in results)
            {
                Results.Content += site.ToString();
            }
        }
    }
}
