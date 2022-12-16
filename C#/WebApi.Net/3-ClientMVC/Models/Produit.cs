using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_ClientMVC.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public string Image { get; set; }
    }
}