using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstExo.DAO
{
    internal class BlogDaoImpl : IBlogDAO
    {
        private Model1Container _context;
        public BlogDaoImpl()
        {
            _context = new Model1Container();
        }

        public List<Blog> FindAll()
        {
            return _context.BlogSet.ToList();
        }
    }
}
