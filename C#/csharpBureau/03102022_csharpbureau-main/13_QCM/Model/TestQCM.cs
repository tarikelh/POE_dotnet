using System;

namespace _13_QCM.Model
{
    public class TestQCM
    {
        public int Id { get; set; }

        public Candidat Candidat { get; set; } = new();

        public Qcm Qcm { get; set; } = new();

        public DateTime DatePassage { get; set; } = DateTime.Now;

        public int Score { get; set; } = 0;

        public TestQCM()
        {

        }

        public TestQCM(int id, Candidat candidat, Qcm qcm, DateTime datePassage, int score)
        {
            Id = id;
            Candidat = candidat;
            Qcm = qcm;
            DatePassage = datePassage;
            Score = score;
        }
    }
}
