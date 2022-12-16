using System;
using System.Data.Entity;
using System.Linq;

namespace _5_ApiProductWithImage.Models
{
    public class MyContext : DbContext
    {
       
        public MyContext()
            : base("name=MyContext")
        {
        }

        public DbSet<Produit> Produits { get; set; }
    }

  
}