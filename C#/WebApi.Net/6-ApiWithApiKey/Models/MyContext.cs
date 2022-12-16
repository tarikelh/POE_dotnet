using System;
using System.Data.Entity;
using System.Linq;

namespace _6_ApiWithApiKey.Models
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employe> Employes { get; set; }

    }

   
}