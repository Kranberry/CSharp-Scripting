using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpScripting
{
    // Since it's a scripting interface, why not make it static
    public static class ScriptingInterface
    {
        // Create a list of people so we can get get them from script
        static List<Person> people = new();

        // This will be called from inside the script
        public static void CallFromScript(string text)
        {
            Console.WriteLine(text);
        }

        // Create a new person
        public static void CreatePerson(string firstName, string lastName, int age)
        {
            Person person = new(firstName, lastName, age);
            people.Add(person);
        }

        // Get all the info from first said person with said name
        public static Person PersonGetInfo(string firstName)
        {
            Person person = people.Find(x => x.FirstName == firstName);

            return person;
        }
    }
}
