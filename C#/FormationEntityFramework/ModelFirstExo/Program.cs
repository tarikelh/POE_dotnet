using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelFirstExo.DAO;

namespace ModelFirstExo
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBlogDAO dao = new BlogDaoImpl();
            ICollection<Blog> blogs = dao.FindAll();

            foreach (var blog in blogs)
            {
                Console.WriteLine(blog.Name);
            }

            Console.ReadLine();
        }
    }
}
