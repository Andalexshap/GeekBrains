using HW1.Models.Exeption;

namespace HW1.Models
{
    internal class Person
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDay { get; init; }
        public int Age { get; set; }
        public Gender Gender { get; init; }

        public Person(string name, string lastName, DateTime birthDay, Gender gender)
        {
            Name = name;
            LastName = lastName;
            if (birthDay > DateTime.Now)
                throw new PersonBirthDayException("Дата рождения не может быть больше текущей");
            BirthDay = birthDay;
            Gender = gender;
            Age = (int)(DateTime.Now - birthDay).TotalDays/365;
        }

        public override string ToString()
        {
            return $"Name: {Name} {LastName}, Gender: {Gender}, BirthDay: {BirthDay.ToString("dd.MM.yyyy")}, Age: {Age}";
        }
        public string GetFullName()
        {
            return $"Name: {Name} {LastName}";
        }

        public override bool Equals(object? targetObj)
        {
            if(targetObj == null || targetObj is not Person) return false;

            var targetPerson = targetObj as Person;

            if( Name == targetPerson.Name &&
                LastName == targetPerson.LastName && 
                Gender == targetPerson.Gender &&
                BirthDay == targetPerson.BirthDay && 
                Age == targetPerson.Age) return true;

            return false;
        }
    }
}
