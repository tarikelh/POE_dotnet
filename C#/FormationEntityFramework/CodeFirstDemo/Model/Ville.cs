﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Model
{
    public class Ville
    {
        public int Id { get; set; }
        public string NomVille { get; set; }
        public virtual ICollection<Client> Clients { get; set; }



    }
}
