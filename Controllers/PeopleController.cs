using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Day_9.Models;
using Day_9.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day_9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        IPeople _peopleServices;
        public class PeopleFilter {
            public string? Name { get; set; }
            public string? Gender { get; set; }
            public string? BirthPlace { get; set; }
        }

        public PeopleController(IPeople peopleServices)
        {
            _peopleServices = peopleServices;
        }
        [HttpGet]
        public List<Person> Index(){
            return _peopleServices.List();
        }
        [HttpPost]
        public HttpStatusCode Add(Person person) {
            _peopleServices.Add(person);
            return HttpStatusCode.OK;
        }
        [HttpDelete]
        public HttpStatusCode Delete(int id) {
            var check = _peopleServices.List().Where(x=>x.PersonId == id).FirstOrDefault() != null;
            if(check){
                var deletePerson = _peopleServices.List().ElementAt(id);
                _peopleServices.Delete(deletePerson);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }
        [HttpPut]
        public HttpStatusCode Update(int id, Person person) {
            var check = _peopleServices.List().Where(x=>x.PersonId == id).FirstOrDefault() != null;
            if(check){
                _peopleServices.Update(id, person);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }
        [HttpPost("search")]
        public List<Person> Filter(PeopleFilter filter) {
            return _peopleServices.Filter(filter);
        }
    }
}