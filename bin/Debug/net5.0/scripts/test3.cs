CallFromScript("Calling methon on the application from the script");
Console.WriteLine(";D");

CreatePerson("Lasse", "Åber", 53);

var person = PersonGetInfo("Lasse");
Console.WriteLine($"{person.FirstName} : {person.LastName} : {person.Age}");
Console.WriteLine(";DD");