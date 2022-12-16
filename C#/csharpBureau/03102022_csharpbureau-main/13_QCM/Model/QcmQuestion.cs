using System.Collections.Generic;

namespace _13_QCM.Model
{
    public class QcmQuestion
    {
        public int Id { get; set; }

        public string Enonce { get; set; } = string.Empty;

        public List<QcmReponse> Reponses { get; set; } = new();

        public bool ChoixMultiple { get; set; }
    }
}
