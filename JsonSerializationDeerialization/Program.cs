using static System.Console;
using JsonSerializationDeerialization.Models;
using System.Text.Json;

var person = new Person {
    Id = 1,
    FirstName = "James",
    LastName = "Gunn",
    Age = 90,
    IsAlive = true
};
var opt = new JsonSerializerOptions 
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

var jsonString = JsonSerializer.Serialize<Person>(person, opt);
// display
WriteLine(jsonString);

// write to a file
var path = "C:\\BUDDHIKA\\Development\\Git\\.NET-Developer-Toolkit\\JsonSerializationDeerialization\\person.json";
File.WriteAllText(path, jsonString);
WriteLine(File.ReadAllText(path));
