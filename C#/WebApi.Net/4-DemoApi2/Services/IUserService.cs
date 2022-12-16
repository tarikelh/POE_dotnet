using _4_DemoApi2.Dtos;
using _4_DemoApi2.Models;
using System.Collections.Generic;

namespace _4_DemoApi2.Services
{
    public interface IUserService
    {
        void Delete(int id);
        List<User> FindAll();
        User FindByEmail(string email);
        List<User> FindByNameOrEmail(string key);
        User GetById(int id);
        void Save(User u);
        void Update(User u);
        User CheckLogin(LoginDTO loginDto);
    }
}