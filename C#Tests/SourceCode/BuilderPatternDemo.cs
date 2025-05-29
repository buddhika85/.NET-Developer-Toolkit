using static C_Tests.SourceCode.Person;

namespace C_Tests.SourceCode
{
    // Builder pattern - provides a methodical way of building complex objects
    public class Person
    {
        public string Name { get; set; }
        public string Dob { get; set; }

        public string Address { get; set; }

        private Person(string name, string dob, string address)
        {
            Name = name;
            Dob = dob;
            Address = address;

        }

        public override string ToString()
        {
            return $"{Name}, {Dob}, {Address}";        
        }

        public class PersonBuilder
        {
            public string Name { get; set; } = null!;
            public string Dob { get; set; } = null!;
            public string Address { get; set; } = null!;

            public PersonBuilder WithName(string name)
            {
                this.Name = name;
                return this;
            }

            public PersonBuilder WithDob(string dob)
            {
                this.Dob = dob;
                return this;
            }

            public PersonBuilder WithAddress(string address)
            {
                this.Address = address;
                return this;
            }

            public Person Build()
            {
                return new Person(Name, Dob, Address);
            }
        }
    }

    public class BuilderDemo
    {
        public static void Demo()
        {
            var p1 = new PersonBuilder().WithName("Jack").WithDob("1990-01-01").WithAddress("1, Sunny Town, 2134").Build();
            Console.WriteLine(p1);

            var p2 = new PersonBuilder().WithName("Gill").WithDob("1991-01-01").WithAddress("2, Rainy Town, 2134").Build();
            Console.WriteLine(p2);
        }
    }
}
