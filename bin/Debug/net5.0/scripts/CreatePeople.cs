List<string> listOfFirstNames = new() {"Lucifer", "Ranken", "Lopisorda", "Opal", "Inneklabdambda", "Polaris", "Linten", "Lanten", "AsgardianMan", "Löken"};
List<string> listOfLastNames = new() {"Morningstar", "Micheal", "Citrus", "Svensson", "Asgardionna", "Nub", "Asdmat", "Indon", "Qwertyman", "God"};
List<int> listOfAges = new() {54, 84 ,12 ,65 ,23 ,56 ,45 ,6 ,32 ,1};
Random rand = new();

for(int i = 0; i < 10; i++)
{
    string firstName = listOfFirstNames[rand.Next(0, listOfFirstNames.Count)];
    string lastName = listOfLastNames[rand.Next(0, listOfLastNames.Count)];
    int age = listOfAges[rand.Next(0, listOfAges.Count)];
    CreatePerson(firstName, lastName, age);
}