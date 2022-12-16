using _13_QCM.Model;

namespace _13_QCM.DAO
{
    public class QcmDAO
    {
        private static Qcm qcm = GenererExemple();

        public QcmDAO()
        {

        }

        private static Qcm GenererExemple()
        {
            qcm = new Qcm();

            QcmQuestion question1 = new()
            {
                Id = 1,
                Enonce = "Enonce de la question 1",
                ChoixMultiple = false
            };

            question1.Reponses.Add(new QcmReponse(1, "Réponse 1 Question 1", false));
            question1.Reponses.Add(new QcmReponse(2, "Réponse 2 Question 1", true));

            QcmQuestion question2 = new()
            {
                Id = 2,
                Enonce = "Enonce de la question 2",
                ChoixMultiple = false
            };

            question2.Reponses.Add(new QcmReponse(1, "Réponse 1 Question 2", false));
            question2.Reponses.Add(new QcmReponse(2, "Réponse 2 Question 2", true));
            question2.Reponses.Add(new QcmReponse(2, "Réponse 3 Question 2", true));

            qcm.Questions.Add(question1);
            qcm.Questions.Add(question2);
            qcm.Sujet = "Enonce du QCM";

            return qcm;
        }

        public Qcm Lister()
        {
            return qcm;
        }
    }
}
