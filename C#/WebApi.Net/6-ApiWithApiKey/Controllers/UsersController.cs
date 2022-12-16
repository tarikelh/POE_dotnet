using _6_ApiWithApiKey.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _6_ApiWithApiKey.Controllers
{
    public class UsersController : ApiController
    {
        private MyContext context = new MyContext();

        //private const string ApiKey = "dawan2022@@@@sdqsdqsdqsdmmpsdqsd";
        private string ApiKey = ConfigurationManager.AppSettings.Get("apikey");

        [HttpGet]
        [Route("api/Users")]
        public HttpResponseMessage Get()
        {
            return  Request.CreateResponse(HttpStatusCode.OK, context.Users.ToList()); ;
        }

        [HttpGet]
        [Route("api/Users/GetById/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, context.Users.Find(id)); ;
        }

        [HttpPost]
        [Route("api/Users/Save")]
        public HttpResponseMessage Post([FromBody] User u)
        {
            context.Users.Add(u);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, "User crée."); ;
        }

        [HttpDelete]
        [Route("api/Users/Delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            User u = context.Users.Find(id);
            context.Users.Remove(u);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "User supprimé"); 
        }

        [HttpPost]
        [Route("api/check-login")]
        public HttpResponseMessage CheckLogin([FromBody] User u)
        {
            User userDB = context.Users.Where(x => x.Email.Equals(u.Email) && x.Password.Equals(u.Password)).SingleOrDefault();
            if (userDB != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ApiKeyModel { Content = ApiKey});
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User inconnu.");
            }
            
            
        }
    }
}
