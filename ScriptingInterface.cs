using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpScripting
{
    // Since it's a scripting interface, why not make it static
    // All methods are made private, but every method has a delegate attached.
    public static class ScriptingInterface
    {
        /*  Print(string text) | Prints said text to the console
         *  NewPerson(string firstName, string lastName, int age) | Creates a new person instance and adds it to the list of people 
         *  GetPerson(string name) | Gets the first person with this name
         *  GetPeople() | Gets a list of every person created
         */

        // Create a list of people so we can get get them from script
        static List<Person> people = new();

        public static Action<string> Print = CallFromScript;
        // This will be called from inside the script
        private static void CallFromScript(string text)
        {
            Console.WriteLine(text);
        }

        public static Action<string, string, int> NewPerson = CreatePerson;
        // Create a new person
        private static void CreatePerson(string firstName, string lastName, int age)
        {
            Person person = new(firstName, lastName, age);
            people.Add(person);
        }

        public static Func<string, Person> GetPerson = PersonGetInfo;
        // Get all the info from first said person with said name
        private static Person PersonGetInfo(string firstName)
        {
            Person person = people.Find(x => x.FirstName == firstName);

            return person;
        }

        public static Func<List<Person>> GetPeople = GetAllPeople;
        private static List<Person> GetAllPeople()
        {
            return people;
        }
    }
}
