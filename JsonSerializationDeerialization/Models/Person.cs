namespace JsonSerializationDeerialization.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public bool IsAlive { get; set; }
    }
}