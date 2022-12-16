using _1_DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1_DemoApi.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {
        static List<Student> Students = new List<Student>
        {
            new Student{Id = 1, Name ="Lucien"},
            new Student{Id = 2, Name ="Marc"},
            new Student{Id = 3, Name ="Jean"}
        };

        //HttpResponseMessage type de retour de V1 de Web API
        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, Students);
        //}

        //public HttpResponseMessage Get(int id)
        //{
        //    var student = Students.SingleOrDefault(s => s.Id == id);

        //    if (student != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, student);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");
        //    }
        //}

        //IHttpActionResult type de retour dans V2 Web Api
        /*
         * OK
         * NotFound
         * Bad Request
         * Created
         * Unauthorized
         * 
         */
        //api/Students
        [HttpGet]
        [Route("")]
        public IHttpActionResult AllStudents()
        {
            return Ok(Students);
        }

        //api/Students/{id}

        [HttpGet]
        [Route("{id:int:range(1,3)}")]
        public IHttpActionResult Get(int id)
        {
            var student = Students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                
                return NotFound();

                //Pour insérer un message dans le Body
                //return Content(HttpStatusCode.NotFound, "Student not found");
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddStudent([FromBody] Student s)
        {
            Students.Add(s);
            return Created(new Uri(Request.RequestUri + "/" + s.Id), "Student added");
        }

        [HttpGet]
        [Route("{id}/courses")]
        public List<string> GetStudentCourses(int id)
        {
            if (id == 1)
            {
                return new List<string> { "c#", "Asp.Net", "Java" };
            }else if(id == 2)
            {
                return new List<string> { "Python", "Angular", "Javascript" };
            }
            else
            {
                return new List<string> { "Html", "CSS", "Angular" };
            }
        }

        //Override du RoutePrefix

        [HttpGet]
        [Route("~/api/Teachers")]
        public List<string> GetTeachers()
        {
            return new List<string> { "Teacher1", "Teacher2" };
        }

        [HttpGet]
        [Route("{name:alpha}")]
        public Student Get(string name)
        {
           return Students.FirstOrDefault(s => s.Name == name);
        }
    }
}/*
  * Contraintes concernant les paramètres des méthodes
  * Int: x:int
  * bool: x:bool
  * DateTime: x:DateTime
  * double-decimal-float: x:double-decimal-float
  * length: x:min(2), max(10)
    range: x: range(1,10)
  * regex: x:regex
  * string: x:alpha
  * 
  */
