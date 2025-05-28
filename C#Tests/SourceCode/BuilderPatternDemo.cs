using static C_Tests.SourceCode.Person;

namespace C_Tests.SourceCode
{
    public class Person
    {
        public string Name { get; set; }
        public string Dob { get; set; }

        private Person(string name, string dob)
        {
            Name = name;
            Dob = dob;
        }

        public override string ToString()
        {
            return $"{Name}, {Dob}";        
        }

        public class PersonBuilder
        {
            public string Name { get; set; } = null!;
            public string Dob { get; set; } = null!;

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

            public Person Build()
            {
                return new Person(Name, Dob);
            }
        }
    }

    public class BuilderDemo
    {
        public static void Demo()
        {
            var p1 = new PersonBuilder().WithName("Jack").WithDob("1990-01-01").Build();
            Console.WriteLine(p1);

            var p2 = new PersonBuilder().WithName("Gill").WithDob("1991-01-01").Build();
            Console.WriteLine(p2);
        }
    }
}
