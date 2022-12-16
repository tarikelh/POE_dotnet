using _4_DemoApi2.Dtos;
using _4_DemoApi2.Models;
using _4_DemoApi2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4_DemoApi2.Services
{
    public class UserService : IUserService
    {
        private IUserRepository repo;

        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }

        public User CheckLogin(LoginDTO loginDto)
        {
            User userDB = repo.FindByEmail(loginDto.Email);
            if (userDB != null && userDB.Password.Equals(loginDto.Password))
            {
                return userDB;
            }

            return null;
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<User> FindAll()
        {
            return repo.FindAll(); //AsNotrucking renvoie les données sans les maintenir dans le cache du context
        }

        public User FindByEmail(string email)
        {
            return repo.FindByEmail(email);
        }

        public List<User> FindByNameOrEmail(string key)
        {
            return repo.FindByNameOrEmail(key);
        }

        public User GetById(int id)
        {
            return repo.GetById(id);
        }

        public void Save(User u)
        {
            repo.Save(u);
        }

        public void Update(User u)
        {
            repo.Update(u);
        }
    }
}