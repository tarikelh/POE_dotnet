using _4_DemoApi2.Dtos;
using _4_DemoApi2.Models;
using _4_DemoApi2.Repositories;
using _4_DemoApi2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _4_DemoApi2.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {

        private IUserService userService;

        //Constructeur appelé implicitement au démarrage de l'API
        public UsersController()
        {
            userService = new UserService(new UserRepository());
        }

        //Nécessaire pour les tests unitaires
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        /*
         * GetAllUser
         * AddUser
         * Get(int id)
         * UpdateUser
         * DeleteUser
         * CheckLogin - Route("api/check-login") - Si user exit renvoie OK (200) - Sinon NotFound (404)
         * 
         */
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, userService.FindAll());
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetById(int id)
        {
            User u = userService.GetById(id);
            if (u != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, u);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User avec id = "+id+" introuvable.");
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post([FromBody] User u)
        {
            userService.Save(u);
            var reponse = Request.CreateResponse(HttpStatusCode.Created, u);

            //Ajout de l'Uri dans le header
            reponse.Headers.Location = new Uri(Request.RequestUri + "/" + u.Id);
            return reponse;
        }

        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Put([FromBody] User u)
        {
            userService.Update(u);
            return Request.CreateResponse(HttpStatusCode.OK, u);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                userService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "User avec id = " + id + " supprimé.");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User introuvable");
            }
           
        }

        [HttpPost]
        [Route("~/api/check-login")]
        public HttpResponseMessage CheckLogin([FromBody] LoginDTO loginDto)
        {
            User u = userService.CheckLogin(loginDto);
            if (u != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,"User OK");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User introuvable");
            }
        }
    }
}
