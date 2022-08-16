using JsonParser.Parser;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var parser = new JsonFileParser();
        var customer = parser.ParseFile("../JsonParser/Files/CustomerJson.json").Result;
        Console.WriteLine($"{customer.FirstName}, {customer.CustomerId}");
    }
}