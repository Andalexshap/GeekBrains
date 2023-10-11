namespace HW1.Models
{
    internal class Person
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDay { get; init; }
        public int Age { get; init; }
        public Gender Gender { get; init; }

        public Person(string name, string lastName, DateTime birthDay, Gender gender)
        {
            Name = name;
            LastName = lastName;
            if (birthDay >= DateTime.Now)
                throw new Exe
            BirthDay = birthDay;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{Name} {LastName}, {Gender} - {BirthDay}";
        }
    }
}
