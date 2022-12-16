using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstExo.DAO
{
    internal interface IBlogDAO
    {
        List<Blog> FindAll();
    }
}
