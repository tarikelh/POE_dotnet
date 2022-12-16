using System.Collections.Generic;
using System.Windows.Documents;

namespace _13_QCM.Model
{
    public class Qcm
    {
        public int Id { get; set; }

        public string Sujet { get; set; } = string.Empty;

        public List<QcmQuestion> Questions { get; set; } = new();
    }
}
