using System;
using System.Data.Entity;
using System.Linq;

namespace _1_DemoApi.Models
{
    public class MyContext : DbContext
    {
      
        public MyContext()
            : base("name=MyContext")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }

    
}