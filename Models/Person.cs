using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_9.Models
{
    public class Person
    {
        public static int index = 0;
        public int PersonId { get; private set; } = index++;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Gender { get; set; } = "Male";
        public string BirthPlace { get; set; } = "Ha noi";
    }
}