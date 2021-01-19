Print("Calling methon on the application from the script");
Console.WriteLine(";D");

NewPerson("Lasse", "Åber", 53);

var person = GetPerson("Lasse");
Console.WriteLine($"{person.FirstName} : {person.LastName} : {person.Age}");
Console.WriteLine(";DD");