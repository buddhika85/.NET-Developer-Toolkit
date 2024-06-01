using static System.Console;
using JsonSerializationDeerialization.Models;
using System.Text.Json;

public class DeserializationDemo
{
    public void Demo()
    {
        var path = "C:\\BUDDHIKA\\Development\\Git\\.NET-Developer-Toolkit\\JsonSerializationDeerialization\\person.json";
        if (!File.Exists(path))
        {
            WriteLine("File not exists");
            return;
        }

        try
        {
            var person = JsonSerializer.Deserialize<Person>(path);
            if (person == null)            
                throw new Exception("Deserialize JSON to C# object unsuccessful");
            
            WriteLine($"{person.Id} {person.FirstName} {person.LastName}");    
        }
        catch (Exception ex)
        {
            WriteLine($"Exception: {ex.Message}");
        }
    }
}