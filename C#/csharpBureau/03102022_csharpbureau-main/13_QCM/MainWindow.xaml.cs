using _13_QCM.DAO;
using _13_QCM.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _13_QCM
{ 
    public partial class MainWindow : Window
    {
        private readonly TestQCM _quiz;

        private readonly QcmDAO _dao;

        private int currentIndex = 0;


        public MainWindow()
        {
            InitializeComponent();

            _dao = new QcmDAO();

            _quiz = new TestQCM()
            {
                Candidat = new Candidat(1, "riri", "ririr@gmail.com"),
                Qcm = _dao.Lister()
            };

            tbIntituleQcm.Text = _quiz.Qcm.Sujet;

            AfficherQuestion(currentIndex);
        }

        private void AfficherQuestion(int index)
        {
            var question = _quiz.Qcm.Questions[index];

            tbQuestion.Text = question.Enonce;

            stpReponses.Children.Clear();

            foreach (var reponse in question.Reponses)
            {
                if (question.ChoixMultiple)
                {
                    CheckBox checkBox = new()
                    {
                        Content = reponse
                    };
                    stpReponses.Children.Add(checkBox);
                }
                else
                {
                    RadioButton radio = new()
                    {
                        Content = reponse
                    };
                    stpReponses.Children.Add(radio);
                }
            }
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnNext.Content == "Fermer")
            {
                Application.Current.Shutdown();
            }


            UpdateScore();

            if (currentIndex<_quiz.Qcm.Questions.Count-1)
            {
                currentIndex++;
                AfficherQuestion(currentIndex);
            }
            else
            {
                AfficherResultat();
            }
        }

        private void AfficherResultat()
        {
            tbQuestion.Text = $"Votre score est de : {_quiz.Score}";

            mainGrid.Children.Remove(stpReponses);

            btnNext.Content = "Fermer";



        }

        private void UpdateScore()
        {
            var question = _quiz.Qcm.Questions[currentIndex];
            int nbReponses = question.Reponses.Count;

            int nbCorrect = 0;


            if (question.ChoixMultiple == true)
            {
                foreach (var box in stpReponses.Children.OfType<CheckBox>())
                {
                    if (box.Content is not QcmReponse reponse)
                    {
                        throw new Exception("Reponse absente");
                    }
                    if((box.IsChecked == true && reponse.Correcte == true ) || (box.IsChecked == false && reponse.Correcte == false)){
                        nbCorrect++;
                    }
                    {
                        nbCorrect--;
                    }
                }
                if (nbCorrect == nbReponses) 
                {
                    _quiz.Score++;
                }
                else
                {
                    _quiz.Score--;
                }
            }
            else
            {
                var checkedRadio = stpReponses.Children.OfType<RadioButton>().Where(currentRadioButton => currentRadioButton.IsChecked == true).FirstOrDefault();
                if (checkedRadio == null)
                {
                    _quiz.Score--;
                    return;
                }

                if(checkedRadio.Content is not QcmReponse reponse)
                {
                    throw new Exception("Réponse absente");
                }

                if (reponse.Correcte)
                {
                    _quiz.Score++;
                }
                else
                {
                    _quiz.Score--;
                }
                
            }
        }
    }
}
