using _6_ApiWithApiKey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _6_ApiWithApiKey.Controllers
{
    public class EmployesController : ApiController
    {
        private MyContext context = new MyContext();

        [HttpGet]
        [Route("api/Employes")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, context.Employes.ToList());
        }

        [HttpGet]
        [Route("api/Employes/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, context.Employes.Find(id));
        }

        [HttpPost]
        [Route("api/Employes")]
        public HttpResponseMessage Post([FromBody] Employe e)
        {
            context.Employes.Add(e);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, e);
        }

        [HttpPut]
        [Route("api/Employes")]
        public HttpResponseMessage Put([FromBody] Employe e)
        {
            context.Employes.Attach(e);
            context.Entry(e).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, e);
        }

        [HttpDelete]
        [Route("api/Employes/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            Employe e = context.Employes.Find(id);
            context.Employes.Remove(e);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Employé supprimé.");
        }
    }
}
