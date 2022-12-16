using _4_DemoApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DemoApi2.Repositories
{
    public interface IUserRepository
    {
        User FindByEmail(string email);
        List<User> FindAll();
        void Save(User u);
        void Update(User u);
        void Delete(int id);
        User GetById(int id);
        List<User> FindByNameOrEmail(string key);
    }
}
