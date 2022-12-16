using _4_DemoApi2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _4_DemoApi2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MyContext context = new MyContext();
        public void Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("User introuvable");
            }
        }

        public List<User> FindAll()
        {
            return context.Users.AsNoTracking().ToList(); //AsNotrucking renvoie les données sans les maintenir dans le cache du context
        }

        public User FindByEmail(string email)
        {
            return context.Users.Where(x => x.Email.ToLower() == email.ToLower()).AsNoTracking().SingleOrDefault();
        }

        public List<User> FindByNameOrEmail(string key)
        {
            return context.Users.AsNoTracking()
                .Where(x => x.Name.ToLower().Contains(key.ToLower()) || x.Email.ToLower().Contains(key.ToLower()))
                .ToList();
        }

        public User GetById(int id)
        {
            return context.Users.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public void Save(User u)
        {
            context.Users.Add(u);
            context.SaveChanges();
        }

        public void Update(User u)
        {
            context.Users.Attach(u);
            context.Entry(u).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}