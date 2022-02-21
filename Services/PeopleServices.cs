using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_9.Models;

namespace Day_9.Services
{
    public class PeopleServices : IPeople
    {
        public static List<Person> people = new List<Person>();

        public List<Person> List(){
            return people;
        }
        public void Add(Person person)
        {
            people.Add(person);
        }

        public void Delete(Person person)
        {
            people.Remove(person);
        }

        public List<Person> Filter(Object request)
        {
            List<Person> result = people;
            foreach(var prop in request.GetType().GetProperties()){
                var filter = prop.Name;
                var value = prop.GetValue(request);
                
                if(value != null){
                    switch(filter){
                        case "Name":
                            result = result.Where(x=>x.FirstName + " " + x.LastName == $"{value}").ToList();
                            break;
                        case "BirthPlace":
                            result = result.Where(x=>x.BirthPlace == $"{value}").ToList();
                            break;
                        case "Gender":
                            result = result.Where(x=>x.Gender == $"{value}").ToList();
                            break;
                        default :
                            break;
                    }
                }
            }
            return result;
        }

        public void Update(int id, Person person)
        {
            people[id].BirthPlace = person.BirthPlace;
            people[id].DateOfBirth = person.DateOfBirth;
            people[id].FirstName = person.FirstName;
            people[id].LastName = person.LastName;
            people[id].Gender = person.Gender;
        }
    }
}