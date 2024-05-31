using static System.Console;
using JsonSerializationDeerialization.Models;
using System.Text.Json;

namespace JsonSerializationDeerialization
{
    public class SerializationDemo
    {
        public void Demo()
        {
            var person = new Person
            {
                Id = 1,
                FirstName = "James",
                LastName = "Gunn",
                Age = 90,
                IsAlive = true,
                Address = new Address
                {
                    StreetName = "1 Main Street",
                    City = "NY",
                    PostCode = "ABC123"
                },
                Phones = new List<Phone>
                {
                    new Phone { PhoneNumber = "123456", Type = PhoneType.Home },
                    new Phone { PhoneNumber = "654321", Type = PhoneType.Mobile },
                }
            };
            
            var opt = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var jsonString = JsonSerializer.Serialize<Person>(person, opt);
            // display
            //WriteLine(jsonString);

            // write to a file
            var path = "C:\\BUDDHIKA\\Development\\Git\\.NET-Developer-Toolkit\\JsonSerializationDeerialization\\person.json";
            File.WriteAllText(path, jsonString);
            WriteLine(File.ReadAllText(path));

        }
    }
}