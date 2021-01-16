using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpScripting
{
    public class Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
