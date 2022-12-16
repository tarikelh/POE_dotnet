using _4_DemoApi2.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace _4_DemoApi2.Repositories
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }

    
}