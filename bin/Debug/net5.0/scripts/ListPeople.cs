var people = GetAllPeople();

foreach (var person in people)
{
    Console.WriteLine(person.FirstName + "  :  " + person.LastName);
}