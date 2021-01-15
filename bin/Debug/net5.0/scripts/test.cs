void TestMethod()
{
    Console.WriteLine("Hello from inside the method!");
}

List<string> lista = new();
lista.Add("Hello from inside the lista");

Console.WriteLine("Hello from inside the file!");
TestMethod();
Console.WriteLine(lista[0]);
