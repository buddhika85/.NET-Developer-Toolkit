using System.Text.Json.Serialization;

namespace JsonSerializationDeerialization.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }

        [JsonIgnore]
        public bool IsAlive { get; set; }

        public Address? Address { get; set; }

        public IEnumerable<Phone>? Phones { get; set; }
    }
}