using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_9.Models;

namespace Day_9.Services
{
    public interface IPeople
    {
        public List<Person> List();
        public void Add (Person person);
        public void Update (int id, Person person);
        public void Delete  (Person person);
        public List<Person> Filter (Object request);
    }
}